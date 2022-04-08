namespace ImageApi.Services
{
    /**
     * Validator class
     * used to check File Type and File Size
     *
     */
    public class Validator
    {
        private string FileType { get; set; }

        private double FileSize { get; set; }

        public Validator(string type, double size)
        {
            FileType = type;
            FileSize = size;
        }

        public bool CorrectFormat()
        {
            var isValid = false;

            // Remove or add the allowed image formats below
            string[] allowedFormats = {"png", "PNG", "jpeg", "jpg", "svg", "gif"};
            int i = 0;
            while (i < allowedFormats.Length)
            {
                if(allowedFormats[i] == FileType)
                {
                    isValid = true;
                }
                i++;
            }
            return isValid;
        }

        // Configured to accept images smaller than 1 Megabyte
        public bool CorrectSize()
        {
            var isValid = FileSize < 1000000;
            return isValid;
         }

    }
}