﻿using BussinessLogic.Managers;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper.QueryableExtensions;
using AutoMapper;
using ModelsDTO;
using System.Web.Http;
using System.Configuration;
using Spring.Context;
using Spring.Context.Support;

namespace WCFCrud.Controllers
{
    public class OrderController : ODataController
    {
        #region Config
        private string springManagersFile = ConfigurationManager.AppSettings["springManagersFile"]; // ConfigurationManager.AppSettings["springFactoriesFile"];
        private string springManagers = ConfigurationManager.AppSettings["springManagers"];
        private IManager<OrderDTO> _orderManager;
        protected IApplicationContext context;
        #endregion

        public OrderController()
        {
            context = new XmlApplicationContext(this.springManagers, this.springManagersFile);
            _orderManager = (IManager<OrderDTO>)context["OrderManager"];
        }

        [EnableQuery]
        [System.Web.Http.HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_orderManager.GetAll().AsQueryable());
        }

        [System.Web.Mvc.HttpPost]
        public System.Web.Http.IHttpActionResult Post([System.Web.Http.FromBody] OrderDTO newOrder)
        {
            if (newOrder == null)
                return BadRequest();

            return Ok(_orderManager.Save(newOrder));
        }

        [System.Web.Mvc.HttpPut]
        public System.Web.Http.IHttpActionResult Put([FromODataUri(Name = "key")] string id, [System.Web.Http.FromBody] OrderDTO updateOrder)
        {
            if (updateOrder == null || id == null)
                return BadRequest();

            return Ok(_orderManager.Update(Convert.ToInt32(id), updateOrder));
        }

        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (id == null)
                return BadRequest();

            return Ok(_orderManager.Delete(Convert.ToInt32(id)));
        }
    }
}