using Apotek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace Apotek.Controllers
{
    public class PembelianController : Controller
    {
        private static List<Models.Pembelian> pembelians = InitializeData();

        private static List<Models.Pembelian> InitializeData()
        {
            List<Models.Pembelian> initialData = new List<Models.Pembelian>
            {
                new Models.Pembelian
                {
                    idTransaksi = "TRS001",
                    tanggalTransaksi = new DateTime(2023,12,12),
                    idObat = "OBA001",
                    jumlah = 2,
                    totalHarga = 25000,


                },
                new Models.Pembelian
                {
                    idTransaksi = "TRS002",
                    tanggalTransaksi = new DateTime(2023,5,12),
                    idObat = "OBA002",
                    jumlah = 1,
                    totalHarga = 10000,

                }
            };
            return initialData;
        }
        public IActionResult Index()
        {
            List<Models.Pembelian> pembelianList = pembelians.ToList();
            return View(pembelianList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pembelian pembelian)
        {
            if (ModelState.IsValid)
            {

                pembelian.totalHarga = pembelian.jumlah * 5000;
                pembelians.Add(pembelian);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(pembelian);
        }
    }
}
