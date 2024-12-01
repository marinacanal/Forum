using System.Text.RegularExpressions;

namespace Domain.Forum.ValueObjects {
    public class Email {
        public string Value { get; private set; }

        public Email(string value) {
            if (!Regex.IsMatch(value,@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")) 
                throw new ArgumentException("E-mail no formato inválido!");
            
            Value = value;
        }
    }
}