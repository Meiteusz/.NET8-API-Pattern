using AutoglassChallenge.API.ResponseBuilder;
using AutoglassChallenge.Application.CustomExceptions;
using AutoglassChallenge.Application.DTOs;
using AutoglassChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoglassChallenge.API.Controllers
{
    [ApiController]
    [Route("api/v1/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] SupplierDto productDto)
        {
            try
            {
                var response = _supplierService.CreateSupplier(productDto);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithMessage("Fornecedor criado com sucesso.")
                                                    .WithData(response)
                                                    .Build());
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModelBuilder().WithMessage(ex.Message)
                                                            .Build());
            }
        }

        [HttpGet("{supplierId}")]
        public IActionResult Get([FromRoute] long supplierId)
        {
            try
            {
                var response = _supplierService.GetSupplierById(supplierId);

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
                var response = _supplierService.GetSuppliersFromPagination(pageNumber, pageSize);

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

        [HttpPut("{supplierId}")]
        public IActionResult Put([FromRoute] long supplierId, [FromBody] SupplierDto supplierDto)
        {
            try
            {
                _supplierService.UpdateSupplier(supplierId, supplierDto);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithMessage("Fornecedor atualizado com sucesso.")
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

        [HttpDelete("{supplierId}")]
        public IActionResult Delete([FromRoute] long supplierId)
        {
            try
            {
                _supplierService.DeleteSupplier(supplierId);

                return Ok(new ResponseModelBuilder().WithSuccess()
                                                    .WithMessage("Fornecedor removido com sucesso.")
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
