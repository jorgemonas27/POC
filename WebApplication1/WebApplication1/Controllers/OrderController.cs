using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using ISession = NHibernate.ISession;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IWebHostEnvironment _env; 
        public OrderController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public ActionResult Get()
        {
            using (ISession session = NHibernateSession.OpenSession(_env))
            {
                var orders = session.Query<ClientOrder>().ToList();
                return Ok(orders);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] ClientOrder order)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession(_env))
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(order);
                        transaction.Commit();
                    }
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]ClientOrder order)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession(_env))
                {
                    using (var transaction = session.BeginTransaction())
                    { 
                        var orderUpdate = session.Get<ClientOrder>(id);
                        orderUpdate.NameOrderField = order.NameOrderField;
                        orderUpdate.DeliveryDateOrderField = order.DeliveryDateOrderField;
                        session.Update(orderUpdate);
                        transaction.Commit();
                    }
                }
                return Ok($"updated {order.NameOrderField}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult GetOrder(int id)
        {
            using (var session = NHibernateSession.OpenSession(_env))
            {
                var order = session.Get<ClientOrder>(id);
                return Ok(order);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession(_env))
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var order = session.Get<ClientOrder>(id);
                        session.Delete(order);
                        transaction.Commit();
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}