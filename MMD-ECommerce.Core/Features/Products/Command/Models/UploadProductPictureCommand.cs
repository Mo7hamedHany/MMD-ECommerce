using MediatR;
using Microsoft.AspNetCore.Http;
using MMD_ECommerce.Core.Bases;

namespace MMD_ECommerce.Core.Features.Products.Command.Models
{
    public class UploadProductPictureCommand : IRequest<Response<string>>
    {
        public UploadProductPictureCommand(IFormFile file)
        {
            File = file;
        }

        public IFormFile File { get; set; }
    }
}
