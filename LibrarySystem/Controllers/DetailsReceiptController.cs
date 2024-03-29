﻿using LibraryApi.services.detailsreceipt;
using LibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsReceiptController : ControllerBase
    {
        private readonly IDetailsReceiptRepository _detailsReceiptRepository ;

        public DetailsReceiptController(IDetailsReceiptRepository detailsReceiptRepository)
        {
            _detailsReceiptRepository = detailsReceiptRepository;
        }
        // GET: api/DetailsReceipt
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<DetailsReceipt>>> GetDetailsReceipt(int id)
        {
            // if(await _productRepository.GetProducts()==null)
            //     return NotFound();

            return Ok(await _detailsReceiptRepository.GetDetailsReceiptByReceiptId(id));
        }

        [HttpPost]
        [ActionName("AddDetailsReceipt")]
        public async Task AddDetailsReceipt(List<DetailsReceipt> detailsReceipts)
        {
            await _detailsReceiptRepository.AddDetailsReceipt(detailsReceipts);
        }

        [HttpDelete]
        [ActionName("refundItems")]
        public async Task refundItems(List<DetailsReceipt> detailsReceipts)
        {
            await _detailsReceiptRepository.refundItems(detailsReceipts);
        }

    }
}
