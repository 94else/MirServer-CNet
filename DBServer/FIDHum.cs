//using System;
//using System.Windows.Forms;
//using System.Collections;
//using DBServer.Entity;

//namespace DBServer
//{
//    public partial class TFrmIDHum : Form
//    {
//        private TFrmCreateChr FrmCreateChr = null;//��ɫ��������
//        private TFrmFDBViewer FrmFDBViewer = null;//������������

//        /// <summary>
//        /// ���캯��
//        /// </summary>
//        public TFrmIDHum()
//        {
//            InitializeComponent();
//        }

//        /// <summary>
//        /// ��������
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void TFrmIDHum_Load(object sender, EventArgs e)
//        {
//            //�ʺ��б�
//            IdGrid.Columns.Add("", "��¼�ʺ�");
//            IdGrid.Columns.Add("", "����");
//            IdGrid.Columns.Add("", "�û�����");
//            IdGrid.Columns.Add("", "ResiRegi");
//            IdGrid.Columns.Add("", "Tran");
//            IdGrid.Columns.Add("", "Secretwd");
//            IdGrid.Columns.Add("", "Adress(cont)");
//            IdGrid.Columns.Add("", "��ע");
//            //�����б�
//            ChrGrid.Columns.Add("", "������");
//            ChrGrid.Columns.Add("", "��������");
//            ChrGrid.Columns.Add("", "��¼�ʺ�");
//            ChrGrid.Columns.Add("", "�Ƿ����");
//            ChrGrid.Columns.Add("", "����ʱ��");
//            ChrGrid.Columns.Add("", "��������");
//            ChrGrid.Columns.Add("", "ѡ����");
//            ChrGrid.Columns.Add("", "�Ƿ���Ӣ��");
//        }

//        public void EdChrNameKeyPress(System.Object Sender, System.Windows.Forms.KeyPressEventArgs _e1)
//        {

//            if (_e1.KeyChar == '\r')
//            {
//                _e1.KeyChar = '\0';
//                BtnChrNameSearchClick(Sender, null);
//            }
//        }

//        /// <summary>
//        /// ����ɫ������
//        /// </summary>
//        /// <param name="Sender"></param>
//        /// <param name="e"></param>
//        public void BtnChrNameSearchClick(System.Object Sender, System.EventArgs e)
//        {
//            HumInfo objHumInfo;
//            objHumInfo = DBShare.g_HumCharDB.FindObjectByChrName(EdChrName.Text);
//            if (objHumInfo != null)
//            {
//                if (CbShowDelChr.Checked)
//                {
//                    RefChrGrid(objHumInfo);
//                }
//                else if (!objHumInfo.boDeleted.Value)
//                {
//                    RefChrGrid(objHumInfo);
//                }
//            }
//        }

//        /// <summary>
//        /// ģ�����ҽ�ɫ
//        /// </summary>
//        /// <param name="Sender"></param>
//        /// <param name="e"></param>
//        public void BtnSelAllClick(System.Object Sender, System.EventArgs e)
//        {
//            string sChrName;
//            ArrayList ChrList;
//            int I;
//            int nIndex;
//            sChrName = EdChrName.Text;
//            ChrGrid.RowCount = 1;
//            ChrList = new ArrayList();
//            if (DBShare.g_HumCharDB.FindByName(sChrName, ref ChrList) > 0)
//            {
//                for (I = 0; I < ChrList.Count; I++)
//                {
//                    nIndex = ((int)ChrList[I]);
//                    HumInfo objHumInfo = (ChrList[I] as HumInfo);
//                    if (objHumInfo != null)
//                    {
//                        if (CbShowDelChr.Checked)
//                        {
//                            RefChrGrid(objHumInfo);
//                        }
//                        else if (!objHumInfo.boDeleted.Value)
//                        {
//                            RefChrGrid(objHumInfo);
//                        }
//                    }
//                }
//            }
//        }

//        public void BtnEraseChrClick(System.Object Sender, System.EventArgs _e1)
//        {
//            string sChrName;
//            sChrName = EdChrName.Text;
//            if (sChrName == "")
//            {
//                return;
//            }
//            if (MessageBox.Show("�Ƿ�ȷ��ɾ������ " + sChrName + " ��", Application.ProductName, System.Windows.Forms.MessageBoxButtons.YesNo | System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//            {
//                try
//                {
//                    if (DBShare.g_HumCharDB.Open())
//                    {
//                        DBShare.g_HumCharDB.Delete(sChrName);
//                    }
//                }
//                finally
//                {
//                    DBShare.g_HumCharDB.Close();
//                }
//            }
//        }

//        public void FormShow(Object Sender)
//        {
//            EdChrName.Focus();
//        }

//        public void ChrGridClick(System.Object Sender, System.EventArgs _e1)
//        {
//            int nRow;
//            nRow = ChrGrid.CurrentCell.RowIndex;
//            if (nRow < 1)
//            {
//                return;
//            }
//            if (ChrGrid.RowCount - 1 < nRow)
//            {
//                return;
//            }
//            EdChrName.Text = ChrGrid.Rows[nRow].Cells[1].Value.ToString();
//        }

//        public void ChrGridDblClick(System.Object Sender, System.EventArgs _e1)
//        {
//            int nCurrentRowIndex;
//            int nC;//chr����
//            string sChrName = string.Empty;
//            //THumDataInfo ChrRecord;
//            HumDataInfo objChrRecode = null;
//            sChrName = "";
//            if (ChrGrid.SelectedCells.Count <= 0) return;
//            nCurrentRowIndex = ChrGrid.SelectedCells[0].RowIndex;
//            if ((nCurrentRowIndex >= 1) && (ChrGrid.RowCount - 1 >= nCurrentRowIndex))
//            {

//                sChrName = ChrGrid.Rows[nCurrentRowIndex].Cells[1].Value.ToString();
//            }
//            try
//            {
//                if (DBShare.g_HumDataDB.OpenEx())
//                {
//                    objChrRecode = DBShare.g_HumDataDB.FindObjectByChrName(sChrName);
//                    if (objChrRecode != null)
//                    {
//                        //�����Ӵ���
//                        FrmFDBViewer.nChrIndex = nC;
//                        FrmFDBViewer.s2FC = sChrName;
//                        FrmFDBViewer.ChrRecord = objChrRecode;
//                        FrmFDBViewer.ShowHumData();
//                        FrmFDBViewer.Left = this.Left - 144;
//                        FrmFDBViewer.Top = this.Top + 100;
//                        FrmFDBViewer.Show();
//                    }
//                }
//            }
//            finally
//            {
//                DBShare.g_HumDataDB.Close();
//            }
//        }

//        public void BtnDeleteChrClick(System.Object Sender, System.EventArgs _e1)
//        {
//            string sChrName;
//            int nIndex;
//            //THumInfo HumRecord;
//            HumInfo HumRecord = new HumInfo();
//            sChrName = EdChrName.Text;
//            if (sChrName == "")
//            {
//                return;
//            }
//            if (MessageBox.Show("�Ƿ�ȷ�Ͻ������� " + sChrName + " ��", Application.ProductName, System.Windows.Forms.MessageBoxButtons.YesNo | System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//            {
//                try
//                {
//                    if (DBShare.g_HumCharDB.Open())
//                    {
//                        //nIndex = DBShare.g_HumCharDB.Index(sChrName);
//                        //DBShare.g_HumCharDB.Get(nIndex, HumRecord);
//                        HumRecord = DBShare.g_HumCharDB.FindObjectByChrName(sChrName);
//                        HumRecord.boDeleted = true;
//                        HumRecord.dModDate = DateTime.Now.ToOADate();
//                        HumRecord.btCount++;
//                        //DBShare.g_HumCharDB.Update(nIndex, HumRecord);
//                    }
//                }
//                finally
//                {
//                    DBShare.g_HumCharDB.Close();
//                }
//            }
//        }

//        public void BtnRevivalClick(System.Object Sender, System.EventArgs _e1)
//        {
//            string sChrName;
//            int nIndex;
//            THumInfo HumRecord;
//            sChrName = EdChrName.Text;
//            if (sChrName == "")
//            {
//                return;
//            }
//            if (MessageBox.Show("�Ƿ�ȷ���������� " + sChrName + " ��", Application.ProductName, System.Windows.Forms.MessageBoxButtons.YesNo | System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//            {
//                try
//                {
//                    if (DBShare.g_HumCharDB.Open())
//                    {
//                        //nIndex = DBShare.g_HumCharDB.Index(sChrName);
//                        //DBShare.g_HumCharDB.Get(nIndex, HumRecord);
//                        //HumRecord.boDeleted = false;
//                        //HumRecord.btCount++;
//                        //DBShare.g_HumCharDB.Update(nIndex, HumRecord);
//                    }
//                }
//                finally
//                {
//                    DBShare.g_HumCharDB.Close();
//                }
//            }
//        }

//        public void SpeedButton1Click(System.Object Sender, System.EventArgs _e1)
//        {
//            // FrmFDBExplore.Show;

//        }

//        public void BtnCreateChrClick(System.Object Sender, System.EventArgs _e1)
//        {
//            int nCheckCode;
//            THumInfo HumRecord;
//            if (!FrmCreateChr.IncputChrInfo())
//            {
//                return;
//            }
//            nCheckCode = 0;
//            try
//            {
//                if (DBShare.g_HumCharDB.Open())
//                {
//                    //if (DBShare.g_HumCharDB.ChrCountOfAccount(CreateChr.Units.CreateChr.FrmCreateChr.sUserId) < 2)
//                    //{
//                    //    //HumRecord.Header.boDeleted = false;
//                    //    //HumRecord.Header.boIsHero = false;
//                    //    //HumRecord.Header.sName = CreateChr.Units.CreateChr.FrmCreateChr.sChrName;
//                    //    //HumRecord.Header.nSelectID = CreateChr.Units.CreateChr.FrmCreateChr.nSelectID;
//                    //    //HumRecord.boIsHero = false;
//                    //    //// HumRecord.boSelected := True;
//                    //    //HumRecord.sChrName = CreateChr.Units.CreateChr.FrmCreateChr.sChrName;
//                    //    //HumRecord.sAccount = CreateChr.Units.CreateChr.FrmCreateChr.sUserId;
//                    //    //HumRecord.boDeleted = false;
//                    //    //HumRecord.btCount = 0;
//                    //    //if (HumRecord.Header.sName != "")
//                    //    //{
//                    //    //    if (!DBShare.g_HumCharDB.Add(HumRecord))
//                    //    //    {
//                    //    //        nCheckCode = 2;
//                    //    //    }
//                    //    //}
//                    //}
//                    //else
//                    //{
//                    //    nCheckCode = 3;
//                    //}
//                }
//            }
//            finally
//            {
//                DBShare.g_HumCharDB.Close();
//            }
//            if (nCheckCode == 0)
//            {
//                MessageBox.Show("���ﴴ���ɹ�...");
//            }
//            else
//            {
//                MessageBox.Show("���ﴴ��ʧ�ܣ�����");
//            }
//        }

//        public void BtnDeleteChrAllInfoClick(System.Object Sender, System.EventArgs _e1)
//        {
//            string sChrName;
//            sChrName = EdChrName.Text;
//            if (sChrName == "")
//            {
//                return;
//            }
//            if (MessageBox.Show("�Ƿ�ȷ��ɾ������ " + sChrName + " ���������ݣ�", Application.ProductName, System.Windows.Forms.MessageBoxButtons.YesNo | System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//            {
//                try
//                {
//                    if (DBShare.g_HumCharDB.Open())
//                    {
//                        DBShare.g_HumCharDB.Delete(sChrName);
//                    }
//                }
//                finally
//                {
//                    DBShare.g_HumCharDB.Close();
//                }
//                try
//                {
//                    if (DBShare.g_HumDataDB.Open())
//                    {
//                        DBShare.g_HumDataDB.Delete(sChrName);
//                    }
//                }
//                finally
//                {
//                    DBShare.g_HumDataDB.Close();
//                }
//            }
//        }

//        public void BtnChrIndexClick(System.Object Sender, System.EventArgs _e1)
//        {
//            //int nIndex;
//            //THumInfo HumRecord;
//            //int nRow;
//            //nRow = ChrGrid.CurrentRowIndex;
//            //if (nRow < 1)
//            //{
//            //    return;
//            //}
//            ////@ Unsupported property or method(C): 'RowCount'
//            //if (ChrGrid.RowCount - 1 < nRow)
//            //{
//            //    return;
//            //}

//            ////@ Undeclared identifier(3): 'Str_ToInt'
//            //nIndex = Str_ToInt(ChrGrid.Cells[0, nRow], 0);
//            //if (MessageBox.Show("�Ƿ�ȷ�Ͻ��ü�¼ " + (nIndex).ToString() + " ��", Application.ProductName, System.Windows.Forms.MessageBoxButtons.YesNo | System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//            //{
//            //    try
//            //    {
//            //        if (DBShare.g_HumCharDB.Open())
//            //        {
//            //            if (DBShare.g_HumCharDB.GetBy(nIndex, HumRecord))
//            //            {
//            //                HumRecord.boDeleted = true;
//            //                HumRecord.dModDate = DateTime.Now;
//            //                HumRecord.btCount++;
//            //                DBShare.g_HumCharDB.UpdateBy(nIndex, HumRecord);
//            //            }
//            //        }
//            //    }
//            //    finally
//            //    {
//            //        DBShare.g_HumCharDB.Close();
//            //    }
//            //}
//        }

//        /// <summary>
//        /// ˢ�½�ɫ����
//        /// </summary>
//        /// <param name="HumDBRecord"></param>
//        public void RefChrGrid(HumInfo HumDBRecord)
//        {
//            ChrGrid.Rows.Add(1);
//            int nRowCount = ChrGrid.RowCount - 1;
//            ChrGrid.Rows[nRowCount].Cells[0].Value = HumDBRecord.nID;
//            ChrGrid.Rows[nRowCount].Cells[1].Value = HumDBRecord.sChrName;
//            ChrGrid.Rows[nRowCount].Cells[2].Value = HumDBRecord.sAccount;
//            ChrGrid.Rows[nRowCount].Cells[3].Value = HumDBRecord.boDeleted.Value.ToString();
//            if (HumDBRecord.boDeleted.Value)
//            {
//                ChrGrid.Rows[nRowCount].Cells[4].Value = HumDBRecord.dModDate.ToString();
//            }
//            else
//            {
//                ChrGrid.Rows[nRowCount].Cells[4].Value = "";
//            }
//            ChrGrid.Rows[nRowCount].Cells[5].Value = HumDBRecord.btCount.ToString();
//            ChrGrid.Rows[nRowCount].Cells[6].Value = HumDBRecord.nSelectID.ToString();
//            ChrGrid.Rows[nRowCount].Cells[7].Value = HumDBRecord.boIsHero.ToString();
//            LabelCount.Text = (ChrGrid.RowCount - 1).ToString();
//        }

//        public void BtnEditDataClick(System.Object Sender, System.EventArgs _e1)
//        {
//            //int nRow;
//            //int nIdx;
//            //string sName;
//            //THumDataInfo ChrRecord;
//            //sName = "";
//            //nRow = ChrGrid.CurrentRowIndex;
//            ////@ Unsupported property or method(C): 'RowCount'
//            //if ((nRow >= 1) && (ChrGrid.RowCount - 1 >= nRow))
//            //{

//            //    sName = ChrGrid.Cells[1, nRow];
//            //}
//            //if (sName == "")
//            //{
//            //    return;
//            //}
//            //try
//            //{
//            //    if (DBShare.g_HumDataDB.OpenEx())
//            //    {
//            //        nIdx = DBShare.g_HumDataDB.Index(sName);
//            //        if (nIdx >= 0)
//            //        {
//            //            if (DBShare.g_HumDataDB.Get(nIdx, ChrRecord) >= 0)
//            //            {
//            //                EditRcd.Units.EditRcd.frmEditRcd.m_nIdx = nIdx;
//            //                EditRcd.Units.EditRcd.frmEditRcd.m_ChrRcd = ChrRecord;
//            //            }
//            //        }
//            //    }
//            //}
//            //finally
//            //{
//            //    DBShare.g_HumDataDB.Close();
//            //}
//            //EditRcd.Units.EditRcd.frmEditRcd.Left = Units.FIDHum.FrmIDHum.Left + 50;
//            //EditRcd.Units.EditRcd.frmEditRcd.Top = Units.FIDHum.FrmIDHum.Top + 50;
//            //EditRcd.Units.EditRcd.frmEditRcd.Open();
//        }

//        private void EdUserId_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            //string sAccount;
//            //ArrayList ChrList;
//            //int I;
//            //int nIndex;
//            //THumInfo HumDBRecord;
//            //if (e.KeyChar == '\r')
//            //{
//            //    e.KeyChar = '\0';
//            //    sAccount = EdUserId.Text;
//            //    ChrGrid.RowCount = 1;
//            //    if (sAccount != "")
//            //    {
//            //        try
//            //        {
//            //            if (DBShare.g_HumCharDB.OpenEx())
//            //            {
//            //                if (DBShare.g_HumCharDB.FindByAccount(sAccount, ref ChrList) >= 0)
//            //                {
//            //                    for (I = 0; I < ChrList.Count; I++)
//            //                    {
//            //                        //@ Undeclared identifier(3): 'pTQuickID'
//            //                        //@ Unsupported property or method(D): 'nIndex'
//            //                        nIndex = pTQuickID(ChrList[I]).nIndex;
//            //                        if (nIndex >= 0)
//            //                        {
//            //                            DBShare.g_HumCharDB.GetBy(nIndex, HumDBRecord);
//            //                            if (CbShowDelChr.Checked)
//            //                            {
//            //                                RefChrGrid(nIndex, HumDBRecord);
//            //                            }
//            //                            else if (!HumDBRecord.boDeleted)
//            //                            {
//            //                                RefChrGrid(nIndex, HumDBRecord);
//            //                            }
//            //                        }
//            //                    }
//            //                }
//            //            }
//            //        }
//            //        finally
//            //        {
//            //            DBShare.g_HumCharDB.Close();
//            //        }
//            //    }
//            //}
//        }



//    } // end TFrmIDHum

//}
