using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class Employment
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [DataType(DataType.Date), Display(Name ="Датум на започнување")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Датум на завршување")]
        public DateTime? FinishDate { get; set; }
        [StringLength(100, MinimumLength=5), Display(Name ="Коментар")]
        public string Comment { get; set; }
    }
}
