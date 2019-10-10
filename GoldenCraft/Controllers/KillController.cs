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

        public ActionResult GetKills()
        {
            JsonResult result = new JsonResult(null);

            try
            {
                var kills = context.Kills.Include(it => it.Player).ToList();

                var graphData = kills
                    .Where(it => it.Player != null)
                    .GroupBy(it => new { it.Player })
                    .Select(it => new { it.Key.Player.UserName, Amount = it.Sum(x => x.Amount) })
                    .ToList();

                result = this.Json(graphData);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return result;
        }
    }
}