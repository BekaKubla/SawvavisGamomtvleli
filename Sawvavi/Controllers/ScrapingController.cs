using FuelProject.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            fuels[0].RompetrolPrice = fuels[0].RompetrolPrice + "superi";
            fuels[1].RompetrolPrice = fuels[1].RompetrolPrice + "evropremiumi";
            fuels[2].RompetrolPrice = fuels[2].RompetrolPrice + "evroregulari";
            fuels[3].RompetrolPrice = fuels[3].RompetrolPrice + "evrodizeli";
            fuels[4].RompetrolPrice = fuels[4].RompetrolPrice + "diseli";

            //Gulf Scraping
            var gulfUrl = "https://gulf.ge/ge/fuel_prices";

            var gulfHttpClient = new HttpClient();
            var gulfHtml = await gulfHttpClient.GetStringAsync(gulfUrl);
            var gulfHtmlDocument = new HtmlDocument();

            gulfHtmlDocument.LoadHtml(gulfHtml);


            var gulfProductsHtml = gulfHtmlDocument.DocumentNode.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("prices_cnt")).ToList();

            var gulfProductList = gulfProductsHtml[0].Descendants("td")
                .Where(o => o.InnerText.StartsWith("1.") || o.InnerText.StartsWith("2.")).ToList();

            foreach (var item in gulfProductList)
            {
                fuels.Add(new FuelPrice
                {
                    GulfPrice = item.InnerText.ToString().Trim()
                });
            }
            fuels[5].GulfPrice = fuels[5].GulfPrice + "superi";
            fuels[6].GulfPrice = fuels[6].GulfPrice + "premiumi";
            fuels[7].GulfPrice = fuels[7].GulfPrice + "evroregulari";
            fuels[8].GulfPrice = fuels[8].GulfPrice + "regularri";
            fuels[9].GulfPrice = fuels[9].GulfPrice + "evrodizeli";
            fuels[10].GulfPrice = fuels[10].GulfPrice + "diseli";
            fuels[11].GulfPrice = fuels[11].GulfPrice + "gazi";

            //portal  Scraping
            var portalUrl = "http://portal.com.ge/georgian/home";

            var portalfHttpClient = new HttpClient();
            var portalHtml = await gulfHttpClient.GetStringAsync(portalUrl);
            var portalHtmlDocument = new HtmlDocument();

            portalHtmlDocument.LoadHtml(portalHtml);

            var portalProductsHtml = portalHtmlDocument.DocumentNode.Descendants("div")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Contains("fule_cols")).ToList();

            var portalProductList = portalProductsHtml[0].Descendants("td")
                                  .Where(o => o.InnerText.StartsWith("1.") || o.InnerText.StartsWith("2.")).ToList();
            foreach(var item in portalProductList)
            {
                fuels.Add(new FuelPrice
                {
                    PortalPrice = item.InnerText.ToString().Trim()
                });
            }
            fuels[12].PortalPrice = fuels[12].PortalPrice + "premiumi";
            fuels[13].PortalPrice = fuels[13].PortalPrice + "evroregulari";
            fuels[14].PortalPrice = fuels[14].PortalPrice + "regularri";
            fuels[15].PortalPrice = fuels[15].PortalPrice + "evrodizeli";
            fuels[16].PortalPrice = fuels[16].PortalPrice + "effectivedisseli";
            fuels[17].PortalPrice = fuels[17].PortalPrice + "diseli";

            //optima scraping

            var optimaUrl = "http://optimapetrol.ge/";

            var optimaHttpClient = new HttpClient();
            var optimaHtml = await optimaHttpClient.GetStringAsync(optimaUrl);
            var optimaHtmlDocument = new HtmlDocument();

            optimaHtmlDocument.LoadHtml(optimaHtml);

            var optimaProductsHtml= optimaHtmlDocument.DocumentNode.Descendants("div")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Contains("container")).ToList();
            var optimaProductList = optimaProductsHtml[4].Descendants("div")
                .Where(o => o.InnerText.StartsWith("1.") || o.InnerText.StartsWith("2.")).ToList();

            foreach(var item in optimaProductList)
            {
                fuels.Add(new FuelPrice
                {
                    OptimaPrice = item.InnerText.ToString().Trim()
                });
            }
            fuels[18].OptimaPrice = fuels[18].OptimaPrice + "premiumi";
            fuels[19].OptimaPrice = fuels[19].OptimaPrice + "evroregulari";
            fuels[20].OptimaPrice = fuels[20].OptimaPrice + "evrodizeli";
            fuels[21].OptimaPrice = fuels[21].OptimaPrice + "diseli";

            //socar scraping
            var socarUrl = "https://www.sgp.ge/ge/price";

            var socarHttpClient = new HttpClient();
            var socarHtml = await optimaHttpClient.GetStringAsync(socarUrl);
            var socarHtmlDocument = new HtmlDocument();

            socarHtmlDocument.LoadHtml(socarHtml);


            var socarProductsHtml = socarHtmlDocument.DocumentNode.Descendants("table")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Contains("table table-bordered table-striped")).ToList();
            var socarProductList = socarProductsHtml[0].Descendants("td")
                                   .Where(o => o.InnerText.Contains("1.")||o.InnerText.Contains("2.")||o.InnerText.Contains("3")||o.InnerText.Contains("0"));
            var socarProductListTake = socarProductList.Skip(1).Take(8);
            foreach(var item in socarProductListTake)
            {
                fuels.Add(new FuelPrice
                {
                    SocarPrice = item.InnerText.ToString().Trim()
                });
            }

            fuels[22].SocarPrice = fuels[22].SocarPrice + "superi";
            fuels[23].SocarPrice = fuels[23].SocarPrice + "premiumi";
            fuels[24].SocarPrice = fuels[24].SocarPrice + "regularri";
            fuels[25].SocarPrice = fuels[25].SocarPrice + "evroregulari";
            fuels[26].SocarPrice = fuels[26].SocarPrice + "diseli";
            fuels[27].SocarPrice = fuels[27].SocarPrice + "evrodizeli";
            fuels[28].SocarPrice = fuels[28].SocarPrice + "LPG";
            fuels[29].SocarPrice = fuels[29].SocarPrice + "CNG";


            //lukoil scraping
            var lukoilUrl = "http://www.lukoil.ge/index.php?m=300";

            var lukoilHttpClient = new HttpClient();
            var lukoilHtml = await optimaHttpClient.GetStringAsync(lukoilUrl);
            var lukoilHtmlDocument = new HtmlDocument();

            lukoilHtmlDocument.LoadHtml(lukoilHtml);

            var lukoilProductsHtml = lukoilHtmlDocument.DocumentNode.Descendants("div")
                       .Where(node => node.GetAttributeValue("id", "")
                       .Contains("wrap1")).ToList();

            var lukoilProductList = lukoilProductsHtml[0].Descendants("tr")
                                   .Where(o => o.InnerText.Contains("1:") || o.InnerText.Contains("2:") || o.InnerText.Contains("3:"));

            foreach(var item in lukoilProductList)
            {
                fuels.Add(new FuelPrice
                {
                    LukoilPrice = item.InnerText.ToString().Trim()
                });
            }

            fuels[30].LukoilPrice = fuels[30].LukoilPrice.Replace(":",".") + "ectosupperi";
            fuels[31].LukoilPrice = fuels[31].LukoilPrice.Replace(":", ".") + "superi";
            fuels[32].LukoilPrice = fuels[32].LukoilPrice.Replace(":", ".") + "premiumi";
            fuels[33].LukoilPrice = fuels[33].LukoilPrice.Replace(":", ".") + "evroregulari";
            fuels[34].LukoilPrice = fuels[34].LukoilPrice.Replace(":", ".") + "evrodizeli";


            return View(fuels);
        }
    }
}
