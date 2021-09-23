using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelRoomDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Masukkan nama ruangan")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Masukkan Okupansi")]
        public int Occupancy { get; set; }
        [Range(1, 3000, ErrorMessage ="Mohon diisi dari 1 sampai 3000")]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }
    }
}
