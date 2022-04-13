using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using TradeCategory.Application.Interfaces;
using TradeCategory.Infra.CrossCutting.IoC;

namespace TradeCategory.Presentation.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IServiceCollection services = new ServiceCollection();
                ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                var tradeAppService = serviceProvider.GetService<ITradeAppService>();

                List<string> results = new List<string>();

                System.Console.WriteLine(":::Input:::");

                System.Console.WriteLine("Reference Date (Format mm/dd/yyyy):");
                DateTime referenceDate = DateTime.Parse(System.Console.ReadLine(), CultureInfo.GetCultureInfo("en-US"));

                System.Console.WriteLine("Trades Number:");
                int tradesNumber = int.Parse(System.Console.ReadLine());

                System.Console.WriteLine("Trade (Ex: 2000000 Private 12/01/2025 false) enter to continue:");
                for (int i = 0; i < tradesNumber; i++)
                {
                    var element = System.Console.ReadLine();

                    Models.Trade trade = new Models.Trade()
                    {
                        Value = double.Parse(element.Split(' ')[0]),
                        ClientSector = element.Split(' ')[1],
                        NextPaymentDate = DateTime.Parse(element.Split(' ')[2], CultureInfo.GetCultureInfo("en-US")),
                        IsPoliticallyExposed = bool.Parse(element.Split(' ')[3])
                    };

                    results.Add(tradeAppService.Trade(referenceDate, trade));                    
                }

                System.Console.WriteLine(string.Empty);
                System.Console.WriteLine(":::Output:::");
                foreach (string result in results)
                    System.Console.WriteLine(result);

                System.Console.ReadKey();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error: " + e.Message);
            }                                   
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
