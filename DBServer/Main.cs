using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using DBServer.Entity;
using GameFramework;
using NetFramework;
using NetFramework.AsyncSocketServer;
using NetFramework.AsyncSocketClient;

namespace DBServer
{
    public partial class TFrmMain : Form
    {
        private System.Threading.Timer TimerMain = null;
        private System.Threading.Timer TimerStart = null;
        private System.Threading.Timer TimerClose = null;

        private IServerSocket ServerSocket = null;
        private IServerSocket SelectSocket = null;
        TFrmIDSoc FrmIDSoc = null;

        public TFrmMain()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.Initialization();
            DBShare.MainOutMessage("�����������ݿ������...");
            FrmIDSoc = new TFrmIDSoc(this);
            FrmIDSoc.Show();
            FrmIDSoc.Hide();
            ModuleGrid.AllowUserToAddRows = false;
            ModuleGrid.RowHeadersVisible = false;
            ModuleGrid.ReadOnly = true;
            ModuleGrid.Columns.Add("MKMC", "ģ������");
            ModuleGrid.Columns.Add("LJDZ", "���ӵ�ַ");
            ModuleGrid.Columns.Add("SJTX", "����ͨѶ");
            ModuleGrid.Columns[0].Width = 80;
            ModuleGrid.Columns[1].Width = 468 - 80 * 2;
            ModuleGrid.Columns[2].Width = 80;
            ModuleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ModuleGrid.MultiSelect = false;
            ModuleGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModuleGrid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModuleGrid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModuleGrid.RowTemplate.Height = 18;
            ModuleGrid.Rows.Add(5);
            //M2�׽���
            ServerSocket = new IServerSocket(1000, Int16.MaxValue);
            ServerSocket.OnClientConnect += ServerSocket_OnClientConnect;
            ServerSocket.OnClientDisconnect += ServerSocket_OnClientDisconnect;
            ServerSocket.OnClientError += ServerSocket_OnClientError;
            ServerSocket.OnClientRead += ServerSocket_OnClientRead;
            ServerSocket.OnDataSendCompleted += ServerSocket_OnDataSendCompleted;
            //ѡ��������׽���
            SelectSocket = new IServerSocket(1000, Int16.MaxValue);
            SelectSocket.OnClientConnect += SelectSocket_OnClientConnect;
            SelectSocket.OnClientDisconnect += SelectSocket_OnClientDisconnect;
            SelectSocket.OnClientError += SelectSocket_OnClientError;
            SelectSocket.OnClientRead += SelectSocket_OnClientRead;
            SelectSocket.OnDataSendCompleted += SelectSocket_OnDataSendCompleted;
            ServerSocket.Init();
            SelectSocket.Init();
            CheckBoxShowMainLogMsg.Checked = DBShare.g_boShowLogMsg;
            //Units.Main.RankingThread = new TRankingThread(true);
            //Units.Main.RankingThread.Resume();
            DBShare.SendGameCenterMsg(Common.SG_STARTNOW, "�����������ݿ������...");
            TimerMain = new System.Threading.Timer(TimerMainTimer, null, 0, 1);
            TimerStart = new System.Threading.Timer(TimerStartTimer, null, -1, -1);
            TimerClose = new System.Threading.Timer(TimerCloseTimer, null, -1, -1);
            TimerStart.Change(0, 1000);
        }

        public void SelectSocket_OnDataSendCompleted(object sender, AsyncUserToken e)
        {
            throw new NotImplementedException();
        }

        public void SelectSocket_OnClientRead(object sender, AsyncUserToken e)
        {
            byte[] data = new byte[e.BytesReceived];
            Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
            DBShare.MainOutMessage(System.Text.Encoding.Default.GetString(data));
            (e.Tag as TSelectClient).ExecGateBuffers(System.Text.Encoding.Default.GetString(data), e.BytesReceived);
        }

        public void SelectSocket_OnClientError(object sender, AsyncSocketErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SelectSocket_OnClientDisconnect(object sender, AsyncUserToken e)
        {
            DBShare.MainOutMessage("Sel�Ͽ�: " + e.EndPoint.ToString());
        }

        public void SelectSocket_OnClientConnect(object sender, AsyncUserToken e)
        {
            DBShare.MainOutMessage("Sel����: " + e.EndPoint.ToString());
            TSelectClient ClentSocket = new TSelectClient(e, FrmIDSoc);
            e.Tag = ClentSocket;
        }

        public void ServerSocket_OnDataSendCompleted(object sender, AsyncUserToken e)
        {
            throw new NotImplementedException();
        }

        public void ServerSocket_OnClientRead(object sender, AsyncUserToken e)
        {
            byte[] data = new byte[e.BytesReceived];
            Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
            (((object[])e.Tag)[0] as ServerClient.TServerClient).ProcessServerPacket(System.Text.Encoding.Unicode.GetString(data), e.BytesReceived);
        }

        public void ServerSocket_OnClientError(object sender, AsyncSocketErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ServerSocket_OnClientDisconnect(object sender, AsyncUserToken e)
        {
            DBShare.MainOutMessage("�Ͽ�����: " + e.EndPoint.ToString());
        }

        public void ServerSocket_OnClientConnect(object sender, AsyncUserToken e)
        {
            string sRemoteAddress;
            TModuleInfo ModuleInfo = new TModuleInfo();
            sRemoteAddress = e.EndPoint.Address.ToString();
            DBShare.MainOutMessage("M2����: " + e.EndPoint.ToString());
            if ((!DBShare.CheckServerIP(sRemoteAddress)))
            {
                DBShare.MainOutMessage("�Ƿ�����������: " + sRemoteAddress);
                e.Socket.Close();
                return;
            }
            if (!(THumDB.boDataDBReady && THumDB.boHumDBReady && DBShare.g_boStartService))
            {
                e.Socket.Close();
            }
            else
            {
                ModuleInfo.Module = e;
                ModuleInfo.ModuleName = "��Ϸ����";
                ModuleInfo.Address = string.Format("{0}:{1} �� {2}:{3}", sRemoteAddress, e.EndPoint.Port, sRemoteAddress, 6000);// Format("%s:%d �� %s:%d", new object[] {sRemoteAddress, Socket.RemotePort, sRemoteAddress, ServerSocket.Port});
                ModuleInfo.Buffer = "0/0";
                ModuleInfo = DBShare.AddModule(ModuleInfo);
            }
            TServerClient ClentSocket = new TServerClient(e, FrmIDSoc);
            e.Tag = new object[] { ClentSocket, ModuleInfo };
        }

        /// <summary>
        /// ��Main������ʾ��־
        /// </summary>
        private void ShowMainLogMsg()
        {
            if ((GameFramework.HUtil32.GetTickCount() - DBShare.g_dwShowMainLogTick) > 20)
            {
                DBShare.g_dwShowMainLogTick = GameFramework.HUtil32.GetTickCount();
                List<string> TempLogList = new List<string>();
                try
                {
                    //�ƶ�����ʱ�����洢
                    DBShare.g_MainLogMsgList.__Lock();
                    try
                    {
                        for (int I = 0; I < DBShare.g_MainLogMsgList.Count; I++)
                        {
                            TempLogList.Add(DBShare.g_MainLogMsgList[I]);
                        }
                        DBShare.g_MainLogMsgList.Clear();
                    }
                    finally
                    {
                        DBShare.g_MainLogMsgList.UnLock();
                    }
                    for (int I = 0; I < TempLogList.Count; I++)
                    {
                        MemoLog.Invoke((MethodInvoker)delegate() { MemoLog.AppendText(TempLogList[I] + Environment.NewLine); });
                    }
                }
                finally
                {
                }
            }
        }

        /// <summary>
        /// ��ʾ������������Ϣ
        /// </summary>
        private void ShowModule()
        {
            int I;
            TModuleInfo ModuleInfo;
            try
            {
                if ((GameFramework.HUtil32.GetTickCount() - DBShare.g_dwShowModuleTick) > 2000)
                {
                    DBShare.g_dwShowModuleTick = GameFramework.HUtil32.GetTickCount();
                    ModuleGrid.RowCount = HUtil32._MAX(DBShare.g_ModuleList.Count + 1, 5);
                    for (I = 0; I < ModuleGrid.RowCount; I++)
                    {
                        if (I < DBShare.g_ModuleList.Count)
                        {
                            ModuleInfo = DBShare.g_ModuleList[I];
                            ModuleGrid.Invoke((MethodInvoker)delegate()
                            {
                                ModuleGrid.Rows[I].Cells[0].Value = ModuleInfo.ModuleName;
                                ModuleGrid.Rows[I].Cells[1].Value = ModuleInfo.Address;
                                ModuleGrid.Rows[I].Cells[2].Value = ModuleInfo.Buffer;
                            });
                        }
                        else
                        {
                            ModuleGrid.Invoke((MethodInvoker)delegate()
                            {
                                ModuleGrid.Rows[I].Cells[0].Value = "";
                                ModuleGrid.Rows[I].Cells[1].Value = "";
                                ModuleGrid.Rows[I].Cells[2].Value = "";
                            });
                        }
                    }
                }
            }
            catch
            {
                DBShare.MainOutMessage("[Exception] ShowModule");
            }
        }

        /// <summary>
        /// ��ʾ����״̬
        /// </summary>
        private void ShowWorkStatus()
        {
            switch (DBShare.g_nWorkStatus)
            {
                case Common.DB_LOADHUMANRCD:
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "��ȡ��������";
                    });
                    break;

                case Common.DB_SAVEHUMANRCD:
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "������������";
                    });
                    break;

                case Common.DB_LOADHERORCD:
                    // ��ȡӢ������
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "��ȡӢ������";
                    });
                    break;

                case Common.DB_NEWHERORCD:
                    // �½�Ӣ��
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "����Ӣ��";
                    });
                    break;

                case Common.DB_DELHERORCD:

                    // ɾ��Ӣ��
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "ɾ��Ӣ��";
                    });

                    break;

                case Common.DB_SAVEHERORCD:

                    // ����Ӣ������
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "����Ӣ������";
                    });

                    break;

                case Common.DB_LOADRANKING:
                    // ���а�
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "��ȡ���а�����";
                    });

                    break;
                default:
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Blue;
                    });

                    break;
            }
            if (GameFramework.HUtil32.GetTickCount() - DBShare.g_dwWorkStatusTick > 1000)
            {
                DBShare.g_dwWorkStatusTick = GameFramework.HUtil32.GetTickCount();
                LabelCreateHum.Invoke((MethodInvoker)delegate()
                {
                    LabelCreateHum.Text = string.Format("��������:{0}", DBShare.g_nCreateHumCount);
                });
                LabelDeleteHum.Invoke((MethodInvoker)delegate()
                {
                    LabelDeleteHum.Text = string.Format("ɾ������:{0}", DBShare.g_nDeleteHumCount);
                });
                LabelLoadHumRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelLoadHumRcd.Text = string.Format("��ȡ��������:{0}", DBShare.g_nLoadHumCount);
                });
                LabelSaveHumRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelSaveHumRcd.Text = string.Format("������������:{0}", DBShare.g_nSaveHumCount);
                });

                LabelCreateHero.Invoke((MethodInvoker)delegate()
                {
                    LabelCreateHero.Text = string.Format("����Ӣ��:{0}", DBShare.g_nCreateHeroCount);
                });
                LabelDeleteHero.Invoke((MethodInvoker)delegate()
                {
                    LabelDeleteHero.Text = string.Format("ɾ��Ӣ��:{0}", DBShare.g_nDeleteHeroCount);
                });
                LabelLoadHeroRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelLoadHeroRcd.Text = string.Format("��ȡӢ������:{0}", DBShare.g_nLoadHeroCount);
                });
                LabelSaveHeroRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelSaveHeroRcd.Text = string.Format("����Ӣ������:{0}", DBShare.g_nSaveHeroCount);
                });
            }
        }

        /// <summary>
        /// ��ʱ��
        /// </summary>
        /// <param name="objState">״̬��Ϣ</param>
        public void TimerMainTimer(object objState)
        {
            ShowMainLogMsg();
            ShowModule();
            ShowWorkStatus();
        }

        private void StartService()
        {
            try
            {
                DBShare.MainOutMessage("��������������...");
                DBShare.LoadConfig();
                ServerSocket.Start(new IPEndPoint(IPAddress.Parse("0.0.0.0"), DBShare.g_nServerPort));
                SelectSocket.Start(new IPEndPoint(IPAddress.Parse("0.0.0.0"), DBShare.g_nGatePort));
                DBShare.g_boStartService = true;
                FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.OpenConnect(); });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_START.Enabled = false; });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_STOP.Enabled = true; });
                DBShare.MainOutMessage("���ݿ�����������ɹ�...");
                DBShare.SendGameCenterMsg(Common.SG_STARTOK, "���ݿ�������������...");
            }
            catch (Exception ex)
            {
                DBShare.MainOutMessage(ex.Message);
                DBShare.g_boStartService = false;
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_START.Enabled = true; });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_STOP.Enabled = false; });
                FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.CloseConnect(); });
                SelectSocket.Shutdown();
                ServerSocket.Shutdown();
            }
        }

        private void StopService()
        {
            DBShare.g_boStartService = false;
            DBShare.MainOutMessage("����ֹͣ������...");
            MENU_CONTROL_START.Enabled = true;
            MENU_CONTROL_STOP.Enabled = false;
            FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.CloseConnect(); });
            SelectSocket.Shutdown();
            ServerSocket.Shutdown();
            DBShare.MainOutMessage("��������ֹͣ...");
        }

        public void TimerStartTimer(object objState)
        {
            TimerStart.Dispose();
            StartService();
        }

        public void MENU_OPTION_GAMEGATEClick(System.Object Sender, System.EventArgs _e1)
        {
            //RouteManage.Units.RouteManage.frmRouteManage.Open();
        }

        public void MENU_MANAGE_DATAClick(System.Object Sender, System.EventArgs _e1)
        {
            //if (HumDB.Units.HumDB.boHumDBReady && HumDB.Units.HumDB.boDataDBReady)
            //{
            //    FIDHum.Units.FIDHum.FrmIDHum.Show();
            //}
        }

        public void MENU_RANKINGClick(System.Object Sender, System.EventArgs _e1)
        {
            //Ranking.Units.Ranking.FrmRankingDlg.Top = this.Top;
            //Ranking.Units.Ranking.FrmRankingDlg.Left = this.Left;
            //Ranking.Units.Ranking.FrmRankingDlg.Open();
        }

        /// <summary>
        /// ����ѡ������
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void MENU_TEST_SELGATEClick(System.Object Sender, System.EventArgs _e1)
        {
            TfrmTestSelGate frmTestSelGate = new TfrmTestSelGate();
            frmTestSelGate.ShowDialog();
        }

        public void CheckBoxShowMainLogMsgClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.g_boShowLogMsg = CheckBoxShowMainLogMsg.Checked;
        }

        /// <summary>
        /// ��������˵�
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void MENU_CONTROL_STARTClick(System.Object Sender, System.EventArgs _e1)
        {
            StartService();
        }

        /// <summary>
        /// ֹͣ����˵�
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void MENU_CONTROL_STOPClick(System.Object Sender, System.EventArgs _e1)
        {
            StopService();
        }

        public void MENU_CONTROL_EXITClick(System.Object Sender, System.EventArgs _e1)
        {
            this.Close();
        }

        public void TimerCloseTimer(object objState)
        {
            if (DBShare.g_boStartService)
            {
                DBShare.g_boStartService = false;
                DBShare.MainOutMessage("����ֹͣ������...");
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_START.Enabled = true; });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_STOP.Enabled = false; });
                FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.CloseConnect(); });
            }
            TimerClose.Change(-1, -1);
            SelectSocket.Shutdown();
            ServerSocket.Shutdown();
            DBShare.MainOutMessage("��������ֹͣ...");
        }

        
        public void MENU_HELP_VERSIONClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.MainOutMessage(DBShare.g_sVersion);
            DBShare.MainOutMessage(DBShare.g_sUpDateTime);
            DBShare.MainOutMessage(DBShare.g_sProgram);
            DBShare.MainOutMessage(DBShare.g_sWebSite);
        }

        public void G1Click(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.LoadGateID();
            DBShare.LoadIPTable();
            DBShare.MainOutMessage("�������ü������");
        }

        public void C1Click(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.LoadChrNameList("DenyChrName.txt");
            DBShare.LoadAICharNameList("AICharName.txt");
            DBShare.MainOutMessage("��ɫ�����б�������");
        }

        public void MemoLogChange(System.Object Sender, System.EventArgs _e1)
        {
            if (MemoLog.Lines.Length > 100)
            {
                MemoLog.Clear();
            }
        }

        public void MemoLogDblClick(System.Object Sender, System.EventArgs _e1)
        {
            if (MessageBox.Show("�Ƿ�ȷ�������־��Ϣ������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MemoLog.Clear();
            }
        }

        public void MENU_OPTION_GENERALClick(System.Object Sender, System.EventArgs _e1)
        {
            //Setting.Units.Setting.FrmSetting = new TFrmSetting(this.Owner);
            //Setting.Units.Setting.FrmSetting.Open();
            //Setting.Units.Setting.FrmSetting.Free;
        }

        private void TFrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DBShare.g_boRemoteClose || DBShare.g_boSoftClose)
            {
                //��Ҫ�ж�һ���Ƿ������ӵ���������ӵľ������ر�ʱ��
            }
            else
            {
                if ((MessageBox.Show("�Ƿ�ȷ���˳����ݿ��������", "ȷ����Ϣ", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    DBShare.g_boSoftClose = true;
                        //��Ҫ�ж�һ���Ƿ������ӵ���������ӵľ������ر�ʱ��
                        TimerClose.Change(0, 1000);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// ��ȡѡ���׽���������
        /// </summary>
        /// <returns></returns>
        public long GetSelectCharCount()
        {
            return SelectSocket.NumConnectedSockets;
        }

    } // end TFrmMain

}