using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Common.Requests;

namespace Infrastructure.Helpers
{
    public class CsvParserHelper
    {
        public List<CsvImportData> ParseCsv(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Read();
                    csv.ReadHeader();

                    csv.Context.RegisterClassMap<CsvHeadersMap>();

                    return csv.GetRecords<CsvImportData>().ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while parsing the CSV file: " + ex.Message);
                return new List<CsvImportData>();
            }
        }

        public class CsvHeadersMap : ClassMap<CsvImportData>
        {
            /// <summary>
            /// This definition assumes that csv file will have headers as Mapped in this constructor.
            /// </summary>
            public CsvHeadersMap()
            {
                // Map CSV headers to corresponding class properties
                Map(m => m.Id).Name("Payment ID");
                Map(m => m.AccountHolder).Name("Account Holder");
                Map(m => m.BranchCode).Name("Branch Code");
                Map(m => m.AccountNumber).Name("Account Number");
                Map(m => m.AccountType).Name("Account Type");
                Map(m => m.TransactionDate).TypeConverterOption.Format("dd/MM/yyyy").Name("Transaction Date");
                Map(m => m.Amount);
                Map(m => m.Status);
                Map(m => m.EffectiveStatusDate).TypeConverterOption.Format("dd/MM/yyyy").Name("Effective Status Date");
            }
        }
    }
}
