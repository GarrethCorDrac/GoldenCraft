using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldenCraft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenCraft.Controllers
{
    public class KillController : Controller
    {
        private readonly DataContext context = new DataContext();

        public ActionResult Index()
        {
            var kills = context.Kills.Include(it => it.Player).ToList();
            return View(kills);
        }

        // GET: Kill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }      
    }
}