using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DataBase.DbModel
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string? CountryName { get; set; } 
    }
}
