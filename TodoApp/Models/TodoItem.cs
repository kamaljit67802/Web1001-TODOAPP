namespace TodoApp.Models
{
    public class TodoItem
    {
        public int ID { get; set; } // A unique identifier for the TodoItem.

        public string? Title { get; set; } // The name or title of the TodoItem (can be null).

        public string? Description { get; set; } // Additional details about the TodoItem (can be null).

        public bool IsDone { get; set; } // Indicates whether the TodoItem has been completed (true) or is pending (false).
    }
}
