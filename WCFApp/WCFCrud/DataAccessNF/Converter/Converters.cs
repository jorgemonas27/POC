using DataAccessNF.Models;
using ModelsDB;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Converter
{
    public class Converters
    {
        public static ClientLoad Cast(LoadDB load)
        {
            var newLoad = new ClientLoad()
            {
                IdLoad = load.IdLoad,
                Shipments = Cast(load.Shipments),
                StopsLoad = load.StopsLoad,
                TotalDistanceLoad = load.TotalDistanceLoad,
                TruckLoad = load.TruckLoad,
                QuantityShipmentsLoad = load.QuantityShipmentsLoad,
                TotalCostLoad = load.TotalCostLoad
            };

            return newLoad;
        }

        public static ClientOrder Cast(OrderDB order)
        {
            var newObject = new ClientOrder()
            {
                IdOrder = order.IdOrder,
                NameCompany = order.NameCompany,
                OriginAddress = order.OriginAddress,
                OriginCity = order.OriginCity,
                OriginState = order.OriginState,
                OriginCountry = order.OriginCountry,
                DestinationAddress = order.DestinationAddress,
                DestinationCity = order.DestinationCity,
                DestinationCountry = order.DestinationCountry,
                DestinationState = order.DestinationState,
                Description = order.Description,
                Status = order.Status,
                IdLoad = order.IdLoad,
                IdShipment = order.IdShipment,
                WeigthOrder = order.WeigthOrder,
                CostOrder = order.CostOrder
            };

            return newObject;
        }

        public static ClientShipment Cast(ShipmentDB order)
        {
            var newObject = new ClientShipment()
            {
               IdShipment = order.IdShipment,
               Orders = Cast(order.Orders),
               QuantityOrders = order.Quantity,
               TotalWeigthOrders = order.TotalWeigthOrders
            };

            return newObject;
        }

        public static IList<ClientShipment> Cast(IList<ShipmentDB> order)
        {
            var list = new List<ClientShipment>();
            foreach (var item in order)
            {
                var newObject = new ClientShipment()
                {
                    IdShipment = item.IdShipment,
                    Orders = Cast(item.Orders),
                    QuantityOrders = item.Quantity,
                    TotalWeigthOrders = item.TotalWeigthOrders
                };
                list.Add(newObject);
            }

            return list;
        }
        public static IList<LoadDB> Cast(IList<ClientLoad> loads)
        {
            var list = new List<LoadDB>();
            foreach (var load in loads)
            {
                var cast = new LoadDB()
                {
                    IdLoad = load.IdLoad,
                    Shipments = Cast(load.Shipments),
                    StopsLoad = load.StopsLoad,
                    TotalDistanceLoad = load.TotalDistanceLoad,
                    TruckLoad = load.TruckLoad,
                    QuantityShipmentsLoad = load.QuantityShipmentsLoad,
                    TotalCostLoad = load.TotalCostLoad
                };
                list.Add(cast);
            }

            return list;
        }

        public static IList<ShipmentDB> Cast(IList<ClientShipment> shipments)
        {
            var list = new List<ShipmentDB>();
            foreach (var ships in shipments)
            {
                var ship = new ShipmentDB()
                {
                    IdShipment = ships.IdShipment,
                    Orders = Cast(ships.Orders),
                    Quantity = ships.QuantityOrders,
                    TotalWeigthOrders = ships.TotalWeigthOrders
                };
                list.Add(ship);
            }

            return list;

        }

        public static IList<OrderDB> Cast(IList<ClientOrder> clientOrders)
        {
            var list = new List<OrderDB>();
            foreach (var order in clientOrders)
            {
                var newobj = new OrderDB()
                {
                    IdOrder = order.IdOrder,
                    NameCompany = order.NameCompany,
                    OriginAddress = order.OriginAddress,
                    OriginCity = order.OriginCity,
                    OriginState = order.OriginState,
                    OriginCountry = order.OriginCountry,
                    DestinationAddress = order.DestinationAddress,
                    DestinationCity = order.DestinationCity,
                    DestinationCountry = order.DestinationCountry,
                    DestinationState = order.DestinationState,
                    Description = order.Description,
                    Status = order.Status,
                    IdLoad = order.IdLoad,
                    IdShipment = order.IdShipment,
                    WeigthOrder = order.WeigthOrder,
                    CostOrder = order.CostOrder
                };
                list.Add(newobj);
            }
            return list;

        }

        public static IList<ClientOrder> Cast(IList<OrderDB> orders)
        {
            var list = new List<ClientOrder>();
            foreach (var order in orders)
            {
                var newobj = new ClientOrder()
                {
                    IdOrder = order.IdOrder,
                    NameCompany = order.NameCompany,
                    OriginAddress = order.OriginAddress,
                    OriginCity = order.OriginCity,
                    OriginState = order.OriginState,
                    OriginCountry = order.OriginCountry,
                    DestinationAddress = order.DestinationAddress,
                    DestinationCity = order.DestinationCity,
                    DestinationCountry = order.DestinationCountry,
                    DestinationState = order.DestinationState,
                    Description = order.Description,
                    Status = order.Status,
                    IdLoad = order.IdLoad,
                    IdShipment = order.IdShipment,
                    WeigthOrder = order.WeigthOrder,
                    CostOrder = order.CostOrder
                };
                list.Add(newobj);
            }
            return list;

        }


    }
}
