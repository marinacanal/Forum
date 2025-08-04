namespace Application.Forum.Dtos.Channel
{
    public class GetResponseDto
    {
        public Guid ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelDescription { get; set; }
        public string ProfilePicture { get; set; }  

        // to do: return count posts and users
    }
}