using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Contacts
    {
        public Contacts()
        {
            ContactConfigurations = new HashSet<ContactConfigurations>();
            Emails = new HashSet<Emails>();
            Phones = new HashSet<Phones>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ContactConfigurations> ContactConfigurations { get; set; }
        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
