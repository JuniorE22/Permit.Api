using System;

namespace Permit.Model.Entities
{
    public class Entities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {get; set;}
        public int PermitType { get; set;}
        public DateTime PermitDate { get; set; }
    }
}
