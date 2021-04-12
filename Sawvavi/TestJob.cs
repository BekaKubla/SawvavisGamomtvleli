using FuelProject.Models;
using FuelProject.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FuelProject
{
    public class TestJob : ITestJob
    {
        private readonly IFuel _fuel;

        public TestJob(IFuel fuel)
        {
            _fuel = fuel;
        }
        public async Task Job()
        {
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
                _fuel.Create(new FuelPrice()
                {
                    RompetrolPrice = item.InnerText.ToString().Trim(),
                    DateTimeNow = DateTime.Now,
                    PriceCategory = PriceCategory.superi
                });
                _fuel.SaveChange();
            }
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
                _fuel.Create(new FuelPrice()
                {
                    GulfPrice = item.InnerText.ToString().Trim()
                });
                _fuel.SaveChange();
            }
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
            foreach (var item in portalProductList)
            {
                _fuel.Create(new FuelPrice()
                {
                    PortalPrice = item.InnerText.ToString().Trim()

                });
                _fuel.SaveChange();
            }
            //optima scraping

            var optimaUrl = "http://optimapetrol.ge/";

            var optimaHttpClient = new HttpClient();
            var optimaHtml = await optimaHttpClient.GetStringAsync(optimaUrl);
            var optimaHtmlDocument = new HtmlDocument();

            optimaHtmlDocument.LoadHtml(optimaHtml);

            var optimaProductsHtml = optimaHtmlDocument.DocumentNode.Descendants("div")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Contains("container")).ToList();
            var optimaProductList = optimaProductsHtml[4].Descendants("div")
                .Where(o => o.InnerText.StartsWith("1.") || o.InnerText.StartsWith("2.")).ToList();

            foreach (var item in optimaProductList)
            {
                _fuel.Create(new FuelPrice()
                {
                    OptimaPrice = item.InnerText.ToString().Trim()
                });
                _fuel.SaveChange();
            }//socar scraping
            var socarUrl = "https://www.sgp.ge/ge/price";

            var socarHttpClient = new HttpClient();
            var socarHtml = await optimaHttpClient.GetStringAsync(socarUrl);
            var socarHtmlDocument = new HtmlDocument();

            socarHtmlDocument.LoadHtml(socarHtml);


            var socarProductsHtml = socarHtmlDocument.DocumentNode.Descendants("table")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Contains("table table-bordered table-striped")).ToList();
            var socarProductList = socarProductsHtml[0].Descendants("td")
                                   .Where(o => o.InnerText.Contains("1.") || o.InnerText.Contains("2.") || o.InnerText.Contains("3") || o.InnerText.Contains("0"));
            var socarProductListTake = socarProductList.Skip(1).Take(8);
            foreach (var item in socarProductListTake)
            {
                _fuel.Create(new FuelPrice()
                {
                    SocarPrice = item.InnerText.ToString().Trim()
                });
                _fuel.SaveChange();
            }
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

            foreach (var item in lukoilProductList)
            {
                _fuel.Create(new FuelPrice()
                {
                    LukoilPrice = item.InnerText.ToString().Trim()
                });
                _fuel.SaveChange();
            }
        }

    }
}