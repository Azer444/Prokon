using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Manage.Services
{
    public class FileService : IFileService
    {
        public async Task<string> UploadAsync(IFormFile file, string savePath = "uploads")
        {
            string filename = Guid.NewGuid() + "_" + file.FileName;

            var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
            if (!Directory.Exists(writePath))
                Directory.CreateDirectory(writePath);

            var path = Path.Combine(writePath, filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filename;
        }

        public void Delete(string filename)
        {
            string path = Path.Combine(
                               Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                               filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
