using szczepix.RGSystem.Core;
using VRage.Game.Components;

namespace szczepix.RGSystem
{
    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
    public class RGSystem : MySessionComponentBase
    {
        public static RGSystem Instance;
        private bool initialized;
        public static string Name => "RGSystem";

        public override void UpdateBeforeSimulation()
        {
            if (!initialized)
            {
                InitializeMod();
            }
        }

        private void InitializeMod()
        {
            Logging.Instance.WriteLine("RGSystem.InitializeMod() - START");
            Instance = this;
            initialized = true;
            StorageModule.Instance.RegisterModuleAll();
            Logging.Instance.WriteLine("RGSystem.InitializeMod() - END");
        }

        protected override void UnloadData()
        {
            Logging.Instance.WriteLine("RGSystem.UnloadData() - START");
            //Some things
            Logging.Instance.WriteLine("RGSystem.UnloadData() - END");
            Logging.Instance.Close();
        }

        public override void LoadData()
        {

        }

        public override void SaveData()
        {
        }
    }
}