using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            //model parameter = _mapper.Map<ViewModel, Model>(parameter)
            HotelRoom hotelRoom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "admin";
            var addedHotelRoom = _db.HotelRooms.Add(hotelRoom);
            await _db.SaveChangesAsync();
            //model parameter = _mapper.Map<Model, ViewModel>(parameter)
            return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
        }

        public Task<IEnumerable<HotelRoomDTO>> GetHotelRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoomDTO> IsSameNameRoomAlreadyPresent(string name)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoomDTO> UpddateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            throw new NotImplementedException();
        }
    }
}
