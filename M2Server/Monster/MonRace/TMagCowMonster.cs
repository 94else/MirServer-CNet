﻿using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TMagCowMonster : TATMonster
    {
        public TMagCowMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }

        private void sub_4A9F6C(byte btDir)
        {
            TAbility WAbil;
            int n10;
            TBaseObject BaseObject;
            m_btDirection = btDir;
            WAbil = m_WAbil;
            n10 = HUtil32.Random((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1 + HUtil32.LoWord(WAbil.DC);
            if (n10 > 0)
            {
                SendRefMsg(Grobal2.RM_HIT, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                BaseObject = GetPoseCreate();
                if ((BaseObject != null) && IsProperTarget(BaseObject) && (m_nAntiMagic >= 0))
                {
                    n10 = BaseObject.GetMagStruckDamage(this, n10);
                    if (n10 > 0)
                    {
                        BaseObject.StruckDamage(n10);
                        BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, n10, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, Parse(this), "", 300);
                    }
                }
            }
        }

        public override bool AttackTarget()
        {
            bool result = false;
            byte btDir = 0;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (GetAttackDir(m_TargetCret, ref btDir))
            {
                if ((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    sub_4A9F6C(btDir);
                    BreakHolySeizeMode();
                }
                result = true;
            }
            else
            {
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }
    }
}
