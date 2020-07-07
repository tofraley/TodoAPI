namespace TodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Content { get; set; }
    }
}