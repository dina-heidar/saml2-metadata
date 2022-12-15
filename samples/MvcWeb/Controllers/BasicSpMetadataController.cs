using Microsoft.AspNetCore.Mvc;
using Saml.MetadataBuilder;

namespace MvcWeb.Controllers
{
    public class BasicSpMetadataController : Controller
    {
        private readonly ILogger<BasicSpMetadataController> logger;

        public BasicSpMetadataController(ILogger<BasicSpMetadataController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BasicSpMetadata());
        }

        [HttpPost]
        public IActionResult Create(BasicSpMetadata basicSpMetadata)
        {
            return View();
        }
    }
}
