﻿using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.IRepository
{
    public interface IHotelRoomTypeRepo
    {
        List<HotelRoomType> GetAll();
        HotelRoomType GetBuId(int Id);
        void Update(HotelRoomType obj);
        void Delete(int Id);
        void Insert(HotelRoomType obj);
        void Save();
        List<HotelRoom> GetByRoomTypeId(int roomTypeId);
        //public List<HotelRoomType> GetByGuest();
        public List<HotelRoomType> Search(string search);
            
    }
}
