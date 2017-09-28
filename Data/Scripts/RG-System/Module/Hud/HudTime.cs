using System;
using szczepix.RGSystem.Module.Hud;
using Sandbox.ModAPI;
using VRage.Game.Components;

[MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
public class HudTime : MySessionComponentBase
{
    bool initialize = true;

    public override void UpdateBeforeSimulation()
    {
        if (ModuleHud.Enabled)
        {
            if (MyAPIGateway.Utilities.IsDedicated && MyAPIGateway.Multiplayer.IsServer) return;
            if (MyAPIGateway.Session == null) return;
            if (initialize)
            {
                MyAPIGateway.Utilities.GetObjectiveLine().Title = DateTime.Now.ToShortTimeString();
                MyAPIGateway.Utilities.GetObjectiveLine().Objectives.Add(null);
                MyAPIGateway.Utilities.GetObjectiveLine().Show();
            }
        }
    }
}