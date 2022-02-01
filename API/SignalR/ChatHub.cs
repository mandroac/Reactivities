using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly ICommentsService _commentsService;
        public ChatHub(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task SendComment(string body, Guid activityId)
        {
            var commentResult = await _commentsService.CreateAsync(body, activityId);

            await Clients.Group(activityId.ToString()).SendAsync("ReceiveComment", commentResult.Value);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var activityId = httpContext.Request.Query["activityId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, activityId);
           
            var result = await _commentsService.GetAllCommentsOfActivity(Guid.Parse(activityId));
            await Clients.Caller.SendAsync("LoadComments", result.Value);
        }
    }
}