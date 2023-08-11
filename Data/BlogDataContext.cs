using Blog.Models;
using BlogEF.Mappings;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

namespace BlogEF.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }             
        public DbSet<User> Users { get; set; }
        public DbSet<PostWithTagsCount> PostWithTagsCounts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Persist Security Info=False;Integrated Security=true;Initial Catalog=Blog;server=DESKTOP-3PVVSJJ\\SERVERSQL");

           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());


            modelBuilder.Entity<PostWithTagsCount>(x =>
            {
                x.ToSqlQuery(@"
                SELECT
                    [Title],
                SELECT COUNT ([Id]) FROM [Tags] WHERE [PostId] = [Id]
                        AS [Count]
                FROM
                    [Posts]");
            }
            );
        }
    }
}
