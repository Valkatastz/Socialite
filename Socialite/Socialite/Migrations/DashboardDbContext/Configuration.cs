namespace Socialite.Migrations.DashboardDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Socialite.Models.DashboardDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DashboardDbContext";
        }

        protected override void Seed(Models.DashboardDbContext context)
        {
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat1", Name = "Lorem", UrlSeo = "Lorem", Description = "Lorem Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat2", Name = "Duis", UrlSeo = "Duis", Description = "Duis Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat3", Name = "Nulla", UrlSeo = "Nulla", Description = "Nulla Category" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "cat4", Name = "Ipsum", UrlSeo = "Ipsum", Description = "Ipsum Category" });

            context.Posts.AddOrUpdate(new Models.Post
            {
                Id = "1",
                Title = "Lorem",
                Body = "Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem ",
                ShortDescription = "Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem",
                PostedOn = DateTime.Now,
                Meta = "Lorem",
                UrlSeo = "Lorem",
                Published = true
            });

            context.Posts.AddOrUpdate(new Models.Post
            {
                Id = "2",
                Title = "Duis",
                Body = "Duis Duis Duis Duis Duis Duis Duis Duis Duis Duis Duis Duis Duis ",
                ShortDescription = "Duis Duis Duis Duis",
                PostedOn = DateTime.Now,
                Meta = "Duis",
                UrlSeo = "Duis",
                Published = true
            });

            context.Posts.AddOrUpdate(new Models.Post { Id = "3", Title = "Nulla", Body = "Nulla Nulla Nulla Nulla Nulla Nulla Nulla Nulla Nulla Nulla Nulla", ShortDescription = "Nulla Nulla Nulla", PostedOn = DateTime.Now, Meta = "Nulla", UrlSeo = "Nulla", Published = true });

            context.Posts.AddOrUpdate(new Models.Post { Id = "4", Title = "Ipsum", Body = "Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum Ipsum", ShortDescription = "Ipsum Ipsum Ipsum Ipsum Ipsum", PostedOn = DateTime.Now, Meta = "Ipsum", UrlSeo = "Ipsum", Published = true });

            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "1", CategoryId = "cat1" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "1", CategoryId = "cat4" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "2", CategoryId = "cat2" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "3", CategoryId = "cat3" });

            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 1, PostId = "1", VideoSiteName = "Youtube", VideoUrl = "https://www.youtube.com/embed/kJQP7kiw5Fk", VideoThumbnail = "~/Content/post/Despacito.jpg" });
            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 2, PostId = "2", VideoSiteName = "Youtube", VideoUrl = "https://www.youtube.com/embed/6Mgqbai3fKo", VideoThumbnail = "~/Content/post/Chantaje.jpg" });
            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 3, PostId = "3", VideoSiteName = "Youtube", VideoUrl = "https://www.youtube.com/embed/iOe6dI2JhgU", VideoThumbnail = "~/Content/post/VentePaCa.jpg" });
            context.PostVideos.AddOrUpdate(new Models.PostVideo { Id = 4, PostId = "1", VideoSiteName = "Youtube", VideoUrl = "https://www.youtube.com/embed/TapXs54Ah3E", VideoThumbnail = "~/Content/post/AyVamos.jpg" });
        }
    }
}
