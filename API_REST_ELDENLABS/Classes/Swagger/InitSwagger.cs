using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API_REST_ELDENLABS.Classes.Swagger
{
    /// <summary>
    /// Clase para la configuración inicial del Swagger
    /// </summary>
    internal static class InitSwagger
    {
        /// <summary>
        /// Método para inicializar el swagger con ciertos párametros.
        /// </summary>
        /// <param name="_builder">Objeto de tipo WebApplicationBuilder.</param>
        internal static void ConfigureSwagger(WebApplicationBuilder _builder)
        {
            ParamsSwagger paramsSwagger = new();

            IServiceCollection services = _builder.Services;
            paramsSwagger.InitParamsSwagger(_builder);

            bool validations = ParamsSwagger.ValidParamsSwagger(paramsSwagger, services);

            if (validations)
            {
                if (paramsSwagger.EnableSwagger.ToLower().ToString() == "false")
                    return;

                services.AddSwaggerGen(
                    options =>
                    {
                        // Options Docs
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "API  - " + paramsSwagger.EnvironmentAPI,
                            Description = "Data CELSIA - ELDEN LABS",
                            TermsOfService = new Uri(paramsSwagger.URISwagger),
                            Contact = new OpenApiContact
                            {
                                Name = "CELSIA - ELDENLABS.",
                                Url = new Uri(paramsSwagger.URISwagger)
                            },
                            License = new OpenApiLicense
                            {
                                Name = "CELSIA License",
                                Url = new Uri(paramsSwagger.URISwagger)
                            }
                        });

                        options.IgnoreObsoleteActions();

                        options.ResolveConflictingActions(apiDescriptions => apiDescriptions.FirstOrDefault());

                        // XML Comentarios API.
                        string xmlFilenameApi = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                        // XML Comentarios Assembly Domain.
                        string xmlFilenameDomain = $"{Assembly.Load("API_REST_ELDENLABS_BL").GetName().Name!}.xml";

                        if (!string.IsNullOrEmpty(xmlFilenameApi) && !string.IsNullOrEmpty(xmlFilenameDomain))
                        {
                            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameApi));
                            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameDomain));
                        }
                    });
            }
        }


        /// <summary>
        /// Método para inicializar el swagger con ciertos párametros.
        /// </summary>
        /// <param name="_builder">Objeto de tipo WebApplicationBuilder.</param>
        /// <param name="_app">>Objeto de tipo WebApplication.</param>
        internal static void ConfigureSwaggerUI(WebApplicationBuilder _builder, WebApplication _app)
        {
            ParamsSwagger paramsSwagger = new();
            paramsSwagger.InitParamsSwagger(_builder);

            if (!string.IsNullOrEmpty(paramsSwagger.EnableSwagger) && !paramsSwagger.EnableSwagger.EndsWith("__"))
            {
                if (paramsSwagger.EnableSwagger.ToLower().ToString() == "false")
                    return;

                _app.UseSwagger();
                _app.UseSwaggerUI();
            }
        }

    }
}
