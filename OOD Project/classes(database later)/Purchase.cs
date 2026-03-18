using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project.classes_database_later_
{
    public class Purchase
    {
        public int Id { get; set; }
        public string GameTitle { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}