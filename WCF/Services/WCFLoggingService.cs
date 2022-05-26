using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Services
{
    public class WCFLoggingService
    {
        private readonly ILog log;
        public WCFLoggingService()
        {
            //Load log4net Configuration
            XmlConfigurator.Configure();
            //Get logger
            log = LogManager.GetLogger(typeof(WCFLoggingService));
            //Start logging
            log.Debug("WCFLoggingService Call");

        }
    }
}