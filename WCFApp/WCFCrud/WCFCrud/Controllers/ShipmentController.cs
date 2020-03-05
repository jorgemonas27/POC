using BussinessLogic.Managers;
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

namespace WCFCrud.Controllers
{
    public class ShipmentController: ODataController
    {
        private ShipmentsManager _shipmentManager;
        public ShipmentController()
        {
            _shipmentManager = new ShipmentsManager();
        }

        [EnableQuery]
        [System.Web.Http.HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok("");// Ok(_shipmentManager.GetData().AsQueryable());
        }

        [System.Web.Mvc.HttpPost]
        public string Post()//[System.Web.Http.FromBody] ShipmentDTO newOrder)
        {
            //if (newOrder == null)
            //    return BadRequest();

            _shipmentManager.Save();
            return "done";
        }
    }
}