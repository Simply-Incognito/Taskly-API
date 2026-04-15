namespace Taskly.Models
{
    public class TaskItem
    {
        public int Id { get; set; } = default;
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = default;

        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
