#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevotugasDaStreet.TodoTodo.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "nvarchar(20)")]
        public string Title {get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Description {get; set; }

        [DefaultValue(Status.pending)]
        public Status Status {get; set; }

        public DateTime createdAt {get; set; }

        public DateTime updatedAt {get; set; }
    }
}