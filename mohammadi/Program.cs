using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mohammadi.Models.ViewModel;
using Infrastructure.ExMethod;
using Domain;

namespace mohammadi
{
    public class Program
    {
        public static void Main(string[] args)
        {


            //res.ForEach(x =>
            //{
            //    Console.WriteLine(x);
            //});

            //var res = list.FirstOrDefault();

            //Console.WriteLine(res);
            //var result = input.toInt();
            //Console.WriteLine(result);
            // var inputNum = "1a";
            // int intValue = 1;
            // Console.WriteLine(inputNum.StringToInt(intValue));
            // Console.ReadKey();

            //var propertyTest = new PropertyTest();

            //propertyTest.MyProperty = Console.ReadLine();
            //System.Console.WriteLine(propertyTest.MyProperty);
            //Console.ReadKey();
            //var str = string.Format("kdjfdhf{0} {1}", propertyTest.MyProperty, propertyTest.MyProperty);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
public static class emm
{

    public static int toInt(this string inpute)
    {
        try
        {
            var re = int.Parse(inpute);
            return re;
        }
        catch
        {

            return 0;
        }


    }
}
