using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

using GreyHound.Models.Common;
using GreyHound.Models.Dogs;
using GreyHound.Models.Enums;
using GreyHound.Models.Tracks;
using GreyHound.Models.Race;
using GreyHound.Models.Kennels;
using GreyHound.Models.Classifieds;
using GreyHound.Models.Users;
using GreyHound.Models.GreyhoundLibrary;
using System.Data.Entity.Infrastructure;

namespace GreyHound.Models
{    
    /*public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("GreyHoundContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 30000000;
        }
    }
    */

    public class GreyHoundContext : DbContext
    {
        public GreyHoundContext()
            : base("name = GreyHoundContext")
        {
            // Get the ObjectContext related to this DbContext
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 30000000;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Dog>()
        //    .HasOptional(d => d.Dam)
        //    .WithMany(p => p.Sire)
        //    .HasForeignKey(p => p.DamId)
        //    .WillCascadeOnDelete(false);           
        //}

        #region Common

        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<DogBreeder> DogBreeders { get; set; }
        public DbSet<DogTrainer> DogTrainers { get; set; }
        public DbSet<DogAdoptedOwner> DogAdoptedOwners { get; set; }
        public DbSet<DogColor> DogColors { get; set; }
        public DbSet<CountryGroup> CountryGroups { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }

        #endregion

        #region Dogs

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<BreededDog> BreededDogs { get; set; }
        public DbSet<AdoptedDog> AdoptedDogs { get; set; }
        public DbSet<TrainedDog> TrainedDogs { get; set; }
        public DbSet<DogStat> DogStats { get; set; }
        #endregion

        #region Users

        public DbSet<User> Users { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        //public DbSet<Audience> Audience { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region Tracks

        public DbSet<AdminBody> AdminBodies { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<TrackDistance> TrackDistances { get; set; }
        public DbSet<TrackType> TrackType { get; set; }
        public DbSet<TrackForm> TrackForms { get; set; }
        public DbSet<StadiumOpenDay> StadiumOpenDays { get; set; }
        ////public DbSet<Continent> Continents { get; set; }

        #endregion

        #region Race

        public DbSet<DistanceToWinner> DistanceToWinners { get; set; }
        //public DbSet<DistanceType> DistanceTypes { get; set; }
        public DbSet<RaceClass> RaceClasses { get; set; }
        public DbSet<RaceFinishedOrder> RaceFinishedOrders { get; set; }
        public DbSet<RaceGrade> RaceGrades { get; set; }
        public DbSet<RaceResultType> RaceResultTypes { get; set; }
        public DbSet<RaceSpecialClass> RaceSpecialClasses { get; set; }
        public DbSet<RaceType> RaceTypes { get; set; }
        public DbSet<Race.Race> Races { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }

        //stat related tables
        public DbSet<RaceStat> RaceStats { get; set; }

        #endregion

        #region Kennel

        public DbSet<Studbook.Studbook> Studbooks { get; set; }
        public DbSet<Studbook.StudbookVolume> StudbookVolumes { get; set; }

        #endregion

        #region Kennel

        public DbSet<Kennel> Kennels { get; set; }
        public DbSet<KennlStudDogs> KennelStudDogs { get; set; }
        public DbSet<KennelBreed> KennelBreeds { get; set; }
        public DbSet<KennelBrood> KennelBroods { get; set; }

        #endregion

        #region Classifieds

        //public DbSet<MiscSaleType> MiscSaleTypes { get; set; }
        public DbSet<DogSaleType> DogSaleType { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<DogsSale> DogsSales { get; set; }
        public DbSet<LitterSale> LitterSales { get; set; }
        public DbSet<MiscellaneousSale> MiscellaneousSales { get; set; }
        public DbSet<ClassifiedPrice> ClassifiedPrices { get; set; }

        #endregion

        #region Sire

        public DbSet<Sire.Sire> Sires { get; set; }

        #endregion

        #region Library

        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryFile> LibraryFiles { get; set; }

        #endregion

        //public DbSet<> { get; set; }

    }
}
