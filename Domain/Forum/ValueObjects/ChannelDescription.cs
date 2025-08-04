namespace Domain.Forum.ValueObjects
{
    public class ChannelDescription
    {
        public string Value { get; private set; }

        public ChannelDescription(string value) {
            if(value.Length > 3000) 
                throw new ArgumentException("Descrição não pode ter mais que 3000 caracteres!");          

            Value = value;
        }
    }
}