﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = Nunu_Beta_Fixed.MenusSettings.Modes.Harass;

namespace Nunu_Beta_Fixed.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }
        public override void Execute()
        {
            if (Settings.UseE && E.IsReady() && Player.Instance.ManaPercent >= Settings.MinMana || Player.Instance.HasBuff("Visions") && Settings.UseE && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (target != null)
                {
                    E.Cast(target);
                    return;
                }
            }
        }
    }
}
