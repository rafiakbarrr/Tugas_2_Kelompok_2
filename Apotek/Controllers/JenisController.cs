using Apotek.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apotek.Controllers
{
    public class JenisController : Controller
    {
        private static List<Models.Jenis> jeniss = InitializeData();

        private static List<Models.Jenis> InitializeData()
        {
            List<Models.Jenis> initialData = new List<Models.Jenis>
            {
                new Models.Jenis
                {
                    idJenis = 1,
                    namaJenis = "Batuk",
                    
                },
                new Models.Jenis
                {
                    idJenis = 2,
                    namaJenis = "Pilek",
                   
                }
            };
            return initialData;
        }
        public IActionResult Index()
        {
            List<Models.Jenis> jenisList = jeniss.ToList();
            return View(jenisList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Jenis jenis)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (jeniss.Any(b => b.idJenis == new_id))
                {
                    new_id++;
                }

                jenis.idJenis= new_id;

                jeniss.Add(jenis);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(jenis);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus Jenis." };
            int idpass = id;
            try
            {
                var jenis = jeniss.FirstOrDefault(b => b.idJenis == id);
                if (jenis != null)
                {
                    jeniss.Remove(jenis);
                    response = new { success = true, message = "Jenis berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Jenis tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Jenis jenis = jeniss.FirstOrDefault(b => b.idJenis == id);

            if (jenis == null)
            {
                return NotFound();
            }

            return View(jenis);
        }

        [HttpPost]
        public IActionResult Edit(Models.Jenis jenis)
        {
            if (ModelState.IsValid)
            {
                Models.Jenis newJenis = jeniss.FirstOrDefault(b => b.idJenis == jenis.idJenis);

                if (newJenis == null)
                {
                    return NotFound();
                }

                newJenis.namaJenis = jenis.namaJenis;

                TempData["SuccessMessage"] = "Jenis berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(jenis);
        }
    }
}
