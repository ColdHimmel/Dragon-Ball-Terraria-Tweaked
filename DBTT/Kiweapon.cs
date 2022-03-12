using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil.Cil;
using MonoMod.Cil;
namespace DBTT
{
    class Kiweapon
    {
        public static void Kiweaponsload()
        {
            IL.DBZMOD.Items.Weapons.Tier_4.BigBangAttack.SetDefaults += Bigbangattack;
            IL.DBZMOD.Items.Weapons.Tier_1.KiBlast.SetDefaults += Kiblast;
            IL.DBZMOD.Items.Weapons.Tier_4.SpiritBomb.SetDefaults += Spiritbomb;
            IL.DBZMOD.Items.Weapons.Tier_5.FinalFlash.SetDefaults += FinalFlash;
            IL.DBZMOD.Items.Weapons.Tier_6.FinalShine.SetDefaults += Finalshine;
        }
        public static void Kiweaponsunload()
        {
            IL.DBZMOD.Items.Weapons.Tier_4.BigBangAttack.SetDefaults -= Bigbangattack;
            IL.DBZMOD.Items.Weapons.Tier_1.KiBlast.SetDefaults -= Kiblast;
            IL.DBZMOD.Items.Weapons.Tier_4.SpiritBomb.SetDefaults -= Spiritbomb;
            IL.DBZMOD.Items.Weapons.Tier_5.FinalFlash.SetDefaults -= FinalFlash;
            IL.DBZMOD.Items.Weapons.Tier_6.FinalShine.SetDefaults -= Finalshine;
        }
        public static void Bigbangattack(ILContext iL)
        {
            var bigbang = new ILCursor(iL);
            if (!bigbang.TryGotoNext(i => i.MatchLdcR4(100f)))
            {
                return;
            }
            bigbang.Index++;
            bigbang.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 200f);
        }
        public static void Kiblast(ILContext iL)
        {
            var kiblastReuse = new ILCursor(iL);
            if (!kiblastReuse.TryGotoNext(i => i.MatchLdcI4(0), i => i.MatchStfld(out var field) && field.Name == "autoReuse"))
            {
                return;
            }
            //kiblastReuse.Index++;
            kiblastReuse.Remove();
            kiblastReuse.Emit(OpCodes.Ldc_I4_1);
            var kiblastdmg = new ILCursor(iL);
            if (!kiblastdmg.TryGotoNext(i => i.MatchLdcI4(19), i => i.MatchStfld(out var field) && field.Name == "damage"))
            {
                return;
            }
            kiblastdmg.Index++;
            kiblastdmg.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 22);

            var kiblastcost = new ILCursor(iL);
            if (!kiblastcost.TryGotoNext(i => i.MatchLdcR4(15), i => i.MatchStfld(out var field) && field.Name == "kiDrain"))
            {
                return;
            }
            kiblastcost.Index++;
            kiblastcost.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 10f);
            var kiblastusespeed = new ILCursor(iL);
            if (!kiblastusespeed.TryGotoNext(i => i.MatchLdcI4(22), i => i.MatchStfld(out var field) && field.Name == "useTime"))
            {
                return;
            }
            kiblastusespeed.Index++;
            kiblastusespeed.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 13);
            var kiblastuseani = new ILCursor(iL);
            if (!kiblastuseani.TryGotoNext(i => i.MatchLdcI4(22), i => i.MatchStfld(out var field) && field.Name == "useAnimation"))
            {
                return;
            }
            kiblastuseani.Index++;
            kiblastuseani.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 13);
        }
        public static void Spiritbomb(ILContext iL)
        {
            var Spiritbombdmg = new ILCursor(iL);
            if (!Spiritbombdmg.TryGotoNext(i => i.MatchLdcI4(80), i => i.MatchStfld(out var field) && field.Name == "damage"))
            {
                return;
            }
            Spiritbombdmg.Index++;
            Spiritbombdmg.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 100);
        }
        public static void FinalFlash(ILContext iL)
        {
            var finalflashdmg = new ILCursor(iL);
            if (!finalflashdmg.TryGotoNext(i => i.MatchLdcI4(85), i => i.MatchStfld(out var field) && field.Name == "damage"))
            {
                return;
            }
            finalflashdmg.Index++;
            finalflashdmg.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 110);
                 var finalflashwidth = new ILCursor(iL);
                 if (!finalflashwidth.TryGotoNext(i => i.MatchLdcI4(40), i => i.MatchStfld(out var field) && field.Name == "width"))
                 {
                     return;
                 }
                 finalflashwidth.Index++;
                 finalflashwidth.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 40);
                 var finalflashheight = new ILCursor(iL);
                 if (!finalflashheight.TryGotoNext(i => i.MatchLdcI4(40), i => i.MatchStfld(out var field) && field.Name == "height"))
                 {
                     return;
                 }
                 finalflashheight.Index++;
                 finalflashheight.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 40); 
        }
        public static void Finalshine(ILContext iL)
        {
            var Spiritbombdmg = new ILCursor(iL);
            if (!Spiritbombdmg.TryGotoNext(i => i.MatchLdcI4(122), i => i.MatchStfld(out var field) && field.Name == "damage"))
            {
                return;
            }
            Spiritbombdmg.Index++;
            Spiritbombdmg.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 152);
        }
    }
}

