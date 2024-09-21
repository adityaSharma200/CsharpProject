////var builder = WebApplication.CreateBuilder(args);

////// Define CORS policy name
////var apiCorsPolicy = "ApiCorsPolicy";

////// Configure CORS policy
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy(name: apiCorsPolicy,
////        builder =>
////        {
////            builder.WithOrigins("https://localhost:44321") // Replace with your client's URL
////                   .AllowAnyHeader()
////                   .AllowAnyMethod();
////        });
////});

////builder.Services.AddControllers();

////// Configure Swagger/OpenAPI
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var app = builder.Build();

////// Configure the HTTP request pipeline
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////app.UseStaticFiles();

////app.UseRouting();

////app.UseCors(apiCorsPolicy); // Apply CORS policy

////app.UseAuthorization();

////app.MapControllers();

////app.Run();

//var builder = WebApplication.CreateBuilder(args);
//var apiCorsPolicy = "ApiCorsPolicy";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name:apiCorsPolicy,
//        builder =>
//        {
//            builder.WithOrigins("*") // Your client app's URL
//                   .AllowAnyHeader()
//                   .AllowAnyMethod()
//                   .SetIsOriginAllowed(origin => true);

//        });
//});
//builder.Services.AddControllers();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();
//app.UseCors(apiCorsPolicy);
//// Apply CORS policy
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Product}/{action=Index}/{id?}");
//});
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
var builder = WebApplication.CreateBuilder(args);

// Define the CORS policy name
var apiCorsPolicy = "ApiCorsPolicy";

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: apiCorsPolicy,
        builder =>
        {
            builder.WithOrigins("https://localhost:44321") // Replace with your client's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ensure CORS middleware is used
app.UseCors(apiCorsPolicy); // Apply the CORS policy here

app.UseAuthorization();

app.MapControllers();

app.Run();
