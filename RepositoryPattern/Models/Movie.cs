using RepositoryPattern.Data;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        // ^ asserts the start of the string
        // [A-Z]+ matches one or more uppercase letters at the beggining of the string
        // [a-zA-Z""'\s-]* matches zero or more occurences of letters ..etc
        // $ asserts the end of the string
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
    }
}
