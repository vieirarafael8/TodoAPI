namespace DevotugasDaStreet.TodoTodo.Models
{
    public class TodoViewModel
    {
        string title {get; set; }
        string description {get; set; }
        
        Status status {get; set; }

        DateTime createdAt {get; set; }

        DateTime updatedAt {get; set; }
    }
}