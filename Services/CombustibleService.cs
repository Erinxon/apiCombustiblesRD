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

        public List<Combustible> GetCombustible()
        {
            var htmlDoc = GetHtmlDocument();
            var combustibles = htmlDoc.GetCombustibles(_xpath);
            return combustibles;
        }
        
        private HtmlDocument GetHtmlDocument()
        {
            HtmlWeb htmlWeb = new();
            return htmlWeb.Load(this._UrlPage.Url);
        }
    }

}
