﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class LanguangesController : ControllerBase
    {
        private readonly Context db = new Context();
        public static IConfigurationRoot Configuration { get; set; }
        private readonly IFileProvider fileProvider;
        public LanguangesController(IFileProvider fileProvider)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            this.fileProvider = fileProvider;
        }


        [HttpGet]
        [Route("GetData")]
        public async Task<List<LanguangesTable>> GetData()
        {
            List<LanguangesTable> languanges = await db.Languanges.ToListAsync();
            return languanges;
        }
    }
}