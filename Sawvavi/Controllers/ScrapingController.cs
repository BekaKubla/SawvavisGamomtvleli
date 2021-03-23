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
                    RompetrolPrice=item.InnerText.ToString().Trim()
                });
            }
            fuels[0].RompetrolName = "Efix სუპერი";
            fuels[1].RompetrolName = "Efix ევრო პრემიუმი";
            fuels[2].RompetrolName = "ევრო რეგულარი";
            fuels[3].RompetrolName = "Efix ევრო დიზელი";
            fuels[4].RompetrolName = "ევრო დიზელი";

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
                fuels.Add(new FuelPrice
                {
                    GulfPrice = item.InnerText.ToString().Trim()
                });

                //fuels.Add(new FuelPrice()
                //{
                //    Price = item.InnerText.ToString().Trim()
                //});
            }
            fuels[5].GulfName = "G-Force სუპერი";
            fuels[6].GulfName = "G-Force პრემიუმი";
            fuels[7].GulfName = "G-Force ევრო რეგულარი";
            fuels[8].GulfName = "ევრო რეგულარი";
            fuels[9].GulfName = "G-Force ევრო დიზელი";
            fuels[10].GulfName = "ევრო დიზელი";
            fuels[11].GulfName = "გაზი";

            return View(fuels);
        }
    }
}
