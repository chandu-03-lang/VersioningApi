using Asp.Versioning;
using Asp.Versioning.Conventions;
using VersioningApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//url segment http://localhost/api/v1.0/customers
// query string  xxxxxxx ?v=1.0

builder.Services.AddApiVersioning(setupAction =>
{
    //major version and minor version  and builder number and revision number 
    // 4.0.30319  here major version is 4 minor version is 0 and revision number is 30319 is builde revision
    setupAction.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    setupAction.AssumeDefaultVersionWhenUnspecified = true; // when version is not specified use default version
    setupAction.ReportApiVersions = true; // tells clients the available versions
    setupAction.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("v"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("X-Version"));
})

    .AddMvc(options => {
        //options.Conventions.Controller<HomeController>()
        //.Action<HomeController>(c=>c.GetGreting())
        //.Action<HomeController>(c=>c.GetToday())
         

        })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
