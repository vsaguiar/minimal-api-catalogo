namespace ApiCatalogo.AppServicesExtensions;

public static class ApplicationBuilderExtensions
{
    // Tratando exceção com base no ambiente 
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        return app;
    }

    // Habilitando CORS
    public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
    {
        app.UseCors(p =>
        {
            p.AllowAnyOrigin();
            p.WithMethods("GET");
            p.AllowAnyHeader();
        });
        return app;
    }

    // Habilitando Swagger
    public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { });
        return app;
    }
}
