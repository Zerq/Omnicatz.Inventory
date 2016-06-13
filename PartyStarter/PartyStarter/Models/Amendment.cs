using System;
using System.Collections.Generic;

namespace PartyStarter.Models {
    public class Amendment {
        public Guid Id { get; set; }

        public ApplicationUser Author { get; set; }
        public bool HostApproval { get; set; }
          
        //if the amendment concerns a resource owned by one actor
        public ApplicationUser DependantActor { get; set; }
        public bool DependatActorApproval { get; set; }

        public virtual List<AmendmentVote> Votes { get; set; } 
        public string Title { get; set; }
        public string Contenet { get; set; }
    }
}