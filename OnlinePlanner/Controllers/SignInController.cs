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
        private readonly SignInContext _context;

        public SignInController(SignInContext context)
        {
            _context = context;
        }

        public IActionResult Login(string username, string password, IEnumerable<SignIn> smodel)
        {
            //System.Diagnostics.Debug.WriteLine(username);
            //ViewData["username"] = username;
            //ViewData["password"] = Data_password;
            //@model IEnumerable<OnlinePlanner.Models.SignIn>
            //System.Diagnostics.Debug.WriteLine(ViewData["username"]);
            //System.Diagnostics.Debug.WriteLine(username);
            //System.Diagnostics.Debug.WriteLine(ViewData["password"]);
            //System.Diagnostics.Debug.WriteLine(password);
            //ViewData["password"] = password;
            //System.Diagnostics.Debug.WriteLine(password);
            System.Diagnostics.Debug.WriteLine(smodel);
            //var model = smodel.GetType().GetProperties();
            //System.Diagnostics.Debug.WriteLine("CONTROLLER: " + model);
            System.Diagnostics.Debug.WriteLine("CONTROLLER: " + smodel.ToArray());
            var model = smodel.ToArray();
            System.Diagnostics.Debug.WriteLine("CONTROLLER: " + model[1]);

            foreach (var item in model)
            {
                System.Diagnostics.Debug.WriteLine("CONTROLLER: " + item);
                System.Diagnostics.Debug.WriteLine("CONTROLLER: " + item.Username);
                System.Diagnostics.Debug.WriteLine("CONTROLLER: " + item.Password);
                //var user = item.Username;
            }
            if (username != null && password != null && username.Equals(username) && password.Equals(password))
            {
                //HttpContext.Session.SetString("username", username);
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
