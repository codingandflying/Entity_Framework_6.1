using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexType.Entities
{
    [ComplexType]
    public class Address
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public bool HasValue { get { return (Street != null || City != null | ZipCode != null); } }
    }
}