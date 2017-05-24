using Socialite.Models;
using Socialite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace Socialite.Controllers
{
    public class DashboardController : Controller
    {
        private IDashboardRepo _dashboardRepo;
        public static List<DashboardViewModel> postList = new List<DashboardViewModel>();
        public static List<AllPostsViewModel> allPostsList = new List<AllPostsViewModel>();
        public static List<AllPostsViewModel> checkCatList = new List<AllPostsViewModel>();
        public static List<AllPostsViewModel> checkTagList = new List<AllPostsViewModel>();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public DashboardController()
        {
            _dashboardRepo = new DashboardRepo(new DashboardDbContext());
        }

        public DashboardController(IDashboardRepo dashboardRepo, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _dashboardRepo = dashboardRepo;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            checkCatList.Clear();
            checkTagList.Clear();
            CreateCatAndTagList();


            DashboardViewModel model = new DashboardViewModel();
            model.CommentViewModel = CreateCommentViewModel("mainPage", sortOrder);
            model.PagedBlogViewModel = CreatePagedBlogViewModel(page, sortOrder, searchString, searchCategory, searchTag);
            return View(model);
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


        public IPagedList<DashboardViewModel> CreatePagedBlogViewModel(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
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
                List<DashboardViewModel> newlist = new List<DashboardViewModel>();
                foreach (var catName in searchCategory)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostCategories.Where(x => x.Name == catName).Any())
                        {
                            newlist.Add(item);
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
                postList = postList.Intersect(newlist).ToList();
            }

            if (searchTag != null)
            {
                List<DashboardViewModel> newlist = new List<DashboardViewModel>();
                foreach (var tagName in searchTag)
                {
                    foreach (var item in postList)
                    {
                        if (item.PostTags.Where(x => x.Name == tagName).Any())
                        {
                            newlist.Add(item);
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
                postList = postList.Intersect(newlist).ToList();
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
            return postList.ToPagedList(pageNumber, pageSize);
        }

        #region Post

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Post(string sortOrder, string slug)
        {
            PostViewModel model = new PostViewModel();
            var posts = GetPosts();
            var postid = _dashboardRepo.GetPostIdBySlug(slug);
            var post = _dashboardRepo.GetPostById(postid);
            var videos = GetPostVideos(post);
            var firstPostId = posts.OrderBy(i => i.PostedOn).First().Id;
            var lastPostId = posts.OrderBy(i => i.PostedOn).Last().Id;
            var nextId = posts.OrderBy(i => i.PostedOn).SkipWhile(i => i.Id != postid).Skip(1).Select(i => i.Id).FirstOrDefault();
            var previousId = posts.OrderBy(i => i.PostedOn).TakeWhile(i => i.Id != postid).Select(i => i.Id).LastOrDefault();
            model.FirstPostId = firstPostId;
            model.LastPostId = lastPostId;
            model.PreviousPostSlug = posts.Where(x => x.Id == previousId).Select(x => x.UrlSeo).FirstOrDefault();
            model.NextPostSlug = posts.Where(x => x.Id == nextId).Select(x => x.UrlSeo).FirstOrDefault();
            model.ID = post.Id;
            model.PostCount = posts.Count();
            model.UrlSeo = post.UrlSeo;
            model.Videos = videos;
            model.Title = post.Title;
            model.Body = post.Body;
            model.PostLikes = _dashboardRepo.LikeDislikeCount("postlike", post.Id);
            model.PostDislikes = _dashboardRepo.LikeDislikeCount("postdislike", post.Id);
            model.CommentViewModel = CreateCommentViewModel(post.Id, sortOrder);
            return View(model);
        }



        public ActionResult UpdatePostLike(string postid, string slug, string username, string likeordislike, string sortorder)
        {
            _dashboardRepo.UpdatePostLike(postid, username, likeordislike);
            return RedirectToAction("Post", new { slug = slug, sortorder = sortorder });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPost(string slug)
        {
            var model = CreatePostViewModel(slug);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditPost(PostViewModel model)
        {
            var post = _dashboardRepo.GetPostById(model.ID);
            post.Body = model.Body;
            post.Title = model.Title;
            post.Meta = model.Meta;
            post.UrlSeo = model.UrlSeo;
            post.ShortDescription = model.ShortDescription;
            post.Modified = DateTime.Now;
            _dashboardRepo.Save();

            return RedirectToAction("Post", new { slug = model.UrlSeo });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddVideoToPost(string postid, string slug)
        {
            PostViewModel model = new PostViewModel();
            model.ID = postid;
            model.UrlSeo = slug;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVideoToPost(string postid, string slug, string videoUrl)
        {
            CreatePostViewModel(slug);
            _dashboardRepo.AddVideoToPost(postid, videoUrl);
            return RedirectToAction("EditPost", new { slug = slug });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveVideoFromPost(string slug, string postid, string videoUrl)
        {
            CreatePostViewModel(slug);
            _dashboardRepo.RemoveVideoFromPost(postid, videoUrl);
            return RedirectToAction("EditPost", new { slug = slug });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddCategoryToPost(string postid)
        {
            PostViewModel model = new PostViewModel();
            model.ID = postid;
            model.Categories = _dashboardRepo.GetCategories();
            return View(model);
        }
        
        public ActionResult AddCategoryToPost(PostViewModel model)
        {
            var post = _dashboardRepo.GetPostById(model.ID);
            var postCats = _dashboardRepo.GetPostCategories(post);
            List<string> pCatIds = new List<string>();
            foreach (var pCat in postCats)
            {
                pCatIds.Add(pCat.Id);
            }
            var newCats = model.Categories.Where(x => x.Checked == true).ToList();
            List<string> nCatIds = new List<string>();
            foreach (var pCat in newCats)
            {
                nCatIds.Add(pCat.Id);
            }
            if (!pCatIds.SequenceEqual(nCatIds))
            {
                foreach (var pCat in postCats)
                {
                    _dashboardRepo.RemovePostCategories(model.ID, pCat.Id);
                }
                foreach (var cat in model.Categories)
                {
                    PostCategory postCategory = new PostCategory();
                    if (cat.Checked == true)
                    {
                        postCategory.PostId = model.ID;
                        postCategory.CategoryId = cat.Id;
                        postCategory.Checked = true;
                        _dashboardRepo.AddPostCategories(postCategory);
                    }
                }
                _dashboardRepo.Save();
            }
            return RedirectToAction("EditPost", new { slug = post.UrlSeo });
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveCategoryFromPost(string slug, string postid, string catName)
        {
            CreatePostViewModel(slug);
            _dashboardRepo.RemoveCategoryFromPost(postid, catName);
            return RedirectToAction("EditPost", new { slug = slug });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddNewCategory(string postid, bool callfrompost)
        {
            if (postid != null && callfrompost)
            {
                PostViewModel model = new PostViewModel();
                model.ID = postid;
                return View(model);
            }
            else
            {
                return View();
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewCategory(string postid, string catName, string catUrlSeo, string catDesc)
        {
            if (postid != null)
            {
                _dashboardRepo.AddNewCategory(catName, catUrlSeo, catDesc);
                return RedirectToAction("AddCategoryToPost", new { postid = postid });
            }
            else
            {
                _dashboardRepo.AddNewCategory(catName, catUrlSeo, catDesc);
                return RedirectToAction("CategoriesAndTags", "Dashboard");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeletePost(PostViewModel model, string postid)
        {
            model.ID = postid;
            return View(model);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(string postId)
        {
            _dashboardRepo.DeletePostandComponents(postId);
            return RedirectToAction("Index", "Dashboard");
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddNewPost()
        {
            List<int> numlist = new List<int>();
            int num = 0;
            var posts = _dashboardRepo.GetPosts();
            if (posts.Count != 0)
            {
                foreach (var post in posts)
                {
                    var postid = post.Id;
                    Int32.TryParse(postid, out num);
                    numlist.Add(num);
                }
                numlist.Sort();
                num = numlist.Last();
                num++;
            }
            else
            {
                num = 1;
            }
            var newid = num.ToString();
            PostViewModel model = new PostViewModel();
            model.ID = newid;
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddNewPost(PostViewModel model)
        {
            var post = new Post
            {
                Id = model.ID,
                Body = model.Body,
                Meta = model.Meta,
                PostedOn = DateTime.Now,
                Published = true,
                ShortDescription = model.ShortDescription,
                Title = model.Title,
                UrlSeo = model.UrlSeo
            };
            _dashboardRepo.AddNewPost(post);
            return RedirectToAction("EditPost", "Dashboard", new { slug = model.UrlSeo });
        }

        #endregion Post


        [ChildActionOnly]
        public ActionResult Comments(PostViewModel model, Post post, string pageId, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DataSortParm = string.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.BestSortParm = sortOrder == "Best" ? "best_desc" : "Best";

            var postComments = _dashboardRepo.GetPostComments(post).OrderByDescending(d => d.DateTime).ToList();

            foreach (var comment in postComments)
            {
                var likes = LikeDislikeCount("commentlike", comment.Id);
                var dislikes = LikeDislikeCount("commentdislike", comment.Id);
                comment.NetLikeCount = likes - dislikes;
                if (comment.Replies != null) comment.Replies.Clear();
                List<CommentViewModel> replies = _dashboardRepo.GetParentReplies(comment);
                foreach (var reply in replies)
                {
                    var rep = _dashboardRepo.GetReplyById(reply.Id);
                    comment.Replies.Add(rep);
                }
            }

            switch (sortOrder)
            {
                case "date_asc":
                    postComments = postComments.OrderBy(x => x.DateTime).ToList();
                    ViewBag.DateSortLink = "active";
                    break;
                case "Best":
                    postComments = postComments.OrderByDescending(x => x.NetLikeCount).ToList();
                    ViewBag.BestSortLink = "active";
                    break;
                case "best_desc":
                    postComments = postComments.OrderBy(x => x.NetLikeCount).ToList();
                    ViewBag.BestSortLink = "active";
                    break;
                default:
                    postComments = postComments.OrderByDescending(x => x.DateTime).ToList();
                    ViewBag.DateSortLink = "active";
                    break;
            }

            model.UrlSeo = post.UrlSeo;
            model.Comments = postComments;
            return PartialView(model);

        }
        public CommentViewModel CreateCommentViewModel(string pageId, string sortOrder)
        {
            CommentViewModel model = new CommentViewModel();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.BestSortParm = sortOrder == "Best" ? "best_desc" : "Best";

            var comments = _dashboardRepo.GetCommentsByPageId(pageId).OrderByDescending(d => d.DateTime).ToList();
            foreach (var comment in comments)
            {
                var likes = LikeDislikeCount("commentlike", comment.Id);
                var dislikes = LikeDislikeCount("commentdislike", comment.Id);
                comment.NetLikeCount = likes - dislikes;
                if (comment.Replies != null) comment.Replies.Clear();
                List<CommentViewModel> replies = _dashboardRepo.GetParentReplies(comment);
                foreach (var reply in replies)
                {
                    var rep = _dashboardRepo.GetReplyById(reply.Id);
                    comment.Replies.Add(rep);
                }
            }
            if (pageId.Contains("post"))
            {
                model.UrlSeo = _dashboardRepo.GetPostById(pageId).UrlSeo;
            }


            switch (sortOrder)
            {
                case "date_asc":
                    comments = comments.OrderBy(x => x.DateTime).ToList();
                    ViewBag.DateSortLink = "active";
                    break;
                case "Best":
                    comments = comments.OrderByDescending(x => x.NetLikeCount).ToList();
                    ViewBag.BestSortLink = "active";
                    break;
                case "best_desc":
                    comments = comments.OrderBy(x => x.NetLikeCount).ToList();
                    ViewBag.BestSortLink = "active";
                    break;
                default:
                    comments = comments.OrderByDescending(x => x.DateTime).ToList();
                    ViewBag.DateSortLink = "active";
                    break;
            }

            model.Comments = comments;
            return model;
        }
        public PartialViewResult Replies()
        {
            return PartialView();
        }
        public PartialViewResult ChildReplies()
        {
            return PartialView();
        }


        public ActionResult UpdateCommentLike(string commentid, string username, string likeordislike, string slug, string sortorder)
        {
            if (username != null)
            {
                _dashboardRepo.UpdateCommentLike(commentid, username, likeordislike);
            }
            return RedirectToAction("Post", new { slug = slug, sortorder = sortorder });
        }
        public ActionResult UpdateReplyLike(string replyid, string username, string likeordislike, string sortorder)
        {
            if (username != null)
            {
                _dashboardRepo.UpdateReplyLike(replyid, username, likeordislike);
            }
            var slug = _dashboardRepo.GetPostByReply(replyid).UrlSeo;
            return RedirectToAction("Post", "Dashboard", new { slug = slug, sortorder = sortorder });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult NewComment(string commentBody, string comUserName, string slug, string pageId)
        {
            List<int> numlist = new List<int>();
            int num = 0;
            var comments = _dashboardRepo.GetComments().ToList();
            if (comments.Count() != 0)
            {
                foreach (var cmnt in comments)
                {
                    var comid = cmnt.Id;
                    Int32.TryParse(comid.Replace("cmt", ""), out num);
                    numlist.Add(num);
                }
                numlist.Sort();
                num = numlist.Last();
                num++;
            }
            else
            {
                num = 1;
            }
            var newid = "cmt" + num.ToString();
            var comment = new Comment()
            {
                Id = newid,
                PageId = pageId,
                DateTime = DateTime.Now,
                UserName = comUserName,
                Body = commentBody,
                NetLikeCount = 0
            };
            _dashboardRepo.AddNewComment(comment);

            if (pageId.Contains("post"))
            {
                return RedirectToAction("Post", new { slug = slug });
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult NewParentReply(string replyBody, string comUserName, string commentid, string slug)
        {
            var comDelChck = CommentDeleteCheck(commentid);
            if (!comDelChck)
            {
                List<int> numlist = new List<int>();
                int num = 0;
                var replies = _dashboardRepo.GetReplies().ToList();
                if (replies.Count != 0)
                {
                    foreach (var rep in replies)
                    {
                        var repid = rep.Id;
                        Int32.TryParse(repid.Replace("rep", ""), out num);
                        numlist.Add(num);
                    }
                    numlist.Sort();
                    num = numlist.Last();
                    num++;
                }
                else
                {
                    num = 1;
                }
                var newid = "rep" + num.ToString();
                var reply = new Reply()
                {
                    Id = newid,
                    CommentId = commentid,
                    ParentReplyId = null,
                    DateTime = DateTime.Now,
                    UserName = comUserName,
                    Body = replyBody,
                };
                _dashboardRepo.AddNewReply(reply);
            }

            var pageId = _dashboardRepo.GetPageIdByComment(commentid);
            if (pageId.Contains("post"))
            {
                return RedirectToAction("Post", new { slug = slug });
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult NewChildReply(string preplyid, string comUserName, string replyBody)
        {
            var repDelCheck = ReplyDeleteCheck(preplyid);
            var preply = _dashboardRepo.GetReplyById(preplyid);
            if (!repDelCheck)
            {
                List<int> numlist = new List<int>();
                int num = 0;
                var replies = _dashboardRepo.GetReplies().ToList();
                if (replies.Count != 0)
                {
                    foreach (var rep in replies)
                    {
                        var repid = rep.Id;
                        Int32.TryParse(repid.Replace("rep", ""), out num);
                        numlist.Add(num);
                    }
                    numlist.Sort();
                    num = numlist.Last();
                    num++;
                }
                else
                {
                    num = 1;
                }
                var newid = "rep" + num.ToString();
                var reply = new Reply()
                {
                    Id = newid,
                    CommentId = preply.CommentId,
                    ParentReplyId = preply.Id,
                    DateTime = DateTime.Now,
                    UserName = comUserName,
                    Body = replyBody,
                };
                _dashboardRepo.AddNewReply(reply);
            }
            var pageId = _dashboardRepo.GetPageIdByComment(preply.CommentId);
            if (pageId.Contains("post"))
            {
                return RedirectToAction("Post", new { slug = _dashboardRepo.GetUrlSeoByReply(preply) });
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }



        [HttpGet]
        public async Task<ActionResult> EditComment(CommentViewModel model, string commentid)
        {
            var user = await GetCurrentUserAsync();
            var comment = _dashboardRepo.GetCommentById(commentid);
            if (comment.UserName == user.UserName)
            {
                model.Id = commentid;
                model.Body = comment.Body;
                return View(model);
            }
            else
            {
                return RedirectToAction("Post", new { slug = _dashboardRepo.GetPosts().Where(x => x.Id == comment.PageId).FirstOrDefault().UrlSeo });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditComment(string commentid, string commentBody)
        {
            var comment = _dashboardRepo.GetCommentById(commentid);
            comment.Body = commentBody;
            comment.DateTime = DateTime.Now;
            _dashboardRepo.Save();
            return RedirectToAction("Post", new { slug = _dashboardRepo.GetPosts().Where(x => x.Id == comment.PageId).FirstOrDefault().UrlSeo });
        }


        [HttpGet]
        public async Task<ActionResult> DeleteComment(CommentViewModel model, string commentid)
        {
            var user = await GetCurrentUserAsync();
            var comment = _dashboardRepo.GetCommentById(commentid);
            if (comment.UserName == user.UserName)
            {
                model.Id = commentid;
                return View(model);
            }
            else
            {
                return RedirectToAction("Post", new { slug = _dashboardRepo.GetPosts().Where(x => x.Id == comment.PageId).FirstOrDefault().UrlSeo });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(string commentid)
        {
            var comment = _dashboardRepo.GetCommentById(commentid);
            var postid = comment.PageId;
            var repliesList = _dashboardRepo.GetParentReplies(comment);
            if (repliesList.Count() == 0)
            {
                _dashboardRepo.DeleteComment(commentid);
            }
            else
            {
                comment.DateTime = DateTime.Now;
                comment.Body = "<p style=\"color:red;\"><i>This comment has been deleted.</i></p>";
                comment.Deleted = true;
                _dashboardRepo.Save();
            }
            return RedirectToAction("Post", new { slug = _dashboardRepo.GetPosts().Where(x => x.Id == postid).FirstOrDefault().UrlSeo });
        }


        [HttpGet]
        public async Task<ActionResult> EditReply(CommentViewModel model, string replyid)
        {
            var user = await GetCurrentUserAsync();
            var reply = _dashboardRepo.GetReplyById(replyid);
            if (reply.UserName == user.UserName)
            {
                model.Id = replyid;
                model.Body = reply.Body;
                return View(model);
            }
            else
            {
                return RedirectToAction("Post", new { slug = _dashboardRepo.GetUrlSeoByReply(reply) });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditReply(string replyid, string replyBody)
        {
            var reply = _dashboardRepo.GetReplyById(replyid);
            reply.Body = replyBody;
            reply.DateTime = DateTime.Now;
            _dashboardRepo.Save();
            return RedirectToAction("Post", new { slug = _dashboardRepo.GetUrlSeoByReply(reply) });
        }


        [HttpGet]
        public async Task<ActionResult> DeleteReply(CommentViewModel model, string replyid)
        {
            var user = await GetCurrentUserAsync();
            var reply = _dashboardRepo.GetReplyById(replyid);
            if (reply.UserName == user.UserName)
            {
                model.Id = replyid;
                return View(model);
            }
            else
            {
                return RedirectToAction("Post", new { slug = _dashboardRepo.GetUrlSeoByReply(reply) });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReply(string replyid)
        {
            var reply = _dashboardRepo.GetReplyById(replyid);
            var repliesList = _dashboardRepo.GetChildReplies(reply);
            var postid = _dashboardRepo.GetUrlSeoByReply(reply);
            if (repliesList.Count() == 0)
            {
                _dashboardRepo.DeleteReply(replyid);
            }
            else
            {
                reply.DateTime = DateTime.Now;
                reply.Body = "<p style=\"color:red;\"><i>This comment has been deleted.</i></p>";
                reply.Deleted = true;
                _dashboardRepo.Save();
            }
            return RedirectToAction("Post", new { slug = _dashboardRepo.GetPosts().Where(x => x.Id == postid).FirstOrDefault().UrlSeo });
        }




        #region Helper

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await UserManager.FindByIdAsync(User.Identity.GetUserId());
        }

        public List<CommentViewModel> GetChildReplies(Reply parentReply)
        {
            return _dashboardRepo.GetChildReplies(parentReply);
        }

        public static string TimePassed(DateTime postDate)
        {
            string date = null;
            double dateDiff = 0.0;
            var timeDiff = DateTime.Now - postDate;
            var yearPassed = timeDiff.TotalDays / 365;
            var monthPassed = timeDiff.TotalDays / 30;
            var dayPassed = timeDiff.TotalDays;
            var hourPassed = timeDiff.TotalHours;
            var minutePassed = timeDiff.TotalMinutes;
            var secondPassed = timeDiff.TotalSeconds;
            if (Math.Floor(yearPassed) > 0)
            {
                dateDiff = Math.Floor(yearPassed);
                date = dateDiff == 1 ? dateDiff + " year ago" : dateDiff + "years ago";
            }
            else
            {
                if (Math.Floor(monthPassed) > 0)
                {
                    dateDiff = Math.Floor(monthPassed);
                    date = dateDiff == 1 ? dateDiff + " month ago" : dateDiff + " months ago";
                }
                else
                {
                    if (Math.Floor(dayPassed) > 0)
                    {
                        dateDiff = Math.Floor(dayPassed);
                        date = dateDiff == 1 ? dateDiff + "day ago" : dateDiff + "days ago";
                    }
                    else
                    {
                        if (Math.Floor(hourPassed) > 0)
                        {
                            dateDiff = Math.Floor(hourPassed);
                            date = dateDiff == 1 ? dateDiff + "hour ago " : dateDiff + "hours ago";
                        }
                        else
                        {
                            if (Math.Floor(minutePassed) > 0)
                            {
                                dateDiff = Math.Floor(minutePassed);
                                date = dateDiff == 1 ? dateDiff + " minute ago" : dateDiff + "minutes ago";
                            }
                            else
                            {
                                dateDiff = Math.Floor(secondPassed);
                                date = dateDiff == 1 ? dateDiff + "second ago " : dateDiff + "seconds ago";
                            }
                        }
                    }
                }
            }
            return date;
        }


        public string[] NewCommentDetails(string username)
        {
            string[] newCommentDetails = new string[3];
            newCommentDetails[0] = "td" + username;
            newCommentDetails[1] = "tdc" + username;
            newCommentDetails[2] = "tb" + username;
            return newCommentDetails;
        }


        public string[] CommentDetails(Comment comment)
        {
            string[] commentDetails = new string[17];
            commentDetails[0] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(comment.UserName);
            commentDetails[1] = "/Content/images/profile/" + commentDetails[0] + ".png?time=" + DateTime.Now.ToString();
            commentDetails[2] = TimePassed(comment.DateTime);
            commentDetails[3] = comment.DateTime.ToLongDateString().Replace(comment.DateTime.DayOfWeek.ToString() + ", ", "");
            commentDetails[4] = "gp" + comment.Id;
            commentDetails[5] = "mc" + comment.Id;
            commentDetails[6] = "crp" + comment.Id;
            commentDetails[7] = "cex" + comment.Id;
            commentDetails[8] = "ctex" + comment.Id;
            commentDetails[9] = "ctflg" + comment.Id;
            commentDetails[10] = "sp" + comment.Id;
            commentDetails[11] = "sc" + comment.Id;
            commentDetails[12] = "td" + comment.Id;
            commentDetails[13] = "tdc" + comment.Id;
            commentDetails[14] = "rpl" + comment.Id;
            commentDetails[15] = "cc1" + comment.Id;
            commentDetails[16] = "cc2" + comment.Id;
            return commentDetails;
        }

        public string[] ReplyDetails(string replyId)
        {
            string[] replyDetails = new string[17];
            var reply = _dashboardRepo.GetReplyById(replyId);
            replyDetails[0] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(reply.UserName);
            replyDetails[1] = "/Content/images/profile/" + replyDetails[0] + ".png?time=" + DateTime.Now.ToString();
            replyDetails[2] = TimePassed(reply.DateTime);
            replyDetails[3] = reply.DateTime.ToLongDateString().Replace(reply.DateTime.DayOfWeek.ToString() + ", ", "");
            replyDetails[4] = "gp" + replyId;
            replyDetails[5] = "rp" + replyId;
            replyDetails[6] = "crp" + replyId;
            replyDetails[7] = "cex" + replyId;
            replyDetails[8] = "ctex" + replyId;
            replyDetails[9] = "ctflg" + replyId;
            replyDetails[10] = "sp" + replyId;
            replyDetails[11] = "sc" + replyId;
            replyDetails[12] = "td" + replyId;
            replyDetails[13] = "tdc" + replyId;
            replyDetails[14] = "rpl" + replyId;
            replyDetails[15] = "cc1" + replyId;
            replyDetails[16] = "cc2" + replyId;
            return replyDetails;







        }

        public bool ReplyDeleteCheck(string replyid)
        {
            return _dashboardRepo.ReplyDeleteCheck(replyid);
        }

        public int LikeDislikeCount(string typeAndlike, string id)
        {
            switch (typeAndlike)
            {
                case "commentlike":
                    return _dashboardRepo.LikeDislikeCount("commentlike", id);
                case "commentdislike":
                    return _dashboardRepo.LikeDislikeCount("commentdislike", id);
                case "replylike":
                    return _dashboardRepo.LikeDislikeCount("replylike", id);
                case "replydislike":
                    return _dashboardRepo.LikeDislikeCount("replydislike", id);
                default:
                    return 0;
            }
        }

        public bool CommentDeleteCheck(string commentid)
        {
            return _dashboardRepo.CommentDeleteCheck(commentid);
        }

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

        public PostViewModel CreatePostViewModel(string slug)
        {
            PostViewModel model = new PostViewModel();
            var postid = _dashboardRepo.GetPostIdBySlug(slug);
            var post = _dashboardRepo.GetPostById(postid);
            model.ID = postid;
            model.Title = post.Title;
            model.Body = post.Body;
            model.Meta = post.Meta;
            model.UrlSeo = post.UrlSeo;
            model.Videos = _dashboardRepo.GetPostVideos(post).ToList();
            model.PostCategories = _dashboardRepo.GetPostCategories(post).ToList();
            model.PostTags = _dashboardRepo.GetPostTags(post).ToList();
            model.ShortDescription = post.ShortDescription;
            return model;
        }

        #endregion
    }
}