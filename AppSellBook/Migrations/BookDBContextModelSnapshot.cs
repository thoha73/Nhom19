﻿// <auto-generated />
using System;
using AppSellBook.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppSellBook.Migrations
{
    [DbContext(typeof(BookDBContext))]
    partial class BookDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppSellBook.Entities.Author", b =>
                {
                    b.Property<int>("authorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("authorId"));

                    b.Property<string>("authorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("authorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("AppSellBook.Entities.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookId"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("authorId")
                        .HasColumnType("int");

                    b.Property<string>("bookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("listedPrice")
                        .HasColumnType("float");

                    b.Property<string>("publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("rank")
                        .HasColumnType("float");

                    b.Property<double>("sellPrice")
                        .HasColumnType("float");

                    b.HasKey("bookId");

                    b.HasIndex("authorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("AppSellBook.Entities.BookCategory", b =>
                {
                    b.Property<int>("booksbookId")
                        .HasColumnType("int");

                    b.Property<int>("categoriescategoryId")
                        .HasColumnType("int");

                    b.HasKey("booksbookId", "categoriescategoryId");

                    b.HasIndex("categoriescategoryId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("AppSellBook.Entities.BookWishList", b =>
                {
                    b.Property<int>("booksbookId")
                        .HasColumnType("int");

                    b.Property<int>("wishListswishListId")
                        .HasColumnType("int");

                    b.HasKey("booksbookId", "wishListswishListId");

                    b.HasIndex("wishListswishListId");

                    b.ToTable("BookWishList");
                });

            modelBuilder.Entity("AppSellBook.Entities.Cart", b =>
                {
                    b.Property<int>("cartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cartId"));

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("deliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("purchaseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("cartId");

                    b.HasIndex("userId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("AppSellBook.Entities.CartDetail", b =>
                {
                    b.Property<int>("cartDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cartDetailId"));

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<bool>("isSelected")
                        .HasColumnType("bit");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("sellPrice")
                        .HasColumnType("float");

                    b.HasKey("cartDetailId");

                    b.HasIndex("bookId");

                    b.HasIndex("cartId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("AppSellBook.Entities.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"));

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AppSellBook.Entities.Commentation", b =>
                {
                    b.Property<int>("commentationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentationId"));

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ranK")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("commentationId");

                    b.HasIndex("bookId");

                    b.HasIndex("userId");

                    b.ToTable("Commentations");
                });

            modelBuilder.Entity("AppSellBook.Entities.Image", b =>
                {
                    b.Property<int>("imageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("imageId"));

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<bool>("icon")
                        .HasColumnType("bit");

                    b.Property<byte[]>("imageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("imageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imageId");

                    b.HasIndex("bookId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AppSellBook.Entities.Notification", b =>
                {
                    b.Property<int>("notificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("notificationId"));

                    b.Property<string>("context")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRead")
                        .HasColumnType("bit");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("notificationId");

                    b.HasIndex("userId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("AppSellBook.Entities.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"));

                    b.Property<string>("deliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("deliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("orderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("purchaseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalMoney")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AppSellBook.Entities.OrderDetail", b =>
                {
                    b.Property<int>("orderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderDetailId"));

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("sellPrice")
                        .HasColumnType("float");

                    b.HasKey("orderDetailId");

                    b.HasIndex("bookId");

                    b.HasIndex("orderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("AppSellBook.Entities.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"));

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AppSellBook.Entities.RoleUser", b =>
                {
                    b.Property<int>("usersuserId")
                        .HasColumnType("int");

                    b.Property<int>("rolesroleId")
                        .HasColumnType("int");

                    b.HasKey("usersuserId", "rolesroleId");

                    b.HasIndex("rolesroleId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("AppSellBook.Entities.Student", b =>
                {
                    b.Property<string>("studentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("AppSellBook.Entities.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<DateTime?>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("deliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isBlock")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("point")
                        .HasColumnType("int");

                    b.Property<string>("purchaseAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppSellBook.Entities.WishList", b =>
                {
                    b.Property<int>("wishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("wishListId"));

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("wishListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("wishListId");

                    b.HasIndex("userId");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("AppSellBook.Entities.Book", b =>
                {
                    b.HasOne("AppSellBook.Entities.Author", "author")
                        .WithMany("books")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");
                });

            modelBuilder.Entity("AppSellBook.Entities.BookCategory", b =>
                {
                    b.HasOne("AppSellBook.Entities.Book", "book")
                        .WithMany("bookCategories")
                        .HasForeignKey("booksbookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSellBook.Entities.Category", "category")
                        .WithMany("bookCategories")
                        .HasForeignKey("categoriescategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("category");
                });

            modelBuilder.Entity("AppSellBook.Entities.BookWishList", b =>
                {
                    b.HasOne("AppSellBook.Entities.Book", "book")
                        .WithMany("bookWishLists")
                        .HasForeignKey("booksbookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSellBook.Entities.WishList", "wishList")
                        .WithMany("bookWishLists")
                        .HasForeignKey("wishListswishListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("wishList");
                });

            modelBuilder.Entity("AppSellBook.Entities.Cart", b =>
                {
                    b.HasOne("AppSellBook.Entities.User", "user")
                        .WithMany("carts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AppSellBook.Entities.CartDetail", b =>
                {
                    b.HasOne("AppSellBook.Entities.Book", "book")
                        .WithMany("cartDetails")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSellBook.Entities.Cart", "cart")
                        .WithMany("cartDetails")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("cart");
                });

            modelBuilder.Entity("AppSellBook.Entities.Commentation", b =>
                {
                    b.HasOne("AppSellBook.Entities.Book", "book")
                        .WithMany("commentations")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSellBook.Entities.User", "user")
                        .WithMany("commentations")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("user");
                });

            modelBuilder.Entity("AppSellBook.Entities.Image", b =>
                {
                    b.HasOne("AppSellBook.Entities.Book", "book")
                        .WithMany("images")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");
                });

            modelBuilder.Entity("AppSellBook.Entities.Notification", b =>
                {
                    b.HasOne("AppSellBook.Entities.User", "user")
                        .WithMany("notifications")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("user");
                });

            modelBuilder.Entity("AppSellBook.Entities.Order", b =>
                {
                    b.HasOne("AppSellBook.Entities.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AppSellBook.Entities.OrderDetail", b =>
                {
                    b.HasOne("AppSellBook.Entities.Book", "book")
                        .WithMany("orderDetails")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSellBook.Entities.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("order");
                });

            modelBuilder.Entity("AppSellBook.Entities.RoleUser", b =>
                {
                    b.HasOne("AppSellBook.Entities.Role", "Role")
                        .WithMany("roleUsers")
                        .HasForeignKey("rolesroleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSellBook.Entities.User", "User")
                        .WithMany("roleUsers")
                        .HasForeignKey("usersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppSellBook.Entities.WishList", b =>
                {
                    b.HasOne("AppSellBook.Entities.User", "user")
                        .WithMany("wishLists")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AppSellBook.Entities.Author", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("AppSellBook.Entities.Book", b =>
                {
                    b.Navigation("bookCategories");

                    b.Navigation("bookWishLists");

                    b.Navigation("cartDetails");

                    b.Navigation("commentations");

                    b.Navigation("images");

                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("AppSellBook.Entities.Cart", b =>
                {
                    b.Navigation("cartDetails");
                });

            modelBuilder.Entity("AppSellBook.Entities.Category", b =>
                {
                    b.Navigation("bookCategories");
                });

            modelBuilder.Entity("AppSellBook.Entities.Order", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("AppSellBook.Entities.Role", b =>
                {
                    b.Navigation("roleUsers");
                });

            modelBuilder.Entity("AppSellBook.Entities.User", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("commentations");

                    b.Navigation("notifications");

                    b.Navigation("orders");

                    b.Navigation("roleUsers");

                    b.Navigation("wishLists");
                });

            modelBuilder.Entity("AppSellBook.Entities.WishList", b =>
                {
                    b.Navigation("bookWishLists");
                });
#pragma warning restore 612, 618
        }
    }
}
