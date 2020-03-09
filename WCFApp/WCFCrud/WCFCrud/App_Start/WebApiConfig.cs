using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WCFCrud.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", "odata", GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "WCFCrud.ModelsDTO";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<ModelsDTO.OrderDTO>("Order");
            builder.EntitySet<ModelsDTO.ShipmentDTO>("Shipment");
            builder.EntitySet<ModelsDTO.LoadDTO>("Load");
            builder.Function("Consolidate")
                .Returns<List<ModelsDTO.ShipmentDTO>>();
            builder.Function("Build")
                .Returns<List<ModelsDTO.LoadDTO>>();
            IEdmModel edmModel = builder.GetEdmModel();
            return edmModel;
        }

    }
}