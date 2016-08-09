using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Sire
{
    public class SireDto
    {
        public int SirePageId { get; set; }
        public int DogId { get; set; }
        public string DogName { get; set; }
        public DateTime? DOB { get; set; }
        public string BirthLand { get; set; }
        public string StandingLand { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public string Fee { get; set; }
    }

    public class SirePageDto
    {
        public int SirePageId { get; set; }
        public int DogId { get; set; }
        public string DogName { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
        public string Color { get; set; }
        public DateTime? DOB { get; set; }
        public string BirthLand { get; set; }
        public string StandingLand { get; set; }
        public string BreederName { get; set; }
        public string StudBookLicensedWith { get; set; }
        public string Recommendation { get; set; }
        public string ChoiceOfSemen { get; set; }
        public string SemenCountries { get; set; }
        public string Fee { get; set; }
        public string About { get; set; }
        public string Performance { get; set; }
        public string Progeny { get; set; }
        public string Terms { get; set; }
        public string Contact { get; set; }
    }

    public class RacePerformanceDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string StadiumName { get; set; }
        public DateTime? RaceDate { get; set; }
        public string Grade { get; set; }
        public decimal? Distance { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinnerTime { get; set; }
        public string Film { get; set; }
    }

    public class SireProgenyDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string StadiumName { get; set; }
        public DateTime? RaceDate { get; set; }
        public string Grade { get; set; }
        public decimal? Distance { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinnerTime { get; set; }
        public string Film { get; set; }
    }

    public class PutSirePageDto
    {       
        [Required(ErrorMessage = "Dog Id cannot be blank")]
        public int DogId { get; set; }

        [Required(ErrorMessage = "Fee cannot be blank")]
        public string Fee { get; set; }

        public string StudBookLicensedWith { get; set; }

        [Required(ErrorMessage = "Choice of Semen cannot be blank")]
        public string ChoiceOfSemen { get; set; }

        [Required(ErrorMessage = "Semen available countries cannot be blank")]
        public string SemenCountries { get; set; }

        public string About { get; set; }
        public string Performance { get; set; }
        public string Progeny { get; set; }
        public string Recommendation { get; set; }
        public string Terms { get; set; }

        [Required(ErrorMessage = "Contact cannot be blank")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "User Id is required.")]
        public int UserId { get; set; }
    }

    public class UpdateSirePageDto
    {
        [Required(ErrorMessage = "Sirepage Id is required.")]
        public int SirePageId { get; set; }
        [Required(ErrorMessage = "Dog Id is required.")]
        public int DogId { get; set; }

        [Required(ErrorMessage = "Fee cannot be blank")]
        public string Fee { get; set; }
        
        public string StudBookLicensedWith { get; set; }
        
        [Required(ErrorMessage = "Choice of Semen cannot be blank")]
        public string ChoiceOfSemen { get; set; }

        [Required(ErrorMessage = "Semen available countries cannot be blank")]
        public string SemenCountries { get; set; }

        public string About { get; set; }
        public string Performance { get; set; }
        public string Progeny { get; set; }
        public string Recommendation { get; set; }
        public string Terms { get; set; }

        [Required(ErrorMessage = "Contact cannot be blank")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "User Id is required.")]
        public int UserId { get; set; }
    }

    public class DeleteSirePageDto
    {
        [Required(ErrorMessage = "Sirepage Id is required.")]
        public int SirePageId { get; set; }

        [Required(ErrorMessage = "Delete Comment cannot be blank")]
        public string DeleteComment { get; set; }

        [Required(ErrorMessage = "User Id is required.")]
        public int UserId { get; set; }
    }
}
