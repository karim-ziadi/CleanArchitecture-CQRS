namespace Domain.Todos
{
    //core busness model
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public bool Completed { get; set; }
    }
}
