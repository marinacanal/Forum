using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Channel> ChannelsCreator { get; set; }
        public ICollection<ChannelUser> ChannelsMember { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}