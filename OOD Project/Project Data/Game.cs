using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project.ProjectData
{
    public class Game
    {
        public int GameId { get; set; }   //Primary Key

        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Description { get; set; }

        public DateTime? PurchaseDate { get; set; } //For MyLibrary
    }
}
