using GameFramework;
using M2Server.Base;
using M2Server.Mon;
using M2Server.ScriptSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace M2Server
{
    public class TDefineInfo
    {
        public string sName;
        public string sText;
    }

    public class TQDDinfo
    {
        public int n00;
        public string s04;
        public TStringList sList;
    }

    public class TGoodFileHeader
    {
        public int nItemCount;
        public int[] Resv;
    }

    internal class LocalDB : GameBase
    {
        public static bool isother = false;

        private static readonly object syncObject = new object();

        private static LocalDB singleton;

        public static LocalDB GetInstance()
        {
            if (singleton == null)
            {
                lock (syncObject)
                {
                    if (singleton == null)
                    {
                        singleton = new LocalDB();
                    }
                }

            }
            return singleton;
        }

        public LocalDB()
        {

        }

        /// <summary>
        /// ���ع���Ա�б�
        /// </summary>
        /// <returns></returns>
        public bool LoadAdminList()
        {
            bool result = false;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sIPaddr = string.Empty;
            string sCharName = string.Empty;
            string sData = string.Empty;
            TStringList LoadList;
            TAdminInfo AdminInfo;
            int nLv;
            sFileName = M2Share.g_Config.sEnvirDir + "AdminList.txt";
            if (!File.Exists(sFileName))
            {
                return result;
            }
            try
            {
                UserEngine.m_AdminList.Clear();
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    nLv = -1;
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        if (sLineText[0] == '*')
                        {
                            nLv = 10;
                        }
                        else if (sLineText[0] == '1')
                        {
                            nLv = 9;
                        }
                        else if (sLineText[0] == '2')
                        {
                            nLv = 8;
                        }
                        else if (sLineText[0] == '3')
                        {
                            nLv = 7;
                        }
                        else if (sLineText[0] == '4')
                        {
                            nLv = 6;
                        }
                        else if (sLineText[0] == '5')
                        {
                            nLv = 5;
                        }
                        else if (sLineText[0] == '6')
                        {
                            nLv = 4;
                        }
                        else if (sLineText[0] == '7')
                        {
                            nLv = 3;
                        }
                        else if (sLineText[0] == '8')
                        {
                            nLv = 2;
                        }
                        else if (sLineText[0] == '9')
                        {
                            nLv = 1;
                        }
                        if (nLv > 0)
                        {
                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] { "/", "\\", " ", "\t" });
                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sCharName, new string[] { "/", "\\", " ", "\t" });
                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sIPaddr, new string[] { "/", "\\", " ", "\t" });
                            if ((sCharName == "") || (sIPaddr == ""))
                            {
                                continue;
                            }
                            AdminInfo = new TAdminInfo();
                            AdminInfo.nLv = nLv;
                            AdminInfo.sChrName = sCharName;
                            AdminInfo.sIPaddr = sIPaddr;
                            UserEngine.m_AdminList.Add(AdminInfo);
                        }
                    }
                }
            }
            finally
            {
            }
            result = true;
            return result;
        }

        /// <summary>
        /// ���������б�
        /// </summary>
        /// <returns></returns>
        public int LoadGuardList()
        {
            int result = -1;
            string s14 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            TStringList tGuardList;
            TBaseObject tGuard;
            string sFileName = M2Share.g_Config.sEnvirDir + "GuardList.txt";
            if (File.Exists(sFileName))
            {
                tGuardList = new TStringList();
                tGuardList.LoadFromFile(sFileName);
                if (tGuardList.Count > 0)
                {
                    for (int I = 0; I < tGuardList.Count; I++)
                    {
                        s14 = tGuardList[I];
                        if ((s14 != "") && (s14[0] != ';'))
                        {
                            s14 = HUtil32.GetValidStrCap(s14, ref s1C, new string[] { " " });
                            if ((s1C != "") && (s1C[0] == '\''))
                            {
                                HUtil32.ArrestStringEx(s1C, "\"", "\"", ref s1C);
                            }
                            s14 = HUtil32.GetValidStr3(s14, ref s20, new string[] { " " });
                            s14 = HUtil32.GetValidStr3(s14, ref s24, new string[] { " ", "," });
                            s14 = HUtil32.GetValidStr3(s14, ref s28, new string[] { " ", ",", ":" });
                            s14 = HUtil32.GetValidStr3(s14, ref s2C, new string[] { " ", ":" });
                            if ((s1C != "") && (s20 != "") && (s2C != ""))
                            {
                                tGuard = UserEngine.RegenMonsterByName(s20, HUtil32.Str_ToInt(s24, 0), HUtil32.Str_ToInt(s28, 0), s1C);
                                if (tGuard != null)
                                {
                                    tGuard.m_btDirection = (byte)HUtil32.Str_ToInt(s2C, 0);
                                }
                            }
                        }
                    }
                }
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// ������ҩ�б�
        /// </summary>
        /// <returns></returns>
        public int LoadMakeItem()
        {
            int result = -1;
            int n14;
            string s18;
            string s20 = string.Empty;
            string s24 = string.Empty;
            TStringList LoadList;
            TStringList List28;
            string sFileName = M2Share.g_Config.sEnvirDir + "MakeItem.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                List28 = null;
                s24 = "";
                for (int I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        if (s18[0] == '[')
                        {
                            if (List28 != null)
                            {
                                //  M2Share.g_MakeItemList.Add(s24, List28);
                            }
                            List28 = new TStringList();
                            HUtil32.ArrestStringEx(s18, "[", "]", ref s24);
                        }
                        else
                        {
                            if (List28 != null)
                            {
                                s18 = HUtil32.GetValidStr3(s18, ref s20, new string[] { " ", "\t" });
                                n14 = HUtil32.Str_ToInt(s18.Trim(), 1);
                                // List28.Add(s20, ((n14) as Object));
                            }
                        }
                    }
                }
                if (List28 != null)
                {
                    // M2Share.g_MakeItemList.Add(s24, List28);
                }
                result = 1;
            }
            return result;
        }

        public TMerchant LoadMapInfo_LoadMapQuest(string sName)
        {
            TMerchant result;
            TMerchant QuestNPC;
            QuestNPC = new TMerchant();
            QuestNPC.m_sMapName = "0";
            QuestNPC.m_nCurrX = 0;
            QuestNPC.m_nCurrY = 0;
            QuestNPC.m_sCharName = sName;
            QuestNPC.m_nFlag = 0;
            QuestNPC.m_wAppr = 0;
            QuestNPC.m_sFilePath = "MapQuest_def\\";
            QuestNPC.m_boIsHide = true;
            QuestNPC.m_boIsQuest = false;
            UserEngine.QuestNPCList.Add(QuestNPC);
            result = QuestNPC;
            return result;
        }

        public void LoadMapInfo_LoadSubMapInfo(TStringList LoadList, string sFileName)
        {
            string sFilePatchName;
            string sFileDir;
            TStringList LoadMapList;
            sFileDir = M2Share.g_Config.sEnvirDir + "MapInfo\\";
            if (!Directory.Exists(sFileDir))
            {
                Directory.CreateDirectory(sFileDir);
            }
            sFilePatchName = sFileDir + sFileName;
            if (File.Exists(sFilePatchName))
            {
                LoadMapList = new TStringList();
                LoadMapList.LoadFromFile(sFilePatchName);
                for (int I = 0; I < LoadMapList.Count; I++)
                {
                    // LoadList.Add(LoadMapList[I]);
                }
                LoadMapList.Dispose();
                Dispose(LoadMapList);
                //LoadMapList.Free;
            }
        }

        /// <summary>
        /// // �ж��м���')'��
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int LoadMapInfo_IsStrCount(string str)
        {
            int result = 0;
            if (str.Length <= 0)
            {
                return result;
            }
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if ((new ArrayList(new string[] { ")" }).Contains(str[i])))
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// ���ص�ͼ����
        /// </summary>
        /// <returns></returns>
        public int LoadMapInfo()
        {
            int result;
            string sFileName;
            TStringList LoadList;
            int I;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            string sMapName;
            string sMainMapName = string.Empty;
            string s44;
            string sMapDesc = string.Empty;
            string s4C;
            string sReConnectMap = string.Empty;
            int n14;
            int n18;
            int n1C;
            int n20;
            int nServerIndex;
            TMapFlag MapFlag = null;
            TMerchant QuestNPC;
            string sMapInfoFile;
            result = -1;
            sFileName = M2Share.g_Config.sEnvirDir + "MapInfo.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count < 0)
                {
                    return result;
                }
                I = 0;
                while (true)
                {
                    if (I >= LoadList.Count)
                    {
                        break;
                    }
                    if ((s34 != "") && (s34[0] != '[') && (s34[0] != ';'))
                    {
                        if (HUtil32.CompareLStr("loadmapinfo", LoadList[I], "loadmapinfo".Length))
                        {
                            sMapInfoFile = HUtil32.GetValidStr3(LoadList[I], ref s30, new string[] { " ", "\t" });
                            LoadList.RemoveAt(I);
                            if (sMapInfoFile != "")
                            {
                                LoadMapInfo_LoadSubMapInfo(LoadList, sMapInfoFile);
                            }
                        }
                    }
                    I++;
                }
                result = 1;
                //���ص�ͼ����
                for (I = 0; I < LoadList.Count; I++)
                {
                    s30 = LoadList[I];
                    if ((s30 != "") && (s30[0] == '['))
                    {
                        sMapName = "";
                        s30 = HUtil32.ArrestStringEx(s30, "[", "]", ref sMapName);
                        sMapDesc = HUtil32.GetValidStrCap(sMapName, ref sMapName, new string[] { " ", ",", "\t" });
                        if (sMapName.IndexOf("<") > 0)//�����<>��ͼ��ʶ��
                        {
                            sMapName = HUtil32.ArrestStringEx(sMapName, "<", ">", ref sMainMapName);
                        }
                        else
                        {
                            sMainMapName = HUtil32.GetValidStr3(sMapName, ref sMapName, new string[] { "|", "/", "\\", "\t" }).Trim();//��ȡ�ظ����õ�ͼ
                        }
                        if ((sMapDesc != "") && (sMapDesc[0] == '\'')) // ��ȡ�ظ����õ�ͼ
                        {
                            HUtil32.ArrestStringEx(sMapDesc, "\"", "\"", ref sMapDesc);
                        }
                        s4C = HUtil32.GetValidStr3(sMapDesc, ref sMapDesc, new string[] { " ", ",", "\t" }).Trim();
                        nServerIndex = HUtil32.Str_ToInt(s4C, 0);
                        if (sMapName == "")
                        {
                            continue;
                        }
                        QuestNPC = null;
                        MapFlag = new TMapFlag();
                        MapFlag.boSAFE = false;
                        MapFlag.nNEEDSETONFlag = -1;
                        MapFlag.nNeedONOFF = -1;
                        MapFlag.sUnAllowStdItemsText = "";
                        MapFlag.sUnAllowMagicText = "";
                        MapFlag.boAutoMakeMonster = false;
                        MapFlag.boNOTALLOWUSEMAGIC = false;
                        MapFlag.boFIGHTPK = false;
                        while (true)
                        {
                            if (s30 == "")
                            {
                                break;
                            }
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            if (s34 == "")
                            {
                                break;
                            }
                            MapFlag.nMUSICID = -1;
                            MapFlag.sMUSICName = "";
                            if ((s34).ToLower().CompareTo(("SAFE").ToLower()) == 0)
                            {
                                MapFlag.boSAFE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("DARK").ToLower()) == 0)
                            {
                                MapFlag.boDARK = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT").ToLower()) == 0)
                            {
                                MapFlag.boFIGHT = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT2").ToLower()) == 0)  // PK��װ����ͼ
                            {
                                MapFlag.boFIGHT2 = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT3").ToLower()) == 0)
                            {
                                MapFlag.boFIGHT3 = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT4").ToLower()) == 0)// ��ս��ͼ
                            {
                                MapFlag.boFIGHT4 = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("DAY").ToLower()) == 0)
                            {
                                MapFlag.boDAY = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("QUIZ").ToLower()) == 0)
                            {
                                MapFlag.boQUIZ = true;
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NORECONNECT", 11))
                            {
                                MapFlag.boNORECONNECT = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref sReConnectMap);
                                MapFlag.sReConnectMap = sReConnectMap;
                                if (MapFlag.sReConnectMap == "")
                                {
                                    result = -11;
                                }
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "CHECKQUEST", 10))
                            {
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                QuestNPC = LoadMapInfo_LoadMapQuest(s38);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NEEDSET_ON", 10))
                            {
                                MapFlag.nNeedONOFF = 1;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nNEEDSETONFlag = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NEEDSET_OFF", 11))
                            {
                                MapFlag.nNeedONOFF = 0;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nNEEDSETONFlag = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "MUSIC", 5))
                            {
                                MapFlag.boMUSIC = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nMUSICID = HUtil32.Str_ToInt(s38, -1);
                                MapFlag.sMUSICName = s38;
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "EXPRATE", 7))
                            {
                                MapFlag.boEXPRATE = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nEXPRATE = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKWINLEVEL", 10))
                            {
                                MapFlag.boPKWINLEVEL = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKWINLEVEL = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKWINEXP", 8))
                            {
                                MapFlag.boPKWINEXP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKWINEXP = (uint)HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKLOSTLEVEL", 11))
                            {
                                MapFlag.boPKLOSTLEVEL = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKLOSTLEVEL = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKLOSTEXP", 9))
                            {
                                MapFlag.boPKLOSTEXP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKLOSTEXP = (uint)HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "DECHP", 5))
                            {
                                MapFlag.boDECHP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nDECHPPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nDECHPTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "INCHP", 5))
                            {
                                MapFlag.boINCHP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nINCHPPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nINCHPTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "DECGAMEGOLD", 11))
                            {
                                MapFlag.boDECGAMEGOLD = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nDECGAMEGOLD = (uint)HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nDECGAMEGOLDTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "DECGAMEPOINT", 12))
                            {
                                MapFlag.boDECGAMEPOINT = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nDECGAMEPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nDECGAMEPOINTTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "KILLFUNC", 8))// ��ͼɱ�˴���
                            {
                                MapFlag.boKILLFUNC = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nKILLFUNC = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "INCGAMEGOLD", 11))
                            {
                                MapFlag.boINCGAMEGOLD = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nINCGAMEGOLD = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nINCGAMEGOLDTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "INCGAMEPOINT", 12))
                            {
                                MapFlag.boINCGAMEPOINT = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nINCGAMEPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nINCGAMEPOINTTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            // ------------------------------------------------------------------------------
                            if (HUtil32.CompareLStr(s34, "NEEDLEVELTIME", 13))// ѩ���ͼ����,�жϵȼ�,��ͼʱ��
                            {
                                MapFlag.boNEEDLEVELTIME = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nNEEDLEVELPOINT = HUtil32.Str_ToInt(s38, 0);// ����ͼ��͵ȼ�
                                continue;
                            }
                            // ��ͼ���� NOCALLHERO (��ֹ�ٻ�Ӣ�ۣ����ٻ�Ӣ�۽��Զ���ʧ) 
                            if ((s34).ToLower().CompareTo(("NOCALLHERO").ToLower()) == 0)
                            {
                                MapFlag.boNoCALLHERO = true;
                                continue;
                            }
                            // ��ֹӢ���ػ�
                            if ((s34).ToLower().CompareTo(("NOHEROPROTECT").ToLower()) == 0)
                            {
                                MapFlag.boNOHEROPROTECT = true;
                                continue;
                            }
                            // ��ͼ���� NODROPITEM ��ֹ��������Ʒ
                            if ((s34).ToLower().CompareTo(("NODROPITEM").ToLower()) == 0)
                            {
                                MapFlag.boNODROPITEM = true;
                                continue;
                            }
                            // ��ͼ���� MISSION (������ʹ���κ���Ʒ�ͼ��ܣ����ұ����ڸõ�ͼ���Զ���ʧ�����ܹ���) 
                            if ((s34).ToLower().CompareTo(("MISSION").ToLower()) == 0)
                            {
                                MapFlag.boMISSION = true;
                                continue;
                            }
                            // ------------------------------------------------------------------------------
                            if ((s34).ToLower().CompareTo(("RUNHUMAN").ToLower()) == 0)
                            {
                                MapFlag.boRUNHUMAN = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("RUNMON").ToLower()) == 0)
                            {
                                MapFlag.boRUNMON = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NEEDHOLE").ToLower()) == 0)
                            {
                                MapFlag.boNEEDHOLE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NORECALL").ToLower()) == 0)
                            {
                                MapFlag.boNORECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOGUILDRECALL").ToLower()) == 0)
                            {
                                MapFlag.boNOGUILDRECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NODEARRECALL").ToLower()) == 0)
                            {
                                MapFlag.boNODEARRECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOMASTERRECALL").ToLower()) == 0)
                            {
                                MapFlag.boNOMASTERRECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NORANDOMMOVE").ToLower()) == 0)
                            {
                                MapFlag.boNORANDOMMOVE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NODRUG").ToLower()) == 0)
                            {
                                MapFlag.boNODRUG = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOMANNOMON").ToLower()) == 0)
                            {
                                MapFlag.boNoManNoMon = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("MINE").ToLower()) == 0)
                            {
                                MapFlag.boMINE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOPOSITIONMOVE").ToLower()) == 0)
                            {
                                MapFlag.boNOPOSITIONMOVE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("AUTOMAKEMONSTER").ToLower()) == 0)
                            {
                                MapFlag.boAutoMakeMonster = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHTPK").ToLower()) == 0)
                            {
                                MapFlag.boFIGHTPK = true;
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "THUNDER", 7))
                            {
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nThunder = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "LAVA", 4))// ����ð�ҽ�
                            {
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nLava = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NOTALLOWUSEMAGIC", 16))// ���Ӳ�����ʹ��ħ��
                            {
                                MapFlag.boNOTALLOWUSEMAGIC = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.sUnAllowMagicText = s38.Trim();
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NOTALLOWUSEITEMS", 16)) // ���Ӳ�����ʹ����Ʒ
                            {
                                MapFlag.boUnAllowStdItems = true;
                                if (LoadMapInfo_IsStrCount(s34) > 1)
                                {
                                    // �ж��м���')'
                                    s38 = s34.Substring(s34.IndexOf("(") + 1 - 1, s34.Length - (s34.IndexOf("(") + 1));
                                }
                                else
                                {
                                    HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                }
                                MapFlag.sUnAllowStdItemsText = s38.Trim();
                                continue;
                            }
                        }
                        if (M2Share.g_MapManager.AddMapInfo(sMapName, sMainMapName, sMapDesc, nServerIndex, MapFlag, QuestNPC) == null)//��ӵ���Ϸ��ͼ�б�
                        {
                            result = -10;
                        }
                    }
                    else
                    {
                        // ���ص�ͼ���ӵ�
                        if ((s30 != "") && (s30[0] != '[') && (s30[0] != ';'))
                        {
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            sMapName = s34;
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            n14 = HUtil32.Str_ToInt(s34, 0);
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            n18 = HUtil32.Str_ToInt(s34, 0);
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "-", ">", "\t" });
                            s44 = s34;
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            n1C = HUtil32.Str_ToInt(s34, 0);
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", ";", "\t" });
                            n20 = HUtil32.Str_ToInt(s34, 0);
                            M2Share.g_MapManager.AddMapRoute(sMapName, n14, n18, s44, n1C, n20);
                        }
                    }
                }
            }
            return result;
        }

        public void QFunctionNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList SaveList;
            string sShowFile;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def + "QFunction-0.txt";
                sShowFile = HUtil32.ReplaceChar(sScriptFile, '\\', '/');
                sScritpDir = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def;
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    SaveList = new TStringList();
                    SaveList.Add(";�˽�Ϊ���ܽű�������ʵ�ָ�����ű��йصĹ���");
                    SaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_FunctionNPC = new TMerchant();
                    M2Share.g_FunctionNPC.m_sMapName = "0";
                    M2Share.g_FunctionNPC.m_nCurrX = 0;
                    M2Share.g_FunctionNPC.m_nCurrY = 0;
                    M2Share.g_FunctionNPC.m_sCharName = "QFunction";
                    M2Share.g_FunctionNPC.m_nFlag = 0;
                    M2Share.g_FunctionNPC.m_wAppr = 0;
                    M2Share.g_FunctionNPC.m_sFilePath = M2Share.sMarket_Def;
                    M2Share.g_FunctionNPC.m_sScript = "QFunction";
                    M2Share.g_FunctionNPC.m_boIsHide = true;
                    M2Share.g_FunctionNPC.m_boIsQuest = false;
                    UserEngine.AddMerchant(M2Share.g_FunctionNPC);
                }
                else
                {
                    M2Share.g_FunctionNPC = null;
                }
            }
            catch
            {
                M2Share.g_FunctionNPC = null;
            }
        }

        public void QBatterNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList SaveList;
            string sShowFile;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def + "QBatter-0.txt";
                sShowFile = HUtil32.ReplaceChar(sScriptFile, '\\', '/');
                sScritpDir = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def;
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    SaveList = new TStringList();
                    SaveList.Add(";�˽ű�Ϊ�������ܽű�");
                    SaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_BatterNPC = new TMerchant();
                    M2Share.g_BatterNPC.m_sMapName = "0";
                    M2Share.g_BatterNPC.m_nCurrX = 0;
                    M2Share.g_BatterNPC.m_nCurrY = 0;
                    M2Share.g_BatterNPC.m_sCharName = "QBatter";
                    M2Share.g_BatterNPC.m_nFlag = 0;
                    M2Share.g_BatterNPC.m_wAppr = 0;
                    M2Share.g_BatterNPC.m_sFilePath = M2Share.sMarket_Def;
                    M2Share.g_BatterNPC.m_sScript = "QBatter";
                    M2Share.g_BatterNPC.m_boIsHide = true;
                    M2Share.g_BatterNPC.m_boIsQuest = false;
                    UserEngine.AddMerchant(M2Share.g_BatterNPC);
                }
                else
                {
                    M2Share.g_BatterNPC = null;
                }
            }
            catch
            {
                M2Share.g_BatterNPC = null;
            }
        }

        public void QMangeNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList SaveList;
            string sShowFile;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + "MapQuest_def\\" + "QManage.txt";
                sShowFile = HUtil32.ReplaceChar(sScriptFile, '\\', '/');
                sScritpDir = M2Share.g_Config.sEnvirDir + "MapQuest_def\\";
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    SaveList = new TStringList();
                    SaveList.Add(";�˽�Ϊ��¼�ű�������ÿ�ε�¼ʱ����ִ�д˽ű������������ʼ���ö����Է��ڴ˽ű��С�");
                    SaveList.Add(";�޸Ľű����ݣ�����@ReloadManage�������¼��ظýű���������������");
                    SaveList.Add("[@Login]");
                    SaveList.Add("#if");
                    SaveList.Add("#act");
                    SaveList.Add(";����10��ɱ�־���");
                    SaveList.Add(";CANGETEXP 1 10");
                    SaveList.Add("#say");
                    SaveList.Add("������Զ������Ľű��ļ�����ӭ���뱾��Ϸ������\\ \\");
                    SaveList.Add("<�ر�/@exit> \\ \\");
                    SaveList.Add("��¼�ű��ļ�λ��: \\");
                    SaveList.Add(sShowFile + "\\");
                    SaveList.Add("�ű����������а��Լ���Ҫ���޸ġ�");
                    SaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_ManageNPC = new TMerchant();
                    M2Share.g_ManageNPC.m_sMapName = "0";
                    M2Share.g_ManageNPC.m_nCurrX = 0;
                    M2Share.g_ManageNPC.m_nCurrY = 0;
                    M2Share.g_ManageNPC.m_sCharName = "QManage";
                    M2Share.g_ManageNPC.m_nFlag = 0;
                    M2Share.g_ManageNPC.m_wAppr = 0;
                    M2Share.g_ManageNPC.m_sFilePath = "MapQuest_def\\";
                    M2Share.g_ManageNPC.m_boIsHide = true;
                    M2Share.g_ManageNPC.m_boIsQuest = false;
                    UserEngine.QuestNPCList.Add(M2Share.g_ManageNPC);
                }
                else
                {
                    M2Share.g_ManageNPC = null;
                }
            }
            catch
            {
                M2Share.g_ManageNPC = null;
            }
        }

        public void RobotNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList tSaveList;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + "Robot_def\\RobotManage.txt";
                sScritpDir = M2Share.g_Config.sEnvirDir + "Robot_def\\";
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    tSaveList = new TStringList();
                    tSaveList.Add(";�˽�Ϊ������ר�ýű������ڻ����˴������õĽű���");
                    tSaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_RobotNPC = new TMerchant();
                    M2Share.g_RobotNPC.m_sMapName = "0";
                    M2Share.g_RobotNPC.m_nCurrX = 0;
                    M2Share.g_RobotNPC.m_nCurrY = 0;
                    M2Share.g_RobotNPC.m_sCharName = "RobotManage";
                    M2Share.g_RobotNPC.m_nFlag = 0;
                    M2Share.g_RobotNPC.m_wAppr = 0;
                    M2Share.g_RobotNPC.m_sFilePath = "Robot_def\\";
                    M2Share.g_RobotNPC.m_boIsHide = true;
                    M2Share.g_RobotNPC.m_boIsQuest = false;
                    UserEngine.QuestNPCList.Add(M2Share.g_RobotNPC);
                }
                else
                {
                    M2Share.g_RobotNPC = null;
                }
            }
            catch
            {
                M2Share.g_RobotNPC = null;
            }
        }

        /// <summary>
        /// ���ص�ͼ�¼�
        /// </summary>
        /// <returns></returns>
        public int LoadMapEvent()
        {
            int result;
            string sFileName;
            string tStr;
            TStringList tMapEventList;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s36 = string.Empty;
            string s38 = string.Empty;
            string s40 = string.Empty;
            string s42 = string.Empty;
            string s44 = string.Empty;
            string s46 = string.Empty;
            string sRange = string.Empty;
            TMapEvent MapEvent;
            TEnvirnoment Map;
            result = 1;
            sFileName = M2Share.g_Config.sEnvirDir + "MapEvent.txt";
            if (File.Exists(sFileName))
            {
                tMapEventList = new TStringList();
                tMapEventList.LoadFromFile(sFileName);
                if (tMapEventList.Count > 0)
                {
                    for (int I = 0; I < tMapEventList.Count; I++)
                    {
                        tStr = tMapEventList[I];
                        if ((tStr != "") && (tStr[0] != ';'))
                        {
                            tStr = HUtil32.GetValidStr3(tStr, ref s18, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s1C, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s20, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref sRange, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s24, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s28, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s2C, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s30, new string[] { " ", "\t" });
                            if ((s18 != "") && (s1C != "") && (s20 != "") && (s30 != ""))
                            {
                                Map = M2Share.g_MapManager.FindMap(s18);
                                if (Map != null)
                                {
                                    MapEvent = new TMapEvent();
                                    MapEvent.m_MapFlag = new TQuestUnitStatus();
                                    MapEvent.m_Condition = new TMapCondition();
                                    MapEvent.m_StartScript = new TStartScript();
                                    MapEvent.m_sMapName = s18.Trim();
                                    MapEvent.m_nCurrX = HUtil32.Str_ToInt(s1C, 0);
                                    MapEvent.m_nCurrY = HUtil32.Str_ToInt(s20, 0);
                                    MapEvent.m_nRange = HUtil32.Str_ToInt(sRange, 0);
                                    s24 = HUtil32.GetValidStr3(s24, ref s34, new string[] { ":", "\t" });
                                    s24 = HUtil32.GetValidStr3(s24, ref s36, new string[] { ":", "\t" });
                                    MapEvent.m_MapFlag.nQuestUnit = HUtil32.Str_ToInt(s34, 0);
                                    if (HUtil32.Str_ToInt(s36, 0) != 0)
                                    {
                                        MapEvent.m_MapFlag.boOpen = true;
                                    }
                                    else
                                    {
                                        MapEvent.m_MapFlag.boOpen = false;
                                    }
                                    s28 = HUtil32.GetValidStr3(s28, ref s38, new string[] { ":", "\t" });
                                    s28 = HUtil32.GetValidStr3(s28, ref s40, new string[] { ":", "\t" });
                                    s28 = HUtil32.GetValidStr3(s28, ref s42, new string[] { ":", "\t" });
                                    MapEvent.m_Condition.nHumStatus = HUtil32.Str_ToInt(s38, 0);
                                    MapEvent.m_Condition.sItemName = s40.Trim();
                                    if (HUtil32.Str_ToInt(s42, 0) != 0)
                                    {
                                        MapEvent.m_Condition.boNeedGroup = true;
                                    }
                                    else
                                    {
                                        MapEvent.m_Condition.boNeedGroup = false;
                                    }
                                    MapEvent.m_nRandomCount = HUtil32.Str_ToInt(s2C, 999999);
                                    s30 = HUtil32.GetValidStr3(s30, ref s44, new string[] { ":", "\t" });
                                    s30 = HUtil32.GetValidStr3(s30, ref s46, new string[] { ":", "\t" });
                                    MapEvent.m_StartScript.nLable = HUtil32.Str_ToInt(s44, 0);
                                    MapEvent.m_StartScript.sLable = s46.Trim();
                                    switch (MapEvent.m_Condition.nHumStatus)
                                    {
                                        case 1:
                                            M2Share.g_MapEventListOfDropItem.Add(MapEvent);
                                            break;
                                        case 2:
                                            M2Share.g_MapEventListOfPickUpItem.Add(MapEvent);
                                            break;
                                        case 3:
                                            M2Share.g_MapEventListOfMine.Add(MapEvent);
                                            break;
                                        case 4:
                                            M2Share.g_MapEventListOfWalk.Add(MapEvent);
                                            break;
                                        case 5:
                                            M2Share.g_MapEventListOfRun.Add(MapEvent);
                                            break;
                                        default:
                                            Dispose(MapEvent);
                                            break;
                                    }
                                }
                                else
                                {
                                    result = -I;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public int LoadMapQuest()
        {
            int result = 1;
            string sFileName;
            string tStr;
            TStringList tMapQuestList;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            int n38;
            int n3C;
            bool boGrouped;
            TEnvirnoment Map;
            sFileName = M2Share.g_Config.sEnvirDir + "MapQuest.txt";
            if (File.Exists(sFileName))
            {
                tMapQuestList = new TStringList();
                try
                {

                    tMapQuestList.LoadFromFile(sFileName);
                    if (tMapQuestList.Count > 0)
                    {
                        for (int I = 0; I < tMapQuestList.Count; I++)
                        {
                            tStr = tMapQuestList[I];
                            if ((tStr != "") && (tStr[0] != ';'))
                            {
                                tStr = HUtil32.GetValidStr3(tStr, ref s18, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s1C, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s20, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s24, new string[] { " ", "\t" });
                                if ((s24 != "") && (s24[0] == '\''))
                                {
                                    HUtil32.ArrestStringEx(s24, "\"", "\"", ref s24);
                                }
                                tStr = HUtil32.GetValidStr3(tStr, ref s28, new string[] { " ", "\t" });
                                if ((s28 != "") && (s28[0] == '\''))
                                {
                                    HUtil32.ArrestStringEx(s28, "\"", "\"", ref s28);
                                }
                                tStr = HUtil32.GetValidStr3(tStr, ref s2C, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s30, new string[] { " ", "\t" });
                                if ((s18 != "") && (s24 != "") && (s2C != ""))
                                {
                                    Map = M2Share.g_MapManager.FindMap(s18);
                                    if (Map != null)
                                    {
                                        HUtil32.ArrestStringEx(s1C, "[", "]", ref s34);
                                        n38 = HUtil32.Str_ToInt(s34, 0);
                                        n3C = HUtil32.Str_ToInt(s20, 0);
                                        if (HUtil32.CompareLStr(s30, "GROUP", 5))
                                        {
                                            boGrouped = true;
                                        }
                                        else
                                        {
                                            boGrouped = false;
                                        }
                                        if (!Map.CreateQuest(n38, n3C, s24, s28, s2C, boGrouped))
                                        {
                                            result = -I;
                                        }
                                    }
                                    else
                                    {
                                        result = -I;
                                    }
                                }
                                else
                                {
                                    result = -I;
                                }
                            }
                        }
                    }
                }
                finally
                {

                }
            }
            QMangeNPC();
            QFunctionNPC();
            RobotNPC();
            QBatterNPC();
            return result;
        }

        /// <summary>
        /// ���ؽ���NPC�����ļ�
        /// �ű�   ��ͼ     ����X   ����Y   NPC��ʾ��   ��ʶ   ����  �Ƿ�Ǳ�  �ܷ��ƶ� �Ƿ��ɫ ��ɫʱ��
        /// </summary>
        /// <returns></returns>
        public int LoadMerchant()
        {
            int result;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sScript = string.Empty;
            string sMapName = string.Empty;
            string sX = string.Empty;
            string sY = string.Empty;
            string sName = string.Empty;
            string sFlag = string.Empty;
            string sAppr = string.Empty;
            string sIsCalste = string.Empty;
            string sCanMove = string.Empty;
            string sMoveTime = string.Empty;
            string sAutoChangeColor = string.Empty;
            string sAutoChangeColorTime = string.Empty;
            TStringList tMerchantList;
            TMerchant tMerchantNPC;
            sFileName = M2Share.g_Config.sEnvirDir + "Merchant.txt";
            if (!File.Exists(sFileName))
            {
                return result = 0;
            }

            tMerchantList = new TStringList();
            tMerchantList.LoadFromFile(sFileName);

            for (int I = 0; I < tMerchantList.Count; I++)
            {
                sLineText = tMerchantList[I].Trim();
                if ((sLineText != "") && (sLineText[0] != ';'))
                {
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sScript, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sMapName, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sX, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sY, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sName, new string[] { " ", "\t" });
                    if ((sName != "") && (sName[0] == '\''))
                    {
                        HUtil32.ArrestStringEx(sName, "\'", "\'", ref sName);
                    }
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sFlag, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sAppr, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sIsCalste, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanMove, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sMoveTime, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sAutoChangeColor, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sAutoChangeColorTime, new string[] { " ", "\t" });
                    if ((sScript != "") && (sMapName != "") && (sAppr != ""))
                    {
                        tMerchantNPC = new TMerchant();
                        tMerchantNPC.m_sScript = sScript;
                        tMerchantNPC.m_sMapName = sMapName;
                        tMerchantNPC.m_nCurrX = HUtil32.Str_ToInt(sX, 0);
                        tMerchantNPC.m_nCurrY = HUtil32.Str_ToInt(sY, 0);
                        tMerchantNPC.m_sCharName = sName;// NPC����
                        tMerchantNPC.m_nFlag = (sbyte)HUtil32.Str_ToInt(sFlag, 0);
                        tMerchantNPC.m_wAppr = (ushort)HUtil32.Str_ToInt(sAppr, 0);
                        tMerchantNPC.m_dwMoveTime = (uint)HUtil32.Str_ToInt(sMoveTime, 0);
                        tMerchantNPC.m_dwNpcAutoChangeColorTime = (uint)HUtil32.Str_ToInt(sAutoChangeColorTime, 0) * 1000;
                        if (HUtil32.Str_ToInt(sIsCalste, 0) != 0)
                        {
                            tMerchantNPC.m_boCastle = true;
                        }
                        if ((HUtil32.Str_ToInt(sCanMove, 0) != 0) && (tMerchantNPC.m_dwMoveTime > 0))
                        {
                            tMerchantNPC.m_boCanMove = true;
                        }
                        if (HUtil32.Str_ToInt(sAutoChangeColor, 0) != 0)
                        {
                            tMerchantNPC.m_boNpcAutoChangeColor = true;
                        }
                        UserEngine.AddMerchant(tMerchantNPC);
                    }
                }
            }


            result = 1;
            return result;
        }

        /// <summary>
        /// ����С��ͼ����
        /// </summary>
        /// <returns></returns>
        public int LoadMinMap()
        {
            int result;
            string sFileName;
            string tStr = string.Empty;
            string sMapNO = string.Empty;
            string sMapIdx = string.Empty;
            TStringList tMapList = null;
            int nIdx;
            result = 0;
            sFileName = M2Share.g_Config.sEnvirDir + "MiniMap.txt";
            if (File.Exists(sFileName))
            {
                if (M2Share.MiniMapList.Count > 0)
                {
                    M2Share.MiniMapList.Clear();
                }
                tMapList = new TStringList();
                tMapList.LoadFromFile(sFileName);
                for (int I = 0; I < tMapList.Count; I++)
                {
                    tStr = tMapList[I];
                    if ((tStr != "") && (tStr[0] != ';'))
                    {
                        tStr = HUtil32.GetValidStr3(tStr, ref sMapNO, new string[] { " ", "\t" });
                        tStr = HUtil32.GetValidStr3(tStr, ref sMapIdx, new string[] { " ", "\t" });
                        nIdx = HUtil32.Str_ToInt(sMapIdx, 0);
                        if (nIdx > 0)
                        {
                            M2Share.MiniMapList.Add(new TMinMapInfo() { nIdx = nIdx, sMapNO = sMapNO });
                        }
                    }
                }
            }
            if (tMapList != null)
            {
                tMapList.Dispose();
            }
            Dispose(tMapList);
            return result;
        }

        public void LoadMonGen_LoadMapGen(TStringList MonGenList, string sFileName)
        {
            string sFilePatchName;
            string sFileDir;
            TStringList LoadList;
            sFileDir = M2Share.g_Config.sEnvirDir + "MonGen\\";
            if (!Directory.Exists(sFileDir))
            {
                Directory.CreateDirectory(sFileDir);
            }
            sFilePatchName = sFileDir + sFileName;
            if (File.Exists(sFilePatchName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFilePatchName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    MonGenList.Add(LoadList[I]);
                }
            }
        }

        /// <summary>
        /// ���ع���ˢ������
        /// </summary>
        /// <returns></returns>
        public int LoadMonGen()
        {
            int result = 0;
            string sLineText = string.Empty;
            string sData = string.Empty;
            TMonGenInfo MonGenInfo;
            TStringList LoadList;
            string sMapGenFile;
            int I;
            string sFileName = M2Share.g_Config.sEnvirDir + "MonGen.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                I = 0;
                while (true)
                {
                    if (I >= LoadList.Count)
                    {
                        break;
                    }
                    if (HUtil32.CompareLStr("loadgen", LoadList[I], 7))
                    {
                        sMapGenFile = HUtil32.GetValidStr3(LoadList[I], ref sLineText, new string[] { " ", "\t" });
                        LoadList.RemoveAt(I);
                        if (sMapGenFile != "")
                        {
                            LoadMonGen_LoadMapGen(LoadList, sMapGenFile);
                        }
                    }
                    I++;
                }
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((!string.IsNullOrEmpty(sLineText)) && (sLineText[0] != ';'))
                    {
                        MonGenInfo = new TMonGenInfo();
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// ��ͼ����
                        MonGenInfo.sMapName = sData;
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// X
                        MonGenInfo.nX = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// Y
                        MonGenInfo.nY = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] { " ", "\t" });// ������
                        if ((sData != "") && (sData[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(sData, "\"", "\"", ref sData);
                        }
                        MonGenInfo.sMonName = sData;
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// ��Χ
                        MonGenInfo.nRange = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// ����
                        MonGenInfo.nCount = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// ʱ��
                        MonGenInfo.dwZenTime = (uint)HUtil32.Str_ToInt(sData, 1) * 60000;//
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// �ڹ���,����������������ֵ 
                        MonGenInfo.boIsNGMon = HUtil32.Str_ToInt(sData, 0) != 0;
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// �Զ������ֵ���ɫ
                        MonGenInfo.nNameColor = (byte)HUtil32.Str_ToInt(sData, 255);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });
                        MonGenInfo.nMissionGenRate = HUtil32.Str_ToInt(sData, 0);// ��������ˢ�»��� 1 -100
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });
                        MonGenInfo.nChangeColorType = HUtil32.Str_ToInt(sData, -1);// ��ɫ
                        if (!string.IsNullOrEmpty(MonGenInfo.sMapName) && !string.IsNullOrEmpty(MonGenInfo.sMonName)
                            && MonGenInfo.dwZenTime != 0 && M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, MonGenInfo.sMapName) != null)
                        {
                            MonGenInfo.CertList = new List<TBaseObject>();
                            MonGenInfo.Envir = M2Share.g_MapManager.FindMap(MonGenInfo.sMapName);
                            if (MonGenInfo.Envir != null)
                            {
                                UserEngine.m_MonGenList.Add(MonGenInfo);
                                UserEngine.AddMapMonGenCount(MonGenInfo.sMapName, MonGenInfo.nCount);
                            }
                            else
                            {
                                Dispose(MonGenInfo);
                            }
                        }
                    }
                }
                MonGenInfo = new TMonGenInfo();
                MonGenInfo.sMapName = "";
                MonGenInfo.sMonName = "";
                MonGenInfo.CertList = new List<TBaseObject>();
                MonGenInfo.Envir = null;
                UserEngine.m_MonGenList.Add(MonGenInfo);
                result = 1;
            }
            return result;
        }





        // ;����  ����  ��ͼ   x   y  ��Χ  ͼ�� �Ƿ��ɫ ��ɫʱ��
        public int LoadNpcs()
        {
            int result;
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            string s40 = string.Empty;
            string s42 = string.Empty;
            TStringList LoadList;
            TNormNpc NPC;
            string sFileName = M2Share.g_Config.sEnvirDir + "Npcs.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        s18 = HUtil32.GetValidStrCap(s18, ref s20, new string[] { " ", "\t" });// ����
                        if ((s20 != "") && (s20[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(s20, "\"", "\"", ref s20);
                        }
                        s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });// NPC����
                        s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });// ��ͼ
                        s18 = HUtil32.GetValidStr3(s18, ref s2C, new string[] { " ", "\t" });// X
                        s18 = HUtil32.GetValidStr3(s18, ref s30, new string[] { " ", "\t" });// Y
                        s18 = HUtil32.GetValidStr3(s18, ref s34, new string[] { " ", "\t" });// ��Χ
                        s18 = HUtil32.GetValidStr3(s18, ref s38, new string[] { " ", "\t" });// ͼ��
                        s18 = HUtil32.GetValidStr3(s18, ref s40, new string[] { " ", "\t" });// �Ƿ��ɫ
                        s18 = HUtil32.GetValidStr3(s18, ref s42, new string[] { " ", "\t" });// ��ɫʱ��
                        if ((s20 != "") && (s28 != "") && (s38 != ""))
                        {
                            NPC = null;
                            switch (HUtil32.Str_ToInt(s24, 0))
                            {
                                case 0://��ͨNPC
                                    NPC = new TMerchant();
                                    break;
                                case 1://�л�NPC
                                    NPC = new TGuildOfficial();
                                    break;
                                case 2://�Ǳ�NPC
                                    NPC = new TCastleOfficial();
                                    break;
                            }
                            if (NPC != null)
                            {
                                NPC.m_sMapName = s28;
                                NPC.m_nCurrX = HUtil32.Str_ToInt(s2C, 0);
                                NPC.m_nCurrY = HUtil32.Str_ToInt(s30, 0);
                                NPC.m_sCharName = s20;
                                NPC.m_nFlag = (sbyte)HUtil32.Str_ToInt(s34, 0);
                                NPC.m_wAppr = (ushort)HUtil32.Str_ToInt(s38, 0);
                                NPC.m_NpcType = TNpcType.n_Norm;//by John Add ����NPC����
                                if (HUtil32.Str_ToInt(s40, 0) != 0)
                                {
                                    NPC.m_boNpcAutoChangeColor = true;
                                }
                                NPC.m_dwNpcAutoChangeColorTime = Convert.ToUInt32(HUtil32.Str_ToInt(s42, 0) * 1000);
                                UserEngine.QuestNPCList.Add(NPC);
                            }
                        }
                    }
                }
            }
            result = 1;
            return result;
        }

        public string LoadQuestDiary_sub_48978C(int nIndex)
        {
            string result;
            if (nIndex >= 1000)
            {
                result = (nIndex).ToString();
                return result;
            }
            if (nIndex >= 100)
            {
                result = (nIndex).ToString() + "0";
                return result;
            }
            result = (nIndex).ToString() + "00";
            return result;
        }

        public int LoadQuestDiary()
        {
            int result;
            int I;
            int II;
            IList<TQDDinfo> QDDinfoList;
            TQDDinfo QDDinfo;
            string s14;
            string s18;
            string s1C;
            string s20 = string.Empty;
            bool bo2D;
            int nC;
            TStringList LoadList;
            result = 1;
            if (M2Share.QuestDiaryList.Count > 0)
            {
                for (I = 0; I < M2Share.QuestDiaryList.Count; I++)
                {
                    QDDinfoList = M2Share.QuestDiaryList;
                    if (QDDinfoList.Count > 0)
                    {
                        for (II = 0; II < QDDinfoList.Count; II++)
                        {
                            QDDinfo = QDDinfoList[II];
                            Dispose(QDDinfo);
                        }
                    }
                }
                M2Share.QuestDiaryList.Clear();
            }
            bo2D = false;
            nC = 1;
            while (true)
            {
                QDDinfoList = null;
                s14 = "QuestDiary\\" + LoadQuestDiary_sub_48978C(nC) + ".txt";
                if (File.Exists(s14))
                {
                    s18 = "";
                    QDDinfo = null;
                    LoadList = new TStringList();
                    LoadList.LoadFromFile(s14);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        s1C = LoadList[I];
                        if ((s1C != "") && (s1C[0] != ';'))
                        {
                            if ((s1C[0] == '[') && (s1C.Length > 2))
                            {
                                if (s18 == "")
                                {
                                    HUtil32.ArrestStringEx(s1C, "[", "]", ref s18);
                                    QDDinfoList = new List<TQDDinfo>();
                                    QDDinfo = new TQDDinfo();
                                    QDDinfo.n00 = nC;
                                    QDDinfo.s04 = s18;
                                    QDDinfo.sList = new TStringList();
                                    QDDinfoList.Add(QDDinfo);
                                    bo2D = true;
                                }
                                else
                                {
                                    if (s1C[0] != '@')
                                    {
                                        s1C = HUtil32.GetValidStr3(s1C, ref s20, new string[] { " ", "\t" });
                                        HUtil32.ArrestStringEx(s20, "[", "]", ref s20);
                                        QDDinfo = new TQDDinfo();
                                        QDDinfo.n00 = HUtil32.Str_ToInt(s20, 0);
                                        QDDinfo.s04 = s1C;
                                        QDDinfo.sList = new TStringList();
                                        QDDinfoList.Add(QDDinfo);
                                        bo2D = true;
                                    }
                                    else
                                    {
                                        bo2D = false;
                                    }
                                }
                            }
                            else
                            {
                                if (bo2D)
                                {
                                    //QDDinfo.sList.Add(s1C);
                                }
                            }
                        }
                    }
                }
                if (QDDinfoList != null)
                {
                    //M2Share.QuestDiaryList.Add(QDDinfoList);
                }
                else
                {
                    M2Share.QuestDiaryList.Add(null);
                }
                nC++;
                if (nC >= 105)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// ���ذ�ȫ������
        /// </summary>
        /// <returns></returns>
        public int LoadStartPoint()
        {
            int result = 0;
            string tStr;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s22 = string.Empty;
            string s24 = string.Empty;
            string s26 = string.Empty;
            string s28 = string.Empty;
            string s30 = string.Empty;
            TStringList LoadList;
            TStartPoint StartPoint;
            string sFileName = M2Share.g_Config.sEnvirDir + "StartPoint.txt";
            if (File.Exists(sFileName))
            {
                try
                {
                    M2Share.g_StartPointList.Clear();
                    LoadList = new TStringList();
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        tStr = LoadList[I].Trim();
                        if ((tStr != "") && (tStr[0] != ';'))
                        {
                            tStr = HUtil32.GetValidStr3(tStr, ref s18, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s1C, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s20, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s22, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s24, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s26, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s28, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s30, new string[] { " ", "\t" });
                            if ((s18 != "") && (s1C != "") && (s20 != ""))
                            {
                                StartPoint = new TStartPoint();
                                StartPoint.m_sMapName = s18;
                                StartPoint.m_nCurrX = HUtil32.Str_ToInt(s1C, 0);
                                StartPoint.m_nCurrY = HUtil32.Str_ToInt(s20, 0);
                                StartPoint.m_boNotAllowSay = Convert.ToBoolean(HUtil32.Str_ToInt(s22, 0));
                                StartPoint.m_nRange = HUtil32.Str_ToInt(s24, 0);
                                StartPoint.m_nType = HUtil32.Str_ToInt(s26, 0);
                                StartPoint.m_nPkZone = HUtil32.Str_ToInt(s28, 0);
                                StartPoint.m_nPkFire = HUtil32.Str_ToInt(s30, 0);
                                M2Share.g_StartPointList.Add(StartPoint);
                                //M2Share.g_StartPointList.Add(s18, ((StartPoint) as Object));
                                // g_StartPointList.AddObject(s18, TObject(MakeLong(Str_ToInt(s1C, 0), Str_ToInt(s20, 0))));
                                result = 1;
                            }
                        }
                    }
                }
                finally
                {
                    // M2Share.g_StartPointList.UnLock();
                }
            }
            return result;
        }

        /// <summary>
        /// ��ȡ�����Ʒ�ļ�
        /// </summary>
        /// <returns></returns>
        public unsafe int LoadUnbindList(out string ItemName)
        {
            ItemName = string.Empty;
            int result = 0;
            string tStr;
            string sData = string.Empty;
            int nItemIndex;
            string sItemName = string.Empty;
            TStringList LoadList;
            TUnbindInfo* UnbindInfo;
            string sFileName = M2Share.g_Config.sEnvirDir + "UnbindList.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    tStr = LoadList[I];
                    if ((tStr != "") && (tStr[0] != ';'))
                    {
                        tStr = HUtil32.GetValidStr3(tStr, ref sData, new string[] { " ", "\t" });
                        tStr = HUtil32.GetValidStrCap(tStr, ref sItemName, new string[] { " ", "\t" });
                        if ((sItemName != "") && (sItemName[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(sItemName, "\"", "\"", ref sItemName);
                        }
                        nItemIndex = HUtil32.Str_ToInt(sData, 0);
                        if (nItemIndex > 0 && UserEngine.GetStdItem(sItemName) != null)
                        {
                            UnbindInfo = (TUnbindInfo*)Marshal.AllocHGlobal(sizeof(TUnbindInfo));
                            HUtil32.StrToSByteArry(sItemName, UnbindInfo->sItemName, 14, ref UnbindInfo->sItemNameLen);
                            UnbindInfo->nUnbindCode = nItemIndex;
                            M2Share.g_UnbindList.Add((IntPtr)UnbindInfo);
                        }
                        else
                        {
                            MainOutMessage("������װ��Ʒ��Ϣʧ��.���ݿⲻ����:" + sItemName);
                            result = -I;// ��Ҫȡ����
                            ItemName = sItemName;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // ���¶�ȡ����NPC
        public void ReLoadNpc()
        {
            string sFileName;
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            string s40 = string.Empty;
            string s42 = string.Empty;
            TStringList LoadList;
            TNormNpc NPC;
            int I;
            int II;
            int nX;
            int nY;
            bool boNewNpc;
            try
            {
                sFileName = M2Share.g_Config.sEnvirDir + "Npcs.txt";
                if (!File.Exists(sFileName))
                {
                    return;
                }
                if (UserEngine.QuestNPCList.Count > 0)
                {
                    for (I = 0; I < UserEngine.QuestNPCList.Count; I++)
                    {
                        NPC = UserEngine.QuestNPCList[I];
                        if ((NPC != M2Share.g_ManageNPC) && (NPC != M2Share.g_BatterNPC) && (NPC != M2Share.g_RobotNPC) && (NPC != M2Share.g_FunctionNPC) && (NPC.m_boIsQuest))
                        {
                            NPC.m_nFlag = -1;
                        }
                    }
                }
                LoadList = new TStringList();

                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        s18 = HUtil32.GetValidStrCap(s18, ref s20, new string[] { " ", "\t" });
                        if ((s20 != "") && (s20[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(s20, "\"", "\"", ref s20);
                        }
                        s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s2C, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s30, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s34, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s38, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s40, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s42, new string[] { " ", "\t" });
                        if ((s20 != "") && (s28 != "") && (s38 != ""))
                        {
                            nX = HUtil32.Str_ToInt(s2C, 0);
                            nY = HUtil32.Str_ToInt(s30, 0);
                            boNewNpc = true;
                            if (UserEngine.QuestNPCList.Count > 0)
                            {
                                for (II = 0; II < UserEngine.QuestNPCList.Count; II++)
                                {
                                    NPC = UserEngine.QuestNPCList[II];
                                    if ((NPC.m_sMapName == s28) && (NPC.m_nCurrX == nX) && (NPC.m_nCurrY == nY))
                                    {
                                        boNewNpc = false;
                                        NPC.m_sCharName = s20;
                                        NPC.m_nFlag = Convert.ToSByte(HUtil32.Str_ToInt(s34, 0));
                                        NPC.m_wAppr = Convert.ToUInt16(HUtil32.Str_ToInt(s38, 0));
                                        if (HUtil32.Str_ToInt(s40, 0) != 0)
                                        {
                                            NPC.m_boNpcAutoChangeColor = true;
                                        }
                                        NPC.m_dwNpcAutoChangeColorTime = Convert.ToUInt32(HUtil32.Str_ToInt(s42, 0) * 1000);
                                        break;
                                    }
                                }
                            }
                            if (boNewNpc)
                            {
                                NPC = null;
                                switch (HUtil32.Str_ToInt(s24, 0))
                                {
                                    case 0:
                                        NPC = new TMerchant();
                                        break;
                                    case 1:
                                        NPC = new TGuildOfficial();
                                        break;
                                    case 2:
                                        NPC = new TCastleOfficial();
                                        break;
                                }
                                if (NPC != null)
                                {
                                    NPC.m_sMapName = s28;
                                    NPC.m_nCurrX = nX;
                                    NPC.m_nCurrY = nY;
                                    NPC.m_sCharName = s20;
                                    NPC.m_nFlag = Convert.ToSByte(HUtil32.Str_ToInt(s34, 0));
                                    NPC.m_wAppr = Convert.ToUInt16(HUtil32.Str_ToInt(s38, 0));
                                    if (HUtil32.Str_ToInt(s40, 0) != 0)
                                    {
                                        NPC.m_boNpcAutoChangeColor = true;
                                    }
                                    NPC.m_dwNpcAutoChangeColorTime = Convert.ToUInt32(HUtil32.Str_ToInt(s42, 0) * 1000);
                                    UserEngine.QuestNPCList.Add(NPC);
                                }
                            }
                        }
                    }
                }

                if (UserEngine.QuestNPCList.Count > 0)
                {
                    for (I = UserEngine.QuestNPCList.Count - 1; I >= 0; I--)
                    {
                        NPC = UserEngine.QuestNPCList[I];
                        if (NPC.m_nFlag == -1)
                        {
                            NPC.m_boGhost = true;
                            NPC.m_dwGhostTick = HUtil32.GetTickCount();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        // ���¶�ȡ����NPC
        public void ReLoadMerchants()
        {
            int I;
            int II;
            int nX;
            int nY;
            string sLineText = string.Empty;
            string sFileName = string.Empty;
            string sScript = string.Empty;
            string sMapName = string.Empty;
            string sX = string.Empty;
            string sY = string.Empty;
            string sCharName = string.Empty;
            string sFlag = string.Empty;
            string sAppr = string.Empty;
            string sCastle = string.Empty;
            string sCanMove = string.Empty;
            string sMoveTime = string.Empty;
            TMerchant Merchant;
            TStringList LoadList;
            bool boNewNpc;
            sFileName = M2Share.g_Config.sEnvirDir + "Merchant.txt";
            if (!File.Exists(sFileName))
            {
                return;
            }
            lock (UserEngine.m_MerchantList)
                try
                {
                    if (UserEngine.m_MerchantList.Count > 0)
                    {
                        for (I = 0; I < UserEngine.m_MerchantList.Count; I++)
                        {
                            Merchant = UserEngine.m_MerchantList[I];
                            if (Merchant != null)
                            {
                                if ((Merchant != M2Share.g_FunctionNPC) && (Merchant != M2Share.g_BatterNPC) && (Merchant.m_boIsQuest)) // ���� m_boIsQuest ����
                                {
                                    Merchant.m_nFlag = -1;
                                }
                            }
                        }
                    }
                    LoadList = new TStringList();
                    try
                    {

                        LoadList.LoadFromFile(sFileName);
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I].Trim();
                            if ((sLineText != "") && (sLineText[0] != ';'))
                            {
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sScript, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sMapName, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sX, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sY, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sCharName, new string[] { " ", "\t" });
                                if ((sCharName != "") && (sCharName[0] != '\''))
                                {
                                    HUtil32.ArrestStringEx(sCharName, "\"", "\"", ref sCharName);
                                }
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sFlag, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sAppr, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sCastle, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sCanMove, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sMoveTime, new string[] { " ", "\t" });
                                nX = HUtil32.Str_ToInt(sX, 0);
                                nY = HUtil32.Str_ToInt(sY, 0);
                                boNewNpc = true;
                                if (UserEngine.m_MerchantList.Count > 0)
                                {
                                    for (II = 0; II < UserEngine.m_MerchantList.Count; II++)
                                    {
                                        Merchant = UserEngine.m_MerchantList[II];
                                        if ((Merchant.m_sMapName == sMapName) && (Merchant.m_nCurrX == nX) && (Merchant.m_nCurrY == nY))
                                        {
                                            boNewNpc = false;
                                            Merchant.m_sScript = sScript;
                                            Merchant.m_sCharName = sCharName;
                                            Merchant.m_nFlag = (sbyte)HUtil32.Str_ToInt(sFlag, 0);
                                            Merchant.m_wAppr = (ushort)HUtil32.Str_ToInt(sAppr, 0);
                                            Merchant.m_dwMoveTime = (uint)HUtil32.Str_ToInt(sMoveTime, 0);
                                            if (HUtil32.Str_ToInt(sCastle, 0) != 0)
                                            {
                                                Merchant.m_boCastle = true;
                                            }
                                            else
                                            {
                                                Merchant.m_boCastle = false;
                                            }
                                            if ((HUtil32.Str_ToInt(sCanMove, 0) != 0) && (Merchant.m_dwMoveTime > 0))
                                            {
                                                Merchant.m_boCanMove = true;
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (boNewNpc)
                                {
                                    Merchant = new TMerchant();
                                    Merchant.m_sMapName = sMapName;
                                    Merchant.m_PEnvir = M2Share.g_MapManager.FindMap(Merchant.m_sMapName);
                                    if (Merchant.m_PEnvir != null)
                                    {
                                        Merchant.m_sScript = sScript;
                                        Merchant.m_nCurrX = nX;
                                        Merchant.m_nCurrY = nY;
                                        Merchant.m_sCharName = sCharName;
                                        Merchant.m_nFlag = (sbyte)HUtil32.Str_ToInt(sFlag, 0);
                                        Merchant.m_wAppr = (ushort)HUtil32.Str_ToInt(sAppr, 0);
                                        Merchant.m_dwMoveTime = (uint)HUtil32.Str_ToInt(sMoveTime, 0);
                                        if (HUtil32.Str_ToInt(sCastle, 0) != 0)
                                        {
                                            Merchant.m_boCastle = true;
                                        }
                                        else
                                        {
                                            Merchant.m_boCastle = false;
                                        }
                                        if ((HUtil32.Str_ToInt(sCanMove, 0) != 0) && (Merchant.m_dwMoveTime > 0))
                                        {
                                            Merchant.m_boCanMove = true;
                                        }
                                        UserEngine.m_MerchantList.Add(Merchant);
                                        Merchant.Initialize();
                                    }
                                    else
                                    {
                                        //Merchant.Free;
                                    }
                                }
                            }
                        }
                        // for
                    }
                    finally
                    {

                        //Dispose(LoadList);
                    }
                    if (UserEngine.m_MerchantList.Count > 0)
                    {
                        for (I = UserEngine.m_MerchantList.Count - 1; I >= 0; I--)
                        {
                            Merchant = ((TMerchant)(UserEngine.m_MerchantList[I]));
                            if (Merchant.m_nFlag == -1)
                            {
                                Merchant.m_boGhost = true;
                                Merchant.m_dwGhostTick = HUtil32.GetTickCount();
                                // UserEngine.MerchantList.Delete(I);
                            }
                        }
                    }
                }
                finally
                {
                    //UserEngine.m_MerchantList.UnLock();
                }
        }

        public bool LoadBoxsList_IsNum(string str)
        {
            bool result;
            // �ж�һ���ַ����Ƿ�Ϊ����
            int i;
            for (i = 1; i <= str.Length; i++)
            {
                if (!(str[i] >= '0' && str[i] <= '9'))
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public int LoadBoxsList_IsNum1(string str)
        {
            int result;
            // �ж��м���'('��
            int i;
            result = 0;
            if (str.Length <= 0)
            {
                return result;
            }
            for (i = 0; i <= str.Length - 1; i++)
            {
                if ((new ArrayList(new string[] { "(" }).Contains(str[i])))
                {
                    result++;
                }
            }
            return result;
        }

        // ------------------------------------------------------------------------------
        /// <summary>
        /// ��ȡ����
        /// </summary>
        public unsafe void LoadBoxsList()
        {
            TStringList LoadList;
            TStringList tSaveList;
            int j;
            string sBoxsDir;
            string BoxsFile;
            string SBoxsID = string.Empty;
            string sItemName = string.Empty;
            string nItemNum = string.Empty;
            string nItemType = string.Empty;
            string OpenBox = string.Empty;
            string nGold = string.Empty;
            string nGameGold = string.Empty;
            string nIncGold = string.Empty;
            string nIncGameGold = string.Empty;
            string nEffectiveGold = string.Empty;
            string nEffectiveGameGold = string.Empty;
            string nUses = string.Empty;
            TBoxsInfo* BoxsInfo;
            TStdItem* StdItem;
            string sTemp;
            if (!Directory.Exists(M2Share.g_Config.sBoxsDir))  // Ŀ¼������,�򴴽�
            {
                Directory.CreateDirectory(M2Share.g_Config.sBoxsDir);
            }
            if (!File.Exists(M2Share.g_Config.sBoxsFile))   // BoxsList.txt�ļ�������,�򴴽��ļ�
            {
                tSaveList = new TStringList();
                tSaveList.Add(";��Ϊ�������к��ļ�");
                tSaveList.Add(";���������鿴�����ĵ�");
                tSaveList.Add(";�������ǿ����������޸����䣬���پ�����ֻ������������������");
                tSaveList.SaveToFile(M2Share.g_Config.sBoxsFile);
                tSaveList.Dispose();
            }
            if (File.Exists(M2Share.g_Config.sBoxsFile))
            {
                M2Share.BoxsList.Clear();
                LoadList = new TStringList();
                LoadList.LoadFromFile(M2Share.g_Config.sBoxsFile);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sBoxsDir = LoadList[I].Trim();
                    if ((sBoxsDir != "") && (sBoxsDir[0] != ';'))
                    {
                        if (File.Exists(M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt"))
                        {
                            tSaveList = new TStringList();
                            tSaveList.LoadFromFile(M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt");
                            if (tSaveList.Text == "")
                            {
                                continue;
                            }
                            // ���� ����ļ�����Ϊ����������һ�ļ�
                            for (int K = 0; K < tSaveList.Count; K++)
                            {
                                try
                                {
                                    BoxsFile = tSaveList[K].Trim();
                                    if ((BoxsFile != "") && (BoxsFile[0] != ';'))
                                    {
                                        j = LoadBoxsList_IsNum1(BoxsFile);
                                        switch (j)
                                        {
                                            case 0:
                                                HUtil32.ArrestStringEx(BoxsFile, "(", ")", ref nItemNum);// ��Ʒ����
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref sItemName, new string[] { "	", " ", "\t" });
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref nItemType, new string[] { "	", " ", "\t" });
                                                break;
                                            case 1:// ��Ʒ����
                                                HUtil32.ArrestStringEx(BoxsFile, "(", ")", ref nItemNum);// ��Ʒ����
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref sItemName, new string[] { "	", " ", "\t" });
                                                if (LoadBoxsList_IsNum(nItemNum) && (nItemNum != ""))
                                                {
                                                    // ��Ʒ����
                                                    HUtil32.GetValidStr3(sItemName, ref sItemName, new string[] { "(" });
                                                }
                                                else
                                                {
                                                    nItemNum = "";
                                                }
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref nItemType, new string[] { "	", " ", "\t" });
                                                break;
                                            case 2:// ��Ʒ����
                                                HUtil32.ArrestStringEx(BoxsFile, "(", ")", ref nItemNum);// ��Ʒ����
                                                if (nItemNum != "")
                                                {
                                                    if (!LoadBoxsList_IsNum(nItemNum))
                                                    {
                                                        sTemp = HUtil32.GetValidStr3(BoxsFile, ref sItemName, new string[] { ")" });
                                                        if (sItemName != "")
                                                        {
                                                            sItemName = sItemName + ")";
                                                        }
                                                        HUtil32.ArrestStringEx(sTemp, "(", ")", ref nItemNum);
                                                        nItemType = HUtil32.GetValidStr3(sTemp, ref nItemType, new string[] { "	", " ", "\t" });// ��Ʒ����
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if ((sItemName == "") && (nItemType == ""))
                                    {
                                        continue;
                                    }
                                    if ((sItemName != "") && (nItemType != ""))
                                    {
                                        StdItem = UserEngine.GetStdItem(sItemName);
                                        if (StdItem != null) // �ж��Ƿ������ݿ������Ʒ
                                        {
                                            BoxsInfo = (TBoxsInfo*)Marshal.AllocHGlobal(sizeof(TBoxsInfo));
                                            BoxsInfo->SBoxsID = Convert.ToInt32(SBoxsID);
                                            if (nItemNum != "")
                                            {
                                                BoxsInfo->nItemNum = Convert.ToInt32(nItemNum);
                                            }
                                            else
                                            {
                                                BoxsInfo->nItemNum = 1;
                                            }
                                            BoxsInfo->nItemType = Convert.ToInt32(nItemType);
                                            BoxsInfo->StdItem->MakeIndex = (int)BoxsInfo;
                                            BoxsInfo->nGold = Convert.ToInt32(nGold);
                                            BoxsInfo->nGameGold = Convert.ToUInt32(nGameGold);
                                            BoxsInfo->nIncGold = Convert.ToInt32(nIncGold);
                                            BoxsInfo->nIncGameGold = Convert.ToInt32(nIncGameGold);
                                            BoxsInfo->nEffectiveGold = Convert.ToInt32(nEffectiveGold);
                                            BoxsInfo->nEffectiveGameGold = Convert.ToUInt32(nEffectiveGameGold);
                                            BoxsInfo->nUses = Convert.ToInt32(nUses);
                                            BoxsInfo->StdItem->Dura = (ushort)HUtil32.Round((double)(StdItem->DuraMax / 100) * (20 + HUtil32.Random(80)));// ��ǰ�־�
                                            BoxsInfo->StdItem->DuraMax = (ushort)StdItem->DuraMax;// ���־�
                                            BoxsInfo->StdItem->s = *StdItem;
                                            M2Share.BoxsList.Add((IntPtr)BoxsInfo);
                                        }
                                        else
                                        {
                                            // ����Ǿ��� ���� ���ʯ
                                            // '���ʯ'
                                            if ((sItemName.Trim() == "����") || (sItemName.Trim() == "����") || (sItemName.Trim() == M2Share.g_Config.sGameDiaMond))
                                            {
                                                if (SBoxsID != "")
                                                {
                                                    BoxsInfo = (TBoxsInfo*)Marshal.AllocHGlobal(sizeof(TBoxsInfo));
                                                    BoxsInfo->SBoxsID = Convert.ToInt32(SBoxsID);
                                                    HUtil32.StrToSByteArry(sItemName, BoxsInfo->StdItem->s.Name, 14, ref BoxsInfo->StdItem->s.NameLen);
                                                    BoxsInfo->StdItem->s.StdMode = 0;
                                                    BoxsInfo->StdItem->s.Shape = 0;
                                                    BoxsInfo->StdItem->MakeIndex = Parse(*BoxsInfo);
                                                    if (nItemNum != "")
                                                    {
                                                        BoxsInfo->nItemNum = Convert.ToInt32(nItemNum);
                                                    }
                                                    else
                                                    {
                                                        BoxsInfo->nItemNum = 1;
                                                    }
                                                    BoxsInfo->nItemType = Convert.ToInt32(nItemType);
                                                    BoxsInfo->nGold = Convert.ToInt32(nGold);
                                                    BoxsInfo->nGameGold = Convert.ToUInt32(nGameGold);
                                                    BoxsInfo->nIncGold = Convert.ToInt32(nIncGold);
                                                    BoxsInfo->nIncGameGold = Convert.ToInt32(nIncGameGold);
                                                    BoxsInfo->nEffectiveGold = Convert.ToInt32(nEffectiveGold);
                                                    BoxsInfo->nEffectiveGameGold = Convert.ToUInt32(nEffectiveGameGold);
                                                    BoxsInfo->nUses = Convert.ToInt32(nUses);
                                                    M2Share.BoxsList.Add((IntPtr)BoxsInfo);
                                                }
                                            }
                                            else
                                            {
                                                MainOutMessage("��ʾ:" + M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt �ļ�����Ʒ(" + sItemName + ")���ݿ��в�����...");
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            tSaveList.Dispose();
                            Dispose(tSaveList);
                        }
                        else
                        {
                            MainOutMessage("���������ļ�:" + M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt �ļ�������...");
                        }
                    }
                }
                Dispose(LoadList);
            }
        }

        // ------------------------------------------------------------------------------
        // ��ȡԪ�������б�
        public void LoadSellOffItemList()
        {
            //string sFileName;
            //int FileHandle;
            //TDealOffInfo DealOffInfo;
            //TDealOffInfo sDealOffInfo;
            //sFileName = M2Share.g_Config.sEnvirDir + "UserData";
            //if (!Directory.Exists(sFileName))
            //{
            //    Directory.CreateDirectory(sFileName);
            //}
            //// Ŀ¼������,�򴴽�
            //sFileName = sFileName + "\\UserData.dat";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Read | FileShare.ReadWrite);
            //    if (FileHandle > 0)
            //    {
            //        try {

            //            while (FileRead(FileHandle, sDealOffInfo, sizeof(TDealOffInfo)) == sizeof(TDealOffInfo))
            //            {
            //                // ѭ��������������
            //                if ((sDealOffInfo.sDealCharName != "") && (sDealOffInfo.sBuyCharName != "") && (sDealOffInfo.N < 4))
            //                {
            //                    // �ж����ݵ���Ч�� 20081021
            //                    DealOffInfo = new TDealOffInfo();
            //                    DealOffInfo.sDealCharName = sDealOffInfo.sDealCharName;
            //                    DealOffInfo.sBuyCharName = sDealOffInfo.sBuyCharName;
            //                    DealOffInfo.dSellDateTime = sDealOffInfo.dSellDateTime;
            //                    DealOffInfo.nSellGold = sDealOffInfo.nSellGold;
            //                    DealOffInfo.UseItems = sDealOffInfo.UseItems;
            //                    DealOffInfo.N = sDealOffInfo.N;
            //                    CheckScriptDef.sSellOffItemList.Add(DealOffInfo);
            //                }
            //            }
            //        }
            //        catch {
            //        }
            //        FileHandle.Close();
            //    }
            //}
            //else
            //{
            //    FileHandle = File.Create(sFileName);
            //    FileHandle.Close();
            //}
        }

        // ����Ԫ�������б�
        public void SaveSellOffItemList()
        {
            //string sFileName;
            //int FileHandle;
            //TDealOffInfo DealOffInfo;
            //int I;
            //sFileName = M2Share.g_Config.sEnvirDir + "UserData\\UserData.dat";
            //if (File.Exists(sFileName))
            //{
            //    File.Delete(sFileName);
            //}
            //FileHandle = File.Create(sFileName);
            //if (FileHandle > 0)
            //{
            //    FileSeek(FileHandle, 0, 0);
            //    try {
            //        if (CheckScriptDef.sSellOffItemList.Count > 0)
            //        {
            //            for (I = 0; I < CheckScriptDef.sSellOffItemList.Count; I ++ )
            //            {
            //                DealOffInfo = ((TDealOffInfo)(CheckScriptDef.sSellOffItemList[I]));
            //                if (DealOffInfo != null)
            //                {
            //                    FileWrite(FileHandle, DealOffInfo, sizeof(TDealOffInfo));
            //                }
            //            }
            //        }
            //    }
            //    catch {
            //    }
            //    FileHandle.Close();
            //}
        }

        /// <summary>
        /// ��ȡ��װװ������
        /// </summary>
        public void LoadSuitItemList()
        {
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string ItemCount = string.Empty;
            string Note = string.Empty;
            string Name = string.Empty;
            string MaxHP = string.Empty;
            string MaxMP = string.Empty;
            string DC = string.Empty;
            string MaxDC = string.Empty;
            string MC = string.Empty;
            string MaxMC = string.Empty;
            string SC = string.Empty;
            string MaxSC = string.Empty;
            string AC = string.Empty;
            string MaxAC = string.Empty;
            string MAC = string.Empty;
            string MaxMAC = string.Empty;
            string HitPoint = string.Empty;
            string SpeedPoint = string.Empty;
            string HealthRecover = string.Empty;
            string SpellRecover = string.Empty;
            string RiskRate = string.Empty;
            string btReserved = string.Empty;
            string btReserved1 = string.Empty;
            string btReserved2 = string.Empty;
            string btReserved3 = string.Empty;
            string nEXPRATE = string.Empty;
            string nPowerRate = string.Empty;
            string nMagicRate = string.Empty;
            string nSCRate = string.Empty;
            string nACRate = string.Empty;
            string nMACRate = string.Empty;
            string nAntiMagic = string.Empty;
            string nAntiPoison = string.Empty;
            string nPoisonRecover = string.Empty;
            string sboTeleport = string.Empty;
            string sboParalysis = string.Empty;
            string sboRevival = string.Empty;
            string sboMagicShield = string.Empty;
            string sboUnParalysis = string.Empty;
            TStringList LoadList;
            TSuitItem SuitItem;
            sFileName = M2Share.g_Config.sEnvirDir + "SuitItemList.txt";
            LoadList = new TStringList();
            try
            {
                if (File.Exists(sFileName))
                {
                    M2Share.SuitItemList.Clear();
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (int I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I];
                            if ((sLineText != "") && (sLineText[0] != ';'))
                            {
                                sLineText = HUtil32.GetValidStr3(sLineText, ref ItemCount, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref Note, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref Name, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxHP, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxMP, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref DC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxDC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxMC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref SC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxSC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref AC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxAC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MAC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxMAC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref HitPoint, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref SpeedPoint, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref HealthRecover, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref SpellRecover, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref RiskRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved1, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved2, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved3, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nEXPRATE, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nPowerRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nMagicRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nSCRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nACRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nMACRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nAntiMagic, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nAntiPoison, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nPoisonRecover, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboTeleport, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboParalysis, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboRevival, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboMagicShield, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboUnParalysis, new string[] { " " });
                                if ((ItemCount == "") || (Name == "")) { continue; }
                                SuitItem = new TSuitItem();
                                SuitItem.ItemCount = Convert.ToByte(ItemCount);
                                SuitItem.Note = Note;
                                SuitItem.Name = Name;
                                SuitItem.MaxHP = HUtil32._MIN(100, HUtil32.Str_ToInt(MaxHP, 0));
                                SuitItem.MaxMP = HUtil32._MIN(100, HUtil32.Str_ToInt(MaxMP, 0));
                                SuitItem.DC = (ushort)HUtil32.Str_ToInt(DC, 0);// ������
                                SuitItem.MaxDC = (ushort)HUtil32.Str_ToInt(MaxDC, 0);
                                SuitItem.MC = (ushort)HUtil32.Str_ToInt(MC, 0);// ħ��
                                SuitItem.MaxMC = (ushort)HUtil32.Str_ToInt(MaxMC, 0);
                                SuitItem.SC = (ushort)HUtil32.Str_ToInt(SC, 0);// ����
                                SuitItem.MaxSC = (ushort)HUtil32.Str_ToInt(MaxSC, 0);
                                SuitItem.AC = HUtil32.Str_ToInt(AC, 0);// ����
                                SuitItem.MaxAC = HUtil32.Str_ToInt(MaxAC, 0);
                                SuitItem.MAC = (ushort)HUtil32.Str_ToInt(MAC, 0);// ħ��
                                SuitItem.MaxMAC = (ushort)HUtil32.Str_ToInt(MaxMAC, 0);
                                SuitItem.HitPoint = (byte)HUtil32.Str_ToInt(HitPoint, 0);// ��ȷ��
                                SuitItem.SpeedPoint = (byte)HUtil32.Str_ToInt(SpeedPoint, 0);// ���ݶ�
                                SuitItem.HealthRecover = (sbyte)HUtil32.Str_ToInt(HealthRecover, 0);// �����ָ�
                                SuitItem.SpellRecover = (sbyte)HUtil32.Str_ToInt(SpellRecover, 0);// ħ���ָ�
                                SuitItem.RiskRate = HUtil32.Str_ToInt(RiskRate, 0);// ���ʻ���
                                SuitItem.btReserved = (byte)HUtil32.Str_ToInt(btReserved, 0);// ��Ѫ(����)
                                SuitItem.btReserved1 = (byte)HUtil32.Str_ToInt(btReserved1, 0);// ����
                                SuitItem.btReserved2 = (byte)HUtil32.Str_ToInt(btReserved2, 0);// ����
                                SuitItem.btReserved3 = (byte)HUtil32.Str_ToInt(btReserved3, 0);// ����
                                SuitItem.nEXPRATE = HUtil32.Str_ToInt(nEXPRATE, 1);// ���鱶��
                                SuitItem.nPowerRate = (byte)HUtil32.Str_ToInt(nPowerRate, 1);// ��������
                                SuitItem.nMagicRate = (byte)HUtil32.Str_ToInt(nMagicRate, 1);// ħ������
                                SuitItem.nSCRate = (byte)HUtil32.Str_ToInt(nSCRate, 1);// ��������
                                SuitItem.nACRate = (byte)HUtil32.Str_ToInt(nACRate, 1);// ��������
                                SuitItem.nMACRate = (byte)HUtil32.Str_ToInt(nMACRate, 1);// ħ������
                                SuitItem.nAntiMagic = (sbyte)HUtil32.Str_ToInt(nAntiMagic, 0);// ħ�����
                                SuitItem.nAntiPoison = (byte)HUtil32.Str_ToInt(nAntiPoison, 0);// ������
                                SuitItem.nPoisonRecover = (sbyte)HUtil32.Str_ToInt(nPoisonRecover, 0);// �ж��ָ�
                                SuitItem.boTeleport = sboTeleport != "0";// ���� 
                                SuitItem.boParalysis = sboParalysis != "0";// ���
                                SuitItem.boRevival = sboRevival != "0";// ����
                                SuitItem.boMagicShield = sboMagicShield != "0";// ����
                                SuitItem.boUnParalysis = sboUnParalysis != "0";// �����
                                M2Share.SuitItemList.Add(SuitItem);
                            }
                        }
                    }
                }
                else
                {
                    LoadList.SaveToFile(sFileName);
                }
            }
            finally
            {
                Dispose(LoadList);
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>
        /// ��ȡ������������
        /// </summary>
        public void LoadRefineItem()
        {
            int I;
            string n1 = string.Empty;
            string n11 = string.Empty;
            string n2 = string.Empty;
            string n22 = string.Empty;
            string n3 = string.Empty;
            string n33 = string.Empty;
            string n4 = string.Empty;
            string n44 = string.Empty;
            string n5 = string.Empty;
            string n55 = string.Empty;
            string n6 = string.Empty;
            string n66 = string.Empty;
            string n7 = string.Empty;
            string n77 = string.Empty;
            string n8 = string.Empty;
            string n88 = string.Empty;
            string n9 = string.Empty;
            string n99 = string.Empty;
            string nA = string.Empty;
            string nAA = string.Empty;
            string nB = string.Empty;
            string nBB = string.Empty;
            string nC = string.Empty;
            string nCC = string.Empty;
            string nD = string.Empty;
            string nDD = string.Empty;
            string nE = string.Empty;
            string nEE = string.Empty;
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s25 = string.Empty;
            string s26 = string.Empty;
            string s27 = string.Empty;
            string s28 = string.Empty;
            TStringList LoadList;
            string sFileName = string.Empty;
            IList<TRefineItemInfo> List28;
            TRefineItemInfo TRefineItemInfo;
            sFileName = M2Share.g_Config.sEnvirDir + "RefineItem.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                M2Share.g_RefineItemList.Clear();
                LoadList.LoadFromFile(sFileName);
                List28 = null;
                s24 = "";
                for (I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        if (s18[0] == '[')
                        {
                            if (List28 != null)
                            {
                                //M2Share.g_RefineItemList.Add(s24, List28);
                            }
                            List28 = new List<TRefineItemInfo>();
                            HUtil32.ArrestStringEx(s18, "[", "]", ref s24);// S24-[]�������
                        }
                        else
                        {
                            if (List28 != null)
                            {
                                s18 = HUtil32.GetValidStr3(s18, ref s20, new string[] { " ", "\t" });// S20-��Ʒ���� N14-����
                                s18 = HUtil32.GetValidStr3(s18, ref s25, new string[] { " ", "\t" });// �����ɹ���
                                s18 = HUtil32.GetValidStr3(s18, ref s26, new string[] { " ", "\t" });// ʧ�ܻ�ԭ��
                                s18 = HUtil32.GetValidStr3(s18, ref s27, new string[] { " ", "\t" });// ����ʯ�Ƿ���ʧ 0-����1�־�,1-��ʧ
                                s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });// ��Ʒ����
                                s18 = HUtil32.GetValidStr3(s18, ref n1, new string[] { "-", ",", "\t" });// ������ֵ���Ѷ�
                                s18 = HUtil32.GetValidStr3(s18, ref n11, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n2, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n22, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n3, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n33, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n4, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n44, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n5, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n55, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n6, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n66, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n7, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n77, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n8, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n88, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n9, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n99, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nA, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nAA, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nB, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nBB, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nC, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nCC, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nD, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nDD, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nE, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nEE, new string[] { "-", ",", "\t" });
                                if (s20 != "")
                                {
                                    TRefineItemInfo = new TRefineItemInfo();
                                    TRefineItemInfo.sItemName = s20;
                                    TRefineItemInfo.nRefineRate = HUtil32.Str_ToByte(s25.Trim(), 0);
                                    TRefineItemInfo.nReductionRate = HUtil32.Str_ToByte(s26.Trim(), 0);
                                    TRefineItemInfo.boDisappear = HUtil32.Str_ToInt(s27.Trim(), 0) == 0;// 0-���־� 1-��ʧ
                                    TRefineItemInfo.nNeedRate = HUtil32.Str_ToByte(s28.Trim(), 0);
                                    unsafe
                                    {
                                        TAttribute* nAttribute = (TAttribute*)TRefineItemInfo.TAttributeBuff;
                                        nAttribute[0].nPoints = HUtil32.Str_ToByte(n1.Trim(), 0);
                                        nAttribute[0].nDifficult = HUtil32.Str_ToByte(n11.Trim(), 0);
                                        nAttribute[0].nPoints = HUtil32.Str_ToByte(n2.Trim(), 0);
                                        nAttribute[0].nDifficult = HUtil32.Str_ToByte(n22.Trim(), 0);
                                        nAttribute[2].nPoints = HUtil32.Str_ToByte(n3.Trim(), 0);
                                        nAttribute[2].nDifficult = HUtil32.Str_ToByte(n33.Trim(), 0);
                                        nAttribute[3].nPoints = HUtil32.Str_ToByte(n4.Trim(), 0);
                                        nAttribute[3].nDifficult = HUtil32.Str_ToByte(n44.Trim(), 0);
                                        nAttribute[4].nPoints = HUtil32.Str_ToByte(n5.Trim(), 0);
                                        nAttribute[4].nDifficult = HUtil32.Str_ToByte(n55.Trim(), 0);
                                        nAttribute[5].nPoints = HUtil32.Str_ToByte(n6.Trim(), 0);
                                        nAttribute[5].nDifficult = HUtil32.Str_ToByte(n66.Trim(), 0);
                                        nAttribute[6].nPoints = HUtil32.Str_ToByte(n7.Trim(), 0);
                                        nAttribute[6].nDifficult = HUtil32.Str_ToByte(n77.Trim(), 0);
                                        nAttribute[7].nPoints = HUtil32.Str_ToByte(n8.Trim(), 0);
                                        nAttribute[7].nDifficult = HUtil32.Str_ToByte(n88.Trim(), 0);
                                        nAttribute[8].nPoints = HUtil32.Str_ToByte(n9.Trim(), 0);
                                        nAttribute[8].nDifficult = HUtil32.Str_ToByte(n99.Trim(), 0);
                                        nAttribute[9].nPoints = HUtil32.Str_ToByte(nA.Trim(), 0);
                                        nAttribute[9].nDifficult = HUtil32.Str_ToByte(nAA.Trim(), 0);
                                        nAttribute[10].nPoints = HUtil32.Str_ToByte(nB.Trim(), 0);
                                        nAttribute[10].nDifficult = HUtil32.Str_ToByte(nBB.Trim(), 0);
                                        nAttribute[11].nPoints = HUtil32.Str_ToByte(nC.Trim(), 0);
                                        nAttribute[11].nDifficult = HUtil32.Str_ToByte(nCC.Trim(), 0);
                                        nAttribute[12].nPoints = HUtil32.Str_ToByte(nD.Trim(), 0);
                                        nAttribute[12].nDifficult = HUtil32.Str_ToByte(nDD.Trim(), 0);
                                        nAttribute[13].nPoints = HUtil32.Str_ToByte(nE.Trim(), 0);
                                        nAttribute[13].nDifficult = HUtil32.Str_ToByte(nEE.Trim(), 0);
                                    }
                                    List28.Add(TRefineItemInfo);
                                }
                            }
                        }
                    }
                }
                if (List28 != null)
                {
                    //M2Share.g_RefineItemList.Add(s24, List28);
                }
            }
            else
            {
                LoadList.Add(";��Ϊ���������ļ�");
                LoadList.Add(";���������鿴�����ĵ�");
                LoadList.Add(";���������Ʒ �����ɹ����� ʧ�ܻ�ԭ���� ����ʯ�Ƿ���ʧ ������Ʒ���Լ��� ������Ʒ��������");
                LoadList.Add(";[����ʯ+����ͷ��+����ս��]");
                LoadList.Add(";����ħ�� 30 30 0 1 0-5,0-5,0-5,4-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,");
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
        }

        /// <summary>
        /// �����ػ��޲�д���б�
        /// </summary>
        public void LoadMonFireDragonGuard()
        {
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            TStringList LoadList;
            TBaseObject Monster;
            string sFileName = M2Share.g_Config.sEnvirDir + "FireDragonGuard.txt";
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.Add(";����        ��ͼ    x    y  dir(0-1)  ��������x  ��������Y(����Ϊ�����|�ָ�) ");
                    LoadList.Add("�����ػ���  D2083    51,67  1  77,50|74,50|83,50|80,53|86,53|74,41|71,41|71,44|71,47");
                    LoadList.Add("�����ػ���  D2083    48,70  1  81,44|81,47|78,44|75,44|84,47|78,41|75,41|81,50|84,50");
                    LoadList.Add("�����ػ���  D2083    45,73  1  81,44|84,47|78,41|85,50|75,41|76,51|79,54|73,48");
                    LoadList.Add("�����ػ���  D2083    61,78  0  79,48|79,51|76,48|78,53|75,50|76,45|82,51|81,44|84,47|78,41");
                    LoadList.Add("�����ػ���  D2083    58,81  0  79,48|82,51|85,54|76,45|71,40|82,48|79,45|76,42|85,51|73,42");
                    LoadList.Add("�����ػ���  D2083    55,84  0  80,48|77,48|80,45|77,51|74,51|74,54|71,54|71,57");
                    LoadList.SaveToFile(sFileName);
                }
                finally
                {
                    Dispose(LoadList);
                }
            }
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        s18 = LoadList[I].Trim();
                        if ((s18 != "") && (s18[0] != ';'))
                        {
                            s18 = HUtil32.GetValidStrCap(s18, ref s20, new string[] { " ", "\t" });// ����
                            s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });// ��ͼ
                            s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });// ����
                            s30 = HUtil32.GetValidStr3(s24, ref s2C, new string[] { ",", "\t" });// X,Y
                            s18 = HUtil32.GetValidStr3(s18, ref s34, new string[] { " ", "\t" });// ����
                            s18 = HUtil32.GetValidStr3(s18, ref s38, new string[] { " ", "\t" });// ��������
                            if ((s20 != "") && (s28 != ""))
                            {
                                Monster = UserEngine.RegenMonsterByName(s28, HUtil32.Str_ToInt(s2C, 0), HUtil32.Str_ToInt(s30, 0), s20);
                                if (Monster != null)
                                {
                                    if (Monster.m_btRaceServer == 129) // �ػ��޲ż����б�
                                    {
                                        Monster.m_btDirection = (byte)HUtil32.Str_ToInt(s34, 0);
                                        ((TFireDragonGuard)(Monster)).s_AttickXY = s38;
                                        UserEngine.m_MonObjectList.Add(Monster);
                                    }
                                    else
                                    {
                                        Dispose(Monster);
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Dispose(LoadList);
                }
            }
        }

        public void Dispose(object obj)
        {
            if (obj != null)
            {
                GC.KeepAlive(obj);
                GC.ReRegisterForFinalize(obj);
            }
        }
    }
}