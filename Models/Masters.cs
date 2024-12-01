namespace Inance.Models
{
    public class Masters :BaseEntity
    {
        public int Name { get; set; }
        public int Surname { get; set; }
        public int Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Username { get; set; }

        public int ExperienceYear { get; set; }

        public bool IsActive { get; set; }

        public int ServiceId { get; set; }

        public Services? Service { get; set; }

        public ICollection<Orders> Orders { get; set; }



    }
}
