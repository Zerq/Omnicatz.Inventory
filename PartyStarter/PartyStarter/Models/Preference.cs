using System;

namespace PartyStarter.Models {
    /// <summary>
    /// I leave this abstract for now since EF probalby cant deal with this... which is kind of silly really i dont see what would be the problem in implementing this..
    /// I mean its basically inheritence after all... thats basically a one to one relationship... with a table specifying the diffrence... oh well...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Preference<T> {
        public Guid Id { get; set; }
        public T Item { get; set; }
        public PreferenceRating PreferenceRating { get; set; }
    }
}

