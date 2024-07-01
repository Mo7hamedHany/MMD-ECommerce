using Microsoft.AspNetCore.Http;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IFileService
    {
        Task<string?> UploadFileAsync(IFormFile file);
    }
}
