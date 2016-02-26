/****************************************************************
 ** �ļ�����ViewOnlineHuman.cs
 ** Copyright(c)2012-2020 JohnSoft
 ** �����ˣ���־ǿ
 ** ��  �ڣ�2013-4-21
 ** �޸��ˣ�Daomi
 ** ��  �ڣ�2013-4-21 12:02 Fixed ShowHumanInfo
 ** ��  ���������б�
 ****************************************************************/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GameFramework;
using System.Drawing;

namespace M2Server
{
    public partial class TfrmViewOnlineHuman: Form
    {
        private List<TPlayObject> ViewList = null;//����б�
        private uint dwTimeOutTick = 0;//ʱ��

        /****************************************************************
        ** �� �� ����TfrmViewOnlineHuman
        ** �������������캯��
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public TfrmViewOnlineHuman()
        {
            InitializeComponent();
        }

        /****************************************************************
        ** �� �� ����TfrmViewOnlineHuman_Load
        ** �������������������¼�
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void TfrmViewOnlineHuman_Load(object sender, EventArgs e)
        {
            ViewList = new List<TPlayObject>();
            GridHuman.Columns.Add("���", 80);
            GridHuman.Columns.Add("��������", 80);
            GridHuman.Columns.Add("�Ա�", 80);
            GridHuman.Columns.Add("ְҵ", 80);
            GridHuman.Columns.Add("�ȼ�", 80);
            GridHuman.Columns.Add("�ڹ��ȼ�", 80);
            GridHuman.Columns.Add("��ͼ", 80);
            GridHuman.Columns.Add("����", 80);
            GridHuman.Columns.Add("��¼�ʺ�", 80);
            GridHuman.Columns.Add("��¼IP", 80);
            GridHuman.Columns.Add("Ȩ��", 80);
            GridHuman.Columns.Add("���ڵ���", 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGameGoldName, 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGamePointName, 80);
            GridHuman.Columns.Add(M2Share.g_Config.sPayMentPointName, 80);
            GridHuman.Columns.Add("���߹һ�", 80);
            GridHuman.Columns.Add("�Զ��ظ�", 80);
            GridHuman.Columns.Add("δ������Ϣ", 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGameDiaMond, 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGameGird, 80);
            if (M2Share.UserEngine != null)
            {
                this.Text = string.Format(" [����������{0}]", M2Share.UserEngine.PlayObjectCount);
            }
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
            Timer.Enabled = true;
        }

        /****************************************************************
        ** �� �� ����GetOnlineList
        ** ����������ȡ���������б�
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void GetOnlineList()
        {
            ViewList.Clear();
            //��������
            //ViewList.Add(new TPlayObject() { m_sCharName ="john1"});
            //ViewList.Add(new TPlayObject() { m_sCharName = "john" });
            try {
                HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                if (M2Share.UserEngine != null)
                {
                    for (int I = 0; I < M2Share.UserEngine.m_PlayObjectList.Count; I++)
                    {
                        ViewList.Add(M2Share.UserEngine.m_PlayObjectList[I]);
                    }
                }
            } finally {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        /****************************************************************
        ** �� �� ����RefGridSession
        ** ����������ˢ��������Ϣ
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void RefGridSession()
        {
            PanelStatus.Text = "����ȡ������...";
            GridHuman.Visible = false;
            GridHuman.Items.Clear();
            int i = 1;
            foreach (TPlayObject PlayObject in ViewList)
            {
                if (PlayObject != null)
                {
                    ListViewItem lvItem = GridHuman.Items.Add(i.ToString());
                    lvItem.SubItems.Add(PlayObject.m_sCharName);
                    lvItem.SubItems.Add(HUtil32.IntToSex(PlayObject.m_btGender));
                    lvItem.SubItems.Add(HUtil32.IntToJob(PlayObject.m_btJob));
                    lvItem.SubItems.Add((PlayObject.m_Abil.Level).ToString());
                    lvItem.SubItems.Add((PlayObject.m_NGLevel).ToString());
                    lvItem.SubItems.Add(PlayObject.m_sMapName);
                    lvItem.SubItems.Add((PlayObject.m_nCurrX).ToString() + ":" + (PlayObject.m_nCurrY).ToString());
                    lvItem.SubItems.Add(PlayObject.m_sUserID);
                    lvItem.SubItems.Add(PlayObject.m_sIPaddr);
                    lvItem.SubItems.Add((PlayObject.m_btPermission).ToString());
                    lvItem.SubItems.Add(PlayObject.m_sIPLocal);
                    lvItem.SubItems.Add((PlayObject.m_nGameGold).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nGamePoint).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nPayMentPoint).ToString());
                    lvItem.SubItems.Add(HUtil32.BooleanToStr(PlayObject.m_boNotOnlineAddExp));
                    lvItem.SubItems.Add(PlayObject.m_sAutoSendMsg);
                    lvItem.SubItems.Add((PlayObject.MessageCount()).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nGAMEDIAMOND).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nGAMEGIRD).ToString());
                    i++;
                }
            }
            GridHuman.Visible = true;
        }

        /****************************************************************
        ** �� �� ����Timer_Tick
        ** ����������ʱ���¼�
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((HUtil32.GetTickCount() - dwTimeOutTick > 30000) && (ViewList.Count > 0))
            {
                RefGridSession();
                if (M2Share.UserEngine != null)
                {
                    this.Text = string.Format(" [����������{0}]", M2Share.UserEngine.PlayObjectCount);
                }
                dwTimeOutTick = HUtil32.GetTickCount();
            }
        }

        /****************************************************************
        ** �� �� ����ButtonRefGrid_Click
        ** ����������ˢ�°�ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void ButtonRefGrid_Click(object sender, EventArgs e)
        {
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
        }

        /****************************************************************
        ** �� �� ����ButtonRefGrid_Click
        ** ����������������ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            TPlayObject PlayObject;
            string sHumanName = EditSearchName.Text.Trim();
            if (sHumanName == "")
            {
                MessageBox.Show("������һ���������ƣ�����", "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int I = 0; I < ViewList.Count; I++)
            {
                PlayObject = ViewList[I];
                if (string.Compare(PlayObject.m_sCharName, sHumanName, true) == 0)
                {
                    GridHuman.Items[I].Selected = true;
                    GridHuman.Items[I].BackColor = Color.Green;
                    return;
                }
            }
            MessageBox.Show("����û�����ߣ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        /****************************************************************
        ** �� �� ����ButtonRefGrid_Click
        ** ���������������߰�ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void ButtonKick_Click(object sender, EventArgs e)
        {
            TPlayObject PlayObject;
            string sHumanName = EditSearchName.Text.Trim();
            if (sHumanName == "")
            {
                MessageBox.Show("������һ���������ƣ�����", "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int I = 0; I < ViewList.Count; I++)
            {
                PlayObject = ViewList[I];
                if ((PlayObject.m_sCharName.IndexOf(sHumanName) != -1))
                {
                    PlayObject.m_boEmergencyClose = true;
                    PlayObject.m_boNotOnlineAddExp = false;
                    PlayObject.m_boPlayOffLine = false;
                }
            }
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
        }

        /****************************************************************
        ** �� �� ����ShowHumanInfo
        ** �������������������б�
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�Daomi �����ж�ѡ��Ԫ������Խ��
        ** ��    �ڣ�2013-4-21 12:02
        ****************************************************************/
        private void ShowHumanInfo()
        {
            int nSelIndex;
            string sPlayObjectName;
            TPlayObject PlayObject;
            if (GridHuman.SelectedItems.Count == 0)
            {
                MessageBox.Show("����ѡ��һ��Ҫ�鿴���������", "��ʾ��Ϣ", MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }
            nSelIndex = GridHuman.SelectedItems[0].Index;
            sPlayObjectName = GridHuman.Items[nSelIndex].SubItems[1].Text;
            PlayObject = M2Share.UserEngine.GetPlayObject(sPlayObjectName);
            if (PlayObject == null)
            {
                MessageBox.Show("�������Ѿ������ߣ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TfrmHumanInfo frmHumanInfo = new TfrmHumanInfo();
            frmHumanInfo.PlayObject = PlayObject;
            frmHumanInfo.ShowDialog(this);

        }

        /****************************************************************
        ** �� �� ����ButtonView_Click
        ** ����������������Ϣ��ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void ButtonView_Click(object sender, EventArgs e)
        {
            ShowHumanInfo();
        }

        /****************************************************************
        ** �� �� ����GridHuman_CellDoubleClick
        ** ��������������˫���¼�
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void GridHuman_DoubleClick(object sender, EventArgs e)
        {
            ShowHumanInfo();
        }

        /****************************************************************
        ** �� �� ����Button1_Click
        ** �����������߳����߹һ���ť
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void Button1_Click(object sender, EventArgs e)
        {
            int I;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                for (I = 0; I < M2Share.UserEngine.m_PlayObjectList.Count; I++)
                {
                    if (M2Share.UserEngine.m_PlayObjectList[I].m_boNotOnlineAddExp)
                    {
                        M2Share.UserEngine.m_PlayObjectList[I].m_boNotOnlineAddExp = false;
                        M2Share.UserEngine.m_PlayObjectList[I].m_boPlayOffLine = false;
                        M2Share.UserEngine.m_PlayObjectList[I].m_boKickFlag = true;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
        }

        /****************************************************************
        ** �� �� ����GridHuman_ItemSelectionChanged
        ** ����������Listѡ�����¼�
        ** �����������
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2013-4-21
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        private void GridHuman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridHuman.SelectedItems.Count == 0) return;
            EditSearchName.Text = GridHuman.SelectedItems[0].SubItems[1].Text;
        }

    } 
}

