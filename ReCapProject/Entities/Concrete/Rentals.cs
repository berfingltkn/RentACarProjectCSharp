using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rentals:IEntity
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentDate { get; set; }//kiralama tarihi
        public DateTime ReturnDate { get; set; }//teslim tarihi

    }
}
