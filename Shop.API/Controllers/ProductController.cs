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

        [HttpGet]
        public async Task<IActionResult> GetAllFilteredAsync([FromQuery] ProductFilterDto filter)
        {
            var result = await _productService.GetFilteredAsync(filter);
            return new JsonResult(result);
        }

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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int Id)
        {
            Product product = await _productService.GetByIdAsync(Id);
            if (product == null)
                return NotFound();
            await _productService.DeleteAsync(Id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _productService.DeleteAllAsync();
            return Ok();
        }

        [HttpGet("expensivest")]
        public async Task<IActionResult> GetExpensivestAsync()
        {
            Product result = await _productService.ExpensivestAsync();
            return new JsonResult(result);
        }

        [HttpGet("cheapest")]
        public async Task<IActionResult> GetCheapestAsync()
        {
            Product result = await _productService.CheapestAsync();
            return new JsonResult(result);
        }

        [HttpGet("median")]
        public async Task<IActionResult> GetMedianAsync()
        {
            Product result = await _productService.MedianAsync();
            return new JsonResult(result);
        }

    }
}
