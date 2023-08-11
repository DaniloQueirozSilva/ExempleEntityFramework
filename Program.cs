using Blog.Models;
using BlogEF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BlogEF
{
    internal class Program
    {
        static void Main()
        {
            using var context = new BlogDataContext();

            var user = new User
            {
                Name = "Danilo Queiroz",
                Slug = "daniloqueiroz",
                GitHub = "daniloDev",
                Email = "daniloqueiroz@gmail.com",
                Bio = "1x Microsfot MVP",
                Image = "C:/DANILO",
                PasswordHash = "12345",
            };

            //    var category = new Category
            //    {
            //        Name = "Backend",
            //        Slug = "backend"
            //    };

            //    var post = new Post
            //    {
            //        Author = user,
            //        Category = category,
            //        Body = "<p>Hello World</p>",
            //        Slug = "comecando-com-ef-core",
            //        Summary = "Neste artigo vamos aprender EF Core",
            //        Title = "Começando com EF Core",
            //        CreateDate = DateTime.Now,
            //        LastUpdateDate = DateTime.Now,
            //    };

            //    context.Posts.Add(post);
            //    context.SaveChanges();
            //}

            //var post = context
            //    .Posts
            //    .Include(x => x.Author)
            //    .Include(x => x.Category)
            //    .OrderByDescending(x => x.LastUpdateDate)
            //    .FirstOrDefault();

            //post.Author.Name = "Danilo Teste";

            //context.Posts.Update(post);
            //context.SaveChanges();

            //context.Users.Add(new User {

            //    Name = "Davi Queiroz",
            //    Slug = "daviqueiroz",
            //    Email = "daviqueiroz@gmail.com",
            //    Bio = "3x Microsfot MVP",
            //    Image = "C:/Davi",
            //    PasswordHash = "12345"
            //});

            //context.SaveChanges();

            //var user = context.Users.FirstOrDefault();


            //var post = new Post
            //{
            //    Author = user,
            //    Body = "Meu artigo",
            //    Category = new Category
            //    {
            //        Name = "FrontEnd",
            //        Slug = "frontend"
            //    },
            //    CreateDate = DateTime.Now,
            //    // LastUpdateDate=
            //    Slug = "meu-artigo",
            //    Summary = "Neste artigo vamos conferir....",
            //    // Tags=Null
            //    Title = "Meu artigo"

            //};
            

            context.Users.Add(user);
            context.SaveChanges();


            //var posts = context.Posts
            //    .Include(x => x.Author)
            //        .ThenInclude(x => x.Roles); //pegando itens da role do objeto author

            var posts = context.PostWithTagsCounts.FirstOrDefault();

        }
    }
}
