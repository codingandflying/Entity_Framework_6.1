namespace HQF.Tutorial.EntityFramework.Commons.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BillingDetailId { get; set; }

        public virtual BillingDetail BillingInfo { get; set; }
    }
}
