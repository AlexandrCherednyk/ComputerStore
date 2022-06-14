using ComputerShop.Web.Areas.Admin.ViewModels;

namespace ComputerShop.Web.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IReportRepository _reportRepository;

    public ProductController(
        IProductRepository productRepository,
        IManufacturerRepository manufacturerRepository,
        IProductTypeRepository productTypeRepository,
        IWebHostEnvironment webHostEnvironment,
        IReportRepository reportRepository)
    {
        _productRepository = productRepository;
        _manufacturerRepository = manufacturerRepository;
        _productTypeRepository = productTypeRepository;
        _webHostEnvironment = webHostEnvironment;
        _reportRepository = reportRepository;
    }
    public IActionResult Index()
    {

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddProduct()
    {
        List<ProductType> types = await _productTypeRepository.GetProductTypeList();
        List<Manufacturer> manufacturers = await _manufacturerRepository.GetManufacturerList();

        ViewBag.Types = types;
        ViewBag.Manufacturers = manufacturers;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(ProductViewModel product)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"images");
            var extension = Path.GetExtension(product.Image.FileName);

            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                product.Image.CopyTo(fileStreams);
            }

            string imageUrl = @"\images\" + fileName + extension;

            ProductType type = new()
            {
                ID = product.TypeID,
            };

            Manufacturer manufacturer = new()
            {
                ID = product.ManufacturerID,
            };

            await _productRepository.AddProductAsync(new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Type = type,
                Manufacturer = manufacturer,
                Price = product.Price,
                Count = product.Count,
                PathToFile = imageUrl,
            });

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        else
        {
            List<ProductType> types = await _productTypeRepository.GetProductTypeList();
            List<Manufacturer> manufacturers = await _manufacturerRepository.GetManufacturerList();

            ViewBag.Types = types;
            ViewBag.Manufacturers = manufacturers;
        }

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int ID)
    {
        Product product = await _productRepository.GetProductByIDAsync(ID);

        List<ProductType> types = await _productTypeRepository.GetProductTypeList();
        List<Manufacturer> manufacturers = await _manufacturerRepository.GetManufacturerList();

        ViewBag.Types = types;
        ViewBag.Manufacturers = manufacturers;

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Details(Product product, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            Product newProduct = new();

            if(image is not null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images");
                var extension = Path.GetExtension(image.FileName);

                var oldImagePath = Path.Combine(wwwRootPath, product.PathToFile.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    image.CopyTo(fileStreams);
                }

                newProduct.PathToFile = @"\images\" + fileName + extension;
            }
            
            ProductType type = new()
            {
                ID = product.Type.ID,
            };

            Manufacturer manufacturer = new()
            {
                ID = product.Manufacturer.ID,
            };

            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Type = type;
            newProduct.Manufacturer = manufacturer;
            newProduct.Price = product.Price;
            newProduct.Count = product.Count;

            await _productRepository.UpdateProductAsync(newProduct);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        else
        {
            List<ProductType> types = await _productTypeRepository.GetProductTypeList();
            List<Manufacturer> manufacturers = await _manufacturerRepository.GetManufacturerList();

            ViewBag.Types = types;
            ViewBag.Manufacturers = manufacturers;
        }

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Remove(int ID)
    {
        Product product = await _productRepository.GetProductByIDAsync(ID);

        string wwwRootPath = _webHostEnvironment.WebRootPath;

        var oldImagePath = Path.Combine(wwwRootPath, product.PathToFile.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        await _productRepository.RemoveProductAsync(ID);

        return RedirectToAction("Index", "Home", new { area = "Customer" });
    }
}
