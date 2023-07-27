namespace Common.Requests
{
    public class CsvImportRequest
    {
        public string FilePath { get; set; }
        public UploadRequest UploadRequest { get; set; }
    }
}
