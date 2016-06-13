using System;
namespace PartyStarter.Models {
    public class OtherActivity {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float EstimatedDuration { get; set; }
        public int ParticipantsMin { get; set; }
        public int ParticipantsMax { get; set; }
 
    }
}