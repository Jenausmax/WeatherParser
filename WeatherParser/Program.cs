using HtmlAgilityPack;
using System;

namespace WeatherParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"https://yandex.ru/pogoda/?lat=52.654678&lon=41.871662&via=hnav";
            var htmlTambov = @"https://yandex.ru/pogoda/213";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var htmlHead = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='title title_level_1 header-title__title']");
            var htmlNodesFact = htmlDoc.DocumentNode.SelectNodes("//div[@class='temp fact__temp fact__temp_size_s']//span");
            var nodeYesterday = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/div[2]/div[1]/div[3]");
            var time = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[3]/div[2]/div[1]/div[3]/time").Attributes.AttributesWithName("datetime");
            var veter = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/div[2]/div[1]/div[7]/div[1]/div[2]");
            var humidity = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/div[2]/div[1]/div[7]/div[2]");
            var pressure = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/div[2]/div[1]/div[7]/div[3]");


            foreach (var item in time)
            {
                Console.WriteLine("DateTime: " + item.Value);
            }
            Console.WriteLine(htmlHead.InnerText);
            

            foreach (var item in htmlNodesFact)
            {
                Console.WriteLine(item.InnerText);
            }

            foreach (var item in nodeYesterday)
            {
                Console.WriteLine(item.InnerText);
            }
            foreach (var pres in pressure)
            {
                Console.WriteLine("Давление: " + pres.InnerText);
            }

            foreach (var hum in humidity)
            {
                Console.WriteLine("Влажность: " + hum.InnerText);
            }

            foreach (var Veter in veter)
            {
                Console.WriteLine("Ветер: " + Veter.InnerText);
            }

            Console.ReadLine();
        }
    }
}
