using System.ComponentModel.DataAnnotations;

namespace Application.Forum.Dtos.Channel
{
    public class UpdateProfilePictureRequestDto
    {
        [Required]   
        public Guid ChannelId { get; set; }

        [Required]   
        public string PictureURL { get; set; }

        [Required]
        public Guid UpdatedBy { get; set; }
    }
}