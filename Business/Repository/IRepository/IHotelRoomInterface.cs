using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomInterface
    {
        public Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO);
        public Task<HotelRoomDTO> UpddateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO);
        public Task<IEnumerable<HotelRoomDTO>> GetHotelRoom(int roomId);
        public Task<HotelRoomDTO> IsSameNameRoomAlreadyPresent(string name);
    }
}
