using System;

namespace PartyStarter.Models {

    public class MediaLanguage{
        public MediaFormat Media { get; set; }
        public Language Language { get; set; }
    }
    public class Language {
        public Guid Id {get;set;}
        public string Name { get; set; }
        public LanguageType Type {get; set;}
    }

    public enum LanguageType {
        Voice,
        Text,
        Both
    }
}