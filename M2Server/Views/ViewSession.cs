using GameFramework;
using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewSession: Form
    {
        public TfrmViewSession()
        {
            InitializeComponent();
        }

        private void TfrmViewSession_Load(object sender, EventArgs e)
        {
            GridSession.Columns.Add("���");
            GridSession.Columns.Add("��¼�ʺ�");
            GridSession.Columns.Add("��¼��ַ");
            GridSession.Columns.Add("�ỰID��");
            GridSession.Columns.Add("��ֵ");
            GridSession.Columns.Add("��ֵģʽ");
            RefGridSession();
        }

        private void RefGridSession()
        {
            int I;
            TSessInfo SessInfo;
            PanelStatus.Text = "����ȡ������...";
            GridSession.Visible = false;
            //M2Share.FrmIDSoc.m_SessionList.__Lock();
            try
            {
                GridSession.Items.Clear();
                if (M2Share.FrmIDSoc.m_SessionList.Count <= 0)
                {
                    return;
                }
                for (I = 0; I < M2Share.FrmIDSoc.m_SessionList.Count; I++)
                {
                    SessInfo = M2Share.FrmIDSoc.m_SessionList[I];
                    ListViewItem lvItem = GridSession.Items.Add(I.ToString());
                    lvItem.SubItems.Add(SessInfo.sAccount);
                    lvItem.SubItems.Add(SessInfo.sIPaddr);
                    lvItem.SubItems.Add(SessInfo.nSessionID.ToString());
                    lvItem.SubItems.Add(SessInfo.nPayMent.ToString());
                    lvItem.SubItems.Add(SessInfo.nPayMode.ToString());
                }
            }
            finally
            {
                //M2Share.FrmIDSoc.m_SessionList.UnLock();
            }
            GridSession.Visible = true;
        }

        private void ButtonRefGrid_Click(object sender, EventArgs e)
        {
            RefGridSession();
        }

    } 
}

