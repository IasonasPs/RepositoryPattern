using Microsoft.Build.Framework;
using RepositoryPattern.Data;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models
{
    public class Star : IEntity
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, MinimumLength = 2)]
        public string Surname { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Nationality { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public bool WonOscar { get; set; }
    }
}
