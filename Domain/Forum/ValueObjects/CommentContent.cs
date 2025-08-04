namespace Domain.Forum.ValueObjects
{
    public class CommentContent
    {
        public string Value { get; private set; }

        public CommentContent(string value) {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Conteúdo não pode ser vazio!");

            if(value.Length > 3000) 
                throw new ArgumentException("Conteúdo não pode ter mais que 3000 caracteres!");

            Value = value;
        }
    }
}