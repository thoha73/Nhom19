using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Commentation> Commentations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.book)
                .WithMany(b => b.images)
                .HasForeignKey(i => i.bookId);

            modelBuilder.Entity<Image>()
                .Property(i => i.imageData)
                .HasDefaultValue(null); // Set imageData to null by default (if nullable)

            modelBuilder.Entity<Image>()
                .Property(i => i.bookId)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.books)
                .WithMany(b => b.categories);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.categories)
                .WithMany(c => c.books)
                .UsingEntity(j => j.ToTable("BookCategory"));   
            modelBuilder.Entity<Book>()
                .HasMany(i=>i.images)
                .WithOne(f => f.book)
                .HasForeignKey(f=>f.bookId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>()
                .HasMany(d => d.cartDetails)
                .WithOne(cd => cd.book)
                .HasForeignKey(cd=>cd.bookId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>()
                .HasMany(d=>d.orderDetails)
                .WithOne(i => i.book)
                .HasForeignKey(i=>i.bookId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>()
                .HasMany(c=>c.commentations)
                .WithOne(b=>b.book)
                .HasForeignKey(c=>c.bookId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>()
                .HasMany(w => w.wishLists)
                .WithMany(b => b.books)
                .UsingEntity(j => j.ToTable("BookWishList"));

            modelBuilder.Entity<Book>()
                .HasOne(a => a.author)
                .WithMany(b => b.books)
                .HasForeignKey(a => a.authorId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<WishList>()
                .HasOne(u=>u.user)
                .WithMany(w => w.wishLists)
                .HasForeignKey(uf=>uf.userId);
            modelBuilder.Entity<Commentation>()
                .HasOne(b => b.book)
                .WithMany(c => c.commentations);

            modelBuilder.Entity<Cart>()
                .HasOne(u => u.user)
                .WithMany(c => c.carts)
                .HasForeignKey(u=>u.userId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cart>()
                .HasMany(cd => cd.cartDetails)
                .WithOne(c => c.cart)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(u => u.user)
                .WithMany(o => o.orders)
                .HasForeignKey(u => u.userId);
            modelBuilder.Entity<Order>()
                .HasMany(od => od.orderDetails)
                .WithOne(o => o.order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(c=>c.commentations)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(c => c.wishLists)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(c=>c.carts)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(c => c.orders)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(c => c.roles)
                .WithMany(r => r.users)
                .UsingEntity(j => j.ToTable("RoleUser"));
            modelBuilder.Entity<CartDetail>()
                .HasOne(cd => cd.cart)
                .WithMany(c => c.cartDetails)
                .HasForeignKey(cd => cd.cartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(u => u.users)
                .WithMany(r => r.roles);
                
        }

    }
}
