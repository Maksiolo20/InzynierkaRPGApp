using Microsoft.AspNetCore.Mvc;
using RPGApp.Data;
using RPGApp.Models;
using System.Security.Claims;

namespace RPGApp.Controllers
{
	public class BestiaryCardFileController : Controller
	{
		Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnviroment = null;
		private readonly ApplicationDbContext _context;
		private string UserId;
		public BestiaryCardFileController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			_hostingEnviroment = hostingEnviroment;
		}

		[HttpGet]
		public IActionResult Index(string fileName = "")
		{
			BestiaryCardFileModel fileObj = new BestiaryCardFileModel();
			fileObj.Name = fileName;

			string path = $"{_hostingEnviroment.WebRootPath}\\BestiaryCardFiles\\";
			int nId = 1;
			foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
			{
				string cutPdfPath = pdfPath.Substring(path.Length);
				BestiaryCard cardToPick = _context.BestiaryCards.First(x => x.CardName == cutPdfPath);
				if (cardToPick.SessionId == _context.Users.First(x => x.Id == UserId).CurrentSessionId)
					fileObj.BestiaryCardFiles.Add(new BestiaryCardFileModel()
					{
						FileId = nId++,
						Name = Path.GetFileName(pdfPath),
						Path = pdfPath,

					});
			}
			return View(fileObj);
		}


		[HttpPost]
		public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment, BestiaryCard card)
		{
			string fileName = $"{hostingEnviroment.WebRootPath}\\BestiaryCardFiles\\{file.FileName}";

			card.SessionId = _context.Users.First(x => x.Id == UserId).CurrentSessionId;
			card.CardName = file.FileName;
			_context.BestiaryCards.Add(card);
			_context.SaveChanges();

			using (FileStream fileStream = System.IO.File.Create(fileName))
			{
				file.CopyTo(fileStream);
				fileStream.Flush();
			}
			return Index();
		}
		public IActionResult PDFViewerNewTab(string fileName)
		{
			string path = _hostingEnviroment.WebRootPath + "\\BestiaryCardFiles\\" + fileName;
			return File(System.IO.File.ReadAllBytes(path), "application/pdf");
		}
	}
}
