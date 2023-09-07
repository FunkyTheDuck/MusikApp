﻿// <auto-generated />
using System;
using ApiDBAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiDBAccess.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiDTOModels.DtoArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistPaymentId")
                        .HasColumnType("int");

                    b.Property<string>("HighlightSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistPaymentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ApiDTOModels.DtoArtistPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ArtistPayments");
                });

            modelBuilder.Entity("ApiDTOModels.DtoBlackList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SongID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BlackLists");
                });

            modelBuilder.Entity("ApiDTOModels.DtoFriend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("ApiDTOModels.DtoPremium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("NextTransactionDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TransactionDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Premia");
                });

            modelBuilder.Entity("ApiDTOModels.DtoSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChangeGenre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("HowManyNotifications")
                        .HasColumnType("int");

                    b.Property<int>("HowNewTheMusicIs")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("ApiDTOModels.DtoSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlbumImage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<byte[]>("AudioExample")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("BlackListId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("WhiteListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("BlackListId");

                    b.HasIndex("WhiteListId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("ApiDTOModels.DtoUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlackListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsArtist")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProfilPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("WhiteListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlackListId");

                    b.HasIndex("WhiteListId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiDTOModels.DtoWhiteList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SongID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WhiteLists");
                });

            modelBuilder.Entity("ApiDTOModels.DtoArtist", b =>
                {
                    b.HasOne("ApiDTOModels.DtoArtistPayment", "ArtistPayment")
                        .WithMany("Artist")
                        .HasForeignKey("ArtistPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithOne("Artist")
                        .HasForeignKey("ApiDTOModels.DtoArtist", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtistPayment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoFriend", b =>
                {
                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoPremium", b =>
                {
                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithOne("Premium")
                        .HasForeignKey("ApiDTOModels.DtoPremium", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoSettings", b =>
                {
                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithOne("Settings")
                        .HasForeignKey("ApiDTOModels.DtoSettings", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoSong", b =>
                {
                    b.HasOne("ApiDTOModels.DtoArtist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDTOModels.DtoBlackList", "BlackList")
                        .WithMany("Songs")
                        .HasForeignKey("BlackListId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiDTOModels.DtoWhiteList", "WhiteList")
                        .WithMany("Songs")
                        .HasForeignKey("WhiteListId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("BlackList");

                    b.Navigation("WhiteList");
                });

            modelBuilder.Entity("ApiDTOModels.DtoUser", b =>
                {
                    b.HasOne("ApiDTOModels.DtoBlackList", "BlackList")
                        .WithMany("User")
                        .HasForeignKey("BlackListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiDTOModels.DtoWhiteList", "WhiteList")
                        .WithMany("User")
                        .HasForeignKey("WhiteListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlackList");

                    b.Navigation("WhiteList");
                });

            modelBuilder.Entity("ApiDTOModels.DtoArtist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("ApiDTOModels.DtoArtistPayment", b =>
                {
                    b.Navigation("Artist");
                });

            modelBuilder.Entity("ApiDTOModels.DtoBlackList", b =>
                {
                    b.Navigation("Songs");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoUser", b =>
                {
                    b.Navigation("Artist")
                        .IsRequired();

                    b.Navigation("Friends");

                    b.Navigation("Premium")
                        .IsRequired();

                    b.Navigation("Settings")
                        .IsRequired();
                });

            modelBuilder.Entity("ApiDTOModels.DtoWhiteList", b =>
                {
                    b.Navigation("Songs");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
