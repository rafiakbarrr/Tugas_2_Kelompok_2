using System.ComponentModel.DataAnnotations;

namespace Apotek.Models
{
    public class Pembelian
    {
        [Required(ErrorMessage = "ID Transaksi wajib diisi.")]
        [RegularExpression("^TRS\\d{3}$", ErrorMessage = "Format ID tidak valid. Gunakan format TRSXXX.")]
        public string idTransaksi { get; set; }
        public DateTime tanggalTransaksi { get; set; }

        [Required(ErrorMessage = "ID Obat wajib diisi.")]
        [RegularExpression("^OBA\\d{3}$", ErrorMessage = "Format ID tidak valid. Gunakan format OBAXXX.")]
        public string idObat { get; set; }

        [Required(ErrorMessage = "jumlah wajib diisi.")]
        [RegularExpression("^[0-9]$", ErrorMessage = "Inputan hanya bisa Angka")]
        public int jumlah { get; set; }
        public double totalHarga { get; set; }
    }
}
