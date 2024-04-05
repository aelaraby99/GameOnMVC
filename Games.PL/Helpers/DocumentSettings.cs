namespace GameOn.PL.Helpers
{
    public static class DocumentSettings
    {
        //Upload File
        public static string UploadFile(IFormFile file , string FolderName)
        {
            string fileName = string.Empty;
            if (file != null)
            {
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
                fileName = $"{Guid.NewGuid().ToString()}{file.FileName}";
                string filePath = Path.Combine(uploadFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
        //Delete File
        public static void DeleteFile(string fileName, string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName);
            string filePath = Path.Combine(FolderPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        //Update File
        public static string UpdateFile(IFormFile file, string FolderName, string OldFileName)
        {
            DeleteFile(OldFileName, FolderName);
            return UploadFile(file, FolderName);
        }
    }
}
