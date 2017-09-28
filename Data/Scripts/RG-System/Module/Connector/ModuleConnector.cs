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
            Enabled = true;
            MyAPIGateway.Utilities.ShowMessage(RGSystem.Name, Name + " Enabled");
        }

        public void Disable()
        {
            Enabled = false;
            MyAPIGateway.Utilities.ShowMessage(RGSystem.Name, Name + " Disabled");
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
