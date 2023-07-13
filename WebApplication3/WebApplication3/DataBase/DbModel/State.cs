using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DataBase.DbModel
{
    public class State
    {
        [Key]
        public int Id { get; set; } 

        public string? Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
