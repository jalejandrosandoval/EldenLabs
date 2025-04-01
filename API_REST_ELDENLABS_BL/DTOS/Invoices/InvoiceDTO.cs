using System.Runtime.Serialization;

namespace API_REST_ELDENLABS_BL.DTOS.Invoices
{
    /// <summary>
    /// DTO que permite representar como objetos las Facturas.
    /// </summary>
    [Serializable, DataContract]

    public class InvoiceDTO
    {
        /// <summary>
        /// Id de la Factura.
        /// </summary>
        [DataMember]
        public string ConnectionDeviceID { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del Hefesto
        /// </summary>
        [DataMember]
        public string Hefesto { get; set; } = string.Empty;

        /// <summary>
        /// Tiempo del Procesamiento.
        /// </summary>
        [DataMember]
        public DateTime EventProcessedUtcTime { get; set; }

        /// <summary>
        /// TimeStamp.
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Nombre de la Variables.
        /// </summary>
        public string Var_Name { get; set; } = string.Empty;

        /// <summary>
        /// Valor
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del Plugin.
        /// </summary>
        public string Plugin { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del Requests
        /// </summary>
        public string Request { get; set; } = string.Empty; 
        
        /// <summary>
        /// Nombre de la Variables 1.
        /// </summary>
        public string Var_Name1 { get; set; } = string.Empty;
        
        /// <summary>
        /// Nombre del Dispotivo.
        /// </summary>
        public string Device { get; set; } = string.Empty;
    }
}