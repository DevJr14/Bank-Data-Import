using Application.Helpers;
using Application.Services;
using Common.Requests;
using Domain;
using Infrastructure.Context;
using Infrastructure.Helpers;

namespace Infrastructure.Services
{
    public class ImportService : IImportService
    {
        private readonly ApplicationDbContext _context;

        public ImportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ImportCsvDataAsync(UploadRequest request)
        {
            // First save file in a folder and get a path
            string csvFilePath = UploadFileToFolderAsync(request);

            if (string.IsNullOrEmpty(csvFilePath))
            {
                //Fail early
                return false;
            }

            CsvParserHelper csvParser = new();
            List<CsvImportData> csvImportData = csvParser.ParseCsv(csvFilePath);

            if (csvImportData.Count <= 0)
            {
                //Fail early
                return false;
            }

            // Group transactions by Account Number
            var groupedData = csvImportData.GroupBy(data => data.AccountNumber);

            //Save to database
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var group in groupedData)
                    {
                        Account account = new(group.First().AccountHolder, group.First().AccountNumber, group.First().BranchCode, group.First().AccountType)
                        {
                            Transactions = group
                                .Select(csvData => new Transaction(0, csvData.TransactionDate, csvData.Amount, csvData.Status, csvData.EffectiveStatusDate))
                                .ToList()
                        };

                        await _context.Accounts.AddAsync(account);
                    }

                    await _context.SaveChangesAsync();

                    await dbTransaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    // Roll back the transaction if something goes wrong
                    dbTransaction.Rollback();
                    return false;
                }
            }
        }

        private string UploadFileToFolderAsync(UploadRequest request)
        {
            if (request.Data == null) return string.Empty;
            var streamData = new MemoryStream(request.Data);
            if (streamData.Length > 0)
            {
                var folder = request.UploadType.ToDescriptionString();
                var folderName = Path.Combine("Files", folder);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                bool exists = Directory.Exists(pathToSave);
                if (!exists)
                    Directory.CreateDirectory(pathToSave);
                var fileName = request.FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var localPath = Path.Combine(folderName, fileName);
                if (File.Exists(localPath))
                {
                    localPath = NextAvailableFilename(localPath);
                    fullPath = NextAvailableFilename(fullPath);
                }
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    streamData.CopyTo(stream);
                }
                return Host(localPath);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// For development purpose only.
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns></returns>
        private string Host(string localPath)
        {
            return $"{localPath}";
        }

        private static readonly string numberPattern = " ({0})";

        public static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }
    }
}
