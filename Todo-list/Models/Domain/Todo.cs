//Property(used to access table entity framework core creates in database)
namespace Todo_list.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public DateTime Date { get; set; }
        public Boolean Complete { get; set; }
        public string Description { get; set; }
    }
}
