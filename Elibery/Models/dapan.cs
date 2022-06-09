namespace Elibery.Models
{
    public class dapan
    {
        public int id { get; set; }
        public string dapAn { get; set; }
        public bool isDapan { get; set; }
        public int idCauhoi { get; set; }
        public cauhoi? cauhoi { get; set; }
        
    }
}
