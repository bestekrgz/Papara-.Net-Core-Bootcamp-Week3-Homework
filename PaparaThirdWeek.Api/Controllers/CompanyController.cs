using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.DTOs;

namespace PaparaThirdWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }


        [HttpGet("Companies")]
        public IActionResult Get()
        {
            var result = companyService.GetAll();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            companyService.GetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CompanyDto company)
        {
            var companyDto = new Company
            {
                Name = company.Name,
                Adress = company.Adress,
                City = company.City,
                CreatedBy = "Samet",
                CreatedDate = System.DateTime.Now,
                Email = company.Email,
                IsDeleted = false,
                TaxNumber = company.TaxNumber
            };
            companyService.Add(companyDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Company company)
        {
            companyService.Update(company);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Company company)
        {
            companyService.HardRemove(company);
            return Ok();
        }

    }
}