using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Models;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly Context db = new Context();
        public static IConfigurationRoot Configuration { get; set; }
        private readonly IFileProvider fileProvider;
        public BillsController(IFileProvider fileProvider)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            this.fileProvider = fileProvider;
        }


        [HttpGet]
        [Route("GetNumber")]
        public async Task<NumberModel> GetNumber()
        {
            string code = "#INV-";
            List<BillsTable> currencies = await db.Bills.ToListAsync();
            int no = currencies.Count;
            string lastNumber = (no + 1).ToString();
            if (lastNumber.Length == 2)
            {
                lastNumber = "0" + lastNumber;
            }
            else if (lastNumber.Length == 1)
            {
                lastNumber = "00" + lastNumber;
            }
            NumberModel model = new NumberModel()
            {
                Number = code + lastNumber
            };
            return model;
        }

        

        [HttpPost]
        [Route("InsertBills")]
        public async Task<string> InsertBills(BillPostModel model)
        {
            try
            {
                DateTime date = DateTime.ParseExact(model.Date.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                BillsTable bills = new BillsTable()
                {
                    BillId = model.BillId,
                    Number = model.Number,
                    LanguangeId = model.LanguangeId,
                    CurrencyId = model.CurrencyId,
                    From = model.From,
                    DestinationId = model.DestinationId,
                    Date = date,
                    InvoiceDue = model.InvoiceDue,
                    PurchaseOrderId = model.PurchaseOrderId,
                    MeasurementId = model.MeasurementId,
                    SubTotal = decimal.Parse(model.SubTotal.Replace(".", ",")),
                    Discount = decimal.Parse(model.Discount.Replace(".",",")),
                    Total = decimal.Parse(model.Total.Replace(".", ",")),
                    DiscountName = model.DiscountName,
                    Status = model.Status,
                };
                await db.Bills.AddAsync(bills);
                await db.SaveChangesAsync();
                return bills.Number + " successfully added";
            }
            catch (Exception x)
            {
                return x.Message.ToString();
            }
        }

        [HttpPost]
        [Route("InsertBillDetail")]
        public async Task<string> InsertBillDetail(BillDetailPostModel model)
        {
            try
            {
                BillDetailsTable bills = new BillDetailsTable()
                {
                    BillDetailId = Guid.NewGuid().ToString(),
                    BillId = model.BillId,
                    Name = model.Name,
                    Quantity = decimal.Parse(model.Quantity.Replace(".", ",")),
                    Rate = decimal.Parse(model.Rate.Replace(".", ",")),
                    Amount = decimal.Parse(model.Amount.Replace(".", ",")),
                };
                await db.BillDetails.AddAsync(bills);
                await db.SaveChangesAsync();
                return "Success";
            }
            catch (Exception x)
            {
                return x.Message.ToString();
            }
        }


    }
}