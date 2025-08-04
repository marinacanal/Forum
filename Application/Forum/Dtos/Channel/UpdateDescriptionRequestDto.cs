using System.ComponentModel.DataAnnotations;

namespace Application.Forum.Dtos.Channel
{
    public class UpdateDescriptionRequestDto
    {
        [Required]   
        public Guid ChannelId { get; set; }

        [Required]   
        public string ChannelDescription { get; set; }

        [Required]
        public Guid UpdatedBy { get; set; }
    }
}