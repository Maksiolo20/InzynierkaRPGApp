using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;

namespace RPGApp.Controllers
{
    public class MapController : Controller
    {
        private readonly IMap _map;
        public string HostURL { get; set; }
        public MapController(IMap map)
        {
            _map = map;
        }
        [HttpGet]
        public IActionResult Index()
        {
            MapViewModel model = _map.GetMaps();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SelectedMap(string path)
        {
            MapPath viewModel = _map.GetMapPath(HostURL+path);
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Middlewere(string path)
        {
            return RedirectToAction("SelectedMap",path);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMap(MapViewModel model, IFormFile file)
        {
            _map.AddMapToServer(model.AddedMap, file);
            return RedirectToAction("Index");
        }
    }
}
