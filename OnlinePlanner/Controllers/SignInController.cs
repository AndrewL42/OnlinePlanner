using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlinePlanner.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

 //Model IEnumerable<OnlinePlanner.Models.SignIn>

namespace OnlinePlanner.Controllers
{
    public class SignInController : Controller
    {
        private readonly OnlinePlannerContext _context;

        public SignInController(OnlinePlannerContext context)
        {
            _context = context;
        }

        public IActionResult Login(SignIn smodel)
        {
            var username = smodel.Username;
            var password = smodel.Password;

            SignIn data_SignIn = _context.SignIn.Find(username);
            var user_SignIn = data_SignIn.Username;
            var password_SignIn = data_SignIn.Password;

            if (user_SignIn != null && password_SignIn != null && user_SignIn.Equals(username) && password_SignIn.Equals(password))
            {
                return View("~/Views/Home/Index_LoggedIn.cshtml");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("~/Views/Home/Index.cshtml");
            }
        }

        // GET: SignIn
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignIn.ToListAsync());
        }

        // GET: SignIn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // GET: SignIn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Email")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signIn);
        }

        // GET: SignIn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIn.FindAsync(id);
            if (signIn == null)
            {
                return NotFound();
            }
            return View(signIn);
        }

        // POST: SignIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Email")] SignIn signIn)
        {
            if (id != signIn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignInExists(signIn.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(signIn);
        }

        // GET: SignIn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signIn = await _context.SignIn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // POST: SignIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signIn = await _context.SignIn.FindAsync(id);
            _context.SignIn.Remove(signIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignInExists(int id)
        {
            return _context.SignIn.Any(e => e.Id == id);
        }
    }
}
