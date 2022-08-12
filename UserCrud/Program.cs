global using UserCrud.Data;
global using Microsoft.EntityFrameworkCore;
using UserCrud.Services.Users;


var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddCors(options => 
    {
        options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });

    builder.Services.AddControllers();

    builder.Services.AddDbContext<UserContext>(options =>
    {
        options.UseSqlite("Data Source=users.db");
    });

    builder.Services.AddScoped<IUserService, UserService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors(MyAllowSpecificOrigins);
    // app.UseAuthorization();


    app.MapControllers();

    app.Run();
}
