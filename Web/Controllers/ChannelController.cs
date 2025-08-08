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
            var response = await _channelService.SearchAsync(channelName);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByCreator([FromBody] Guid creatorId)
        {
            var response = await _channelService.GetAllByCreatorAsync(creatorId);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _channelService.CreateAsync(dto);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _channelService.UpdateAsync(dto);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfilePictureRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _channelService.UpdateProfilePictureAsync(dto);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }   
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _channelService.DeleteAsync(dto);

            if (!response.Success)
                return Conflict(response);

            return Ok(response);
        }       
    }
}