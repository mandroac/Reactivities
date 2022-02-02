using System.Threading.Tasks;
using API.Controllers.Base;
using API.DTOs;
using Application.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfilesController : BaseMediatorApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username) 
        {
            return HandleResult(await Mediator.Send(new Details.Query{Username = username}));
        }

        [HttpPut("{username}/edit"), Authorize(Policy = "IsAccountOwner")]
        public async Task<IActionResult> UpdateProfile(string username, [FromBody] EditProfileDto editProfileDto)
        {
            return HandleResult(await Mediator.Send(new Edit.Command{
                Username = username, 
                DisplayName = editProfileDto.DisplayName, 
                Bio = editProfileDto.Bio
            }));
        }

        [HttpGet("{username}/activities")]
        public async Task<IActionResult> GetUserActivities(string username, [FromQuery] string predicate)
        {
            return HandleResult(await Mediator.Send(new UserActivities.Query{Username = username, Predicate = predicate}));
        }
    }
}