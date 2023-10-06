using Apotek.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apotek.Controllers
{
    public class ObatController : Controller
    {
        private static List<Models.Obat> obats = InitializeData();

        private static List<Models.Obat> InitializeData()
        {
            List<Models.Obat> initialData = new List<Models.Obat>
            {
                new Models.Obat
                {
                    idObat = "OBA001",
                    idJenis = 1,
                    namaObat = "Paracetamol",
                    tanggalKadaluarsaObat = new DateTime(2025, 1, 2),
                    hargaObat = 50000,

                },
                new Models.Obat
                {
                    idObat = "OBA002",
                    idJenis = 2,
                    namaObat = "Kombatrin",
                    tanggalKadaluarsaObat = new DateTime(2024, 4, 2),
                    hargaObat = 40000,

                }
            };
            return initialData;
        }
        public IActionResult Index()
        {
            List<Models.Obat> obatList = obats.ToList();
            return View(obatList);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Obat obat)
        {
            if (ModelState.IsValid)
            {
                
                obats.Add(obat);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(obat);
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var response = new { success = false, message = "Gagal menghapus Obat." };
            string idpass = id;
            try
            {
                var obat = obats.FirstOrDefault(b => b.idObat == id);
                if (obat != null)
                {
                    obats.Remove(obat);
                    response = new { success = true, message = "Obat berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Obat tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Models.Obat obat = obats.FirstOrDefault(b => b.idObat == id);

            if (obat == null)
            {
                return NotFound();
            }

            return View(obat);
        }

        [HttpPost]
        public IActionResult Edit(Models.Obat obat)
        {
            if (ModelState.IsValid)
            {
                Models.Obat newObat = obats.FirstOrDefault(b => b.idObat == obat.idObat);

                if (newObat == null)
                {
                    return NotFound();
                }

                newObat.idJenis = obat.idJenis;
                newObat.namaObat = obat.namaObat;
                newObat.tanggalKadaluarsaObat = obat.tanggalKadaluarsaObat;
                newObat.hargaObat = obat.hargaObat;

                TempData["SuccessMessage"] = "Obat berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(obat);
        }
    }
}
