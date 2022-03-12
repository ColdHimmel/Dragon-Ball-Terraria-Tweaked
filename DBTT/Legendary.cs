using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace DBTT
{
   public  class Legendary
    {
        public static void Lssjcall()
        {
            IL.DBZMOD.Buffs.SSJBuffs.LSSJBuff.SetDefaults += Lssj;
            IL.DBZMOD.Buffs.SSJBuffs.LSSJ2Buff.SetDefaults += Lssj2;
        }
        public static void Lssjuncall()
        {
            IL.DBZMOD.Buffs.SSJBuffs.LSSJBuff.SetDefaults -= Lssj;
            IL.DBZMOD.Buffs.SSJBuffs.LSSJ2Buff.SetDefaults -= Lssj2;
        }


        public static void Lssj(ILContext iL)
        {
            var damage = new ILCursor(iL);
            if (!damage.TryGotoNext(i => i.MatchLdcR4(2.3f))) //i => i.MatchStfld(out var field) && field.Name == "damageMulti"))
            {
                return;
            }
            damage.Index++;
            damage.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 3.2f);
            var speed = new ILCursor(iL);
            if (!speed.TryGotoNext(i => i.MatchLdcR4(2.3f), i => i.MatchStfld(out var field) && field.Name == "speedMulti"))
            {
               return;
            }
             speed.Index++;
             speed.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 3.2f);
            var drain = new ILCursor(iL);
            if (!drain.TryGotoNext(i => i.MatchLdcR4(2.15f)))
            {
                return;
            }
            drain.Index++;
            drain.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 3.5f);
            var defence = new ILCursor(iL);
            if (!defence.TryGotoNext(i => i.MatchLdcI4(6)))
            {
                return;
            }
            defence.Index++;
            defence.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 0);
            var attackdrain = new ILCursor(iL);
            if (!attackdrain.TryGotoNext(i => i.MatchLdcR4(2.1f)))
            {
                return; 
            }
            attackdrain.Index++;
            attackdrain.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 5.5f);
        }
        public static void Lssj2(ILContext iL)
        {
            var Name = new ILCursor(iL);
            if (!Name.TryGotoNext(i => i.MatchLdstr("Legendary Super Saiyan 2"))) //i => i.MatchStfld(out var field) && field.Name == "damageMulti"))
            {
                return;
            }
            Name.Index++;
            Name.Emit(OpCodes.Pop).Emit(OpCodes.Ldstr, "????");
            var damage = new ILCursor(iL);
                if (!damage.TryGotoNext(i => i.MatchLdcR4(3.2f))) //i => i.MatchStfld(out var field) && field.Name == "damageMulti"))
                {
                    return;
                }
                damage.Index++;
                damage.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 4.2f);
                var speed = new ILCursor(iL);
                if (!speed.TryGotoNext(i => i.MatchLdcR4(3.2f), i => i.MatchStfld(out var field) && field.Name == "speedMulti"))
                {
                    return;
                }
                speed.Index++;
                speed.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 4.2f);
                var drain = new ILCursor(iL);
                if (!drain.TryGotoNext(i => i.MatchLdcR4(3f)))
                {
                    return;
                }
                drain.Index++;
                drain.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 20f);
                var defence = new ILCursor(iL);
                if (!defence.TryGotoNext(i => i.MatchLdcI4(12)))
                {
                    return;
                }
                defence.Index++;
                defence.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, -15);
                var attackdrain = new ILCursor(iL);
                if (!attackdrain.TryGotoNext(i => i.MatchLdcR4(2.9f)))
                {
                    return;
                }
                attackdrain.Index++;
                attackdrain.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 0.5f);
        }
    }
}
