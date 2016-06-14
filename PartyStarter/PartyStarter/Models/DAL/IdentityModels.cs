using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace PartyStarter.Models {
    //experimental generic classes dont work with entityframework so far as far as i can tell.. think this might work though... it does for winforms which has a similar issue
    public class IngredientPreference : Preference<Ingredient> { }
    public class MediaPreference : Preference<Media> { }
    public class GenrePreference : Preference<Genre> { }
   
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<Guid,GuidIdentityUserLogin , GuidIdentityUserRole, GuidIdentityUserClaim > {
        public virtual List<IngredientPreference> IngredientPreferences { get; set; }
        public virtual List<MediaFormat> Owns { get; set; }
        public virtual List<MediaPreference> MediaPreferences { get; set; }
        public virtual List<GenrePreference> GenrePreferences { get; set; }
        public virtual List<PartyHostingProposal> PartyProposal { get; set; }
        public virtual List<Avalability> AvalabilityPattern { get; set; }
        public virtual List<Amendment> Proposals { get; set; }
        public virtual List<Amendment> ProposalDependencies { get; set; }

        public virtual List<AmendmentVote> Votes { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,GuidIdentityRole, Guid, GuidIdentityUserLogin, GuidIdentityUserRole, GuidIdentityUserClaim>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Amendment> Amendments { get; set; }
        public DbSet<Avalability> Avalabilitys { get; set; }
        public DbSet<EstimatedCostPerUnit> EstimatedCostPerUnits { get; set; }
        public DbSet<MediaReaderFormat> Formats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientMessure> IngredientMessures { get; set; }

        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaFormat> MediaFormats { get; set; }
        public DbSet<MediaReader> MediaReaders { get; set; }
        public DbSet<Objection> Objections { get; set; }
        public DbSet<PartyHostingProposal> PartyHostingProposals { get; set; }
        public DbSet<Peripheral> Peripherals { get; set; }
        public DbSet<IngredientPreference> IngredientPreferences { get; set; }
        public DbSet<MediaPreference> MediaPreferences { get; set; }
        public DbSet<GenrePreference> GenrePreferences { get; set; }
        public DbSet<Recipie> Recipies { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitPrefix> UnitPrefixs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<Amendment>().HasKey(n => n.Id);
            modelBuilder.Entity<Amendment>().HasMany<AmendmentVote>(n => n.Votes).WithRequired(n => n.Amendment);
            modelBuilder.Entity<Amendment>().HasOptional(n => n.DependantActor).WithMany(n => n.Proposals);
            modelBuilder.Entity<Amendment>().HasOptional(n => n.Author).WithMany(n => n.Proposals);


            modelBuilder.Entity<AmendmentVote>().HasKey(n => new { n.User, n.InFavour, n.Amendment });

            modelBuilder.Entity<AmendmentVote>().HasRequired<ApplicationUser>(n => n.User).WithMany(n => n.Votes);



            modelBuilder.Entity<Avalability>().HasKey(n => n.Id);


            modelBuilder.Entity<EstimatedCostPerUnit>().HasKey(n => n.Id);
            modelBuilder.Entity<MediaReaderFormat>().HasKey(n => n.Id);
            modelBuilder.Entity<Genre>().HasKey(n => n.Id);
            modelBuilder.Entity<Ingredient>().HasKey(n => n.Id);
            modelBuilder.Entity<IngredientMessure>().HasKey(n => n.Id);
            modelBuilder.Entity<Media>().HasKey(n => n.Id);
            modelBuilder.Entity<MediaFormat>().HasKey(n => n.Id);
            modelBuilder.Entity<MediaFormat>().HasMany(n => n.LanguageOptions).WithRequired(n => n.Media);
            modelBuilder.Entity<MediaLanguage>().HasKey(n => new { n.Language, n.Media });


            modelBuilder.Entity<MediaReader>().HasKey(n => n.Id);
            modelBuilder.Entity<MediaReader>().HasMany(n => n.Peripherals).WithRequired(n => n.ParentHardware);
            modelBuilder.Entity<MediaReader>().HasMany(n => n.Formats).WithRequired(n => n.);


            modelBuilder.Entity<Objection>().HasKey(n => n.Id);
            modelBuilder.Entity<PartyHostingProposal>().HasKey(n => n.Id);
            modelBuilder.Entity<Peripheral>().HasKey(n => n.Id);
            modelBuilder.Entity<IngredientPreference>().HasKey(n => n.Id);
            modelBuilder.Entity<MediaPreference>().HasKey(n => n.Id);
            modelBuilder.Entity<GenrePreference>().HasKey(n => n.Id);
            modelBuilder.Entity<Recipie>().HasKey(n => n.Id);
            modelBuilder.Entity<Unit>().HasKey(n => n.Id);
            modelBuilder.Entity<UnitPrefix>().HasKey(n => n.Id);



            // modelBuilder.Entity<Avalability>().HasRequired(n=> n)
        
    
 
            modelBuilder.Entity<Amendment>().HasKey(n => n.Id);





            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}