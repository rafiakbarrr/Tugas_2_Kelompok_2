namespace Apotek.Models
{
    public class Pembelian
    {
        public string idTransaksi { get; set; }
        public DateTime tanggalTransaksi { get; set; }
        public string idObat { get; set; }
        public int jumlah { get; set; }
        public double totalHarga { get; set; }
    }
}
