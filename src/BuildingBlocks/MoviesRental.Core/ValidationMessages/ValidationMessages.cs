using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.ValidationMessages
{
    public static class ValidationMessages
    {
        public const string MIN_LENGTH_ERROR_MESSAGE = "{PropertyName} deve ter pelo menos {MinLength} caracteres";
        public const string MAX_LENGTH_ERROR_MESSAGE = "{PropertyName} deve ter no máximo {ManLength} caracteres";
        public const string EMPTY_STRING_ERROR_MESSAGE = "{PropertyName} não pode ser vazia";
        public const string ERROR_MESSAGE = "{PropertyName} inválida";
    }
}
