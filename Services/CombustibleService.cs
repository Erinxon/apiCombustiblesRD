using ApiCombustibles.AppSettingModels;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCombustibles.Models;
using ApiCombustibles.Handles;

namespace ApiCombustibles.Services
{
    public class CombustibleService : ICombustibleService
    {
        private readonly XPathExpression _xpath;
        private readonly UrlPage _UrlPage;

        public CombustibleService(IOptions<UrlPage> urlPage, IOptions<XPathExpression> xpath)
        {
            this._xpath = xpath.Value;
            this._UrlPage = urlPage.Value;
        }

        public async Task<List<Combustible>> GetCombustible()
        {
            var taskhtmlDoc = new Task<HtmlDocument>(GetHtmlDocument);
            taskhtmlDoc.Start();
            var htmlDoc = await taskhtmlDoc;
            taskhtmlDoc.Dispose();
            return  htmlDoc.GetCombustibles(_xpath);
        }
        
        private HtmlDocument GetHtmlDocument()
        {
            HtmlWeb htmlWeb = new();
            return htmlWeb.Load(this._UrlPage.Url);
        }
    }

}
