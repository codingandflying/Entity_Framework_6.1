namespace ComplexType.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BillingDetailId { get; set; }

        public Address Address { get; set; }
    }
}