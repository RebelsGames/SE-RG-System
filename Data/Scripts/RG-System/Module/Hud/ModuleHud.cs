using szczepix.RGSystem.Core;
using Sandbox.ModAPI;

namespace szczepix.RGSystem.Module.Hud
{
    public class ModuleHud : IModule
    {
        private static string Name => "ModuleHud";
        public static bool Enabled { get; private set; }

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

        public ModuleHud()
        {
            
        }
    }
}
