using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using anhmtps11960_assignmentGD2_net104.Models;
using Microsoft.AspNetCore.Http;

namespace anhmtps11960_assignmentGD2_net104.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly QuanLyBHContext _context;

        public SanPhamsController(QuanLyBHContext context)
        {
            _context = context;
        }
        [Route("InLogin")]
        public IActionResult InLogin()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var Account = await _context.Account.ToListAsync();
            foreach (var item in Account)
            {
                if (username != null && password != null && username.Equals(item.Name) && password.Equals(item.Password))
                {
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("index");
                }
            }
            ViewBag.error = "Tài khoản không hợp lệ!";
            return View("InLogin");
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("InLogin");
        }
        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            ProductModel model = new ProductModel();
            ViewBag.findall = model.FindAll();
            var quanLyBHContext = _context.SanPham.Include(s => s.MaDmNavigation);
            return View(await quanLyBHContext.ToListAsync());
        }
        public IActionResult Laptop()
        {
            ProductModel model = new ProductModel();
            ViewBag.laptop = model.DSlt();
            return View();
        }
        public IActionResult Dienthoai()
        {
            ProductModel model = new ProductModel();
            ViewBag.dienthoai = model.DSdt();
            return View();
        }
        public IActionResult Dongho()
        {
            ProductModel model = new ProductModel();
            ViewBag.dongho = model.DSdh();
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["MaDm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm");
            return View();
        }
        //public async Task<IActionResult> _Layout()
        //{
        //    var quanLyBHContext = _context.SanPham.Include(s => s.MaDmNavigation).GroupBy(s => s.MaDm);
        //    return View(await quanLyBHContext.ToListAsync());
        //}

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,GiaSp,ThongtinSp,Hinhanh,LoaiSp,MaDm")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm", sanPham.MaDm);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaDm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm", sanPham.MaDm);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,TenSp,GiaSp,ThongtinSp,Hinhanh,LoaiSp,MaDm")] SanPham sanPham)
        {
            if (id != sanPham.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSp))
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
            ViewData["MaDm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm", sanPham.MaDm);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPham.Any(e => e.MaSp == id);
        }
    }
}
