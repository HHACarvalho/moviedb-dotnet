using System.ComponentModel.DataAnnotations;

namespace moviedb_dotnet.DTOs
{
    public class MovieRequestBody
    {
        [Required]
        [StringLength(96, MinimumLength = 1)]
        public required string Title { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        public required string Director { get; set; }

        [Required]
        [StringLength(512, MinimumLength = 1)]
        public required string Poster { get; set; }

        [Required]
        [StringLength(512, MinimumLength = 1)]
        public required string Synopsis { get; set; }

        [Required]
        [Range(1888, int.MaxValue)]
        public int Year { get; set; }
    }
}
