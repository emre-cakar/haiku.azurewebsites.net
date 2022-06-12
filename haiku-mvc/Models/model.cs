using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace haiku_mvc.Models
{
    public class HaikuazurewebsitesContext : DbContext
    {
        public DbSet<USERS> USERS { get; set; }
        public DbSet<POSTS> POSTS { get; set; }
        public DbSet<LIKES> LIKES { get; set; }
        public DbSet<SHARES> SHARES { get; set; }
        public DbSet<FOLLOWERS> FOLLOWERS { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:haiku-server.database.windows.net,1433;
                Initial Catalog=haiku;Persist Security Info=False;
                User ID=haiku-admin;Password={Marmara.!123};
                MultipleActiveResultSets=False;Encrypt=True;
                TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
    public class USERS
    {
        [Key]
        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> TotalFollowers { get; set; }
        public Nullable<int> TotalFollows { get; set; }
        public Nullable<int> TotalHaiku { get; set; }
        public Nullable<int> TotalLikes { get; set; }
        public Nullable<int> TotalShares { get; set; }

    }
    public class POSTS
    {
        [Key]
        public int HaikuId { get; set; }
        public int AuthorId { get; set; }
        public string Contents { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Likes { get; set; }
        public Nullable<int> Shares { get; set; }
    }
    public class FOLLOWERS
    {
        [Key]
        public int FollowId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> UserWhoFollowed { get; set; }
    }
    public class LIKES

    {
        [Key]
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> UserWhoLiked { get; set; }
    }
    public class SHARES
    {
        [Key]
        public int ShareId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> UserWhoShared { get; set; }
    }
}