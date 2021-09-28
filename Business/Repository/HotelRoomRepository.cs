using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
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
        //public async Task<ViewModel> Action(ViewModel param)
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

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await _db.HotelRooms.FindAsync(roomId);
            if (roomDetails != null)
            {
                _db.HotelRooms.Remove(roomDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoomDTO> hotelRoomDTOs = _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms.Include(x => x.HotelRoomImages));
                return hotelRoomDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _db.HotelRooms.Include(x=>x.HotelRoomImages).FirstOrDefaultAsync(x => x.Id == roomId));

                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //if unique return null else room obj
        public async Task<HotelRoomDTO> IsRoomUnique(string name, int roomId=0)
        {
            try
            {
                if (roomId==0)
                {
                    HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                   await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                    return hotelRoom;
                }
                else
                {
                    HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                   await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() 
                   && x.Id !=roomId));

                    return hotelRoom;
                }
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                if (roomId == hotelRoomDTO.Id)
                {
                    //valid
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomDetails);
                    room.UpdatedBy = "admin";
                    room.UpdatedDate = DateTime.Now;
                    var updateRoom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updateRoom.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}
