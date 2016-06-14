using System;
using System.Collections.Generic;

namespace PartyStarter.Models {
    public class MediaFormat {
        public Guid Id { get; set; }
        public string NameExtra { get; set; } //like "2011: Star Wars: The Complete Saga Blu-ray release"  or the like... there may be more then one version.. and if it star wars people might want to know for instance... because Han solo shot first!
        public Media  Media { get; set; }
        public MediaReaderFormat Format { get; set; }
        public List<MediaLanguage> LanguageOptions {get;set;}
    }
}