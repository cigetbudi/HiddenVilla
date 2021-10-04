using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelAmnetyRepository
    {
        public Task<HotelAmnetyDTO> CreateHotemAmnety(HotelAmnetyDTO hotelAmnetyDTO);
        public Task<HotelAmnetyDTO> UpdateHotelAmnety(int amnetyId, HotelAmnetyDTO hotelAmnetyDTO);
        public Task<HotelAmnetyDTO> GetHotelAmnety(int amnetyId);
        public Task<int> DeleteHotelAmnety(int amnetyId);
        public Task<IEnumerable<HotelAmnetyDTO>> GetAllHotelAmneties();
        public Task<HotelAmnetyDTO> IsAmnetyUnique(string name);

    }
}
