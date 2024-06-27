using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.Core.Features.Category.Query.Models;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            return NewResult(await Mediator.Send(new GetCategoryByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] AddCategoryCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> EditCategory([FromBody] EditCategoryCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory([FromQuery] int id)
        {
            return NewResult(await Mediator.Send(new DeleteCategoryCommand(id)));
        }
    }
}
