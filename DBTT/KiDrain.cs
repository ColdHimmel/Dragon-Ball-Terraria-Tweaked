using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Mono.Cecil.Cil;
using System.Reflection;
using MonoMod.RuntimeDetour.HookGen;
using MonoMod.Cil;
namespace DBTT
{
    public class KiDrain
    {
        public static void KiDraincall()
        {
            //var assembly = ModLoader.GetMod("DBZMOD").Code;
            //var type = assembly.GetType("DBZMOD.Buffs.TransBuff");
            //var method = type.GetMethod("Update", BindingFlags.Public | BindingFlags.Instance); //| BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            //HookEndpointManager.Modify(method, new ILContext.Manipulator(KiDrainfix));
            IL.DBZMOD.Buffs.TransBuff.Update += KiDrainfix;
        }
        public static void KiDrainfix(ILContext iL)
        {
            {
                var c = new ILCursor(iL);
                if (!c.TryGotoNext(i => i.MatchLdcI4(0x258)))
                {
                    return;
                }
                c.Index++;
                c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 999999999);
            }
        }
        public static void KiDrainUncall()
        {
            IL.DBZMOD.Buffs.TransBuff.Update -= KiDrainfix;
        }
    }
}
