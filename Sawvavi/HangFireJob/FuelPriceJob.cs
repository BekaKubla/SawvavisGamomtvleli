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
    public class FuelPriceJob : IFuelPriceJob
    {
        private readonly IFuel _fuel;

        public FuelPriceJob(IFuel fuel)
        {
            _fuel = fuel;
        }
        public async Task FuelPriceJobJob()
        {

            //Rompetrol Scraping

            var rompetrolUrl = "https://www.rompetrol.ge/%E1%83%91%E1%83%98%E1%83%96%E1%83%9C%E1%83%94%E1%83%A1%E1%83%98/%E1%83%A2%E1%83%94%E1%83%9C%E1%83%93%E1%83%94%E1%83%A0%E1%83%94%E1%83%91%E1%83%98-%E1%83%90%E1%83%A3%E1%83%A5%E1%83%AA%E1%83%98%E1%83%9D%E1%83%9C%E1%83%94%E1%83%91%E1%83%98";

            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(rompetrolUrl);

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);
            var ProductsHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("table-responsive")).ToList();


            var rompetrolProductList = ProductsHtml[1].Descendants("td")
                .Where(o => o.InnerText.Contains("2")).ToList();
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
            //socar scraping
            var socarUrl = "https://www.sgp.ge/ge/price";

            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            var socarHttpClient = new HttpClient(clientHandler);
            var socarHtml = await socarHttpClient.GetStringAsync(socarUrl);
            var socarHtmlDocument = new HtmlDocument();

            socarHtmlDocument.LoadHtml(socarHtml);


            var socarProductsHtml = socarHtmlDocument.DocumentNode.Descendants("table")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Contains("table table-bordered table-striped")).ToList();
            var socarProductList = socarProductsHtml[0].Descendants("td")
                                   .Where(o => o.InnerText.Contains("1.") || o.InnerText.Contains("2.") || o.InnerText.Contains("3") || o.InnerText.Contains("0"));
            var socarProductListTake = socarProductList.Skip(1).Take(8);
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


            var rompetrolPriceList = new List<double>();
            foreach (var item in rompetrolProductList)
            {
                rompetrolPriceList.Add(Convert.ToDouble(item.InnerText));
            }
            var gulfPriceList = new List<double>();
            foreach (var item in gulfProductList)
            {
                gulfPriceList.Add(Convert.ToDouble(item.InnerText));
            }
            var portalPriceList = new List<double>();
            foreach (var item in portalProductList)
            {
                portalPriceList.Add(Convert.ToDouble(item.InnerText));
            }
            var optimaPriceList = new List<double>();
            foreach (var item in optimaProductList)
            {
                optimaPriceList.Add(Convert.ToDouble(item.InnerText));
            }
            var socarPriceList = new List<double>();
            foreach (var item in socarProductListTake)
            {
                socarPriceList.Add(Convert.ToDouble(item.InnerText));
            }
            var lukoilPriceList = new List<double>();
            foreach (var item in lukoilProductList)
            {
                var lukoilPrice = item.InnerText.ToString().Trim().Replace(':', '.');
                lukoilPriceList.Add(Convert.ToDouble(lukoilPrice));
            }
            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = rompetrolPriceList[0],
                GulfPrice = gulfPriceList[0],
                PortalPrice = 0,
                OptimaPrice = 0,
                SocarPrice = socarPriceList[0],
                LukoilPrice = lukoilPriceList[0],
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.superi
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = rompetrolPriceList[1],
                GulfPrice = gulfPriceList[1],
                PortalPrice = portalPriceList[0],
                OptimaPrice = optimaPriceList[0],
                SocarPrice = socarPriceList[1],
                LukoilPrice = lukoilPriceList[2],
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.premiumi
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = 0,
                GulfPrice = gulfPriceList[3],
                PortalPrice = 0,
                OptimaPrice = 0,
                SocarPrice = 0,
                LukoilPrice = 0,
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.regulari
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = rompetrolPriceList[2],
                GulfPrice = gulfPriceList[2],
                PortalPrice = portalPriceList[1],
                OptimaPrice = optimaPriceList[1],
                SocarPrice = socarPriceList[3],
                LukoilPrice = lukoilPriceList[3],
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.evroregulari
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = rompetrolPriceList[4],
                GulfPrice = gulfPriceList[5],
                PortalPrice = portalPriceList[4],
                OptimaPrice = optimaPriceList[3],
                SocarPrice = socarPriceList[4],
                LukoilPrice = 0,
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.dizeli
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = rompetrolPriceList[3],
                GulfPrice = gulfPriceList[4],
                PortalPrice = portalPriceList[2],
                OptimaPrice = optimaPriceList[2],
                SocarPrice = socarPriceList[5],
                LukoilPrice = lukoilPriceList[4],
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.evrodizeli
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = 0,
                GulfPrice = 0,
                PortalPrice = 0,
                OptimaPrice = 0,
                SocarPrice = socarPriceList[6],
                LukoilPrice = 0,
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.txevadigazi
            });
            _fuel.SaveChange();

            _fuel.Create(new FuelPrice()
            {
                RompetrolPrice = 0,
                GulfPrice = gulfPriceList[6],
                PortalPrice = 0,
                OptimaPrice = 0,
                SocarPrice = socarPriceList[7],
                LukoilPrice = 0,
                DateTimeNow = DateTime.Now,
                FuelCategory = FuelCategory.bunebrivigazi
            });
            _fuel.SaveChange();
        }

    }
}