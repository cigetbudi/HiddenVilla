using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelImagesRepository
    {
        //Create
        public Task<int> CreateHotelImage(HotelRoomImageDTO image);

        //Delete satuan per Id 
        public Task<int> DeleteHotelImageById(int imageId);

        //Delete image per room
        public Task<int> DeleteHotelImageByRoomId(int roomId);
        //Delete image by url
        public Task<int> DeleteHotelImageByLink (string imageLink);

        //get all image by room Id
        public Task<IEnumerable<HotelRoomImageDTO>> GetHotelImages(int roomId); 
    }
}
