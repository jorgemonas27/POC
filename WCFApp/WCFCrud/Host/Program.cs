using Autofac.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFCrud;
using Autofac;


namespace Host
{
    class Program
    {
        public Program()
        {

        }
        static void Main(string[] args)
        {
            using (var container =
                      BootStrapper.RegisterContainerBuilder().Build())
            {
                var httpLocation = "http://localhost/OrderService";
                Uri address = new Uri(httpLocation);

                var netNamedPipeLocation = "net.pipe://localhost/OrderService/";

                ServiceHost host = new ServiceHost(typeof(OrderService));

                host.AddServiceEndpoint(typeof(IOrderService),
                       new BasicHttpBinding(), httpLocation);

                host.AddServiceEndpoint(typeof(IOrderService),
                    new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                    netNamedPipeLocation);


                IComponentRegistration registration;
                if (!container.ComponentRegistry.TryGetRegistration
                   (new TypedService(typeof(IOrderService)), out registration))
                {
                    Console.WriteLine("The service contract has not been registered in the container.");

                    Console.ReadLine();
                    Environment.Exit(-1);
                }

                host.AddDependencyInjectionBehavior<IOrderService>();
                host.Description.Behaviors.Add(new ServiceMetadataBehavior
                { HttpGetEnabled = true, HttpGetUrl = address });

                // Add MEX endpoint
                host.AddServiceEndpoint(
                    ServiceMetadataBehavior.MexContractName,
                    MetadataExchangeBindings.CreateMexNamedPipeBinding(),
                    netNamedPipeLocation + "mex"
                );

                host.Open();

                Console.WriteLine("The host has been opened.");
                Console.ReadLine();

                host.Close();
                Environment.Exit(0);
            }
        }
    }
}
