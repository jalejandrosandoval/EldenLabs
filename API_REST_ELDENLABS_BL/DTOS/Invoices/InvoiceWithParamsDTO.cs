using System.Runtime.Serialization;

namespace API_REST_ELDENLABS_BL.DTOS.Invoices
{
    /// <summary>
    /// DTO que permite representar como objetos las Facturas con ciertos Parámetros.
    /// </summary>
    [Serializable, DataContract]

    public class InvoiceWithParamsDTO : InvoiceDTO
    {
        /// <summary>
        /// Nombre del Cliente.
        /// </summary>
        [DataMember]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de Cliente.
        /// </summary>
        [DataMember]
        public string ClientType { get; set; } = string.Empty;
    }
}