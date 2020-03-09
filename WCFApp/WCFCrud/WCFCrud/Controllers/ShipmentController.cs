﻿using BussinessLogic.Managers;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Linq;
using System.Web.Http;

namespace WCFCrud.Controllers
{
    public class ShipmentController : ODataController
    {
        private ShipmentsManager _shipmentManager;
        public ShipmentController()
        {
            _shipmentManager = new ShipmentsManager();
        }

        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_shipmentManager.GetAll().AsQueryable());
        }

        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            return Ok(_shipmentManager.Delete(Convert.ToInt32(id)));
        }

        [HttpGet]
        [ODataRoute("Consolidate")]
        public System.Web.Http.IHttpActionResult Consolidate()
        {
            return Ok(_shipmentManager.Consolidate().AsQueryable());
        }


    }
}