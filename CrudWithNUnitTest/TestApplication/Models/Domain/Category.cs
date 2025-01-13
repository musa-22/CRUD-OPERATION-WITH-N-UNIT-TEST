using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(40)]
        public string category { get; set; }


    }
}
