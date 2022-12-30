using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Services
{
    public class MapService: IMap
    {
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnviroment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public MapService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnviroment = hostingEnviroment;
        }
        public MapViewModel GetMaps()
        {
            string UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            MapViewModel viewModel = new MapViewModel();
            int currentSessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            List<Map> mapsInSession = viewModel.MapsInSession = _context.Maps.Where(x => x.SessionId == currentSessionId).ToList();
            //foreach (var item in mapsInSession)
            //{
            //    item.MapPath = $"{_hostingEnviroment.WebRootPath}\\Maps\\{item.MapPath}";
            //};
            return viewModel;
        }
        public void AddMapToServer(Map model, IFormFile file)
        {
            string UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.SessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
            if (file != null)
            {
                string fileName = $"{_hostingEnviroment.WebRootPath}\\Maps\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                model.MapPath = $"Maps/{file.FileName}";
            }
            _context.Maps.Add(model);
            _context.SaveChanges();
        }
        public string GetURL()
        {
            return _httpContextAccessor.HttpContext.Request.GetDisplayUrl();
        }
        public MapPath GetMapPath(string path)
        {
            return new MapPath() { Result= path };
        }

    }
}
