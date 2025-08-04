using Application.Forum.Dtos.Channel;
using Application.Services.Forum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Forum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly ChannelService _channelService;

        public ChannelController(ChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromBody] string channelName)
        {
            var response = await _channelService.SearchChannelsAsync(channelName);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByCreator([FromBody] Guid creatorId)
        {
            var response = await _channelService.GetAllChannelsByCreatorAsync(creatorId);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _channelService.CreateChannelAsync(dto);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }


        [HttpPatch]
        public async Task<IActionResult> UpdateDescription()
        {
            // to do
        }
        
        
    }
}