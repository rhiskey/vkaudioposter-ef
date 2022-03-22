﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vkaudioposter_ef;

namespace vkaudioposter_ef.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220322085022_nvarcharFix2")]
    partial class nvarcharFix2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("vkaudioposter_ef.Model.FoundTracks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("MediaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Trackname")
                        .HasColumnType("text")
                        .HasComment("Fulltrackname");

                    b.HasKey("Id");

                    b.ToTable("FoundTracks");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.SpotyToVkShareBackendConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AntiCaptchaSecretKey")
                        .HasColumnType("text")
                        .HasComment("Anticaptcha secret key");

                    b.Property<decimal>("GroupIdSpotyShare")
                        .HasColumnType("numeric(20,0)")
                        .HasComment("VK community id");

                    b.Property<string>("KateMobileToken")
                        .HasColumnType("text")
                        .HasComment("Загрузка треков");

                    b.Property<string>("RollbarBackendToken")
                        .HasColumnType("text");

                    b.Property<string>("SpotifyClientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpotifyClientSecret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VKCommunityAccessTokenProd")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SpotyToVkShareBackendConfigs");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.SpotyVKUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("HasSubscription")
                        .HasColumnType("boolean");

                    b.Property<long>("VKID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SpotyVKUsers");
                });

            modelBuilder.Entity("vkaudioposter_ef.Model.VKAccounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasComment("Can user auth?");

                    b.Property<string>("VKLogin")
                        .HasColumnType("text");

                    b.Property<string>("VKPassword")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VKAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
