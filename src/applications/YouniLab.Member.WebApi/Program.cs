using YouniLab.Member.Application.AppServices;
using YouniLab.Member.Application.Configs;
using YouniLab.Member.Application.IoC;
using YouniLab.Member.Application.Serialization;
using YouniLab.Member.Database;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContexts(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddConfig(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddRouting();
builder.Services.AddAppServices();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

app.UseCors();
app.UseRouting();
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
});
app.MapGet("/", () => "Hello World!");

app.MapGet("/member/{id}", async (Guid id, MemberAppService memberAppService) => await memberAppService.GetMemberAsync(id));

app.Run();