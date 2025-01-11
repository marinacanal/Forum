using System.ComponentModel.DataAnnotations;

namespace Application.Forum.Dtos
{
    public class CreateChannelResponseDto
    {
        public bool IsSuccessful { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ErrorMessage { get; set; }
    }
}