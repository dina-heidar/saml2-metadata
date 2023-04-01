namespace BasicSpMetadata.Models
{
    public class PfxFile
    {
        public IFormFile? File { get; set; }
        public string? Password { get; set; }
        public bool IsNull()
        {
            if (File == null || string.IsNullOrEmpty(Password))
            {
                return true;
            }
            return false;
        }
    }
}
