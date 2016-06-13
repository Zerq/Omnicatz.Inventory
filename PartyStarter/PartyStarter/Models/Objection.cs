using System;

namespace PartyStarter.Models {
    public class Objection {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Contnent { get; set; }
        public ObjectionStrenght ObjectionStrenght { get; set; }
    }


}

public enum ObjectionStrenght {
    MaybeWeCouldDoSomethingElseIfNoOneMindsMaybeButOnlyIfNoOneObjects_FlutterShy_Mode, //fluttershy style
    Meh,
    DoNotWant,
    OBJECTION,
    WontParticipateInThat,
    IfYouDoThatIAmSkippingTheParty,
    FuckYouGuysImOutOfHere_DropTheMic_Unfriend_DRAMA_MODE
}