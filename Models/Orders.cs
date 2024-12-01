namespace Inance.Models
{
    public class Orders : BaseEntity
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhoneNumber { get; set; }

        public string ClientEmail { get; set; }

        public string Problem { get; set; }
        public bool IsActived { get; set; }
        public int ServiceId { get; set; }

        public Services? Service { get; set; }

        public int MasterId { get; set; }

        public Masters? Masters { get; set; }

    }
}
