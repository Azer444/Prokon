using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Manage.Services
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string savePath = "uploads");
        void Delete(string filename);
    }
}
