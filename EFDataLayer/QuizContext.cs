
using EFDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFDataLayer
{
    public class QuizContext: DbContext
    {
        public string connectionString;

        //public QuizContext() 
        //{
        //    this.connectionString = connectionString;
        //}
        public QuizContext()
        {
             
           
        }

        public QuizContext(DbContextOptions options, string connectionString) : base(options) 
        {
            this.connectionString = connectionString;
        }

        public DbSet<PlayerEF> Player { get; set; }  
        public DbSet<GameEF> Game { get; set; } 
        public DbSet<QuestionEF> Question { get; set; } 
        public DbSet<AnswerEF> Answer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}