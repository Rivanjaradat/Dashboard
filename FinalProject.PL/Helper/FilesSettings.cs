namespace FinalProject.PL.Helper
{
    public class FilesSettings
    {
        public static string UploadFile(IFormFile file,String folderName)
        {
          
            string folderPath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", folderName);
           string fileName=$"{Guid.NewGuid()}{file.FileName}";
            string filePath=Path.Combine(folderPath,fileName);
            var fileStream = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;

        }
        public  static void DeleteFile( string fileName,string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot\\Files" ,fileName, folderName);
            if (File.Exists(filePath) )
            {
                File.Delete(filePath);
            }


        }

    }
}
