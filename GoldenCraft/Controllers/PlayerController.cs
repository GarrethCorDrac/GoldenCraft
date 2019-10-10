using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldenCraft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenCraft.Controllers
{
    public class PlayerController : Controller
    {
        private readonly DataContext db = new DataContext();

        // GET: Player
        public ActionResult Index()
        {
            var players = db.Players.ToList();
            return View(players);
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
     
    }
}