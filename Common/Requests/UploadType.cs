using System.ComponentModel;

namespace Common.Requests
{
    public enum UploadType
    {
        [Description(@"Unknown")]
        Unknown = 0,
        [Description(@"Documents")]
        Document = 1
    }
}
