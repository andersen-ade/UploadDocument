using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UploadDocumentLearn.Models;
using UploadDocumentLearn.Models.Domain;
using UploadDocumentLearn.Models.DTO;
using UploadDocumentLearn.Repository.Abstract;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private IFileService _fileService;
        private IProductRepository _productRepo;

        public ProductController(DatabaseContext context, IFileService fs, IProductRepository productRepo)
        {
            _context = context;
            _fileService = fs;
            _productRepo = productRepo;
        }

       
        [HttpPost("[action]")]
        public IActionResult Add([FromForm]ProductUploadDto model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass valid data";
                return Ok(status);
            }
            if(model.ImageFile != null || model.ItemImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);

                var fileResult2 = _fileService.SaveProductImage(model.ItemImageFile);

                if (fileResult.Item1 == 1 && fileResult2.Item1 == 1)
                {
                    Product product = new Product()
                    {
                        ProductName = model.ProductName,
                        ProductImage = fileResult.Item2,
                        ItemImage = fileResult2.Item2,
                    };

                    _context.Product.Add(product);
                    _context.SaveChanges(); //Getting the name of image  

                    /*if (productResult)
                    {
                        status.StatusCode = 1;
                        status.Message = "Added Successfully";
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error on adding Product";
                    }*/

                }
            }
            return Ok(status);

        }

        //[HttpPost]
        //public IActionResult Index (List<IFormFile> formFiles)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
