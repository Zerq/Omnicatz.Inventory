namespace PartyStarter.Models {





    public class AmendmentVote {
        //3part composit key ensures one user one vote
        public ApplicationUser User { get; set; }
        public Amendment Amendment { get; set; }
        public bool? InFavour { get; set; } //null = abstain vote
      

        //leave empty if not dependant on other amendment vote
        public Amendment ContingentOn { get; set; }
        public bool? ContingencyPassing { get; set; }
    }
}