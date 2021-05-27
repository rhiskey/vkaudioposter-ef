﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vkaudioposter_ef;

namespace vkaudioposter_ef.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210527104302_RemoveMapping2")]
    partial class RemoveMapping2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("vkaudioposter_ef.Model.ParserXpath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Xpath")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)")
                        .HasComment("nodContainer for parsing (outer)");

                    b.Property<string>("XpathInner")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)")
                        .HasComment("nodContainer for parsing (inner if need to go inside)");

                    b.HasKey("Id");

                    b.ToTable("ParserXpaths");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.PostedPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(2056)
                        .HasColumnType("varchar(2056)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostedPhotos");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.ConsolePhotostock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("ParserXpathId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasComment("Enabled status. If = 0 - not included, if = 1 - included in parsing");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 5, 27, 13, 43, 2, 97, DateTimeKind.Local).AddTicks(5703))
                        .HasComment("Update Date");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.HasIndex("ParserXpathId");

                    b.ToTable("console_Photostocks");

                    b
                        .HasComment("URL list of photostocks");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Mood")
                        .HasColumnType("int");

                    b.Property<string>("PlaylistId")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Playlist_ID")
                        .HasComment("Spotify URI");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Playlist_Name")
                        .HasComment("Name of playlist");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasComment("Enabled status. If = 0 - not included, if = 1 - included in parsing");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 5, 27, 13, 43, 2, 95, DateTimeKind.Local).AddTicks(9512))
                        .HasComment("Update Date");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PlaylistName" }, "Playlist_Name")
                        .IsUnique();

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.PostedTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME");

                    b.Property<long?>("MediaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<int?>("PlaylistId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("PreviewUrl")
                        .HasColumnType("text");

                    b.Property<string>("Trackname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("PostId");

                    b.HasIndex("Trackname")
                        .IsUnique();

                    b.ToTable("PostedTracks");

                    b
                        .HasComment("Published tracks info");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.UnfoundTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("PlaylistId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Trackname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("trackname");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("Trackname")
                        .IsUnique();

                    b.ToTable("UnfoundTracks");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.PostedPhoto", b =>
                {
                    b.HasOne("vkaudioposter_ef.Model.Post", "Post")
                        .WithMany("PostedPhotos")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.Role", b =>
                {
                    b.HasOne("vkaudioposter_ef.Model.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.ConsolePhotostock", b =>
                {
                    b.HasOne("vkaudioposter_ef.Model.ParserXpath", "ParserXpath")
                        .WithMany("ConsolePhotostock")
                        .HasForeignKey("ParserXpathId");

                    b.Navigation("ParserXpath");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.PostedTrack", b =>
                {
                    b.HasOne("vkaudioposter_ef.parser.Playlist", "Playlist")
                        .WithMany("PostedTracks")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vkaudioposter_ef.Model.Post", "Post")
                        .WithMany("PostedTracks")
                        .HasForeignKey("PostId");

                    b.Navigation("Playlist");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.UnfoundTrack", b =>
                {
                    b.HasOne("vkaudioposter_ef.parser.Playlist", "Playlist")
                        .WithMany("UnfoundTracks")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.ParserXpath", b =>
                {
                    b.Navigation("ConsolePhotostock");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.Post", b =>
                {
                    b.Navigation("PostedPhotos");

                    b.Navigation("PostedTracks");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.User", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("vkaudioposter_ef.parser.Playlist", b =>
                {
                    b.Navigation("PostedTracks");

                    b.Navigation("UnfoundTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
