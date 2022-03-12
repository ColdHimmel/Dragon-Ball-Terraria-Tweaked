using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil.Cil;
using MonoMod.Cil;
namespace DBTT
{
    public class Cheaperconsumables
    {
        public static void Cheapercall()
        {

            IL.DBZMOD.Items.Consumables.Potions.KiPotion1.AddRecipes += pot1;
            IL.DBZMOD.Items.Consumables.Potions.KiPotion3.AddRecipes += pot3;
            IL.DBZMOD.Items.Consumables.Potions.KiStimulant.SetDefaults += SteroidDuration;
            IL.DBZMOD.Items.Consumables.Potions.KiStimulant.AddRecipes += CheaperSteroid;
        }
        public static void CheaperUncall()
        {
            IL.DBZMOD.Items.Consumables.Potions.KiPotion1.AddRecipes -= pot1;
            IL.DBZMOD.Items.Consumables.Potions.KiPotion3.AddRecipes -= pot3;
            IL.DBZMOD.Items.Consumables.Potions.KiStimulant.SetDefaults -= SteroidDuration;
            IL.DBZMOD.Items.Consumables.Potions.KiStimulant.AddRecipes -= CheaperSteroid;
        }
        public static void SteroidDuration(ILContext iL)
        {
            {
                var duration = new ILCursor(iL);
                if (!duration.TryGotoNext(i => i.MatchLdcI4(0x1C20)))
                {
                    return;
                }
                duration.Index++;
                duration.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 18000);
            }
        }
        public static void CheaperSteroid(ILContext iL)
        {
            var waterleaf = new ILCursor(iL);
            if (!waterleaf.TryGotoNext(i => i.MatchLdcI4(0x13D), i => i.MatchLdcI4(5)))
            {
                return;
            }
            waterleaf.Index+=2;
            waterleaf.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 1);
        }
        public static void pot1(ILContext iL)
        {
            {
                var Waterleaf = new ILCursor(iL);
                if (!Waterleaf.TryGotoNext(i => i.MatchLdcI4(3)))
                {
                    return;
                }
                Waterleaf.Index++;
                Waterleaf.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 1);
            }
        }
        public static void pot3(ILContext iL)
        {
            {
                var waterleaf = new ILCursor(iL);
                if (!waterleaf.TryGotoNext(i => i.MatchLdcI4(0x13D), i => i.MatchLdcI4(3)))
                {
                    return;
                }
                waterleaf.Index+=2;
                waterleaf.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 2);
            }  
        }
    }
}