using System;
using System.ComponentModel.DataAnnotations;

namespace PaxSys.Pccms.ContestAdministration.Models.Contest
{
    public class AddContestViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Contest title is required")]
        [MinLength(5, ErrorMessage = "Contest title must be descriptive enough and must be 5 to 50 characters")]
        [MaxLength(50, ErrorMessage = "Contest title must be descriptive enough and must be 5 to 50 characters")]
        public string Description { get; set; }
        
        [Display(Name = "Contest Date")]
        [Required]
        public DateTime Date { get; set; }
    }
}