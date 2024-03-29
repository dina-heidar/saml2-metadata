﻿using AutoMapper;
using BasicSpMetadata.Models;
using Microsoft.AspNetCore.Mvc;
using Saml2Metadata;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace MvcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        public readonly IMapper mapper;
        private readonly IMetadataWriter writer;

        public HomeController(ILogger<HomeController> logger,
            IMapper mapper, IMetadataWriter writer)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.writer = writer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var bsm = new BasicSpMetadataViewModel();
            return View(bsm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BasicSpMetadataViewModel basicSpMetadataVm)
        {
            if (basicSpMetadataVm.SignatureCertificatePfx != null)
            {
                basicSpMetadataVm.Signature = await GetX509Certificate2(basicSpMetadataVm.SignatureCertificatePfx);
            }
            if (basicSpMetadataVm.EncryptingCertificatePfx != null)
            {
                basicSpMetadataVm.EncryptingCertificate.EncryptionCertificate =
                    await GetX509Certificate2(basicSpMetadataVm.EncryptingCertificatePfx);
            }
            if (basicSpMetadataVm.SigningCertificatePfx != null)
            {
                basicSpMetadataVm.SigningCertificate =
                    await GetX509Certificate2(basicSpMetadataVm.SigningCertificatePfx);
            }

            var bsm = mapper.Map<BasicSpMetadataViewModel, Saml2Metadata.BasicSpMetadata>(basicSpMetadataVm);

            var xml = writer.Output(bsm);
            return new ContentResult
            {
                Content = xml.OuterXml,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }

        private async Task<X509Certificate2?> GetX509Certificate2(PfxFile pfxfile)
        {
            if (pfxfile.File?.Length > 0)
            {
                // Uses Path.GetTempFileName to return a full path for a file, including the file name.
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    // The formFile is the method parameter which type is IFormFile
                    // Saves the files to the local file system using a file name generated by the app.
                    await pfxfile.File.CopyToAsync(stream);
                }
                return new X509Certificate2(filePath, pfxfile.Password, X509KeyStorageFlags.Exportable);
            }
            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}