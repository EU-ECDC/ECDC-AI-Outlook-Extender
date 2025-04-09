using ECDC.OutlookExtender.Helpers;
using ECDC.OutlookExtender.Properties;
using ECDC.Service.Files;
using System;
using System.Threading.Tasks;


namespace ECDC.OutlookExtender.Exceptions
{
    internal class FaultHandledOperation
    {
        public static void Execute(Action action)
        {
            try
            {
                if (SecurityHelper.IsUserInOrganization())
                {
                    action();
                }                
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public static T Execute<T>(Func<T> func)
        {
            try
            {
                if (SecurityHelper.IsUserInOrganization())
                {
                    return func();             
                }              
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return default;
        }

        public static async Task<T> ExecuteAsync<T>(Func<Task<T>> func)
        {
            try
            {
                if (SecurityHelper.IsUserInOrganization())
                {
                    return await func();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return default;
        }

        public static async Task ExecuteAsync(Func<Task> action)
        {
            try
            {
                if (SecurityHelper.IsUserInOrganization())
                {
                    await action();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void HandleException(Exception ex)
        {
            try
            {
                //log the data into files and the system events
                var data = new LoggerDataManager();
                data.Save(ex);
            }
            catch (Exception) { }

            try
            {
                //create an email to support
                var settings = DataFlows.Default;
                var data = new LoggerDataManager();
                string json = data.Load(ex);
                string message = settings.ExceptionMessage
                    .Replace("{FilePath}", data.FilePath())
                    .Replace("{ErrorDetails}", json);
                Globals.ThisAddIn.CreateEmailTo(settings.ExceptionNotificationEmail, message);
            }
            catch (Exception) { }           
        }
    }
}
