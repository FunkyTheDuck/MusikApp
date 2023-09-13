﻿// <auto-generated />
using System;
using ApiDBAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiDBAccess.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20230912084505_musikdatabase")]
    partial class musikdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ArtistPaymentId")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            EndDate = new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4814),
                            StartDate = new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4758)
                        });
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

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("BlackLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SongID = "7xapw9Oy21WpfEcib2ErSA",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            SongID = "7xapw9Oy21WpfEcib2ErSA",
                            UserID = 2
                        },
                        new
                        {
                            Id = 3,
                            SongID = "7xapw9Oy21WpfEcib2ErSA",
                            UserID = 3
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FriendId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            FriendId = 3,
                            UserId = 2
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NextTransactionDay = new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4892),
                            TransactionDay = new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4894),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            NextTransactionDay = new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4896),
                            TransactionDay = new DateTime(2023, 9, 12, 10, 45, 4, 904, DateTimeKind.Local).AddTicks(4898),
                            UserId = 2
                        });
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

                    b.Property<int>("Danceability")
                        .HasColumnType("int");

                    b.Property<int>("Energy")
                        .HasColumnType("int");

                    b.Property<int>("HowNewTheMusicIs")
                        .HasColumnType("int");

                    b.Property<int>("NotificationsAmount")
                        .HasColumnType("int");

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChangeGenre = "k-pop",
                            Danceability = 0,
                            Energy = 0,
                            HowNewTheMusicIs = 10,
                            NotificationsAmount = 5,
                            Popularity = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ChangeGenre = "rock",
                            Danceability = 0,
                            Energy = 0,
                            HowNewTheMusicIs = 5,
                            NotificationsAmount = 3,
                            Popularity = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            ChangeGenre = "pop",
                            Danceability = 0,
                            Energy = 0,
                            HowNewTheMusicIs = 20,
                            NotificationsAmount = 8,
                            Popularity = 0,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("ApiDTOModels.DtoUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsArtist = true,
                            IsPremium = true,
                            LastName = "Bieber",
                            Mail = "justinbieber@hotmail.com",
                            Name = "Justin",
                            Password = "Bruger123",
                            ProfilPicture = "Billede",
                            UserName = "JustinB"
                        },
                        new
                        {
                            Id = 2,
                            IsArtist = false,
                            IsPremium = true,
                            LastName = "Wayne",
                            Mail = "batmanerbest@gmail.com",
                            Name = "Bruce",
                            Password = "Beuger123",
                            ProfilPicture = "Billede1",
                            UserName = "Batman"
                        },
                        new
                        {
                            Id = 3,
                            IsArtist = false,
                            IsPremium = false,
                            LastName = "Kent",
                            Mail = "ilovelois@gmail.com",
                            Name = "Clark",
                            Password = "Bruger123",
                            ProfilPicture = "Billede2",
                            UserName = "Superman"
                        });
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

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("WhiteLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SongID = "6habFhsOp2NvshLv26DqMb",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            SongID = "6habFhsOp2NvshLv26DqMb",
                            UserID = 2
                        },
                        new
                        {
                            Id = 3,
                            SongID = "6habFhsOp2NvshLv26DqMb",
                            UserID = 3
                        });
                });

            modelBuilder.Entity("ApiDTOModels.DtoArtist", b =>
                {
                    b.HasOne("ApiDTOModels.DtoArtistPayment", "ArtistPayment")
                        .WithMany("Artist")
                        .HasForeignKey("ArtistPaymentId");

                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithOne("Artist")
                        .HasForeignKey("ApiDTOModels.DtoArtist", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtistPayment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoBlackList", b =>
                {
                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithOne("BlackList")
                        .HasForeignKey("ApiDTOModels.DtoBlackList", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("ApiDTOModels.DtoWhiteList", b =>
                {
                    b.HasOne("ApiDTOModels.DtoUser", "User")
                        .WithOne("WhiteList")
                        .HasForeignKey("ApiDTOModels.DtoWhiteList", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiDTOModels.DtoArtistPayment", b =>
                {
                    b.Navigation("Artist");
                });

            modelBuilder.Entity("ApiDTOModels.DtoUser", b =>
                {
                    b.Navigation("Artist")
                        .IsRequired();

                    b.Navigation("BlackList")
                        .IsRequired();

                    b.Navigation("Friends");

                    b.Navigation("Premium")
                        .IsRequired();

                    b.Navigation("Settings")
                        .IsRequired();

                    b.Navigation("WhiteList")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}