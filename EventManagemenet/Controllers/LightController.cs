using EventManagemenet.Filters;
using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EventManagemenet.Controllers
{
    [ValidateAdminSession]
    public class LightController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private ILight _ILight;
        public LightController(ILight ILight, IHostingEnvironment hostingEnvironment)
        {
            _ILight = ILight;
            _environment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                var tempLight = new Light();
                tempLight.LightType = "1";
                return View(tempLight);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserting Light
        /// </summary>
        /// <param name="Light"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Light Light)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                if (files == null)
                {
                    ModelState.AddModelError("", "Upload Light Photo !");
                    return View();
                }

                var uploads = Path.Combine(_environment.WebRootPath, "LightImages");

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);
                        newFileName = myUniqueFileName + FileExtension;
                        fileName = Path.Combine(_environment.WebRootPath, "LightImages") + $@"\{newFileName}";
                        PathDB = "LightImages/" + newFileName;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }

                Light objLight = new Light
                {
                    LightFilename = newFileName,
                    LightFilePath = PathDB,
                    LightID = 0,
                    LightName = Light.LightName,
                    LightCost = Light.LightCost,
                    LightType = Light.LightType,
                    Createdate = DateTime.Now,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };


                _ILight.SaveLight(objLight);

                TempData["LightMessage"] = "Light Saved Successfully";
                ModelState.Clear();
                return View(new Light());

            }
            return View(Light);
        }

        /// <summary>
        /// Validating LightName is duplicate or not
        /// </summary>
        /// <param name="LightName"></param>
        /// <returns></returns>
        public JsonResult CheckLightNameAlready(string LightName)
        {
            try
            {
                var isLightNameExists = _ILight.CheckLightAlready(LightName);
                if (isLightNameExists)
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


        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ViewAllLights", "Light");
                }

                Light lightEdit = _ILight.LightByID(Convert.ToInt32(id));

                return View("Edit", lightEdit);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Update Venue
        /// </summary>
        /// <param name="Venue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Light Light)
        {
            var newFileName = string.Empty;
            string PathDB = string.Empty;

            if (!ModelState.IsValid)
            {
                return View("Venue");
            }

            if (HttpContext.Request.Form.Files[0].Length > 0)
            {
                var fileName = string.Empty;

                var files = HttpContext.Request.Form.Files;

                if (files == null)
                {
                    ModelState.AddModelError("", "Upload Venue Photo !");
                    return View();
                }

                var uploads = Path.Combine(_environment.WebRootPath, "LightImages");

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);
                        newFileName = myUniqueFileName + FileExtension;
                        fileName = Path.Combine(_environment.WebRootPath, "LightImages") + $@"\{newFileName}";
                        PathDB = "LightImages/" + newFileName;
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
                Light objLight = new Light
                {
                    LightFilename = newFileName,
                    LightFilePath = PathDB,
                    LightID = Light.LightID,
                    LightName = Light.LightName,
                    LightCost = Light.LightCost,
                    LightType = Light.LightType,
                    Createdate = DateTime.Now,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };



                _ILight.UpdateLight(objLight);

                TempData["LightUpdateMessage"] = "Light Saved Successfully";
                ModelState.Clear();
                return View(new Light());
            }
            else
            {

                Light objLight = new Light
                {
                    LightID = Light.LightID,
                    LightName = Light.LightName,
                    LightCost = Light.LightCost,
                    LightType = Light.LightType,
                    Createdate = DateTime.Now,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };

                _ILight.UpdateLight(objLight);

                TempData["LightUpdateMessage"] = "Light Saved Successfully";
                ModelState.Clear();
                return View(new Light());
            }

        }

        /// <summary>
        /// Delete Lights
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
                    return RedirectToAction("ViewAllLights", "Light");
                }

                int result = _ILight.DeleteLight(Convert.ToInt32(id));

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
        public IActionResult ViewAllLights()
        {
            return View();
        }

        public IActionResult LoadLightData()
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

                var v = _ILight.ShowLight(sortColumn, sortColumnDir, searchValue);
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
