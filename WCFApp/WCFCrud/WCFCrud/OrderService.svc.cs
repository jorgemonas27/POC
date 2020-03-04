﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BussinessLogic.Managers;
using DataAccessNF.Models;
using DataAccessNF.Services;
using WCFCrud.ModelsDTO;
using WCFCrudUtililies.Global.Repositories;


namespace WCFCrud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {

        //IDataRepository<ClientOrder> _orderRepository = app["OrderManager"];

        //private readonly IDataRepository<ClientOrder> _dataRepository;
        //public OrderService(IDataRepository<ClientOrder> repository)
        //{
        //    _dataRepository = repository;
        //}

        public OrderService()
        {

        }
        public string DeleteData(string id)
        {
            //_dataRepository.Delete(Convert.ToInt32(id));
            return "Deleted succesfully";
        }

        public ClientOrder GetCertainData(string id)
        {
            return new ClientOrder();// _dataRepository.Get(Convert.ToInt32(id));
        }

        public IEnumerable<ClientOrder> GetData()
        {
            return new List<ClientOrder>();//_dataRepository.GetAll();
        }

        public string InsertData(OrderDTO order)
        {
            if (order == null)
            {
                return "bad request";
            }

            var newOrder = Convertes.Converter.GetClientOrderObject(order);
            //_dataRepository.Add(newOrder);
            OrderManager orderManager = new OrderManager();
            orderManager.Save(newOrder);
            return "added successfully";
        }

        public string UpdateData(string id, OrdDetails order)
        {
            if(order == null)
            {
                return "bad request";
            }

            //var updateOrder = Convertes.Converter.GetClientOrderObject(order);
            //_dataRepository.Update(Convert.ToInt32(id), updateOrder);
            return ("updated successfully");
        }
    }
}
