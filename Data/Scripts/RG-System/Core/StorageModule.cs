using System;
using System.Collections.Generic;
using szczepix.RGSystem.Module.Connector;
using szczepix.RGSystem.Module.Hud;
using Sandbox.ModAPI;

namespace szczepix.RGSystem.Core
{
    public class StorageModule
    {
        private static Dictionary<IModule, bool> _moduleList;
        private static bool _moduleRegistered;
        private static StorageModule _instance;

        private void RegisterModule(IModule module, bool enabled = true)
        {
            _moduleList.Add(module, enabled);
        }

        public void RegisterModuleAll()
        {
            //TODO: getAllModules and RegisterModuleAll automatically
            if (!_moduleRegistered)
            {
                _moduleRegistered = true;


                RegisterModule(new ModuleHud());
                RegisterModule(new ModuleConnector());

                foreach (var module in _moduleList)
                {
                    MyAPIGateway.Utilities.ShowMessage(RGSystem.Name, module.Key.GetName() + " Registered");
                    if (module.Value)
                    {
                        module.Key.Enable();
                    }
                }
            }
        }

        public static StorageModule Instance
        {
            get
            {
                if (MyAPIGateway.Utilities == null)
                    return null;

                if (_instance == null)
                {
                    _instance = new StorageModule();
                    _moduleList = new Dictionary<IModule, bool>();
                }

                return _instance;
            }
        }
    }
}