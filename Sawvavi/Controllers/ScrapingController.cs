using FuelProject.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FuelProject.Controllers
{
    public class ScrapingController:Controller
    {
        public async Task<IActionResult> Index()
        {
            //Rompetrol Scraping
            List<FuelPrice> fuels = new List<FuelPrice>();
            var rompetrolUrl = "https://www.rompetrol.ge/%E1%83%91%E1%83%98%E1%83%96%E1%83%9C%E1%83%94%E1%83%A1%E1%83%98/%E1%83%A2%E1%83%94%E1%83%9C%E1%83%93%E1%83%94%E1%83%A0%E1%83%94%E1%83%91%E1%83%98-%E1%83%90%E1%83%A3%E1%83%A5%E1%83%AA%E1%83%98%E1%83%9D%E1%83%9C%E1%83%94%E1%83%91%E1%83%98";

            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(rompetrolUrl);

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);
            var ProductsHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("table-responsive")).ToList();


            var ProductrList = ProductsHtml[1].Descendants("td")
                .Where(o => o.InnerText.Contains("2")).ToList();

            foreach (var item in ProductrList)
            {
                fuels.Add(new FuelPrice()
                {
                    Price = item.InnerText.ToString().Trim()
                });
            }
            fuels.Add(new FuelPrice()
            {
                FuelName = "გაზი"
            });
            fuels[0].FuelName = "სუპერი";
            fuels[1].FuelName = "ევრო პრემიუმი";
            fuels[2].FuelName = "ევრო რეგულარი";
            fuels[3].FuelName = "ევრო დიზელი";
            fuels[4].FuelName = "დიზელი";

            //Gulf Scraping

            var gulfUrl = "https://gulf.ge/ge/fuel_prices";

            var gulfHttpClient = new HttpClient();
            var gulfHtml = await gulfHttpClient.GetStringAsync(gulfUrl);
            var gulfHtmlDocument = new HtmlDocument();

            gulfHtmlDocument.LoadHtml(gulfHtml);


            var GulfProductsHtml = gulfHtmlDocument.DocumentNode.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("prices_cnt")).ToList();

            var gulfProductList = GulfProductsHtml[0].Descendants("td")
                .Where(o => o.InnerText.StartsWith("1.") || o.InnerText.StartsWith("2.")).ToList();

            foreach (var item in gulfProductList)
            {
                fuels.Add(new FuelPrice()
                {
                    Price = item.InnerText.ToString().Trim()
                });
            }
            fuels[6].FuelName = "სუპერი";
            fuels[7].FuelName = "პრემიუმი";
            fuels[8].FuelName = "G-Force ევრო რეგულარი";
            fuels[9].FuelName = "ევრო რეგულარი";
            fuels[10].FuelName = "G-Force ევრო დიზელი";
            fuels[11].FuelName = "ევრო დიზელი";
            fuels[12].FuelName = "გაზი";
            Console.ReadKey();

            return View(fuels);
        }
    }
}
