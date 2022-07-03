using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Services;
using Projeto.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data.SqlClient;
using System.Web;
using System.Data;


namespace Projeto.Controllers
{
    public class AdmController : Controller
    {
        private readonly ProjetoContext _context;

        public AdmController(ProjetoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var List = FindAll();

                return View(List);
            }
            return RedirectToAction("Index", "Home");
        }
        public List<Client> FindAll()
        {
            return _context.Client.ToList();
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(product);
            //create a new Product instance.
            Product newproduct = new Product()
            {
                DescriptionP = product.DescriptionP,
                Price = product.Price,
                Size = product.Size,
                ManufactoringDate = product.ManufactoringDate
            };
            //create a Photo list to store the upload files.
            List<Photo> photolist = new List<Photo>();
            if (product.Files.Count > 0)
            {
                foreach (var formFile in product.Files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            // Upload the file if less than 2 MB
                            if (memoryStream.Length < 2097152)
                            {
                                //based on the upload file to create Photo instance.
                                //You can also check the database, whether the image exists in the database.
                                var newphoto = new Photo()
                                {
                                    Bytes = memoryStream.ToArray(),
                                    DescriptionF = formFile.FileName,
                                    FileExtension = Path.GetExtension(formFile.FileName),
                                    Size = formFile.Length,
                                };
                                //add the photo instance to the list.
                                photolist.Add(newphoto);
                            }
                            else
                            {
                                ModelState.AddModelError("File", "The file is too large.");
                            }
                        }
                    }
                }
            }
            //assign the photos to the Product, using the navigation property.
            newproduct.Photos = photolist;
            _context.Product.Add(newproduct);
            _context.SaveChanges();

            return View();
        }
    }
}