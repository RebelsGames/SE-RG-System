using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szczepix.RGSystem.Core;
using Sandbox.ModAPI;
using VRage.Game.Components;

namespace szczepix.RGSystem
{
    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
    public class RGSystem : MySessionComponentBase
    {
        public static RGSystem Instance;
        private bool initialized;
        public static string Name => "RG System";

        public override void UpdateBeforeSimulation()
        {
            if (!initialized)
            {
                InitializeMod();
            }
        }

        private void InitializeMod()
        {
            Instance = this;
            initialized = true;
            StorageModule.Instance.RegisterModuleAll();
        }

        protected override void UnloadData()
        {
        }

        public override void LoadData()
        {
        }

        public override void SaveData()
        {
        }
    }
}