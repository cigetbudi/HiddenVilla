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
    public class HotelAmnetyRepository : IHotelAmnetyRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public HotelAmnetyRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        //public async Task<ViewModel> Action(ViewModel param)
        public async Task<HotelAmnetyDTO> CreateHotemAmnety(HotelAmnetyDTO hotelAmnetyDTO)
        {
            //model variabelmodel = _mapper.Map<ViewModel, Model>(parameter)
            HotelAmnety hotelAmnety = _mapper.Map<HotelAmnetyDTO, HotelAmnety>(hotelAmnetyDTO);
            hotelAmnety.CreatedDate = DateTime.Now;
            hotelAmnety.CreatedBy = "admin";
            var addedHotelAmnety = await _db.HotelAmneties.AddAsync(hotelAmnety);
            await _db.SaveChangesAsync();
            //balikin
            return _mapper.Map<HotelAmnety, HotelAmnetyDTO>(addedHotelAmnety.Entity);
        }

        public async Task<int> DeleteHotelAmnety(int amnetyId)
        {
            var roomAmneties = await _db.HotelAmneties.FindAsync(amnetyId);
            if (roomAmneties !=null)
            {
                _db.HotelAmneties.Remove(roomAmneties);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelAmnetyDTO>> GetAllHotelAmneties()
        {
            try
            {
                IEnumerable<HotelAmnetyDTO> hotelAmnetyDTOs = _mapper.Map<IEnumerable<HotelAmnety>,
                    IEnumerable<HotelAmnetyDTO>>(_db.HotelAmneties);
                return hotelAmnetyDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelAmnetyDTO> GetHotelAmnety(int amnetyId)
        {
            try
            {
                HotelAmnetyDTO hotelAmnety = _mapper.Map<HotelAmnety, HotelAmnetyDTO>(
                await _db.HotelAmneties.FirstOrDefaultAsync(x => x.Id == amnetyId));

                return hotelAmnety;
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

        public async Task<HotelAmnetyDTO> IsAmnetyUnique(string name)
        {
            try
            {
                var amnetyDetails = await _db.HotelAmneties.FirstOrDefaultAsync
                    (x => x.Name.ToLower().Trim() == name.ToLower().Trim());
                return _mapper.Map<HotelAmnety, HotelAmnetyDTO>(amnetyDetails);
            }

            
            catch (Exception ex)
            {

                throw;
            }
            return new HotelAmnetyDTO();
        }

        public async Task<HotelAmnetyDTO> UpdateHotelAmnety(int amnetyId, HotelAmnetyDTO hotelAmnetyDTO)
        {
            try
            {
                if (amnetyId == hotelAmnetyDTO.Id)
                {
                    //valid
                    //get Id
                    HotelAmnety amnetyDetails = await _db.HotelAmneties.FindAsync(amnetyId);
                    HotelAmnety amnety = _mapper.Map<HotelAmnetyDTO, HotelAmnety>(hotelAmnetyDTO, amnetyDetails);
                    amnety.UpdatedBy = "admin";
                    amnety.UpdatedDate = DateTime.Now;
                    var updatedAmnety = _db.HotelAmneties.Update(amnety);
                    await _db.SaveChangesAsync();
                    //return _mapper.Map<HotelAmnety, HotelAmnetyDTO>(_db.HotelAmneties.Update(amnety).Entity)
                    return _mapper.Map<HotelAmnety, HotelAmnetyDTO>(updatedAmnety.Entity);
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
