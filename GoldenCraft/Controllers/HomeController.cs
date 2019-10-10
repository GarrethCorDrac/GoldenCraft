using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoldenCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenCraft.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext context = new DataContext();


        public IActionResult Index()
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

        public ActionResult GetMoves()
        {
            JsonResult result = new JsonResult(null);

            try
            {
                var moves = context.Moves.Include(it => it.Player).ToList();

                var types = new string[] { "walking", "boat", "sprinting", "sneaking", "flying" };

                var graphData = moves
                    .GroupBy(it => new { it.Player })
                    .Select(it => new
                    {
                        it.Key.Player.UserName,
                        Walking = it.Where(x=>x.Type.ToLower() == "walking").Sum(x=>x.Amount),
                        Boat = it.Where(x=>x.Type.ToLower() == "boat").Sum(x=>x.Amount),
                        Sprinting = it.Where(x=>x.Type.ToLower() == "sprinting").Sum(x=>x.Amount),
                        Sneaking = it.Where(x=>x.Type.ToLower() == "sneaking").Sum(x=>x.Amount),
                        Flying = it.Where(x=>x.Type.ToLower() == "flying").Sum(x=>x.Amount),
                        Other = it.Where(x => !types.Contains(x.Type.ToLower())).Sum(x => x.Amount)
                    })
                    .ToList();

                result = this.Json(graphData);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return result;
        }

        public ActionResult GetDiamondBreaks()
        {
            JsonResult result = new JsonResult(null);

            try
            {
                var breaks = context.BlockBreaks.Include(it => it.Player).Where(it=>it.Material.ToLower().Contains("diamond")).ToList();

                var graphData = breaks
                    .GroupBy(it => new { it.Player })
                    .Select(it => new
                    {
                        it.Key.Player.UserName,
                        Amount = it.Sum(x=> x.Amount)
                    })
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
