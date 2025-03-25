using Microsoft.EntityFrameworkCore;
using NguyenDanhHungRazorPages.Models;
using NguyenDanhHungRazorPages.Repositories;
using NguyenDanhHungRazorPages.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FunewsManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FUNewsDB")));

// Configure AdminAccountSettings from appsettings.json
//builder.Services.Configure<AdminAccountSettings>(builder.Configuration.GetSection("AdminAccount"));
// Add services to the container.
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSignalR();
builder.Services.Configure<AdminAccountSettings>(builder.Configuration.GetSection("AdminAccount"));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddSignalR();
builder.Services.AddRazorPages();
builder.Services.AddSession(); // Thêm dịch vụ Session
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages(); // Đảm bảo có dòng này
});
app.UseAuthorization();
app.MapHub<CommentHub>("/commentHub");
app.MapRazorPages();

app.Run();
