using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DataBase.DbModel
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public int stateid { get; set; }
        public string ? CityName { get; set; }
    }
}
