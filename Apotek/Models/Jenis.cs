using System.ComponentModel.DataAnnotations;

namespace Apotek.Models
{
    public class Jenis
    {
        public int idJenis { get; set; }

        [Required(ErrorMessage = "nama wajib diisi.")]
        [MaxLength(30, ErrorMessage = "nama maksimal 30 karakter.")]
        public string? namaJenis { get; set; }

    }
}
