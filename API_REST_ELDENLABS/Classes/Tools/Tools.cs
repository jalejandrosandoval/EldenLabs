namespace API_REST_ELDENLABS.Classes.Tools
{
    /// <summary>
    /// Clase que permite tener ciertas Herramientas durante la ejecución de la Aplicación.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Método que permite conocer si un string es un número entero.
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        public static bool IsNumericByString(this string _string)
        {
            bool isNumber = int.TryParse(_string, out _);
            return isNumber;
        }

        /// <summary>
        /// Método que permite conocer si un string contiene caracteres especiales.
        /// </summary>
        /// <param name="input">Input string to sanitize.</param>
        /// <returns>Sanitized string.</returns>
        public static bool ContainsSpecialChars(this string? input)
        {
            char[] specialChars = { '%', '$', '!', '?', '/', '>', '<' };

            foreach (char item in specialChars)
                if (input!.Contains(item))
                    return true;

            return false;
        }
    }
}