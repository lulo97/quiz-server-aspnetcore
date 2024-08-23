using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Add unique key = HasAlternateKey (can't be update/delete by EF)
            //Add unique index = HasIndex().IsUnique()
            modelBuilder.Entity<DifficultLevel>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<EducationLevel>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Language>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Subject>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<QuestionType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(x => x.Name).IsUnique();

            //Add a combination of unique columns
            modelBuilder.Entity<SubSubject>()
                .HasIndex(x => new { x.Name, x.SubjectId, x.EducationLevelId })
                .IsUnique();
            modelBuilder.Entity<Point>().HasIndex(x => new { x.Value, x.IsPenalty }).IsUnique();

            //Add check constraint = HasCheckConstraint
            modelBuilder.Entity<Point>().ToTable(x => x.HasCheckConstraint("CC_Point_Value", "[Value] > 0"));

            //Seed data
            modelBuilder.Entity<DifficultLevel>().HasData(new DifficultLevel { 
                DifficultLevelId = Guid.Parse("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                Name = "Nhận biết",
                Description = "Nhận biết, nhắc lại được kiến thức, kĩ năng đã học.",
            });
            modelBuilder.Entity<DifficultLevel>().HasData(new DifficultLevel
            {
                DifficultLevelId = Guid.Parse("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                Name = "Đọc hiểu",
                Description = "Hiểu kiến thức, kĩ năng đã học. trình bày, giải thích được kiến thức theo cách hiểu của cá nhân.",
            });
            modelBuilder.Entity<DifficultLevel>().HasData(new DifficultLevel
            {
                DifficultLevelId = Guid.Parse("09593f78-2de4-48dc-9d79-72e72fa33607"),
                Name = "Vận dụng",
                Description = "Biết vận dụng kiến thức, kĩ năng đã học để giải quyết những vấn dề quen thuộc, tương tự trong học tập, cuộc sống.",
            });
            modelBuilder.Entity<DifficultLevel>().HasData(new DifficultLevel
            {
                DifficultLevelId = Guid.Parse("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                Name = "Vận dụng cao",
                Description = "Vận dụng các kiến thức, kĩ năng đã học để giải quyết vấn đề mới hoặc đưa ra những phản hồi hợp lý trong học tập, cuộc sống một cách linh hoạt.",
            });

            //Add admin user
            var user_admin = new User
            {
                Id = Guid.Parse("1e874e00-f545-4a55-9a92-9a70afb606b0"),
                UserName = "admin",
                Fullname = "admin",
                NormalizedUserName = "ADMIN",
                Email = "luongpysl2@gmail.com",
                NormalizedEmail = "LUONGPYSL2@GMAIL.COM",
                EmailConfirmed = true,
                ImageUrl = "https://lh3.googleusercontent.com/a/ACg8ocLV8p2S7WsFyfspBGUcvR-Nh2ojZP7d51i8NqdoPCq-jZ9PUP4=s432-c-no",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user_admin, "123");
            user_admin.PasswordHash = hashed;
            modelBuilder.Entity<User>().HasData(user_admin);

            //Add FK
            modelBuilder.Entity<SubSubject>()
                .HasOne(ss => ss.Subject) // Each SubSubject has one Subject
                .WithMany(s => s.SubSubjects) // Each Subject has many SubSubjects
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);// SubjectId is the foreign key

            modelBuilder.Entity<SubSubject>()
                .HasOne(ss => ss.EducationLevel) // Each SubSubject has one Subject
                .WithMany(s => s.SubSubjects) // Each Subject has many SubSubjects
                .HasForeignKey(ss => ss.EducationLevelId)
                .OnDelete(DeleteBehavior.Restrict);// SubjectId is the foreign key
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<DifficultLevel> DifficultLevels { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportReason> ReportReasons { get; set; }
        public DbSet<ReportTarget> ReportTargets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SelectedAnswer> SelectedAnswers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubSubject> SubSubjects { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<ApplicationConst> ApplicationConsts { get; set; }
    }
}
