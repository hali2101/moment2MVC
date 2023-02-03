using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moment2MVC.Models
{
    //skapar en klass för att definiera strukturen av datat
    public class WorkoutModel
    {
        //properties till modellen
        //sätter fältet som nödvändigt vid ifyllnad och med felmeddelande
        [Required(ErrorMessage = "Ange ett namn för träningspasset.")]
        //vilka labels som ska visas till inmatningsfälten
        [Display(Name = "Träningspassets namn:")]
        [MaxLength(15)]
        public string? Workoutname { get; set; }

        [Required(ErrorMessage = "Välj svårighetsgrad.")]
        [Display(Name = "Svårighetsgrad:")]
        public string? Difficulty { get; set; }

        [Required(ErrorMessage = "Fyll i passets längd.")]
        [Display(Name = "Passets längd:")]
        [Range(1, 200, ErrorMessage = "Lite väl långt pass va? Ej över 200 minuter.")]
        public int? Duration { get; set; }

        [Display(Name = "Avklarat:")]
        public bool Completion { get; set; } = false;

    }
}