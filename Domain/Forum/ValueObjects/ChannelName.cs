namespace Domain.Forum.ValueObjects
{
    public class ChannelName
    {
        public string Value { get; private set; }

        public ChannelName(string value) {
            if(value.Length > 50) 
                throw new ArgumentException("Conteúdo não pode ter mais que 50 caracteres!");
            
            if(string.IsNullOrWhiteSpace(value))
                value = "[Sem nome]";          

            Value = value;
        }
    }
}