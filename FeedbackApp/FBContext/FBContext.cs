using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Models.DBModels;

namespace FeedbackApp.Context
{
    public class FBContext : DbContext
    {
        public DbSet<DBUser> users { get; set; }
        public DbSet<DBMessage> messages { get; set; }
        public string? PathToDb { get; set; }

        public FBContext()
        {
            PathToDb = System.IO.Path.Join(AppDomain.CurrentDomain.BaseDirectory,"FeedbackDb.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={PathToDb}");
        }
    }
}
