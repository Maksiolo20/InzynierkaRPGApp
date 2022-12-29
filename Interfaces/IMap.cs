using RPGApp.Data;
using RPGApp.Models;

namespace RPGApp.Interfaces
{
    public interface IMap
    {
        public MapViewModel GetMaps();
        public void AddMapToServer(Map model, IFormFile file);
        public MapPath GetMapPath(string name);
        public string GetURL();
    }
}
