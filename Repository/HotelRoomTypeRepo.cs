using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.Repository
{
    public class HotelRoomTypeRepo : IHotelRoomTypeRepo
    {
        public HotelContext context;
        public HotelRoomTypeRepo(HotelContext _context)
        {
            context = _context;
        }
   
        public List<HotelRoomType> GetAll()
        {
            return context.HotelRoomTypes.ToList();
        }

        public HotelRoomType GetById(int Id)
        {
            return context.HotelRoomTypes.FirstOrDefault(r => r.Id == Id);
        }

        //public List<HotelRoom> GetByRoomTypeId(int roomTypeId)
        //{
        //    throw new NotImplementedException();
        //}

        public void Insert(HotelRoomType obj)
        {
            context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public List<HotelRoomType> Search(string search)
        {
            return context.HotelRoomTypes                   
                    .Where(i => i.Name.Contains(search))
                    .ToList();
        }

        public void Update(HotelRoomType obj)
        {
            context.Update(obj);
        }

        public void Delete(int Id)
        {
            HotelRoomType hotelRoomType = GetById(Id);
            context.Remove(hotelRoomType);
        }

    }
}
