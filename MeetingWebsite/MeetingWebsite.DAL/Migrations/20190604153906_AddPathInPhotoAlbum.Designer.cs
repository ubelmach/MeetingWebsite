﻿// <auto-generated />
using System;
using MeetingWebsite.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingWebsite.DAL.Migrations
{
    [DbContext(typeof(MeetingDbContext))]
    [Migration("20190604153906_AddPathInPhotoAlbum")]
    partial class AddPathInPhotoAlbum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MeetingWebsite.Models.Entities.BlackList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("WhomId");

                    b.HasKey("Id");

                    b.HasIndex("CurrentUserId");

                    b.HasIndex("WhomId");

                    b.ToTable("BlackLists");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.Dialog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Dialogs");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumId");

                    b.Property<int?>("MessageId");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstFriendId");

                    b.Property<int>("InviteStatus");

                    b.Property<string>("SecondFriendId");

                    b.HasKey("Id");

                    b.HasIndex("FirstFriendId");

                    b.HasIndex("SecondFriendId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("IdDialog");

                    b.Property<int?>("IdFile");

                    b.Property<bool>("New");

                    b.Property<string>("SenderId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("IdDialog");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.PhotoAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PhotoAlbums");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("AnonymityMode");

                    b.Property<int?>("AvatarId");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("HomeDir");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BadHabits");

                    b.Property<string>("Education");

                    b.Property<string>("FinancialSituation");

                    b.Property<string>("Height");

                    b.Property<string>("Interests");

                    b.Property<string>("KnowledgeOfLanguages");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("Nationality");

                    b.Property<string>("PurposeOfDating");

                    b.Property<string>("UserId");

                    b.Property<string>("Weight");

                    b.Property<string>("ZodiacSign");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.BlackList", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User", "CurrentUser")
                        .WithMany("WhoAddedCurrentUser")
                        .HasForeignKey("CurrentUserId");

                    b.HasOne("MeetingWebsite.Models.Entities.User", "Whom")
                        .WithMany("WhomTheUserAdded")
                        .HasForeignKey("WhomId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.Dialog", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User", "Receiver")
                        .WithMany("IncomingMessages")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("MeetingWebsite.Models.Entities.User", "Sender")
                        .WithMany("OutgoingMessages")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.FileModel", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.PhotoAlbum", "Album")
                        .WithMany("Files")
                        .HasForeignKey("AlbumId");

                    b.HasOne("MeetingWebsite.Models.Entities.Message", "Message")
                        .WithMany("Files")
                        .HasForeignKey("MessageId");

                    b.HasOne("MeetingWebsite.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.Friendship", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User", "FirstFriend")
                        .WithMany("OutgoingFriendships")
                        .HasForeignKey("FirstFriendId");

                    b.HasOne("MeetingWebsite.Models.Entities.User", "SecondFriend")
                        .WithMany("IncomingFriendships")
                        .HasForeignKey("SecondFriendId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.Message", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.Dialog", "Dialog")
                        .WithMany()
                        .HasForeignKey("IdDialog");

                    b.HasOne("MeetingWebsite.Models.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.PhotoAlbum", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User", "User")
                        .WithMany("PhotoAlbums")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.User", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.FileModel", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");
                });

            modelBuilder.Entity("MeetingWebsite.Models.Entities.UserProfile", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("MeetingWebsite.Models.Entities.UserProfile", "UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeetingWebsite.Models.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MeetingWebsite.Models.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
