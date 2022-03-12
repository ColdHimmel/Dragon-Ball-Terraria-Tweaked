using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBZMOD;
using DBZMOD.Effects.Animations.Aura;
using DBZMOD.Enums;
using DBZMOD.Models;
using DBZMOD.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ID;

namespace DBTT
{
    class FormMastery
    { 
        public static void Masterycall()
        {
            IL.DBZMOD.MyPlayer.GetProdigyMasteryMultiplier += SlowerMastery;
        }



        public static void Masteryuncall()
        {
            IL.DBZMOD.MyPlayer.GetProdigyMasteryMultiplier -= SlowerMastery;
        }
        public static void SlowerMastery(ILContext iL)
        {
            var kakarot = new ILCursor(iL);
            if (!kakarot.TryGotoNext(i => i.MatchLdcR4(1f)))
            {
                return;
            }
            kakarot.Index++;
            kakarot.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 0.05f);
            {
                var vegeta = new ILCursor(iL);
                if (!vegeta.TryGotoNext(i => i.MatchLdcR4(2f)))
                {
                    return;
                }
                vegeta.Index++;
                vegeta.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 0.1f);
            }
        }
    }
}