namespace Todo.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public DateOnly Date { get; set; }
        public Boolean Complete { get; set; }
        public string Description { get; set; }
    }
}
