using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccessNF.Models;
using DataAccessNF.Services;
using WCFCrudUtililies.Global.Repositories;

namespace WCFCrud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {
        private readonly IDataRepository<ClientOrder> _dataRepository;
        public OrderService(IDataRepository<ClientOrder> repository)
        {
            _dataRepository = repository;
        }

        public OrderService()
        {

        }
        public string DeleteData(string id)
        {

            _dataRepository.Delete(Convert.ToInt32(id));
            return "Deleted succesfully";

            //try
            //{
            //    using (var session = NHibernateSession.OpenSession())
            //    {
            //        using (var transaction = session.BeginTransaction())
            //        {
            //            var order = session.Get<ClientOrder>(Convert.ToInt32(id));
            //            session.Delete(order);
            //            transaction.Commit();
            //        }
            //    }
            //    return "Deleted succesfully";
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
        }

        public ClientOrder GetCertainData(string id)
        {
            return _dataRepository.Get(Convert.ToInt32(id));
            //var order = new ClientOrder();
            //try
            //{
            //    using (var session = NHibernateSession.OpenSession())
            //    {
            //        using (var transaction = session.BeginTransaction())
            //        {
            //            order = session.Get<ClientOrder>(Convert.ToInt32(id));
            //        }
            //    }
            //    return order;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
        }

        public IEnumerable<ClientOrder> GetData()
        {
            return _dataRepository.GetAll();
            //using (var session = NHibernateSession.OpenSession())
            //{
            //    var orders = session.Query<ClientOrder>().ToList();
            //    return orders;
            //}
        }

        public string InsertData(OrdDetails order)
        {
            if (order == null)
            {
                return "bad request";
            }
            var newOrder = new ClientOrder()
            {
                IdOrder = order.Id,
                NameOrderField = order.NameOrder,
                DeliveryDateOrderField = order.DeliveryOrder
            };
            _dataRepository.Add(newOrder);
            return "added successfully";
            //try
            //{
            //    using (var session = NHibernateSession.OpenSession())
            //    {
            //        using (var transaction = session.BeginTransaction())
            //        {
            //            ClientOrder newOrder = new ClientOrder()
            //            {
            //                IdOrder = order.Id,
            //                NameOrderField = order.NameOrder,
            //                DeliveryDateOrderField = order.DeliveryOrder
            //            };

            //            session.Save(newOrder);
            //            transaction.Commit();
            //        }
            //    }

            //    return "Added successfully";
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
        }

        public string UpdateData(string id, OrdDetails order)
        {
            if(order == null)
            {
                return "bad request";
            }
            var updateOrder = new ClientOrder()
            {
                NameOrderField = order.NameOrder,
                DeliveryDateOrderField = order.DeliveryOrder
            };
            _dataRepository.Update(Convert.ToInt32(id), updateOrder);
            return ("updated successfully");

            //try
            //{
            //    using (var session = NHibernateSession.OpenSession())
            //    {
            //        using (var transaction = session.BeginTransaction())
            //        {
            //            var orderUpdate = session.Get<ClientOrder>(Convert.ToInt32(id));
            //            orderUpdate.NameOrderField = order.NameOrder;
            //            orderUpdate.DeliveryDateOrderField = order.DeliveryOrder;
            //            session.Update(orderUpdate);
            //            transaction.Commit();
            //        }
            //    }
            //    return $"updated {order.NameOrder}";
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
        }
    }
}
