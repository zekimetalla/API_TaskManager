using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsComplete { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum Priority
    {
        Low, Medium, High
    }
}
