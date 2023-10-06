using System.ComponentModel.DataAnnotations;

namespace Apotek.Models
{
    public class Obat
    {
        [Required(ErrorMessage = "ID Obat wajib diisi.")]
        [RegularExpression("^OBA\\d{3}$", ErrorMessage = "Format ID tidak valid. Gunakan format OBAXXX.")]
        public string idObat { get; set; }

        [Required(ErrorMessage = "ID Jenis wajib diisi.")]
        public int idJenis { get; set; }

        [Required(ErrorMessage = "Nama Obat wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama Obat maksimal 30 karakter.")]
        public string namaObat { get; set;}
        public DateTime tanggalKadaluarsaObat { get; set;}

        [Required(ErrorMessage = "harga wajib diisi.")]
        [RegularExpression("^[0-9]$", ErrorMessage = "Inputan hanya bisa Angka")]
        public double hargaObat { get; set; }
    }
}
