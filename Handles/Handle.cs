using System.Collections.Generic;
using System.Linq;
using ApiCombustibles.AppSettingModels;
using ApiCombustibles.Models;
using HtmlAgilityPack;

namespace ApiCombustibles.Handles
{
    public static class Handle
    {
        public static List<Combustible> GetCombustibles(this HtmlDocument htmlDoc, XPathExpression xpath)
        {
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes(xpath.XPath).Take(7);
            var combustibles = htmlNodes.Select(n => new Combustible()
            {
                Nombre = n.SelectNodes("td")[(int)EnumCombistible.nombre].InnerText, 
                Precio =  n.SelectNodes("td")[(int)EnumCombistible.precio].InnerText
            }).ToList();
            return combustibles;
        }
    }
}