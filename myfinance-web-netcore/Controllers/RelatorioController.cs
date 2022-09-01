using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class RelatorioController : Controller
    {
        private readonly ILogger<RelatorioController> _logger;

        public RelatorioController(ILogger<RelatorioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.RelatorioTransacaoPorData(DateTime.Now.AddDays(-10).ToString(), DateTime.Now.ToString() );
            return View();
        }

        [HttpGet]
        public IActionResult Filtrar(String DataInicio, String DataFim)
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.RelatorioTransacaoPorData(DataInicio, DataFim );
            return RedirectToAction("Index");
        }
    }
    
}