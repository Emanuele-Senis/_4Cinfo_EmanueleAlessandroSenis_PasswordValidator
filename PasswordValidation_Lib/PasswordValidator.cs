using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordValidation_Lib
{
    /// <summary>
    /// Autore: Emanuele Alessandro Senis
    /// ITIS E. Majorana di Grugliasco
    /// Data: 6 febbraio 2023
    /// Progetto: validazione password su c# + GUI per mostrarne l'utilizzo
    /// </summary>
    public class PasswordValidator
    {
        //attributes
        private readonly string _password;
        
        public event Action OnPasswordValidated;
        public event Action OnPasswordInvalid;

        protected int _minLength, _maxLength;

        public List<string> WarningsList { get; protected set; }
        public PasswordValidator(string password = "", int minLength = 8, int maxLength = 14)
        {
            _password = password;
            WarningsList = new List<string>();
            _minLength = minLength;
            _maxLength = maxLength;
        }
        public void Validate()
        {
            bool isValid = !string.IsNullOrWhiteSpace(_password) &&
                    IsLengthValid() &&
                    ContainsAnyUpperCaseChar() &&
                    ContainsAnyLowerCaseChar() &&
                    !ContainsWhiteSpaces() &&
                    ContainsAnySpecialChar();
            if (isValid)
            {
                OnPasswordValidated?.Invoke();
            }
            else
            {
                OnPasswordInvalid?.Invoke();
            }
        }
        public bool IsLengthValid()
        {
            bool isLengthValid = _password.Length >= _minLength && _password.Length <= _maxLength;
            if (isLengthValid == false)
            {
                WarningsList.Add($"the length of the password must be between {_minLength} and {_maxLength} characters");
            }
            return isLengthValid;
        }

        public bool ContainsAnyUpperCaseChar()
        {
            bool containsAnyUpperCaseChar = _password.Any(char.IsUpper);
            if (containsAnyUpperCaseChar == false)
            {
                WarningsList.Add("the password must contain at least one uppercase character");
            }
            return containsAnyUpperCaseChar;
        }

        public bool ContainsAnyLowerCaseChar()
        {
            bool containsAnyLowerCaseChar = _password.Any(char.IsLower);
            if (containsAnyLowerCaseChar == false)
            {
                WarningsList.Add("the password must contain at least one lowercase character");
            }
            return containsAnyLowerCaseChar;
        }

        public bool ContainsWhiteSpaces()
        {
            bool containsWhiteSpaces = _password.Contains(' ');
            if (containsWhiteSpaces)
            {
                WarningsList.Add("the password mustn't contain any white spaces");
            }
            return containsWhiteSpaces;
        }

        public bool ContainsAnySpecialChar()
        {
            char[] chars = _password.ToCharArray();
            foreach (char c in chars)
            {
                if ((c >= 32 && c <= 47) || (c >= 58 && c <= 64) || (c >= 91 && c <= 96) || (c >= 123 && c <= 126))
                {
                    return true;
                }
            }
            WarningsList.Add("password must contain at least one special character");
            return false;
        }
    }
}
