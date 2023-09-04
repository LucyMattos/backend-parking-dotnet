using Newtonsoft.Json;
using System.Text;

namespace EstacionamentoAPI.Infra
{
    public class EstacionamentoApiKeyMiddleware
    {
        private readonly IConfiguration configuration;
        private readonly RequestDelegate next;

        public EstacionamentoApiKeyMiddleware(IConfiguration configuration, RequestDelegate next)
        {
            this.configuration = configuration;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers["ApiKey"].FirstOrDefault() == configuration["EstacionamentoApiKey"] || context.Request.Method == HttpMethods.Options)
            {
                await next(context);
                return;
            }
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            var result = new
            {
                statusCode = 401,
                message = "Não autorizado. Chave inválida."
            };
            context.Response.Clear();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            var bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(result));
            await originalBodyStream.WriteAsync(bytes, 0, bytes.Length);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
    public static class EstacionamentoApiAuthorization
    {
        public static IApplicationBuilder UseEstacionamentoApiKey(this IApplicationBuilder app)
        {
            return app.UseMiddleware<EstacionamentoApiKeyMiddleware>();
        }
    }
}
