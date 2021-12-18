using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Services.Interfaces;
using Shop.DAL.Models;
using Shop.DTO;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <remarks>
        /// Insert new Product to database. 
        /// Sample request:
        /// 
        ///   POST dto
        ///   {
        ///    "Name": "Chocolate",
        ///    "Price": 12.9
        ///   }
        ///   
        /// "Name" is required
        /// </remarks>
        /// <param name="dto">New Product.</param>
        /// <returns>OK or BadRequest.</returns>
        /// <response code="200">Insert successfully</response>
        /// <response code="400">Bad model, "Name" empty</response>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<CreateProductDto, Product>(dto);
                await _productService.InsertAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <remarks>
        /// Get filtered Products. 
        /// Sample request:
        /// 
        ///   GET filter
        ///   {
        ///    "pageIndex": 1,
        ///    "pageSize": 12,
        ///    "sortField": price,
        ///    "sort": asc
        ///   }
        ///  
        /// </remarks>
        /// <param name="filter">Filter:
        /// "pageIndex" - The page number, more then 1.
        /// "pageSize" - Number or items in one page,more then 1.
        /// "sortField" - Field which is used for sorting. Two options here: price or name.
        /// "sort" - Sorting direction. Two options here asc or desc. Ascending or descending.
        /// </param>
        /// <returns>OK or BadRequest.</returns>
        /// <response code="200">Insert successfully</response>
        /// <response code="400">Bad model, "Name" empty</response>
        [HttpGet]
        public async Task<IActionResult> GetAllFilteredAsync([FromQuery] ProductFilterDto filter)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.GetFilteredAsync(filter);
            return new JsonResult(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <remarks>
        /// Count all Products in database. 
        /// </remarks>
        /// <returns>int number</returns>
        /// <response code="200">Count successfully</response>
        [HttpGet("count")]
        public async Task<IActionResult> GetCountAsync()
        {
            int result = await _productService.CountAsync();
            return new JsonResult(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int Id)
        {
            Product result = await _productService.GetByIdAsync(Id);
            if (result == null)
                return NotFound();
            return new JsonResult(result);
        }

        /// <remarks>
        /// Deletes a specific Product. 
        /// </remarks>
        /// <param name="id">Id Product, what we want to remove.</param>
        /// <returns>OK or NotFound.</returns>
        /// <response code="200">Deleted successfully</response>
        /// <response code="404">Product not found</response>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int Id)
        {
            Product product = await _productService.GetByIdAsync(Id);
            if (product == null)
                return NotFound();
            await _productService.DeleteAsync(Id);
            return Ok();
        }

        /// <remarks>
        /// Deletes all Products. 
        /// </remarks>
        /// <returns>OK</returns>
        /// <response code="200">Deleted successfully</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _productService.DeleteAllAsync();
            return Ok();
        }

        /// <remarks>
        /// Find the expensivest Product. 
        /// </remarks>
        /// <returns>Product or null</returns>
        /// <response code="200">Find successfully</response>
        [HttpGet("expensivest")]
        public async Task<IActionResult> GetExpensivestAsync()
        {
            Product result = await _productService.ExpensivestAsync();
            return new JsonResult(result);
        }

        /// <remarks>
        /// Find the cheapest Product. 
        /// </remarks>
        /// <returns>Product or null</returns>
        /// <response code="200">Find successfully</response>
        [HttpGet("cheapest")]
        public async Task<IActionResult> GetCheapestAsync()
        {
            Product result = await _productService.CheapestAsync();
            return new JsonResult(result);
        }

        /// <remarks>
        /// Find median Product. 
        /// </remarks>
        /// <returns>Product or null</returns>
        /// <response code="200">Find successfully</response>
        [HttpGet("median")]
        public async Task<IActionResult> GetMedianAsync()
        {
            Product result = await _productService.MedianAsync();
            return new JsonResult(result);
        }

    }
}
