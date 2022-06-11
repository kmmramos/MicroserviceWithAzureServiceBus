using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    //Note: IProductRepository - show all fixes then implement interface
    public class ProductRepository : IProductRepository
    {
        //NOTE: We have to target a database using dependency injection
        private readonly ApplicationDbContext _db;

        //NOTE: We need Automapper to get the object from DTO
        //We will have to convert that to Product and toggle the database
        private IMapper _mapper;

        //NOTE: Type ctor for the constructor
        //So we can get the implementation inside the program.cs
        //And we will get the implementation to be assigned to the local variables here
        //And we will use them inside our methods.
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            //NOTE: We want to convert ProductDto to Product
            //and assign that to our variable which is product
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            //NOTE: This is to tell if Create or Update action should be used.
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();

            //NOTE: Return converted Product to ProductDto
            return _mapper.Map<Product, ProductDto>(product);   
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            //NOTE: Use FirstOrDefaultAsync because we only have one product here.
            //Add async to method to use FirstOrDefaultAsync
            Product productList = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(productList);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            //NOTE: We will retrieve all of our products from database.
            //To use ToListAsync add async at the method.
            List<Product> productList = await _db.Products.ToListAsync();
            //NOTE: Convert to ProductDto using automapper
            //productList will be converted to ProductDto
            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}
