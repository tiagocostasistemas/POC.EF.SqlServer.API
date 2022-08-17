namespace POC.EF.SqlServer.API.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseAll(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("all");
        app.UseHttpsRedirection();
        app.UseAuthorization();

        return app;
    }
}
