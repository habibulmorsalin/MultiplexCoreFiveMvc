using Microsoft.AspNetCore.Mvc;
using MultiplexCoreFive.Data;
using MultiplexCoreFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplexCoreFive.Controllers
{
    public class CountryController : Controller
    {
        private readonly MultiplexDbContext _multiplexDbContext;

        public CountryController(MultiplexDbContext context)
        {
            _multiplexDbContext = context;
        }

        public IActionResult Index()
        {
            List<Country> countries = new List<Country>();
            try
            {
                countries = _multiplexDbContext.Country.ToList();
            }
            catch (Exception)
            {

            }

            return View(countries);
        }

        public IActionResult Create()
        {
            var model = new Country();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,ShortName")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _multiplexDbContext.Add(country);
                    _multiplexDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to create country.");
            }

            return View(country);
        }

        public IActionResult Edit(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                Country country = _multiplexDbContext.Country.FirstOrDefault(x => x.Id == id);
                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,ShortName")] Country country)
        {
            try
            {
                if (id != country.Id)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    _multiplexDbContext.Update(country);
                    _multiplexDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to create country.");
            }

            return View(country);
        }


        public IActionResult Details(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                Country country = _multiplexDbContext.Country.FirstOrDefault(x => x.Id == id);
                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Delete(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                Country country = _multiplexDbContext.Country.FirstOrDefault(x => x.Id == id);
                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                Country country = new Country { Id = id };
                _multiplexDbContext.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _multiplexDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
