using Bussiness.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Extensions
{
    public class Helper
    {
        public static string SaveFile(string rootPath, string folder, IFormFile file)
        {
            if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                throw new ImageContentTypeException("The file format is not correct!");
            if (file.Length > 2097152)
                throw new ImageSizeException("The file cannot be more than 2 MB!");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = rootPath + $@"\{folder}\" + fileName;

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }

        public static void DeleteFIle(string rootPath, string folder, string fileName)
        {
            string path = rootPath + $@"\{folder}\" + fileName;

            if (!File.Exists(path))
                throw new Exceptions.FileNotFoundException("File not found!");

            File.Delete(path);
        }
    }
}
