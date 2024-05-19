namespace HotelManagement_MVC.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPages { get; private set;}
        public int PageSize { get; private set;}
        public int TotalPages { get; private set; }
        public int StartPage { get; private set;}
        public int EndPage { get; private set;}
        public Pager() { }
        public Pager(int TotalItems) { }

    }
}
