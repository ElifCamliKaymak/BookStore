﻿using BookStore.Entities.LogModels;
using BookStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Presentation.ActionFilter
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LogFilterAttribute(ILoggerService logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInfo(Log("OnActionExecuting", context.RouteData));
        }

        private string Log(string modelName, RouteData RouteData)
        {
            var logDetails = new LogDetails()
            {
                ModelModel = modelName,
                Controller = RouteData.Values["controller"],
                Action = RouteData.Values["action"]
            };

            if(RouteData.Values.Count>=3)
                logDetails.Id = RouteData.Values["Id"];

            return logDetails.ToString();
        }
    }
}
