/****************************************************************
 ** �ļ�����HumanInfo.cs
 ** Copyright(c)2012-2020 JohnSoft
 ** �����ˣ���־ǿ
 ** ��  �ڣ�2013-4-22
 ** �޸��ˣ�
 ** ��  �ڣ�
 ** ��  ���������б� ��ϸ��Ϣ
 ****************************************************************/
using System;
using System.Windows.Forms;
using GameFramework;
using System.Text;

namespace M2Server
{
    public partial class TfrmHumanInfo: Form
    {
        public static bool boRefHuman = false;//ʵʱ���
        public TPlayObject PlayObject = null;//��ǰ���

        /****************************************************************
        ** �� �� ����TfrmHumanInfo
        ** �������������캯��
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public TfrmHumanInfo()
        {
            InitializeComponent();
        }

        /****************************************************************
        ** �� �� ����TfrmHumanInfo_Load
        ** ������������������
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void TfrmHumanInfo_Load(object sender, EventArgs e)
        {
            GridUserItem.Columns.Add("װ��λ��");
            GridUserItem.Columns.Add("װ������");
            GridUserItem.Columns.Add("ϵ�к�");
            GridUserItem.Columns.Add("�־�");
            GridUserItem.Columns.Add("��");
            GridUserItem.Columns.Add("ħ");
            GridUserItem.Columns.Add("��");
            GridUserItem.Columns.Add("��");
            GridUserItem.Columns.Add("ħ��");
            GridUserItem.Columns.Add("��������");
            GridUserItem.Items.Add("�·�");
            GridUserItem.Items.Add("����");
            GridUserItem.Items.Add("������");
            GridUserItem.Items.Add("����");
            GridUserItem.Items.Add("ͷ��");
            GridUserItem.Items.Add("������");
            GridUserItem.Items.Add("������");
            GridUserItem.Items.Add("���ָ");
            GridUserItem.Items.Add("�ҽ�ָ");
            GridUserItem.Items.Add("��Ʒ");
            GridUserItem.Items.Add("����");
            GridUserItem.Items.Add("Ь��");
            GridUserItem.Items.Add("��ʯ");
            foreach (ListViewItem lvItem in GridUserItem.Items)
            {
                for (int i = 1; i <= 9; i++)
                {
                    lvItem.SubItems.Add("");
                }
            }

            GridBagItem.Columns.Add("���");
            GridBagItem.Columns.Add("װ������");
            GridBagItem.Columns.Add("ϵ�к�");
            GridBagItem.Columns.Add("�־�");
            GridBagItem.Columns.Add("��");
            GridBagItem.Columns.Add("ħ");
            GridBagItem.Columns.Add("��");
            GridBagItem.Columns.Add("��");
            GridBagItem.Columns.Add("ħ��");
            GridBagItem.Columns.Add("��������");

            GridStorageItem.Columns.Add("���");
            GridStorageItem.Columns.Add("װ������");
            GridStorageItem.Columns.Add("ϵ�к�");
            GridStorageItem.Columns.Add("�־�");
            GridStorageItem.Columns.Add("��");
            GridStorageItem.Columns.Add("ħ");
            GridStorageItem.Columns.Add("��");
            GridStorageItem.Columns.Add("��");
            GridStorageItem.Columns.Add("ħ��");
            GridStorageItem.Columns.Add("��������");

            GridHeroUserItem.Columns.Add("װ��λ��");
            GridHeroUserItem.Columns.Add("װ������");
            GridHeroUserItem.Columns.Add("ϵ�к�");
            GridHeroUserItem.Columns.Add("�־�");
            GridHeroUserItem.Columns.Add("��");
            GridHeroUserItem.Columns.Add("ħ");
            GridHeroUserItem.Columns.Add("��");
            GridHeroUserItem.Columns.Add("��");
            GridHeroUserItem.Columns.Add("ħ��");
            GridHeroUserItem.Columns.Add("��������");
            GridHeroUserItem.Items.Add("�·�");
            GridHeroUserItem.Items.Add("����");
            GridHeroUserItem.Items.Add("������");
            GridHeroUserItem.Items.Add("����");
            GridHeroUserItem.Items.Add("ͷ��");
            GridHeroUserItem.Items.Add("������");
            GridHeroUserItem.Items.Add("������");
            GridHeroUserItem.Items.Add("���ָ");
            GridHeroUserItem.Items.Add("�ҽ�ָ");
            GridHeroUserItem.Items.Add("��Ʒ");
            GridHeroUserItem.Items.Add("����");
            GridHeroUserItem.Items.Add("Ь��");
            GridHeroUserItem.Items.Add("��ʯ");
            foreach (ListViewItem lvItem in GridHeroUserItem.Items)
            {
                for (int i = 1; i <= 9; i++)
                {
                    lvItem.SubItems.Add("");
                }
            }

            GridHeroBagItem.Columns.Add("���");
            GridHeroBagItem.Columns.Add("װ������");
            GridHeroBagItem.Columns.Add("ϵ�к�");
            GridHeroBagItem.Columns.Add("�־�");
            GridHeroBagItem.Columns.Add("��");
            GridHeroBagItem.Columns.Add("ħ");
            GridHeroBagItem.Columns.Add("��");
            GridHeroBagItem.Columns.Add("��");
            GridHeroBagItem.Columns.Add("ħ��");
            GridHeroBagItem.Columns.Add("��������");

            PageControl1.SelectedIndex = 0;
            //PageControl1.TabPages[6].TabVisible = true;
            //PageControl1.TabPages[7].TabVisible = true;
            //PageControl1.TabPages[8].TabVisible = true;
            //PageControl1.TabPages[6].TabVisible = false;
            //PageControl1.TabPages[7].TabVisible = false;
            //PageControl1.TabPages[8].TabVisible = false;

            PageControl1.SelectedTab = TabSheet1;
            // 20080901 ����
            RefHumanInfo();
            ButtonKick.Enabled = true;
            Timer.Enabled = true;
            CheckBoxMonitor.Checked = false;
        }

        /****************************************************************
        ** �� �� ����RefHumanInfo
        ** ����������ˢ�±��
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private unsafe void RefHumanInfo()
        {
            int i;
            int nTotleUsePoint;
            TStdItem StdItem;
            TStdItem *Item;
            TUserItem* UserItem;
            if ((PlayObject == null))
            {
                return;
            }
            if (PlayObject.m_boNotOnlineAddExp)
            {
                EditSayMsg.Enabled = true;
            }
            else
            {
                EditSayMsg.Enabled = false;
            }
            EditSayMsg.Text = PlayObject.m_sAutoSendMsg;
            EditName.Text = PlayObject.m_sCharName;
            EditMap.Text = PlayObject.m_sMapName + "(" + PlayObject.m_PEnvir.sMapDesc + ")";
            EditXY.Text = (PlayObject.m_nCurrX).ToString() + ":" + (PlayObject.m_nCurrY).ToString();
            EditAccount.Text = PlayObject.m_sUserID;
            EditIPaddr.Text = PlayObject.m_sIPaddr;
            EditLogonTime.Text = (PlayObject.m_dLogonTime).ToString();
            EditLogonLong.Text = ((HUtil32.GetTickCount() - PlayObject.m_dwLogonTick) / 60000).ToString() + " ����";//��½ʱ��(��)// (60 * 1000)
            EditLevel.Value = PlayObject.m_Abil.Level;
            EditGold.Value = PlayObject.m_nGold;
            EditPKPoint.Value = PlayObject.m_nPkPoint;
            EditExp.Value = PlayObject.m_Abil.Exp;
            EditMaxExp.Value = PlayObject.m_Abil.MaxExp;
            if (PlayObject.m_boTrainingNG)
            {
                EditNGLevel.Enabled = true;
                EditExpSkill69.Enabled = true;
                EditNGLevel.Value = PlayObject.m_NGLevel;
                // 20081005 �ڹ��ȼ�
                EditExpSkill69.Value = PlayObject.m_ExpSkill69;
            // 20081005 �ڹ��ķ���ǰ����
            }
            
            
            EditAC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.AC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.AC)).ToString();
            // ����
            
            
            EditMAC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.MAC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.MAC)).ToString();
            // ħ��
            
            
            EditDC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.DC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.DC)).ToString();
            // ������
            
            
            EditMC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.MC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.MC)).ToString();
            // ħ��
            
            
            EditSC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.SC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.SC)).ToString();
            // ����
            EditHP.Text = (PlayObject.m_WAbil.HP).ToString() + "/" + (PlayObject.m_WAbil.MaxHP).ToString();
            EditMP.Text = (PlayObject.m_WAbil.MP).ToString() + "/" + (PlayObject.m_WAbil.MaxMP).ToString();
            EditGameGold.Value = PlayObject.m_nGameGold;
            EditGameDiaMond.Value = PlayObject.m_nGAMEDIAMOND;
            // ���ʯ
            EditGameGird.Value = PlayObject.m_nGAMEGIRD;
            // ���
            EditGamePoint.Value = PlayObject.m_nGamePoint;
            EditCreditPoint.Value = PlayObject.m_btCreditPoint;
            EditBonusPoint.Value = PlayObject.m_nBonusPoint;
            nTotleUsePoint = PlayObject.m_BonusAbil.DC + PlayObject.m_BonusAbil.MC + PlayObject.m_BonusAbil.SC + PlayObject.m_BonusAbil.AC + PlayObject.m_BonusAbil.MAC + PlayObject.m_BonusAbil.HP + PlayObject.m_BonusAbil.MP + PlayObject.m_BonusAbil.Hit + PlayObject.m_BonusAbil.Speed + PlayObject.m_BonusAbil.X2;
            EditEditBonusPointUsed.Value = nTotleUsePoint;
            CheckBoxGameMaster.Checked = PlayObject.m_boAdminMode;
            CheckBoxSuperMan.Checked = PlayObject.m_boSuperMan;
            CheckBoxObserver.Checked = PlayObject.m_boObMode;
            if (PlayObject.m_boDeath)
            {
                EditHumanStatus.Text = "����";
            }
            else if (PlayObject.m_boGhost)
            {
                EditHumanStatus.Text = "����";
                PlayObject = null;
            }
            else
            {
                EditHumanStatus.Text = "����";
            }

            //������Ʒ
            for (i = PlayObject.m_UseItems.GetLowerBound(0); i <= PlayObject.m_UseItems.GetUpperBound(0); i ++ )
            {
                UserItem = PlayObject.m_UseItems[i];
                if (UserItem->wIndex == 0) continue;
                StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem.Name == null)
                {
                    GridUserItem.Items[i].SubItems[1].Text="";
                    GridUserItem.Items[i].SubItems[2].Text="";
                    GridUserItem.Items[i].SubItems[3].Text="";
                    GridUserItem.Items[i].SubItems[4].Text="";
                    GridUserItem.Items[i].SubItems[5].Text="";
                    GridUserItem.Items[i].SubItems[6].Text="";
                    GridUserItem.Items[i].SubItems[7].Text="";
                    GridUserItem.Items[i].SubItems[8].Text="";
                    GridUserItem.Items[i].SubItems[9].Text="";
                    continue;
                }
                Item = &StdItem;
                M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                GridUserItem.Items[i].SubItems[1].Text = (HUtil32.SBytePtrToString(Item->Name, (int)Item->NameLen));
                GridUserItem.Items[i].SubItems[2].Text = (UserItem->MakeIndex.ToString());
                GridUserItem.Items[i].SubItems[3].Text = (string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                GridUserItem.Items[i].SubItems[4].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                GridUserItem.Items[i].SubItems[5].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                GridUserItem.Items[i].SubItems[6].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                GridUserItem.Items[i].SubItems[7].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                GridUserItem.Items[i].SubItems[8].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                GridUserItem.Items[i].SubItems[9].Text = (string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
            }

            //����
            i = 0;
            GridBagItem.Items.Clear();
            foreach(IntPtr pItem in PlayObject.m_ItemList)
            {
                UserItem = (TUserItem*)pItem;
                StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem.Name == null)
                {
                    GridBagItem.Items[i].SubItems[1].Text = "";
                    GridBagItem.Items[i].SubItems[2].Text = "";
                    GridBagItem.Items[i].SubItems[3].Text = "";
                    GridBagItem.Items[i].SubItems[4].Text = "";
                    GridBagItem.Items[i].SubItems[5].Text = "";
                    GridBagItem.Items[i].SubItems[6].Text = "";
                    GridBagItem.Items[i].SubItems[7].Text = "";
                    GridBagItem.Items[i].SubItems[8].Text = "";
                    GridBagItem.Items[i].SubItems[9].Text = "";
                    continue;
                }
                Item = &StdItem;
                M2Share.ItemUnit.GetItemAddValue(UserItem,Item);
                ListViewItem lvItem = GridBagItem.Items.Add(i.ToString());
                lvItem.SubItems.Add(HUtil32.SBytePtrToString(Item->Name,Item->NameLen));
                lvItem.SubItems.Add(UserItem->MakeIndex.ToString());
                lvItem.SubItems.Add(string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                i++;
            }

            //�ֿ�
            i = 0;
            GridStorageItem.Items.Clear();
            foreach (IntPtr pItem in PlayObject.m_StorageItemList)
            {
                UserItem = (TUserItem*)pItem;
                StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem.Name == null)
                {
                    GridStorageItem.Items[i].SubItems[1].Text = "";
                    GridStorageItem.Items[i].SubItems[2].Text = "";
                    GridStorageItem.Items[i].SubItems[3].Text = "";
                    GridStorageItem.Items[i].SubItems[4].Text = "";
                    GridStorageItem.Items[i].SubItems[5].Text = "";
                    GridStorageItem.Items[i].SubItems[6].Text = "";
                    GridStorageItem.Items[i].SubItems[7].Text = "";
                    GridStorageItem.Items[i].SubItems[8].Text = "";
                    GridStorageItem.Items[i].SubItems[9].Text = "";
                    continue;
                }
                Item = &StdItem;
                M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                ListViewItem lvItem = GridStorageItem.Items.Add(i.ToString());
                lvItem.SubItems.Add(HUtil32.SBytePtrToString(Item->Name, Item->NameLen));
                lvItem.SubItems.Add(UserItem->MakeIndex.ToString());
                lvItem.SubItems.Add(string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                i++;
            }

//#if HEROVERSION = 1 //�ж��Ƿ�ΪӢ�۰汾��M2

            try 
            {
                if (PlayObject.m_MyHero == null)
                {
                    return;
                }
                EditHeroName.Text = PlayObject.m_MyHero.m_sCharName;
                EditHeroMap.Text = PlayObject.m_MyHero.m_sMapName + "(" + PlayObject.m_PEnvir.sMapDesc + ")";
                EditHeroXY.Text = (PlayObject.m_MyHero.m_nCurrX).ToString() + ":" + (PlayObject.m_MyHero.m_nCurrY).ToString();
                EditHeroLevel.Value = PlayObject.m_MyHero.m_Abil.Level;
                EditHeroPKPoint.Value = PlayObject.m_MyHero.m_nPkPoint;
                EditHeroExp.Value = PlayObject.m_MyHero.m_Abil.Exp;
                EditHeroMaxExp.Value = PlayObject.m_MyHero.m_Abil.MaxExp;
                EditHeroLoyal.Value = ((THeroObject)(PlayObject.m_MyHero)).m_nLoyal;
                // Ӣ�۵��ҳ϶�(20080110)
                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
                {
                    EditHeroNGLevel.Enabled = true;
                    EditHeroExpSkill69.Enabled = true;
                    EditHeroNGLevel.Value = ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel;
                    // 20081005 �ڹ��ȼ�
                    EditHeroExpSkill69.Value = ((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69;
                // 20081005 �ڹ��ķ���ǰ����
                }


                //������Ʒ
                for (i = PlayObject.m_MyHero.m_UseItems.GetLowerBound(0); i <= PlayObject.m_UseItems.GetUpperBound(0); i++)
                {
                    UserItem = PlayObject.m_UseItems[i];
                    if (UserItem->wIndex == 0) continue;
                    StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem.Name == null)
                    {
                        GridHeroUserItem.Items[i].SubItems[1].Text = "";
                        GridHeroUserItem.Items[i].SubItems[2].Text = "";
                        GridHeroUserItem.Items[i].SubItems[3].Text = "";
                        GridHeroUserItem.Items[i].SubItems[4].Text = "";
                        GridHeroUserItem.Items[i].SubItems[5].Text = "";
                        GridHeroUserItem.Items[i].SubItems[6].Text = "";
                        GridHeroUserItem.Items[i].SubItems[7].Text = "";
                        GridHeroUserItem.Items[i].SubItems[8].Text = "";
                        GridHeroUserItem.Items[i].SubItems[9].Text = "";
                        continue;
                    }
                    Item = &StdItem;
                    M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                    GridHeroUserItem.Items[i].SubItems[1].Text = (HUtil32.SBytePtrToString(Item->Name, (int)Item->NameLen));
                    GridHeroUserItem.Items[i].SubItems[2].Text = (UserItem->MakeIndex.ToString());
                    GridHeroUserItem.Items[i].SubItems[3].Text = (string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                    GridHeroUserItem.Items[i].SubItems[4].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                    GridHeroUserItem.Items[i].SubItems[5].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                    GridHeroUserItem.Items[i].SubItems[6].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                    GridHeroUserItem.Items[i].SubItems[7].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                    GridHeroUserItem.Items[i].SubItems[8].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                    GridHeroUserItem.Items[i].SubItems[9].Text = (string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                }

                //����
                i = 0;
                GridHeroBagItem.Items.Clear();
                foreach (IntPtr pItem in PlayObject.m_MyHero.m_ItemList)
                {
                    UserItem = (TUserItem*)pItem;
                    StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem.Name == null)
                    {
                        GridHeroBagItem.Items[i].SubItems[1].Text = "";
                        GridHeroBagItem.Items[i].SubItems[2].Text = "";
                        GridHeroBagItem.Items[i].SubItems[3].Text = "";
                        GridHeroBagItem.Items[i].SubItems[4].Text = "";
                        GridHeroBagItem.Items[i].SubItems[5].Text = "";
                        GridHeroBagItem.Items[i].SubItems[6].Text = "";
                        GridHeroBagItem.Items[i].SubItems[7].Text = "";
                        GridHeroBagItem.Items[i].SubItems[8].Text = "";
                        GridHeroBagItem.Items[i].SubItems[9].Text = "";
                        continue;
                    }
                    Item = &StdItem;
                    M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                    ListViewItem lvItem = GridHeroBagItem.Items.Add(i.ToString());
                    lvItem.SubItems.Add(HUtil32.SBytePtrToString(Item->Name, Item->NameLen));
                    lvItem.SubItems.Add(UserItem->MakeIndex.ToString());
                    lvItem.SubItems.Add(string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                    i++;
                }
            }
            catch {
            }


        }

        /****************************************************************
        ** �� �� ����Timer_Tick
        ** ����������ʵʱʱ��
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (PlayObject == null)
            {
                return;
            }
            if (PlayObject.m_boGhost)
            {
                EditHumanStatus.Text = "����";
                PlayObject = null;
                return;
            }
            if (boRefHuman)
            {
                RefHumanInfo();
            }
        }

        /****************************************************************
        ** �� �� ����CheckBoxMonitor_CheckedChanged
        ** ����������ʵʱ���
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void CheckBoxMonitor_CheckedChanged(object sender, EventArgs e)
        {
            boRefHuman = CheckBoxMonitor.Checked;
            ButtonSave.Enabled = !boRefHuman;
        }

        /****************************************************************
        ** �� �� ����ButtonKick_Click
        ** ���������������߰�ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void ButtonKick_Click(object sender, EventArgs e)
        {
            if (PlayObject == null)
            {
                return;
            }
            PlayObject.m_boEmergencyClose = true;
            PlayObject.m_boNotOnlineAddExp = false;
            PlayObject.m_boPlayOffLine = false;
            ButtonKick.Enabled = false;
        }

        /****************************************************************
        ** �� �� ����ButtonSave_Click
        ** �����������޸����ݰ�ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-22
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            int nLevel;
            int nGold;
            int nPKPOINT;
            int nGameGold;
            int nGameDiaMond;
            // 20071226 ���ʯ
            int nGameGird;
            // 20071226 ���
            int nLoyal;
            // Ӣ�۵��ҳ϶�(20080109)
            int nGamePoint;
            int nCreditPoint;
            int nBonusPoint;
            bool boGameMaster;
            bool boObServer;
            bool boSuperman;
            string sAutoSendMsg;
            if (PlayObject == null)
            {
                return;
            }
            sAutoSendMsg = EditSayMsg.Text.Trim();
            nLevel = (int)EditLevel.Value;
            nGold = (int)EditGold.Value;
            nPKPOINT = (int)EditPKPoint.Value;
            nGameGold = (int)EditGameGold.Value;
            nGameDiaMond = (int)EditGameDiaMond.Value;
            // 20071226 ���ʯ
            nGameGird = (int)EditGameGird.Value;
            // 20071226 ���
            nLoyal = (int)EditHeroLoyal.Value;
            // Ӣ�۵��ҳ϶�(20080109)
            nGamePoint = (int)EditGamePoint.Value;
            nCreditPoint = (int)EditCreditPoint.Value;
            nBonusPoint = (int)EditBonusPoint.Value;
            boGameMaster = CheckBoxGameMaster.Checked;
            boObServer = CheckBoxObserver.Checked;
            boSuperman = CheckBoxSuperMan.Checked;

            // (*or (nCreditPoint > High(Integer{Byte}))*)
            // 20080118
            if ((nLevel < 0) || (nLevel > ushort.MaxValue) || (nGold < 0) || (nGold > 200000000) || (nPKPOINT < 0) || (nPKPOINT > 2000000) || (nCreditPoint < 0) || (nBonusPoint < 0) || (nBonusPoint > 20000000) || (nLoyal > 10000))
            {
                MessageBox.Show("�������ݲ���ȷ������", "������Ϣ",System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }
            PlayObject.m_sAutoSendMsg = sAutoSendMsg;
            if (PlayObject.m_Abil.Level != nLevel)
            {
                // �ȼ�������¼��־ 20081102
                M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09" + PlayObject.m_sCharName + "\09" + (PlayObject.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "����(" + (nLevel).ToString() + ")" + "\09" + "�������ﴰ��");
            }
            PlayObject.m_Abil.Level = (ushort)nLevel;
            PlayObject.m_nGold = nGold;
            PlayObject.m_nPkPoint = nPKPOINT;
            PlayObject.m_nGameGold = nGameGold;
            PlayObject.m_nGAMEDIAMOND = nGameDiaMond;
            // 20071226 ���ʯ
            PlayObject.m_nGAMEGIRD = nGameGird;
            // 20071226 ���
            PlayObject.m_nGamePoint = (ushort)nGamePoint;
            PlayObject.m_btCreditPoint = nCreditPoint;
            PlayObject.m_nBonusPoint = nBonusPoint;
            PlayObject.m_boAdminMode = boGameMaster;
            PlayObject.m_boObMode = boObServer;
            PlayObject.m_boSuperMan = boSuperman;
            if (PlayObject.m_boTrainingNG)
            {
                PlayObject.m_NGLevel = (byte)EditNGLevel.Value;
                // 20081005 �ڹ��ȼ�
                PlayObject.m_ExpSkill69 = (uint)EditExpSkill69.Value;
                // 20081005 �ڹ��ķ���ǰ����
                PlayObject.SendNGData();
            // �����ڹ����� 20081005
            }
            PlayObject.GoldChanged();
            PlayObject.GameGoldChanged();
            // 20080211
            PlayObject.HasLevelUp(1);
            //#if HEROVERSION = 1
            if (PlayObject.m_MyHero != null)
            {
                nLevel = (int)EditHeroLevel.Value;
                nPKPOINT = (int)EditHeroPKPoint.Value;
                if (PlayObject.m_MyHero.m_Abil.Level != nLevel)
                {
                    // �ȼ�������¼��־ 20081102
                    M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_MyHero.m_sMapName + "\09" + (PlayObject.m_MyHero.m_nCurrX).ToString() + "\09" + (PlayObject.m_MyHero.m_nCurrY).ToString() + "\09" + PlayObject.m_MyHero.m_sCharName + "\09" + (PlayObject.m_MyHero.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "����(" + (nLevel).ToString() + ")" + "\09" + "�������ﴰ��");
                }
                PlayObject.m_MyHero.m_Abil.Level = (ushort)nLevel;
                PlayObject.m_MyHero.m_nPkPoint = nPKPOINT;
                ((THeroObject)(PlayObject.m_MyHero)).m_nLoyal = nLoyal;
                // Ӣ�۵��ҳ϶�(20080110)
                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
                {
                    ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel = (byte)EditHeroNGLevel.Value;
                    // 20081005 �ڹ��ȼ�
                    ((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69 = (uint)EditHeroExpSkill69.Value;
                    // 20081005 �ڹ��ķ���ǰ����
                    PlayObject.m_MyHero.SendNGData();
                // �����ڹ����� 20081005
                }
                PlayObject.m_MyHero.HasLevelUp(1);
            }
            MessageBox.Show("���������ѱ��档", "��ʾ��Ϣ",System.Windows.Forms.MessageBoxButtons.OK);
        }



    } 
}