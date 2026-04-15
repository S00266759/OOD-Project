using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project.ProjectData
{
    public class Game
    {
        public int GameId { get; set; }  //Primary Key 

        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Description { get; set; }

        //for MyLibrary (also uses title, genre and platform)
        public DateTime PurchaseDate { get; set; }
    }

}
