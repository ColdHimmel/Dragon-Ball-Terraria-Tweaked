using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil.Cil;
using MonoMod.Cil;
namespace DBTT
{
    public class ASSJ
    {
        public static void ASSJcall()
        {
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJpower;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJspeed;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJdrain;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJdefence;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJattackdrain;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJmastereddrain;
        }
        public static void ASSJuncall()
        {
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJpower;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJspeed;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJdrain;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJdefence;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJattackdrain;
            IL.DBZMOD.Buffs.SSJBuffs.ASSJBuff.SetDefaults += ASSJmastereddrain;
        }
        public static void ASSJspeed(ILContext iL)
        {
            {
                var c = new ILCursor(iL);
                if (!c.TryGotoNext(i => i.MatchLdcR4(1.75f), i => i.MatchStfld(out var field) && field.Name == "speedMulti"))
                {
                    return;
                }
                c.Index++;
                c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 1.75f);
            }
        }
        public static void ASSJpower(ILContext iL)
        {
            // iL cursor must match opcodes
            var c = new ILCursor(iL);
            if (!c.TryGotoNext(i => i.MatchLdcR4(1.75f)))
            {
                return;
            }
            c.Index++;
            c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 1.75f);
        }
        public static void ASSJdefence(ILContext iL)
        {
            var c = new ILCursor(iL);
            if (!c.TryGotoNext(i => i.MatchLdcI4(5)))   //i => i.MatchStfld(out var field) && field.Name == "baseDefenceBonus"))
            {
                return;
            }
            c.Index++;
            c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 10);
        }
        public static void ASSJdrain(ILContext iL)
        {
            var c = new ILCursor(iL);
            if (!c.TryGotoNext(i => i.MatchLdcR4(1.15f)))  //,i => i.MatchStfld(out var field) && field.Name == "kiDrainRate"))
            {
                return;
            }
            c.Index++;
            c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 2.30f);
        }
        public static void ASSJmastereddrain(ILContext iL)
        {
            var c = new ILCursor(iL);
            if (!c.TryGotoNext(i => i.MatchLdcR4(0.575f)))
            {
                return;
            }
            c.Index++;
            c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 1.5f);
        }
        public static void ASSJattackdrain(ILContext iL)
        {
            var c = new ILCursor(iL);
            if (!c.TryGotoNext(i => i.MatchLdcR4(1.4F)))
            {
                return;
            }
            c.Index++;
            c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 3.3f);
        }
    }
}

