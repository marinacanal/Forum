namespace Domain.Forum.ValueObjects
{
    public class PostContent
    {
        public string Value { get; private set; }

        public PostContent(string value) {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Conteúdo não pode ser vazio!");

            if(value.Length > 5000) 
                throw new ArgumentException("Conteúdo não pode ter mais que 5000 caracteres!");

            Value = value;
        }

        public override string ToString() => Value;
    }
}