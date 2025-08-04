using System.ComponentModel.DataAnnotations;

namespace Application.Forum.Dtos.Channel
{
    public class DeleteRequestDto
    {
        [Required]   
        public Guid ChannelId { get; set; }

        [Required]
        public Guid DeletedBy { get; set; }
    }
}