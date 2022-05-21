using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IT_StudioTestTask;
using IT_StudioTestTask.Models;
using Microsoft.AspNetCore.Hosting;

namespace IT_StudioTestTask.Controllers
{
    public class PhotosController : Controller
    {
        private readonly AppDBContent _context;
        private readonly AppDB2Content _context2;

        public PhotosController(AppDBContent context,AppDB2Content context2)
        {
            _context = context;
            _context2 = context2;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
              return _context.Photos != null ? 
                          View(await _context.Photos.ToListAsync()) :
                          Problem("Entity set 'AppDBContent.Photos'  is null.");
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photos == null)
            {
                return NotFound();
            }
            if (!photos.CopyCheck)
            {
                photos.CopyCheck = true;
                CopyPhoto copyPhoto = new CopyPhoto();
                copyPhoto.photosId = photos.Id;
                _context2.Add(copyPhoto);
                await _context.SaveChangesAsync();
                await _context2.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Disription,Image,CopyCheck")] Photos photos)
        {
            if (ModelState.IsValid)
            {
                photos.uploadTime = DateTime.Now;
                photos.ImageSrc = photos.getSrc(photos);
                _context.Add(photos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos.FindAsync(id);
            if (photos == null)
            {
                return NotFound();
            }
            return View(photos);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageSrc,uploadTime,Disription")] Photos photos)
        {
            _context.Update(photos);
            await _context.SaveChangesAsync();

            //return View(photos);
            return RedirectToAction(nameof(Index));
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Photos == null)
            {
                return Problem("Entity set 'AppDBContent.Photos'  is null.");
            }
            var photos = await _context.Photos.FindAsync(id);
            if (photos != null)
            {
                string dir = "wwwroot/Images/" + photos.ImageSrc;
                System.IO.File.Delete(dir);
                _context.Photos.Remove(photos);
                if (photos.CopyCheck)
                {
                    var copephoto = await _context2.CopyPhoto.Where(c => c.photosId == id).FirstAsync();
                    _context2.CopyPhoto.Remove(copephoto);
                    await _context2.SaveChangesAsync();


                }
                
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotosExists(int id)
        {
          return (_context.Photos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
