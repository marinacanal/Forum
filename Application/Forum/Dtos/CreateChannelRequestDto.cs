using System.ComponentModel.DataAnnotations;

namespace Application.Forum.Dtos
{
    public class CreateChannelRequestDto
    {
        [Required]   
        public Guid CreatorId { get; set; }

        [Required]
        public string ChannelName { get; set; }

        [Required]
        public string ChannelDescription { get; set; }
    }
}