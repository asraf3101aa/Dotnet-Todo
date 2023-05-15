namespace Todo_list.Models
{
    public class UpdateTodoViewModel
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public DateOnly Date { get; set; }
        public Boolean Complete { get; set; }
        public string Description { get; set; }
    }
}
