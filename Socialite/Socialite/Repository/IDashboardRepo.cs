using Socialite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socialite.Repository
{
    public interface IDashboardRepo : IDisposable
    {
        IList<Post> GetPosts();
        IList<Category> GetPostCategories(Post post);
        IList<Tag> GetPostTags(Post post);
        IList<PostVideo> GetPostVideos(Post post);
        int LikeDislikeCount(string typeAndlike, string id);

        IList<Tag> GetTags();
        IList<Category> GetCategories();
    }
}