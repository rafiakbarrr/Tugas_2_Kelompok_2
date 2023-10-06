namespace Apotek.Models
{
    public class Obat
    {
        public string idObat { get; set; }
        public int idJenis { get; set; }
        public string namaObat { get; set;}
        public DateTime tanggalKadaluarsaObat { get; set;}
        public double hargaObat { get; set; }
    }
}
