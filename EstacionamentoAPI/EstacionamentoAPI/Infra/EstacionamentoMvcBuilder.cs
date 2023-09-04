using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Infra
{
    public static class EstacionamentoMvcBuilder
    {
        public static IMvcBuilder ConfigureEstacionamentoApiBehavior(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(setup =>
            {
                setup.InvalidModelStateResponseFactory = c =>
                {
                    var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
                                                    .SelectMany(v => v.Errors)
                                                    .Select(v => v.ErrorMessage);
                    return new BadRequestObjectResult(errors);
                };
            });
            builder.AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
            return builder;
        }
    }
}