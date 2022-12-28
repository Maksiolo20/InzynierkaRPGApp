using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Controllers
{
    public class HeroController : Controller
    {
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnviroment = null;
		private readonly ApplicationDbContext _context;
		private string UserId;
		public HeroController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
			UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			_hostingEnviroment = hostingEnviroment;
        }

        [HttpGet]
        public IActionResult Index(string fileName = "")
        {
            HeroCardFileModel fileObj = new HeroCardFileModel();
    //        fileObj.Name = fileName;

    //        string path = $"{_hostingEnviroment.WebRootPath}\\HeroCardFiles\\";
    //        int nId = 1;
    //        foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
    //        {
    //            string cutPdfPath = pdfPath.Substring(path.Length);
				//HeroCard cardToPick = _context.HeroCards.First(x=>x.CardPath== cutPdfPath);
    //            if(cardToPick.SessionId == _context.Users.First(x => x.Id == UserId).CurrentSessionId)
				//fileObj.HeroCardFiles.Add(new HeroCardFileModel()
    //            {
    //                FileId = nId++,
    //                Name = Path.GetFileName(pdfPath),
    //                Path = pdfPath,

    //            });
    //        }
            return View(fileObj);
        }


        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment, HeroCard card)
        {
   //         string fileName = $"{hostingEnviroment.WebRootPath}\\HeroCardFiles\\{file.FileName}";

   //         card.SessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
   //         card.CardPath = file.FileName;
			//_context.HeroCards.Add(card);
			//_context.SaveChanges();

			//using (FileStream fileStream = System.IO.File.Create(fileName))
   //         {
   //             file.CopyTo(fileStream);
   //             fileStream.Flush();
   //         }
            return Index();
        }
        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = _hostingEnviroment.WebRootPath + "\\HeroCardFiles\\" + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
    }
}
