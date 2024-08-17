﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240817100200_AddConstTable")]
    partial class AddConstTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Achievement", b =>
                {
                    b.Property<Guid>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AchievementId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Backend.Models.Answer", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnswerId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Backend.Models.ApplicationConst", b =>
                {
                    b.Property<Guid>("ApplicationConstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationConstId");

                    b.ToTable("ApplicationConsts");
                });

            modelBuilder.Entity("Backend.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ParentCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend.Models.CommentVote", b =>
                {
                    b.Property<Guid>("CommentVoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUpvote")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentVoteId");

                    b.ToTable("CommentVotes");
                });

            modelBuilder.Entity("Backend.Models.DifficultLevel", b =>
                {
                    b.Property<Guid>("DifficultLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DifficultLevelId");

                    b.HasAlternateKey("Name")
                        .HasName("UK_DifficultLevel_Name");

                    b.ToTable("DifficultLevels");

                    b.HasData(
                        new
                        {
                            DifficultLevelId = new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                            CreatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1648),
                            Description = "Nhận biết, nhắc lại được kiến thức, kĩ năng đã học.",
                            Name = "Nhận biết",
                            UpdatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1664)
                        },
                        new
                        {
                            DifficultLevelId = new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                            CreatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1711),
                            Description = "Hiểu kiến thức, kĩ năng đã học. trình bày, giải thích được kiến thức theo cách hiểu của cá nhân.",
                            Name = "Đọc hiểu",
                            UpdatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1712)
                        },
                        new
                        {
                            DifficultLevelId = new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                            CreatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1728),
                            Description = "Biết vận dụng kiến thức, kĩ năng đã học để giải quyết những vấn dề quen thuộc, tương tự trong học tập, cuộc sống.",
                            Name = "Vận dụng",
                            UpdatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1728)
                        },
                        new
                        {
                            DifficultLevelId = new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                            CreatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1746),
                            Description = "Vận dụng các kiến thức, kĩ năng đã học để giải quyết vấn đề mới hoặc đưa ra những phản hồi hợp lý trong học tập, cuộc sống một cách linh hoạt.",
                            Name = "Vận dụng cao",
                            UpdatedAt = new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1747)
                        });
                });

            modelBuilder.Entity("Backend.Models.EducationLevel", b =>
                {
                    b.Property<Guid>("EducationLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("EducationLevelId");

                    b.HasAlternateKey("Name")
                        .HasName("UK_EducationLevel_Name");

                    b.ToTable("EducationLevels");
                });

            modelBuilder.Entity("Backend.Models.Favourite", b =>
                {
                    b.Property<Guid>("FavouriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavouriteId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("Backend.Models.Follow", b =>
                {
                    b.Property<Guid>("FollowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FolloweeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FollowId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Backend.Models.Language", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("LanguageId");

                    b.HasAlternateKey("Name")
                        .HasName("UK_Language_Name");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Backend.Models.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserReceivedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserSentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Backend.Models.Play", b =>
                {
                    b.Property<Guid>("PlayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubmitTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayId");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("Backend.Models.Point", b =>
                {
                    b.Property<Guid>("PointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPenalty")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("PointId");

                    b.HasAlternateKey("Value")
                        .HasName("UK_Point_Value");

                    b.ToTable("Points", t =>
                        {
                            t.HasCheckConstraint("CC_Point_Value", "[Value] > 0");
                        });
                });

            modelBuilder.Entity("Backend.Models.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AudioUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DifficultLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EducationLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PenaltyPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Backend.Models.QuestionType", b =>
                {
                    b.Property<Guid>("QuestionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("QuestionTypeId");

                    b.HasAlternateKey("Name")
                        .HasName("UK_QuestionType_Name");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("Backend.Models.Quiz", b =>
                {
                    b.Property<Guid>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EducationLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserVerifiedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("QuizId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Backend.Models.QuizQuestion", b =>
                {
                    b.Property<Guid>("QuizQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuizQuestionId");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("Backend.Models.Rating", b =>
                {
                    b.Property<Guid>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RatingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Backend.Models.Report", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReportReasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReportTargetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ResolvedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserResolveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Backend.Models.ReportReason", b =>
                {
                    b.Property<Guid>("ReportReasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ReportReasonId");

                    b.ToTable("ReportReasons");
                });

            modelBuilder.Entity("Backend.Models.ReportTarget", b =>
                {
                    b.Property<Guid>("ReportTargetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ReportTargetId");

                    b.ToTable("ReportTargets");
                });

            modelBuilder.Entity("Backend.Models.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartQuizTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Backend.Models.SelectedAnswer", b =>
                {
                    b.Property<Guid>("SelectedAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SelectedAnswerId");

                    b.ToTable("SelectedAnswers");
                });

            modelBuilder.Entity("Backend.Models.SubSubject", b =>
                {
                    b.Property<Guid>("SubSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EducationLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SubSubjectId");

                    b.HasAlternateKey("Name")
                        .HasName("UK_SubSubject_Name");

                    b.ToTable("SubSubjects");
                });

            modelBuilder.Entity("Backend.Models.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SubjectId");

                    b.HasAlternateKey("Name")
                        .HasName("UK_Subject_Name");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Backend.Models.Time", b =>
                {
                    b.Property<Guid>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("SecondValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeId");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.UserRoom", b =>
                {
                    b.Property<Guid>("UserRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinRoomTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveRoomTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartQuizTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubmitQuizTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoomId");

                    b.ToTable("UserRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
