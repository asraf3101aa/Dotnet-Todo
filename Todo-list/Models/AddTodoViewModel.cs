namespace Todo_list.Models
{
    public class AddTodoViewModel
    {
        public string Task { get; set; }
        public DateOnly Date { get; set; }
        public Boolean Complete { get; set; }
        public string Description { get; set; }
    }
}
