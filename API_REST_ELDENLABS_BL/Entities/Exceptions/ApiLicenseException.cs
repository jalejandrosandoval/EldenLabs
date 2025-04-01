using API_REST_ELDENLABS_BL.Models.Execptions;

namespace API_REST_ELDENLABS_BL.Entities.Exceptions
{
    /// <summary>
    /// Clase que representa una excepción que se lanza cuando la respuesta de los Métodos no es la esperada.
    /// </summary>
    public class ApiRestException : Exception
    {
        /// <summary>
        /// Objeto de Tipo MessageExceptions. 
        /// </summary>
        public MessageExceptionsModel MessageException { get; set; } = new();

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de los Métodos no es la esperada.
        /// </summary>
        public ApiRestException() : base() { }

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de los Métodos no es la esperada.
        /// </summary>
        /// <param name="message">String que corresponde al mensaje de la excepción que se desea lanzar.</param>
        public ApiRestException(string? message) : base(message) { }

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de la API a consumir no es la esperada o adecuada.
        /// </summary>
        /// <param name="_messageExceptions">Objeto de tipo MessageExceptionsModel.</param>
        public ApiRestException(MessageExceptionsModel _messageExceptions) : base() { MessageException = _messageExceptions; }

        /// <summary>
        /// Método Constructor que inicializa una excepción que se lanza cuando la respuesta de la API a consumir no es la esperada o adecuada.
        /// </summary>
        /// <param name="innerException">Objeto de Tipo Exception que corresponde a la excepción que causo la actual excepción.</param>
        public ApiRestException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}
