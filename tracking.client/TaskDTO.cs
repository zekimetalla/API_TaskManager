using System.ComponentModel.DataAnnotations;

namespace tracking.client
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum Priority
    {
        Low, Medium, High
    }
}