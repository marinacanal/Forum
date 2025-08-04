namespace Domain.Forum.ValueObjects
{   
    public class PostTitle
    {
        public string Value { get; private set; }

        public PostTitle(string value) => Value = value ?? throw new ArgumentNullException("Título não pode ser vazio!");

        public override string ToString() => Value;
    }
}