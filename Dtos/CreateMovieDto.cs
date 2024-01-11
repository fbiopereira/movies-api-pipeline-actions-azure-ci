using System.ComponentModel.DataAnnotations;

namespace movies_api_pipeline_actions_azure_ci.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Movie Title is required")]
        [StringLength(50, ErrorMessage = "Movie Title must not exceed 50 characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Movie Genre is required")]
        [StringLength(30, ErrorMessage = "Movie Genre must not exceed 30 characters")]
        [Display(Name = "Genre")] public string Genre { get; set; }

        [Required(ErrorMessage = "Movie duration is required")]
        [Range(1, 300, ErrorMessage = "Movie Duration must be between 1 and 300 minutes")]
        [Display(Name = "Duration (minutes)")]
        public int Duration { get; set; }
    }
}

