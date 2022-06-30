using DOAN_WEB_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace DOAN_WEB_1.Controllers
{
    public class SanphamController : Controller
    {
        DataQLWebIPDataContext data = new DataQLWebIPDataContext();
        private List<SANPHAM> Layiphonemoi(int count)
        {
            return data.SANPHAMs.OrderByDescending(a => a.NgayCapNhap).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);

            var iphonemoi = Layiphonemoi(7);
            return View(iphonemoi.ToPagedList(pageSize,pageNum));
        }
        // GET: Sanpham
        public ActionResult Detail(int id)
        {
            var iphone = from x in data.SANPHAMs
                       where x.MaSP == id
                       select x;
            return View(iphone.Single());
        }
    }
}