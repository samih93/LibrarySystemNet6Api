﻿using AutoMapper;
using LibraryApi.services.receipt;
using LibraryModel;
using LibraryModel.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {

        private readonly IReceiptRepository _receiptRepository;


        public ReceiptsController(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }
        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<List<Receipt>>> GetReceipts()
        {
            var receipt = await _receiptRepository.GetReceipts();

            return Ok(receipt);
        }
        [HttpDelete]
        // put: api/Receipts
        public async Task DeleteProduct(int id)
        {

            await _receiptRepository.DeleteReceipt(id);

        }

        // GET: api/Receipts/GetReceiptsByDay?date=
        [HttpGet("GetReceiptsByDay")]
        public async Task<ActionResult<List<Receipt>>> GetReceiptsByDay(DateTime date)
        {
            var receipt = await _receiptRepository.GetReceiptsByDat(date);

            return Ok(receipt);
        }


        // GET: api/Receipts/GetDailyIncome?date=
        [HttpGet("GetDailyIncome")]

        public async Task<ActionResult<double>> GetDailyIncome(DateTime date)  
        {
            var receipt = await _receiptRepository.GetDailyInCome(date);

            return Ok(receipt);
        }

        // GET: api/Receipts/GetDailySaleinMonth
        [HttpGet("GetDailySaleinMonth")]

        public async Task<ActionResult<List<DailySale>>> GetDailySaleinMonth(DateTime date)
        {
             return Ok(await _receiptRepository.GetDailyInComeInMonth(date));

        }





        // POST: api/Receipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Receipt> AddReceipt(Receipt receipt)
        {

            return await _receiptRepository.AddReceipt(receipt);

        }

        // GET: api/Receipts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            try
            {
                if (await _receiptRepository.GetReceipts() == null)
                {
                    return NotFound();
                }

                var result = await _receiptRepository.GetReceipt(id) ;

                if (result == null) return NotFound();

                return  Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
