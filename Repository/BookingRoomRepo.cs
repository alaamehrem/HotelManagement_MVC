using HotelManagement_MVC.IRepository;
using HotelManagement_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_MVC.Repository
{
    public class BookingRoomRepo : IBookingRoomRepo
    {
        public HotelContext context;
        public BookingRoomRepo(HotelContext _context)
        {
            context = _context;
        }
        public List<BookingRoom> GetAll()
        {
            return context.BookingRooms.Include(G=>G.Guest).Include(h=>h.HotelRoom).Include(o=>o.Offer).ToList();
        }

        public BookingRoom GetById(int Id)
        {
            return context.BookingRooms.FirstOrDefault(d => d.Id == Id);
        }


        public void Insert(BookingRoom obj)
        {
            context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public List<BookingRoom> Search(string search)
        {
            return context.BookingRooms
                    .Where(d => d.GuestId == int.Parse(search))
                    .ToList();
        }

        public void Update(HotelRoom obj)
        {
            context.Update(obj);
        }

        public void Delete(int Id)
        {
            BookingRoom bookingRoom = GetById(Id);
            context.Remove(bookingRoom);
        }
    }
}
