using System;
using System.Collections.Generic;

namespace PartyStarter.Models {
    public class PartyHostingProposal {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Recipie> MealsProposal { get; set; }
        public virtual List<MediaFormat> SepecificMediaProposal { get; set; }
        public virtual List<Objection> Objections { get; set; }
        public virtual List<Amendment> Amendments { get; set; }
        public virtual List<OtherActivity> OtherActivity { get; set; }

        public bool Finalized { get; set; }
        public bool HostApproval { get; set; }
        public virtual List<ApplicationUser> Attendees { get; set; }
    }
}