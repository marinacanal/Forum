namespace Domain.UserManagement.ValueObjects
{
    public class Username
    {
        public string Value { get; private set; }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username não pode ser vazio!");

            Value = value;
        }
    }
}
