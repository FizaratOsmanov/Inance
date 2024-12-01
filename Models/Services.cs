namespace Inance.Models
{
    public class Services : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Masters> Masters { get; set;}

        public ICollection<Orders> Orders { get; set;}


    }
}
