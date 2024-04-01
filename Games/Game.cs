using System.ComponentModel.DataAnnotations;

namespace Games
{
    public class Game
    {
        [Key] 
        public int id { get; set; }
        [Required] [MaxLength(50)] 
        public string name { get; set; }
        [MaxLength(50)]
        public string studio { get; set; }
        [MaxLength(50)] 
        public string genre { get; set; }
        public int year { get; set; }
        public int sold { get; set; }
        [MaxLength(50)] 
        public string players { get; set; }

    }
}