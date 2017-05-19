using Socialite.Models;
using Socialite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;

namespace Socialite.Controllers
{
    public class DashboardController : Controller
    {
        private IDashboardRepo _dashboardRepo;
        public static List<DashboardViewModel> postList = new List<DashboardViewModel>();
        public static List<AllPostsViewModel> checkCatList = new List<AllPostsViewModel>();
        public static List<AllPostsViewModel> checkTagList = new List<AllPostsViewModel>();
        public DashboardController()
        {
            _dashboardRepo = new DashboardRepo(new DashboardDbContext());
        }

        public DashboardController(IDashboardRepo dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            checkCatList.Clear();
            checkTagList.Clear();
            CreateCatAndTagList();
            Posts(page, sortOrder, searchString, searchCategory, searchTag);
            return View();
        }

        [ChildActionOnly]
        public ActionResult Posts(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            postList.Clear();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentSearchCategory = searchCategory;
            ViewBag.CurrentSearchTag = searchTag;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title_desc" : "Title";

            var posts = _dashboardRepo.GetPosts();
            foreach (var post in posts)
            {
                var postCategories = GetPostCategories(post);
                var postTags = GetPostTags(post);
                var likes = _dashboardRepo.LikeDislikeCount("postlike", post.Id);
                var dislikes = _dashboardRepo.LikeDislikeCount("postdislike", post.Id);
                postList.Add(new DashboardViewModel() { Post = post, Modified = post.Modified, Title = post.Title, ShortDescription = post.ShortDescription, PostedOn = post.PostedOn, ID = post.Id, PostLikes = likes, PostDislikes = dislikes, PostCategories = postCategories, PostTags = postTags, UrlSlug = post.UrlSeo });
            }
            if (searchString != null)
            {
                postList = postList.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            }

            if (searchCategory != null)
            {
                List<DashboardViewModel> newList = new List<DashboardViewModel>();
                foreach (var catName in searchCategory)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostCategories.Where(x => x.Name == catName).Any())
                        {
                            newList.Add(item);
                        }
                    }
                    foreach (var item in checkCatList)
                    {
                        if (item.Category.Name == catName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                postList = postList.Intersect(newList).ToList();
            }

            if (searchTag != null)
            {
                List<DashboardViewModel> newList = new List<DashboardViewModel>();
                foreach (var tagName in searchTag)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostTags.Where(x => x.Name == tagName).Any())
                        {
                            newList.Add(item);
                        }
                    }
                    foreach (var item in checkTagList)
                    {
                        if (item.Tag.Name == tagName)
                        {
                            item.Checked = true;
                        }
                    }
                }
                postList = postList.Intersect(newList).ToList();
            }

            switch (sortOrder)
            {
                case "date_desc":
                    postList = postList.OrderByDescending(x => x.PostedOn).ToList();
                    break;
                case "Title":
                    postList = postList.OrderBy(x => x.Title).ToList();
                    break;
                case "title_desc":
                    postList = postList.OrderByDescending(x => x.Title).ToList();
                    break;
                default:
                    postList = postList.OrderBy(x => x.PostedOn).ToList();
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return PartialView("Posts", postList.ToPagedList(pageNumber, pageSize));
        }

        #region Helper

        public IList<Post> GetPosts ()
        {
            return _dashboardRepo.GetPosts();
        }

        public IList<Category> GetPostCategories(Post post)
        {
            return _dashboardRepo.GetPostCategories(post);
        }

        public IList<Tag> GetPostTags(Post post)
        {
            return _dashboardRepo.GetPostTags(post);
        }

        public IList<PostVideo> GetPostVideos(Post post)
        {
            return _dashboardRepo.GetPostVideos(post);
        }

        public void CreateCatAndTagList()
        {
            foreach (var ct in _dashboardRepo.GetCategories())
            {
                checkCatList.Add(new AllPostsViewModel { Category = ct, Checked = false });
            }
            foreach (var tg in _dashboardRepo.GetTags())
            {
                checkTagList.Add(new AllPostsViewModel { Tag = tg, Checked = false });
            }
        }

        #endregion
    }
}