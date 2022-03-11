﻿// <auto-generated />
using System;
using ApiServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiServer.Migrations
{
    [DbContext(typeof(MarshmallowChatContext))]
    partial class MarshmallowChatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiServer.Models.Friendship", b =>
                {
                    b.Property<int>("User1Id")
                        .HasColumnType("int");

                    b.Property<int>("User2Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("User1Id", "User2Id");

                    b.HasIndex(new[] { "User2Id" }, "IX_Friendship_User2Id");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("ApiServer.Models.Message", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "MessageId");

                    b.HasIndex(new[] { "UserId" }, "IX_Message_UserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("ApiServer.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RoomId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ApiServer.Models.RoomInfo", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoomId");

                    b.ToTable("RoomInfo");
                });

            modelBuilder.Entity("ApiServer.Models.RoomMember", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "UserId");

                    b.HasIndex(new[] { "UserId" }, "IX_Room_Member_UserId");

                    b.ToTable("RoomMember");
                });

            modelBuilder.Entity("ApiServer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DayOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ApiServer.Models.Friendship", b =>
                {
                    b.HasOne("ApiServer.Models.User", "User1")
                        .WithMany("FriendshipUser1s")
                        .HasForeignKey("User1Id")
                        .IsRequired();

                    b.HasOne("ApiServer.Models.User", "User2")
                        .WithMany("FriendshipUser2s")
                        .HasForeignKey("User2Id")
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("ApiServer.Models.Message", b =>
                {
                    b.HasOne("ApiServer.Models.Room", "Room")
                        .WithMany("Messages")
                        .HasForeignKey("RoomId")
                        .IsRequired();

                    b.HasOne("ApiServer.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiServer.Models.RoomInfo", b =>
                {
                    b.HasOne("ApiServer.Models.Room", "Room")
                        .WithOne("RoomInfo")
                        .HasForeignKey("ApiServer.Models.RoomInfo", "RoomId")
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ApiServer.Models.RoomMember", b =>
                {
                    b.HasOne("ApiServer.Models.Room", "Room")
                        .WithMany("RoomMembers")
                        .HasForeignKey("RoomId")
                        .IsRequired();

                    b.HasOne("ApiServer.Models.User", "User")
                        .WithMany("RoomMembers")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiServer.Models.Room", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("RoomInfo");

                    b.Navigation("RoomMembers");
                });

            modelBuilder.Entity("ApiServer.Models.User", b =>
                {
                    b.Navigation("FriendshipUser1s");

                    b.Navigation("FriendshipUser2s");

                    b.Navigation("Messages");

                    b.Navigation("RoomMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
