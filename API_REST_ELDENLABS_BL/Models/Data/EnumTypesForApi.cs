namespace API_REST_ELDENLABS_BL.Models.Data
{
    /// <summary>
    /// Modelo para los diferentes tipos de Métodos para acceder a la Data.
    /// </summary>
    public class EnumTypesForApi
    {
        /// <summary>
        /// Lista Enumerada para establecer los tipos de las Acciones para acceder a la Data.
        /// </summary>
        public enum EnumActions
        {
            /// <summary>
            /// Acciones de Tipo de Facturas.
            /// </summary>
            InvoicesActions
        }

        /// <summary>
        /// Lista Enumerada para establecer los diferentes nombre de las Acicones para acceder a la Data.
        /// </summary>
        public enum EnumActionsDetails
        {
            /// <summary>
            /// Método para obtener las facturas.
            /// </summary>
            GetInvoicesSP,

            /// <summary>
            /// Método que permite obtener los detalles con Parámetros de las Facturas.
            /// </summary>
            GetInvoicesByParamsSP
        }
    }
}