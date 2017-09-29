using szczepix.RGSystem.Core;
using Sandbox.ModAPI;

namespace szczepix.RGSystem.Module.Connector
{
    public class ModuleConnector : IModule
    {
        private static string Name => "ModuleConnector";
        private static bool Enabled { get; set; }

        public void Enable()
        {
            Logging.Instance.WriteLine("ModuleConnector.Enable() - START");
            Enabled = true;
            Logging.Instance.WriteLine("ModuleConnector.Enable() - END");
        }

        public void Disable()
        {
            Logging.Instance.WriteLine("ModuleConnector.Disable() - START");
            Enabled = false;
            Logging.Instance.WriteLine("ModuleConnector.Disable() - END");
        }
        public string GetName()
        {
            return Name;
        }

        public ModuleConnector()
        {

        }
    }
}
