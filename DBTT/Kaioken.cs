using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBZMOD;
using DBZMOD.Util;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;

namespace DBTT
{
    public class Kaioken
    {
        public static void Kaiokencall()
        {
            IL.DBZMOD.Buffs.KaiokenBuff.Update += Kaiokenpower;
          //  IL.DBZMOD.Buffs.KaiokenBuff.Update += Kaiokenspeed; 
            On.DBZMOD.Buffs.KaiokenBuff.GetHealthDrain += KaiokenRework;
        }
       


       public static void Kaiokenuncall()
        {
           // IL.DBZMOD.Buffs.KaiokenBuff.GetHealthDrain -= Kaiokendrain;
            IL.DBZMOD.Buffs.KaiokenBuff.Update -= Kaiokenpower;
        On.DBZMOD.Buffs.KaiokenBuff.GetHealthDrain -= KaiokenRework;
        }
        /*  public static void Kaiokendrain(ILContext iL)
          {
              var c = new ILCursor(iL);
              if (!c.TryGotoNext(i => i.MatchLdcI4(4)))
              {
                  return;
              }
              c.Index++;
              c.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 2);
              var d = new ILCursor(iL);
              if (!d.TryGotoNext(i => i.MatchLdcI4(1)))
              {
                  return;
              }
              d.Index++;
              d.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 0);

              var e = new ILCursor(iL);
              if (!e.TryGotoNext(i => i.MatchLdcI4(8)))
              {
                  return;
              }
              e.Index++;
              e.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_I4, 0);
          }  */
        public static void Kaiokenpower(ILContext iL)
        {
            var damage = new ILCursor(iL);
            if (!damage.TryGotoNext(i => i.MatchLdcR4(0.1f))) //i => i.MatchStfld(out var field) && field.Name == "damageMulti"))
            {
                return;
            }
            damage.Index++;
            damage.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 0.07f);
                var speed = new ILCursor(iL);
                if (!speed.TryGotoNext(i => i.MatchStfld(out var field) && field.Name == "speedMulti") || !speed.TryGotoPrev(i => i.MatchLdcR4(0.1f)))
                {
                    return;
                }
                speed.Index++;
                speed.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 0.07f);
                       var drain = new ILCursor(iL);
                    if (!drain.TryGotoNext(i => i.MatchStfld(out var field) && field.Name == "kiDrainBuffMulti") || !drain.TryGotoPrev(i => i.MatchLdcR4(0.1f)))
                    {
                           return;
                    }
                      drain.Index++;
                      drain.Emit(OpCodes.Pop).Emit(OpCodes.Ldc_R4, 0f);
          }
        private static int KaiokenRework(On.DBZMOD.Buffs.KaiokenBuff.orig_GetHealthDrain orig, MyPlayer modPlayer)
        {
          //  Player player = modPlayer.player;
            var Tplayer = MyPlayer.ModPlayer(modPlayer.player); //make it easier to read
            var kaioken = modPlayer.kaiokenLevel;
            if (!TransformationHelper.IsKaioken(modPlayer.player))
                return 0;
            else if (Tplayer.OverallKiMax() >= 2000 && kaioken == 1)
            {
                return 0;
            }
            else if (Tplayer.OverallKiMax() >= 2500 && kaioken == 2)
            {
                return 0;
            }
            else if (Tplayer.OverallKiMax() >= 3000 && kaioken == 3)
            {
                return 0;
            }
   
            else if (Tplayer.OverallKiMax() >= 3500 && kaioken == 4)
            {
                return 0;
            }
            else if (Tplayer.OverallKiMax() >= 4000 && kaioken == 5)
            {
                return 0;
            }
            return 2 * kaioken;
         /*   else if (MyPlayer.ModPlayer(player).kaioFragment1 && modPlayer.kaiokenLevel == 1)
            {
                return modPlayer.kaiokenLevel;
            }
            else if ((MyPlayer.ModPlayer(player).kaioFragment2 && modPlayer.kaiokenLevel == 2))
            {
                return modPlayer.kaiokenLevel;
            }
            else if ((MyPlayer.ModPlayer(player).kaioFragment3 && modPlayer.kaiokenLevel == 3))
            {
                return modPlayer.kaiokenLevel;
            }
            else if ((MyPlayer.ModPlayer(player).kaioFragment4 && modPlayer.kaiokenLevel == 4))
            {
                return modPlayer.kaiokenLevel;
            }
            return 2 * modPlayer.kaiokenLevel; */ // scrapped

        }
    }
}