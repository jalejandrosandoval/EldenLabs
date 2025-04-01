using API_REST_ELDENLABS.Classes.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// SWAGGER CONFIG
InitSwagger.ConfigureSwagger(builder);

var app = builder.Build();

// SWAGGER CONFIG UI
InitSwagger.ConfigureSwaggerUI(builder, app);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();