using System;
using Attributes.BLExceptions;
using Attributes.DALExceptions;
using Domain.Entities;
using Domain.Models;
using Services.Concrete;
using System.Configuration;

namespace Runner
{
    class Program
    {
		private static string pathToDLALog = ConfigurationManager.AppSettings["dlalogfile"];
		private static string pathToBLLog = ConfigurationManager.AppSettings["bllogfile"];
		private static string pathToSysLog = ConfigurationManager.AppSettings["syslogfile"];

        static void Main()
        {
            try
			{
				OrderService orderService = new OrderService();

				orderService.Add(new OrderModel() { Description = "order model #1", Price = 100 });
				orderService.Add(new OrderModel() { Description = "order model #2", Price = -10 });
				orderService.Add(new OrderModel() { Description = "order model #3", Price = 500 });
				orderService.Add(new OrderModel() { Price = 200 });
			}
			catch(DLABaseException dlaEx)
			{				
				string errorMessage = dlaEx.Message;
				string additional = dlaEx.AdditionalDetails;
			}
			catch(BLBaseException blEx)
			{
				string errorMessage = blEx.Message;
				string additional = blEx.AdditionalDetails;
			}
			catch(SystemException ex)
			{
				string errorMessage = ex.Message;
			}
        }
    }
}
