using System.ComponentModel.DataAnnotations;

namespace Application.Forum.Dtos.Channel
{
    public class UpdateRequestDto
    {
        [Required]   
        public Guid ChannelId { get; set; }

        public string ChannelName { get; set; }

        public string ChannelDescription { get; set; }

        [Required]
        public Guid UpdatedBy { get; set; }
    }
}