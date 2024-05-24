namespace EserKepenk.Models
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
    }
}
