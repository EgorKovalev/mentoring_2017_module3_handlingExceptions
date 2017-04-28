using System;
using Attributes.BLExceptions;
using Attributes.DALExceptions;
using Domain.Entities;
using Domain.Models;
using Services.Concrete;
using System.Configuration;
using System.Text;
using Attributes.Logger;

namespace Runner
{
    class Program
    {
		private static string pathToDLALog = ConfigurationManager.AppSettings["dalLogFile"];
		private static string pathToBLLog = ConfigurationManager.AppSettings["blLogFile"];
		private static string pathToSysLog = ConfigurationManager.AppSettings["sysLogFile"];

        static void Main()
        {
			string basePath = AppDomain.CurrentDomain.BaseDirectory;

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

				string path = new StringBuilder(basePath).Append(pathToDLALog).ToString();
				string message = String.Format("{0} - data access layer exception has been threw in object {1}", errorMessage, additional);

				ILogger logger = new Logger();
				logger.Write(path, message);
			}
			catch(BLBaseException blEx)
			{
				string errorMessage = blEx.Message;
				string additional = blEx.AdditionalDetails;

				string path = new StringBuilder(basePath).Append(pathToBLLog).ToString();
				string message = String.Format("{0} - business layer exception has been threw in object {1}", errorMessage, additional);

				ILogger logger = new Logger();
				logger.Write(path, message);
			}
			catch(SystemException ex)
			{
				string errorMessage = ex.Message;

				string path = new StringBuilder(basePath).Append(pathToSysLog).ToString();
				string message = String.Format("{0} - system exception has been threw", errorMessage);
				
				ILogger logger = new Logger();
				logger.Write(path, message);
			}
        }
    }
}
