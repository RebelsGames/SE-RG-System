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
            Logging.Instance.WriteLine("ModuleHud.Enable() - START");
            Enabled = true;
            Logging.Instance.WriteLine("ModuleHud.Enable() - END");
        }

        public void Disable()
        {
            Logging.Instance.WriteLine("ModuleHud.Disable() - START");
            Enabled = false;
            Logging.Instance.WriteLine("ModuleHud.Disable() - END");
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
