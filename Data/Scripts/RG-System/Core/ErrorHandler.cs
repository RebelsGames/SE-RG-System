using System;
using Sandbox.ModAPI;
using VRage.Game;

namespace szczepix.RGSystem.Core
{
    public class ErrorHandler
    {
        private static ErrorHandler _instance;
        private static bool _debug;
        public static ErrorHandler Instance
        {
            get
            {
                if (MyAPIGateway.Utilities == null)
                    return null;

                if (_instance == null)
                {
                    _instance = new ErrorHandler();

                    if (MyAPIGateway.Session.OnlineMode == MyOnlineModeEnum.OFFLINE)
                    {
                        _debug = true;
                    }
                }

                return _instance;
            }
        }

        public static void ExceptionScreen(Exception exception, string name = "")
        {
            if (_debug)
            {
                string message = "";
                message += "Message: \n" + exception.Message + "\n\n";
                message += "StackTrace: \n" + exception.StackTrace + "\n\n";
                message += "Source: \n" + exception.Source + "\n\n";
                MyAPIGateway.Utilities.ShowMissionScreen(RGSystem.Name, "Exception: ", name, message, null, "Zamknij");
            }
        }
    }
}
