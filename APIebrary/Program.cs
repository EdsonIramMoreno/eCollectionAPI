using API.Application;
using Core.Interfaces.Category;
using Core.Interfaces.Collection;
using Core.Interfaces.Item.ItemInfo;
using Core.Interfaces.Item.ItemPhoto;
using Core.Interfaces.rel_Category_Collection;
using Core.Interfaces.User;
using Infrastructure.Data;
using Infrastructure.Repositories.Category;
using Infrastructure.Repositories.Collection;
using Infrastructure.Repositories.Item;
using Infrastructure.Repositories.rel_Category_Collection;
using Infrastructure.Repositories.User;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Interfaces Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

//Interfaces User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

//Interfaces Collection
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<ICollectionServices, CollectionServices>();

//Interfaces Item
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemServices, ItemServices>();

//Interfaces Item
builder.Services.AddScoped<IItemPhotoRepository, ItemPhotoRepository>();
builder.Services.AddScoped<IItemPhotoServices, ItemPhotoServices>();

//Interfaces Rel_Cat_Collection
builder.Services.AddScoped<ICat_CollectionRepository, Cat_CollectionRepository>();
builder.Services.AddScoped<ICat_CollectionServices, Cat_CollectionServices>();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseSession();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();