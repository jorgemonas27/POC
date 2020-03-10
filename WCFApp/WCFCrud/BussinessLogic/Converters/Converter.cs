using DataAccessNF.Models;
using ModelsDB;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Converters
{
    public static class Converter
    {
        public static IList<OrderDTO> Cast(IEnumerable<OrderDB> orders)
        {
            var orderList = new List<OrderDTO>();
            foreach (var order in orders)
            {
                var newObject = new OrderDTO()
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
                orderList.Add(newObject);
            }

            return orderList;
        }
        public static IList<OrderDB> Cast(IEnumerable<OrderDTO> orders)
        {
            var orderList = new List<OrderDB>();
            foreach (var order in orders)
            {
                var newObject = new OrderDB()
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
                orderList.Add(newObject);
            }

            return orderList;
        }
        public static IList<LoadDTO> Cast(IEnumerable<LoadDB> loads)
        {
            var loadList = new List<LoadDTO>();
            foreach (var load in loads)
            {
                var cast = new LoadDTO()
                {
                    IdLoad = load.IdLoad,
                    Shipments = Cast(load.Shipments),
                    StopsLoad = load.StopsLoad,
                    TotalDistanceLoad = load.TotalDistanceLoad,
                    TruckLoad = load.TruckLoad,
                    QuantityShipmentsLoad = load.QuantityShipmentsLoad,
                    TotalCostLoad = load.TotalCostLoad
                };
                loadList.Add(cast);
            }

            return loadList;
        }

        public static IList<ShipmentDTO> Cast(IEnumerable<ShipmentDB> orders)
        {
            var shipmentList = new List<ShipmentDTO>();
            foreach (var order in orders)
            {
                var newObject = new ShipmentDTO()
                {
                    IdShipment = order.IdShipment,
                    Orders = Cast(order.Orders),
                    Quantity = order.Quantity,
                    TotalWeigthOrders = order.TotalWeigthOrders,
                    IdLoad = order.IdLoad
                };
                shipmentList.Add(newObject);
            }

            return shipmentList;
        }

        public static IList<ShipmentDB> Cast(IEnumerable<ShipmentDTO> orders)
        {
            var shipmentList = new List<ShipmentDB>();
            foreach (var order in orders)
            {
                var newObject = new ShipmentDB()
                {
                    IdShipment = order.IdShipment,
                    Orders = Cast(order.Orders),
                    Quantity = order.Quantity,
                    TotalWeigthOrders = order.TotalWeigthOrders,
                    IdLoad = order.IdLoad
                };
                shipmentList.Add(newObject);
            }

            return shipmentList;
        }

        public static OrderDB Cast(OrderDTO order)
        {
            var newObject = new OrderDB()
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

        public static LoadDB Cast(LoadDTO load)
        {
            var newObject = new LoadDB()
            {
                IdLoad = load.IdLoad,
                Shipments = Cast(load.Shipments),
                StopsLoad = load.StopsLoad,
                TotalDistanceLoad = load.TotalDistanceLoad,
                TruckLoad = load.TruckLoad,
                QuantityShipmentsLoad = load.QuantityShipmentsLoad,
                TotalCostLoad = load.TotalCostLoad
            };

            return newObject;
        }
        public static ShipmentDB Cast(ShipmentDTO shipment)
        {
            var newObject = new ShipmentDB()
            {
                IdLoad = shipment.IdLoad,
                Quantity = shipment.Quantity,
                TotalWeigthOrders = shipment.TotalWeigthOrders,
                IdShipment = shipment.IdShipment,
                Orders = Cast(shipment.Orders)
            };

            return newObject;
        }
    }
}