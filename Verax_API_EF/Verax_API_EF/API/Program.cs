using API_Services;
using DbContextLib;
using DbDataManager;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlite("Data Source=Entity_FrameWork.Article.db");
    
});
builder.Services.AddScoped<IArticleService, DbManagerArticle>();
builder.Services.AddScoped<IUserService, DbManagerUser>();
builder.Services.AddScoped<IFormulaireService, DbManagerFormulaire>();
builder.Services.AddScoped<IArticleUserService, DbManagerArticleUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using var scoped = app.Services.CreateScope();
var libraryContext = scoped.ServiceProvider.GetService<LibraryContext>();
//libraryContext.Database.EnsureCreated();
libraryContext.Database.Migrate();
app.Run();



