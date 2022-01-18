using System;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController<ActivityDto>
    {
        private readonly IActivitiesService _activitiesService;
        public ActivitiesController(IActivitiesService activitiesService)
        : base(activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await _activitiesService.UpdateAttendanceAsync(id));
        }

        [Authorize(Policy = "IsActivityHost")]
        public override async Task<IActionResult> UpdateAsync(Guid id, ActivityDto updatedDto)
        {
            return await base.UpdateAsync(id, updatedDto);
        }

        [Authorize(Policy = "IsActivityHost")]
        public override async Task<IActionResult> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}