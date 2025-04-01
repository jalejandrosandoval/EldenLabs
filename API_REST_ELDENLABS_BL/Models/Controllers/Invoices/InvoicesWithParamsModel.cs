namespace API_REST_ELDENLABS_BL.Models.Controllers.Invoices
{
    /// <summary>
    /// Modelo de parámetros de las Facturas.
    /// </summary>
    public class InvoicesWithParamsModel
    {
        /// <summary>
        /// Identificador del Cliente.
        /// </summary>
        public string IdClient { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del Cliente.
        /// </summary>
        public string FullNameClient { get; set; } = string.Empty;

        /// <summary>
        /// Tipo del Cliente.
        /// </summary>
        public string ClientType { get; set; } = string.Empty;
    }
}
