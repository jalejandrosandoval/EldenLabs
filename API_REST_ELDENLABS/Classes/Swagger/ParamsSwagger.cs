namespace API_REST_ELDENLABS.Classes.Swagger
{
    /// <summary>
    /// Clase que permite obtener los parametros principales para el Swagger.
    /// </summary>
    internal class ParamsSwagger
    {
        /// <summary>
        /// Ambiente del API.
        /// </summary>
        internal string EnvironmentAPI { get; set; } = string.Empty;

        /// <summary>
        /// Valor que corresponde a si se quiere o no activar el swagger de acuerdo al ambiente.
        /// </summary>
        internal string EnableSwagger { get; set; } = string.Empty;

        /// <summary>
        /// URL que aparecerá en las URI del SWAGGER como Terminos de Servicio, Información de Componente entre otros.
        /// </summary>
        internal string URISwagger { get; set; } = string.Empty;

        /// <summary>
        /// Método que permite inicializar los párametros transversales obteniendolos desde el AppSettings.json.
        /// </summary>
        /// <param name="_builder">Objeto de tipo WebApplicationBuilder..</param>
        internal void InitParamsSwagger(WebApplicationBuilder _builder)
        {
            if (_builder != null)
            {
                var _EnvironmentAPI = _builder.Configuration.GetSection("Environment").GetSection("EnvironmentAPI").Value;
                var _EnableSwagger = _builder.Configuration.GetSection("Swagger").GetSection("EnableSwagger").Value;
                var _URISwagger = _builder.Configuration.GetSection("Swagger").GetSection("URISwagger").Value;

                if (!string.IsNullOrEmpty(_EnvironmentAPI) && !string.IsNullOrEmpty(_EnableSwagger) &&
                    !string.IsNullOrEmpty(_URISwagger))
                {
                    EnvironmentAPI = _EnvironmentAPI;
                    EnableSwagger = _EnableSwagger;
                    URISwagger = _URISwagger;
                }
            }
        }

        /// <summary>
        /// Método que permite realizar validaciones a los párametros del SWAGGER.
        /// </summary>
        /// <param name="paramsSwagger">Objeto de tipo ParamsSwagger.</param>
        /// <param name="services">Objeto de tipo IServiceCollection.</param>
        /// <returns>Booleano que corresponde al estado de las validaciones.</returns>
        internal static bool ValidParamsSwagger(ParamsSwagger paramsSwagger, IServiceCollection services)
        {
            bool validations = false;

            if (!string.IsNullOrEmpty(paramsSwagger.EnableSwagger) && !string.IsNullOrEmpty(paramsSwagger.EnvironmentAPI) &&
               !string.IsNullOrEmpty(paramsSwagger.URISwagger) && services != null &&
               !paramsSwagger.EnableSwagger.EndsWith("__") && !paramsSwagger.EnvironmentAPI.EndsWith("__") &&
               !paramsSwagger.EnvironmentAPI.EndsWith("__"))
                validations = true;

            return validations;
        }
    }
}