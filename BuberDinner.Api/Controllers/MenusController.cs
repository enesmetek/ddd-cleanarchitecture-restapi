using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/hosts/{hostId}/[controller]")]
    public class MenusController(IMapper mapper, ISender mediator) : ApiController
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISender _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((request, hostId));
            ErrorOr<Menu> createMenuResult = await _mediator.Send(command); 
            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }
    }
}
