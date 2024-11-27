using AppSellBook.Schema.Mutations;
using AppSellBook.Schema.Queries;
using AppSellBook.Schema.Subscriptions;
using AppSellBook.Services;
using AppSellBook.Services.Books;
using AppSellBook.Services.CartDetails;
using AppSellBook.Services.Categories;
using AppSellBook.Services.Commentations;
using AppSellBook.Services.Images;
using AppSellBook.Services.PasswordHashers;
using AppSellBook.Services.Roles;
using AppSellBook.Services.Users;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddGraphQLServer().AddQueryType<BookQuery>()
                                    .AddMutationType<BookMutation>()
                                    .AddSubscriptionType<BookSupscription>()
                                    .AddInMemorySubscriptions()
                                    .AddSorting();

//builder.Services.AddPooledDbContextFactory<BookDBContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("BookDBContext"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BookDBContext"))
//    )
//);
builder.Services.AddPooledDbContextFactory<BookDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookDBContext")).LogTo(Console.WriteLine));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        policy => policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());
});
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentationRepository, CommentationRepository>();  
builder.Services.AddScoped<ICartDetailRepository,CartDetailRepository>();
builder.Services.AddSingleton<IPasswordHashser, BcryptPasswordHasher>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleUserRepository, RoleUserRepository>();
builder.Services.AddScoped<BookQuery>(); 
builder.Services.AddScoped<CategoryQuery>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 44317); 
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UsePlayground();
}else
{
    // In production, you might want to show a generic error page.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Kích hoạt HTTP Strict Transport Security
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.MapControllers();
app.MapGraphQL("/graphql");
app.UsePlayground();
app.UseWebSockets();

app.Run();
