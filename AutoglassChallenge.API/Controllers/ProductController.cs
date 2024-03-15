using AutoglassChallenge.API.ResponseBuilder;
using AutoglassChallenge.Application.CustomExceptions;
using AutoglassChallenge.Application.DTOs;
using AutoglassChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoglassChallenge.API.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] ProductDto productDto)
        {
            try
            {
                var response = _productService.CreateProduct(productDto);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithMessage("Produto criado com sucesso.")
                                                    .WithData(response)
                                                    .Build());
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModelBuilder().WithMessage(ex.Message)
                                                            .Build());
            }
        }

        [HttpGet("{productId}")]
        public IActionResult Get([FromRoute] long productId)
        {
            try
            {
                var response = _productService.GetProductById(productId);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithData(response)
                                                    .Build());
            }
            catch (RecordNotFoundException ex)
            {
                return NotFound(new ResponseModelBuilder().WithMessage(ex.Message)
                                                          .Build());
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModelBuilder().WithMessage(ex.Message)
                                                            .Build());
            }
        }

        [HttpGet("get-all/{pageNumber}/{pageSize}")]
        public IActionResult GetFromPagination([FromRoute] int pageNumber, int pageSize)
        {
            try
            {
                var response = _productService.GetProductsFromPagination(pageNumber, pageSize);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithData(response)
                                                    .Build());
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModelBuilder().WithMessage(ex.Message)
                                                            .Build());
            }
        }

        [HttpPut("{productId}")]
        public IActionResult Put([FromRoute] long productId, [FromBody] ProductDto productDto)
        {
            try
            {
                _productService.UpdateProduct(productId, productDto);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithMessage("Produto atualizado com sucesso.")
                                                    .Build());
            }
            catch (RecordNotFoundException ex)
            {
                return NotFound(new ResponseModelBuilder().WithMessage(ex.Message)
                                                          .Build());
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModelBuilder().WithMessage(ex.Message)
                                                            .Build());
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete([FromRoute] long productId)
        {
            try
            {
                _productService.DeleteProduct(productId);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithMessage("Produto removido com sucesso.")
                                                    .Build());
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModelBuilder().WithMessage(ex.Message)
                                                            .Build());
            }
        }
    }
}
