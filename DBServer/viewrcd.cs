//using System;
//using System.Windows.Forms;
//using GameFramework;

//namespace DBServer
//{
//    public partial class TFrmFDBViewer : Form
//    {
//        public int nChrIndex = 0;
//        public string s2FC = String.Empty;
//        public  HumDataInfo ChrRecord = null;//��ɫ��¼

//        public TFrmFDBViewer()
//        {
//            InitializeComponent();
//        }

//        public void FormCreate(System.Object Sender, System.EventArgs _e1)
//        {
//            InitHumanGrid();
//            InitBagItemGrid();
//            InitSaveItemGrid();
//            InitUseMagicGrid();
//            InitUserItemGrid();
//        }

//        public void ShowHumData()
//        {
//            if (HumanGrid.Visible)
//            {
//                ShowHumanInfo();
//            }
//            if (UserItemGrid.Visible)
//            {
//                ShowUserItems();
//            }
//            if (BagItemGrid.Visible)
//            {
//                ShowBagItems();
//            }
//            if (UseMagicGrid.Visible)
//            {
//                ShowUseMagic();
//            }
//            if (SaveItemGrid.Visible)
//            {
//                ShowSaveItem();
//            }
//            TabbedNotebook1.TabIndex = 0;
//        }

//        /// <summary>
//        /// ��ʼ��������Ϣ����
//        /// </summary>
//        private void InitHumanGrid()
//        {
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Rows.Add(8);

//            HumanGrid.Rows[0].Cells[0].Value = "������";
//            HumanGrid.Rows[0].Cells[1].Value = "����";
//            HumanGrid.Rows[0].Cells[2].Value = "��ͼ";
//            HumanGrid.Rows[0].Cells[3].Value = "CX";
//            HumanGrid.Rows[0].Cells[4].Value = "CY";
//            HumanGrid.Rows[0].Cells[5].Value = "����";
//            HumanGrid.Rows[0].Cells[6].Value = "ְҵ";
//            HumanGrid.Rows[0].Cells[7].Value = "�Ա�";
//            HumanGrid.Rows[0].Cells[8].Value = "ͷ��";
//            HumanGrid.Rows[0].Cells[9].Value = "�����";
//            HumanGrid.Rows[0].Cells[10].Value = "����";
//            HumanGrid.Rows[0].Cells[11].Value = "Home";

//            HumanGrid.Rows[2].Cells[0].Value = "HomeX";
//            HumanGrid.Rows[2].Cells[1].Value = "HomeY";
//            HumanGrid.Rows[2].Cells[2].Value = "�ȼ�";
//            HumanGrid.Rows[2].Cells[3].Value = "AC";
//            HumanGrid.Rows[2].Cells[4].Value = "MAC";
//            HumanGrid.Rows[2].Cells[5].Value = "Reserved1";
//            HumanGrid.Rows[2].Cells[6].Value = "DC/1";
//            HumanGrid.Rows[2].Cells[7].Value = "DC/2";
//            HumanGrid.Rows[2].Cells[8].Value = "MC/1";
//            HumanGrid.Rows[2].Cells[9].Value = "MC/2";
//            HumanGrid.Rows[2].Cells[10].Value = "SC/1";
//            HumanGrid.Rows[2].Cells[11].Value = "SC/2";

//            HumanGrid.Rows[4].Cells[0].Value = "Reserved2";
//            HumanGrid.Rows[4].Cells[1].Value = "HP";
//            HumanGrid.Rows[4].Cells[2].Value = "MaxHP";
//            HumanGrid.Rows[4].Cells[3].Value = "MP";
//            HumanGrid.Rows[4].Cells[4].Value = "MaxMP";
//            HumanGrid.Rows[4].Cells[5].Value = "Reserved2";
//            HumanGrid.Rows[4].Cells[6].Value = "��ǰ����";
//            HumanGrid.Rows[4].Cells[7].Value = "��������";
//            HumanGrid.Rows[4].Cells[8].Value = "PK����";
//            HumanGrid.Rows[4].Cells[9].Value = "";
//            HumanGrid.Rows[4].Cells[10].Value = "��¼�ʺ�";
//            HumanGrid.Rows[4].Cells[11].Value = "����¼ʱ��";

//            HumanGrid.Rows[6].Cells[0].Value = "��ż";
//            HumanGrid.Rows[6].Cells[1].Value = "ʦͽ";
//            HumanGrid.Rows[6].Cells[2].Value = "�ֿ�����";
//            HumanGrid.Rows[6].Cells[3].Value = "������";
//            HumanGrid.Rows[6].Cells[4].Value = "�Ƿ���Ӣ��";
//            HumanGrid.Rows[6].Cells[5].Value = "";
//            HumanGrid.Rows[6].Cells[6].Value = "";
//            HumanGrid.Rows[6].Cells[7].Value = "";
//            HumanGrid.Rows[6].Cells[8].Value = "";
//            HumanGrid.Rows[6].Cells[9].Value = "";
//            HumanGrid.Rows[6].Cells[10].Value = "";
//            HumanGrid.Rows[6].Cells[11].Value = "";
//        }

//        /// <summary>
//        /// ��ʼ������װ������
//        /// </summary>
//        private void InitUserItemGrid()
//        {
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Rows.Add(14);

//            HumanGrid.Rows[0].Cells[0].Value = "��Ʒλ��";
//            HumanGrid.Rows[0].Cells[1].Value = "��ƷID";
//            HumanGrid.Rows[0].Cells[2].Value = "��Ʒ��";
//            HumanGrid.Rows[0].Cells[3].Value = "�־�";
//            HumanGrid.Rows[0].Cells[4].Value = "��Ʒ����";

//            HumanGrid.Rows[0].Cells[0].Value = "�·�";
//            HumanGrid.Rows[0].Cells[0].Value = "����";
//            HumanGrid.Rows[0].Cells[0].Value = "������";
//            HumanGrid.Rows[0].Cells[0].Value = "����";
//            HumanGrid.Rows[0].Cells[0].Value = "ͷ��";
//            HumanGrid.Rows[0].Cells[0].Value = "������";
//            HumanGrid.Rows[0].Cells[0].Value = "������";
//            HumanGrid.Rows[0].Cells[0].Value = "���ָ";
//            HumanGrid.Rows[0].Cells[0].Value = "�ҽ�ָ";
//            HumanGrid.Rows[0].Cells[0].Value = "��Ʒ";
//            HumanGrid.Rows[0].Cells[0].Value = "����";
//            HumanGrid.Rows[0].Cells[0].Value = "Ь��";
//            HumanGrid.Rows[0].Cells[0].Value = "��ʯ";
//        }

//        /// <summary>
//        /// ������Ʒ����
//        /// </summary>
//        private void InitBagItemGrid()
//        {
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Rows.Add(50);
//            HumanGrid.Rows[0].Cells[0].Value = "���";
//            HumanGrid.Rows[0].Cells[1].Value = "��ƷID";
//            HumanGrid.Rows[0].Cells[2].Value = "��Ʒ��";
//            HumanGrid.Rows[0].Cells[3].Value = "�־�";
//            HumanGrid.Rows[0].Cells[4].Value = "��Ʒ����";
//        }

//        /// <summary>
//        /// �ֿ�����
//        /// </summary>
//        private void InitSaveItemGrid()
//        {
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Rows.Add(50);
//            HumanGrid.Rows[0].Cells[0].Value = "���";
//            HumanGrid.Rows[0].Cells[1].Value = "��ƷID";
//            HumanGrid.Rows[0].Cells[2].Value = "��Ʒ��";
//            HumanGrid.Rows[0].Cells[3].Value = "�־�";
//            HumanGrid.Rows[0].Cells[4].Value = "��Ʒ����";
//        }

//        /// <summary>
//        /// ���＼������
//        /// </summary>
//        private void InitUseMagicGrid()
//        {
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Columns.Add("", "");
//            HumanGrid.Rows.Add(50);
//            HumanGrid.Rows[0].Cells[0].Value = "����ID";
//            HumanGrid.Rows[0].Cells[1].Value = "��ݼ�";
//            HumanGrid.Rows[0].Cells[2].Value = "����״̬";
//            HumanGrid.Rows[0].Cells[3].Value = "��������";
//        }

//        private void ShowBagItem(int nIndex, string sName, TUserItem Item)
//        {
//            if (Item.wIndex > 0)
//            {
//                HumanGrid.Rows[nIndex].Cells[0].Value = sName;
//                HumanGrid.Rows[nIndex].Cells[1].Value = (Item.MakeIndex).ToString();
//                HumanGrid.Rows[nIndex].Cells[2].Value = (Item.wIndex).ToString();
//                HumanGrid.Rows[nIndex].Cells[3].Value = (Item.Dura).ToString() + '/' + (Item.DuraMax).ToString();
//                HumanGrid.Rows[nIndex].Cells[4].Value = DBShare.GetStdItemName(Item.wIndex);
//            }
//            else
//            {
//                HumanGrid.Rows[nIndex].Cells[0].Value = sName;
//                HumanGrid.Rows[nIndex].Cells[1].Value = "";
//                HumanGrid.Rows[nIndex].Cells[2].Value = "";
//                HumanGrid.Rows[nIndex].Cells[3].Value = "";
//                HumanGrid.Rows[nIndex].Cells[4].Value = "";
//            }
//        }

//        private void ShowUserItem(int nIndex, string sName, TUserItem Item)
//        {
//            if (Item.wIndex > 0)
//            {
//                HumanGrid.Rows[nIndex].Cells[0].Value = sName;
//                HumanGrid.Rows[nIndex].Cells[1].Value = (Item.MakeIndex).ToString();
//                HumanGrid.Rows[nIndex].Cells[2].Value = (Item.wIndex).ToString();
//                HumanGrid.Rows[nIndex].Cells[3].Value = (Item.Dura).ToString() + '/' + (Item.DuraMax).ToString();
//                HumanGrid.Rows[nIndex].Cells[4].Value = DBShare.GetStdItemName(Item.wIndex);
//            }
//            else
//            {
//                HumanGrid.Rows[nIndex].Cells[0].Value = sName;
//                HumanGrid.Rows[nIndex].Cells[1].Value = "";
//                HumanGrid.Rows[nIndex].Cells[2].Value = "";
//                HumanGrid.Rows[nIndex].Cells[3].Value = "";
//                HumanGrid.Rows[nIndex].Cells[4].Value = "";
//            }
//        }

//        /// <summary>
//        /// ��ʾ��ɫ��Ϣ
//        /// </summary>
//        private void ShowHumanInfo()
//        {
//            HumanGrid.Rows[1].Cells[0].Value = nChrIndex.ToString();
//            HumanGrid.Rows[1].Cells[1].Value = ChrRecord.sChrName;
//            HumanGrid.Rows[1].Cells[2].Value = ChrRecord.sCurMap;
//            HumanGrid.Rows[1].Cells[3].Value = ChrRecord.wCurX.Value.ToString();
//            HumanGrid.Rows[1].Cells[4].Value = ChrRecord.wCurY.Value.ToString();
//            HumanGrid.Rows[1].Cells[5].Value = ChrRecord.btDir.Value.ToString();
//            HumanGrid.Rows[1].Cells[6].Value = ChrRecord.btJob.Value.ToString();
//            HumanGrid.Rows[1].Cells[7].Value = ChrRecord.btSex.Value.ToString();
//            HumanGrid.Rows[1].Cells[8].Value = ChrRecord.btHair.Value.ToString();
//            HumanGrid.Rows[1].Cells[9].Value = ChrRecord.nGold.Value.ToString();
//            HumanGrid.Rows[1].Cells[10].Value = ChrRecord.sDearName;
//            HumanGrid.Rows[1].Cells[11].Value = ChrRecord.sHomeMap;

//            HumanGrid.Rows[3].Cells[0].Value = ChrRecord.wHomeX.Value.ToString();
//            HumanGrid.Rows[3].Cells[1].Value = ChrRecord.wHomeY.Value.ToString();
//            HumanGrid.Rows[3].Cells[2].Value = ChrRecord.Level.Value.ToString();
//            HumanGrid.Rows[3].Cells[3].Value = ChrRecord.AC.Value.ToString();
//            HumanGrid.Rows[3].Cells[4].Value = ChrRecord.MAC.Value.ToString();
//            HumanGrid.Rows[3].Cells[5].Value = "";
//            HumanGrid.Rows[3].Cells[6].Value = ChrRecord.DC.Value.ToString();
//            HumanGrid.Rows[3].Cells[7].Value = ChrRecord.DC.Value.ToString();
//            HumanGrid.Rows[3].Cells[8].Value = ChrRecord.MC.Value.ToString();
//            HumanGrid.Rows[3].Cells[9].Value = ChrRecord.MC.Value.ToString();
//            HumanGrid.Rows[3].Cells[10].Value = ChrRecord.SC.Value.ToString();
//            HumanGrid.Rows[3].Cells[11].Value = ChrRecord.SC.Value.ToString() ;
            
//            HumanGrid.Cells[6, 4] = (LoByte(HumData.Abil.DC)).ToString();
//            HumanGrid.Cells[7, 4] = (HiByte(HumData.Abil.DC)).ToString();
//            HumanGrid.Cells[8, 4] = (LoByte(HumData.Abil.MC)).ToString();
//            HumanGrid.Cells[9, 4] = (HiByte(HumData.Abil.MC)).ToString();
//            HumanGrid.Cells[10, 4] = (LoByte(HumData.Abil.SC)).ToString();
//            HumanGrid.Cells[11, 4] = (HiByte(HumData.Abil.SC)).ToString();

//            HumanGrid.Rows[5].Cells[0].Value = "";
//            HumanGrid.Rows[5].Cells[1].Value = ChrRecord.HP.Value.ToString();
//            HumanGrid.Rows[5].Cells[2].Value = ChrRecord.HP.Value.ToString();
//            HumanGrid.Rows[5].Cells[3].Value = ChrRecord.MaxMP.Value.ToString();
//            HumanGrid.Rows[5].Cells[4].Value = ChrRecord.MaxMP.Value.ToString();
//            HumanGrid.Rows[5].Cells[5].Value = "";
//            HumanGrid.Rows[5].Cells[6].Value = ChrRecord.Exp.Value.ToString();
//            HumanGrid.Rows[5].Cells[7].Value = ChrRecord.MaxExp.Value.ToString();
//            HumanGrid.Rows[5].Cells[8].Value = ChrRecord.nPKPOINT.Value.ToString();
//            HumanGrid.Rows[5].Cells[9].Value = "";
//            HumanGrid.Rows[5].Cells[10].Value = ChrRecord.sAccount;
//            HumanGrid.Rows[5].Cells[11].Value = ChrRecord.dCreateDate.Value.ToString();

//            HumanGrid.Rows[7].Cells[0].Value = ChrRecord.sDearName;
//            HumanGrid.Rows[7].Cells[1].Value = ChrRecord.sMasterName;
//            HumanGrid.Rows[7].Cells[2].Value = ChrRecord.sStoragePwd;
//            HumanGrid.Rows[7].Cells[3].Value = ChrRecord.btCreditPoint.Value.ToString();
//            HumanGrid.Rows[7].Cells[4].Value = ChrRecord.boIsHero.Value.ToString();
//            if (ChrRecord.boIsHero.Value)
//            {
//                HumanGrid.Rows[6].Cells[1].Value = "ʦͽ";
//                HumanGrid.Rows[6].Cells[5].Value = "�Ƿ���Ӣ��";
//                HumanGrid.Rows[6].Cells[6].Value = "Ӣ������";
//                HumanGrid.Rows[7].Cells[5].Value = ChrRecord.boHasHero.Value.ToString();
//                HumanGrid.Rows[7].Cells[6].Value = ChrRecord.sHeroChrName;
//            }
//            else
//            {
//                HumanGrid.Rows[6].Cells[1].Value = "��������";
//                HumanGrid.Rows[6].Cells[5].Value ="";
//                HumanGrid.Rows[6].Cells[6].Value = "";
//                HumanGrid.Rows[7].Cells[5].Value = "";
//                HumanGrid.Rows[7].Cells[6].Value = "";
//            }
//        }

//        private void ShowBagItems()
//        {
//            int I;
//            int II;
            
            
//            for (I = 1; I < BagItemGrid.RowCount; I++)
//            {
//                for (II = 0; II < BagItemGrid.ColumnCount(); II++)
//                {
                    
//                    BagItemGrid.Rows[I].Cells[II].Value = "";
//                }
//            }
//            for (I = ChrRecord.Data.BagItems.GetLowerBound(0); I <= ChrRecord.Data.BagItems.GetUpperBound(0); I++)
//            {
//                ShowBagItem(I + 1, (I + 1).ToString(), ChrRecord.Data.BagItems[I]);
//            }
//        }

//        private void ShowUserItems()
//        {
//            int I;
//            int II;
//            //@ Unsupported property or method(C): 'RowCount'
//            for (I = 1; I < UserItemGrid.RowCount; I++)
//            {
//                //@ Unsupported property or method(C): 'ColCount'
//                for (II = 1; II < UserItemGrid.ColCount; II++)
//                {
                    
//                    UserItemGrid.Cells[II, I] = "";
//                }
//            }
//            ShowUserItem(1, "�·�", ChrRecord.Data.HumItems[0]);
//            ShowUserItem(2, "����", ChrRecord.Data.HumItems[1]);
//            ShowUserItem(3, "������", ChrRecord.Data.HumItems[2]);
//            ShowUserItem(4, "����", ChrRecord.Data.HumItems[3]);
//            ShowUserItem(5, "ͷ��", ChrRecord.Data.HumItems[4]);
//            ShowUserItem(6, "������", ChrRecord.Data.HumItems[5]);
//            ShowUserItem(7, "������", ChrRecord.Data.HumItems[6]);
//            ShowUserItem(8, "���ָ", ChrRecord.Data.HumItems[7]);
//            ShowUserItem(9, "�ҽ�ָ", ChrRecord.Data.HumItems[8]);
//            ShowUserItem(10, "��Ʒ", ChrRecord.Data.HumAddItems[9]);
//            ShowUserItem(11, "����", ChrRecord.Data.HumAddItems[10]);
//            ShowUserItem(12, "Ь��", ChrRecord.Data.HumAddItems[11]);
//            ShowUserItem(13, "��ʯ", ChrRecord.Data.HumAddItems[12]);
//        }

//        private void ShowUseMagic()
//        {
//            int I;
//            int ii;
//            //@ Unsupported property or method(C): 'RowCount'
//            for (I = 1; I < UseMagicGrid.RowCount; I++)
//            {
//                //@ Unsupported property or method(C): 'ColCount'
//                for (ii = 0; ii < UseMagicGrid.ColCount; ii++)
//                {
                    
//                    UseMagicGrid.Cells[ii, I] = "";
//                }
//            }
//            for (I = ChrRecord.Data.HumMagics.GetLowerBound(0); I <= ChrRecord.Data.HumMagics.GetUpperBound(0); I++)
//            {
//                if (ChrRecord.Data.HumMagics[I].wMagIdx <= 0)
//                {
//                    break;
//                }
                
//                UseMagicGrid.Cells[0, I + 1] = (ChrRecord.Data.HumMagics[I].wMagIdx).ToString();
                
//                UseMagicGrid.Cells[1, I + 1] = (ChrRecord.Data.HumMagics[I].btKey).ToString();
                
//                UseMagicGrid.Cells[2, I + 1] = (ChrRecord.Data.HumMagics[I].nTranPoint).ToString();
                
//                UseMagicGrid.Cells[3, I + 1] = DBShare.Units.DBShare.GetMagicName(ChrRecord.Data.HumMagics[I].wMagIdx);
//            }
//        }

//        private void ShowSaveItem()
//        {
//            int I;
//            int ii;
//            int nCount;
//            //@ Unsupported property or method(C): 'RowCount'
//            for (I = 1; I < SaveItemGrid.RowCount; I++)
//            {
//                //@ Unsupported property or method(C): 'ColCount'
//                for (ii = 0; ii < SaveItemGrid.ColCount; ii++)
//                {
                    
//                    SaveItemGrid.Cells[ii, I] = "";
//                }
//            }
//            nCount = 0;
//            for (I = ChrRecord.Data.StorageItems.GetLowerBound(0); I <= ChrRecord.Data.StorageItems.GetUpperBound(0); I++)
//            {
//                if (ChrRecord.Data.StorageItems[I].wIndex <= 0)
//                {
//                    continue;
//                }
                
//                SaveItemGrid.Cells[0, I + 1] = (nCount).ToString();
                
//                SaveItemGrid.Cells[1, I + 1] = (ChrRecord.Data.StorageItems[I].MakeIndex).ToString();
                
//                SaveItemGrid.Cells[2, I + 1] = (ChrRecord.Data.StorageItems[I].wIndex).ToString();
                
//                SaveItemGrid.Cells[3, I + 1] = (ChrRecord.Data.StorageItems[I].Dura).ToString() + '/' + (ChrRecord.Data.StorageItems[I].DuraMax).ToString();
                
//                SaveItemGrid.Cells[4, I + 1] = DBShare.Units.DBShare.GetStdItemName(ChrRecord.Data.StorageItems[I].wIndex);
//                nCount++;
//            }
//        }

//    } // end TFrmFDBViewer

//}