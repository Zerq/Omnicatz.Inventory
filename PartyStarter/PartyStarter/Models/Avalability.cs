using System;

namespace PartyStarter.Models {
    public class Avalability {

        public Guid Id { get; set; }
        /// <summary>
        /// additive will add it to the calender first then subtractive avalabilites will be removed or marked down as less convenient (probably rendered by color scales in the UI)
        /// </summary>
        public AvalabilityType AvalabilityType { get; set; }

        public DayOfWeek? ReoccuringWeekDay { get; set; }

        public int? DayOfMonth { get; set; }
        
        /// <summary>
        /// One Time start time
        /// </summary>
      public DateTime? StatDate { get; set; }

      /// <summary>
      /// used if DayOfWeek or day of month is specified
      /// </summary>
      public TimeSpan? RelativeStartTime { get; set; }
        
        /// <summary>
        /// Duration from start to end
        /// </summary>
      public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Like "Only if there is not a furry meetup that day" or some similar condition that may be verified somwere elese 
        /// </summary>
      public string Conditional { get; set; }

        /// <summary>
        /// How grudginly someone might attend an event... i.e so one can try to find the ideal time for everyone...
        /// </summary>
      public Convenience Convenience { get; set; }
    }
}

public enum Convenience {
Perfect, Ok, Tollerable, ShittyButDoable, Imposible
}

public enum AvalabilityType {
    Additive,Subtractive
}