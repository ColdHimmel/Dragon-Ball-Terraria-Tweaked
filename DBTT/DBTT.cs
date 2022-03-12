using Terraria.ModLoader;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using System.Reflection;
using MonoMod.RuntimeDetour.HookGen;
using System;

namespace DBTT
{
	public class DBTT : Mod
	{

        public override void Load()
        {
            Transform.LoadTransform();
            Kiweapon.Kiweaponsload();
            Cheaperconsumables.Cheapercall();
            KiDrain.KiDraincall();
            FormMastery.Masterycall();
            Kaioken.Kaiokencall();
            SSJ.SSJcall();  
            ASSJ.ASSJcall();
            USSJ.USSJcall();
            Superkaioken.CallSuperkaioken();
            SSJ2.SSJ2call();
            SSJ3.SSJ3call();
            SSJG.SSJGcall();
            Legendary.Lssjcall();
        }



        public override void Unload()
        {
          Transform.UnLoadTransform();
            Kiweapon.Kiweaponsunload();
            Cheaperconsumables.CheaperUncall();
            KiDrain.KiDrainUncall();
            FormMastery.Masteryuncall();
             Kaioken.Kaiokenuncall();
            SSJ.SSJUncall();
            ASSJ.ASSJuncall();
            USSJ.USSJuncall();
            Superkaioken.UncallSuperkaioken();
            SSJ2.SSJ2Uncall();
            SSJ3.SSJ3uncall();
            SSJG.SSJGuncall();
            Legendary.Lssjuncall();
        }
    }
}