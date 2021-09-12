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
            var htmlDoc = await GetHtmlDocument();
            return  htmlDoc.GetCombustibles(_xpath);
        }
        
        private async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlWeb htmlWeb = new();
            return await htmlWeb.LoadFromWebAsync(this._UrlPage.Url2);
        }
    }

}
