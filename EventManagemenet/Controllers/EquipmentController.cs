using EventManagemenet.Filters;
using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EventManagemenet.Controllers
{
    [ValidateAdminSession]
    public class EquipmentController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private IEquipment _IEquipment;

        public EquipmentController(IEquipment IEquipment, Microsoft.AspNetCore.Hosting.IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
            _IEquipment = IEquipment;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View(new Equipment());
        }

        /// <summary>
        /// Inserting Equipment
        /// </summary>
        /// <param name="Equipment"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Equipment Equipment)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                if (files == null)
                {
                    ModelState.AddModelError("", "Upload Equipment Photo !");
                    return View();
                }

                var uploads = Path.Combine(_environment.WebRootPath, "EquipmentImages");

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);
                        newFileName = myUniqueFileName + FileExtension;
                        fileName = Path.Combine(_environment.WebRootPath, "EquipmentImages") + $@"\{newFileName}";
                        PathDB = "EquipmentImages/" + newFileName;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }

                Equipment objEqu = new Equipment
                {
                    EquipmentFilename = newFileName,
                    EquipmentFilePath = PathDB,
                    EquipmentID = 0,
                    EquipmentName = Equipment.EquipmentName,
                    EquipmentCost = Equipment.EquipmentCost,
                    Createdate = DateTime.Now,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };

                _IEquipment.SaveEquipment(objEqu);

                TempData["EquipmentMessage"] = "Equipment Saved Successfully";
                ModelState.Clear();
                return View(new Equipment());

            }
            return View(Equipment);
        }

        /// <summary>
        /// Validating VenueName is duplicate or not
        /// </summary>
        /// <param name="venueName"></param>
        /// <returns></returns>
        public JsonResult CheckEquipmentNameExists(string EquipmentName)
        {
            try
            {
                var isVenueNameExists = _IEquipment.CheckEquipmentAlready(EquipmentName);
                if (isVenueNameExists)
                {
                    return Json(data: true);
                }
                else
                {
                    return Json(data: false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get Equipment Details to Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ViewAllVenues", "Venue");
                }

                Equipment EquipmentEdit = _IEquipment.GetEquipmentByID(Convert.ToInt32(id));

                return View("Edit", EquipmentEdit);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Equipment
        /// </summary>
        /// <param name="Equipment"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]                                                                                                                                                                                                                                             
        public IActionResult Edit(Equipment Equipment)
        {
            var newFileName = string.Empty;
            string PathDB = string.Empty;

            //if (!ModelState.IsValid)
            //{
            //    return View("Equipment");
            //}

            if (HttpContext.Request.Form.Files[0].Length > 0)
            {
                var fileName = string.Empty;

                var files = HttpContext.Request.Form.Files;

                if (files == null)
                {
                    ModelState.AddModelError("", "Upload Equipment Photo !");
                    return View();
                }

                var uploads = Path.Combine(_environment.WebRootPath, "EquipmentImages");

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);
                        newFileName = myUniqueFileName + FileExtension;
                        fileName = Path.Combine(_environment.WebRootPath, "EquipmentImages") + $@"\{newFileName}";
                        PathDB = "EquipmentImages/" + newFileName;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }

            }

            if (!string.IsNullOrEmpty(PathDB))
            {
                Equipment objEqu = new Equipment
                {
                    EquipmentFilename = newFileName,
                    EquipmentFilePath = PathDB,
                    EquipmentID = Equipment.EquipmentID,
                    EquipmentName = Equipment.EquipmentName,
                    Createdate = DateTime.Now,
                    EquipmentCost = Equipment.EquipmentCost,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };

                _IEquipment.UpdateEquipment(objEqu);

                TempData["VenueUpdateMessage"] = "Equipment Saved Successfully";
                ModelState.Clear();
                return View(new Equipment());
            }
            else
            {

                Equipment objEqu = new Equipment
                {
                    EquipmentID = Equipment.EquipmentID,
                    EquipmentName = Equipment.EquipmentName,
                    EquipmentCost = Equipment.EquipmentCost,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };

                _IEquipment.UpdateEquipment(objEqu);

                TempData["VenueUpdateMessage"] = "Equipment Saved Successfully";
                ModelState.Clear();
                return View(new Equipment());
            }

        }

        /// <summary>
        /// Delete Equipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ViewAllVenues", "Venue");
                }

                int result = _IEquipment.DeleteEquipment(Convert.ToInt32(id));

                if (result > 0)
                {
                    return Json(data: true);
                }
                else
                {
                    return Json(data: false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        // GET: /<controller>/
        public IActionResult ViewAllEquipments()
        {
            return View();
        }

        public IActionResult LoadEquipmentData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var v = _IEquipment.ShowEquipment(sortColumn, sortColumnDir, searchValue);
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
