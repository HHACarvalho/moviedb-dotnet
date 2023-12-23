using System.ComponentModel.DataAnnotations;

namespace moviedb_dotnet.DTOs
{
    public class MovieRequestBody
    {
        [Required]
        [MaxLength(96)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(48)]
        public required string Director { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Poster { get; set; }

        [Required]
        [MaxLength(512)]
        public required string Synopsis { get; set; }

        [Required]
        [Range(1888, int.MaxValue)]
        public int Year { get; set; }
    }
}
