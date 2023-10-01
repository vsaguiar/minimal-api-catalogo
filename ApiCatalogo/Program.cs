using ApiCatalogo.ApiEndpoints;
using ApiCatalogo.AppServicesExtensions;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

var app = builder.Build();

#region ENDPOINTS
app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();
#endregion

var environment = app.Environment;
app.UseExceptionHandling(environment).UseSwaggerMiddleware().UseAppCors();


app.UseAuthentication();
app.UseAuthorization();


app.Run();
