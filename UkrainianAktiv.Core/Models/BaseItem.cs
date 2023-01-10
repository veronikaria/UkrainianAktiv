namespace UkrainianAktiv.Core.Models
{
    public class BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public BaseItem()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
    }
}
