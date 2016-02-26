/****************************************************************
** �ļ�����DataGridViewHelper.cs
** Copyright(c)2012-2020 JohnSoft
** �����ˣ���־ǿ
** ��  �ڣ�2012-3-17
** �޸��ˣ�
** ��  �ڣ�
** ��  ����DataGridView����
****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace GameFramework
{
    public class DataGridViewHelper
    {
        /****************************************************************
        ** �� �� ����AddDataGridViewColumn
        ** �������������DataGridView��
        ** ���������strHeaderText �ַ��� <����ʾ����>
        **           strDataPropertyName �ַ��� <���ֶ�>
        **           nWidth ������ <���>
        **           objTag �ַ��� <������>
        **           myDataGridView DataGridView <Ŀ����������>
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2012-3-17
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public static void AddDataGridViewColumn(string strHeaderText, string strDataPropertyName, int nWidth, object objTag, DataGridView myDataGridView)
        {
            DataGridViewTextBoxColumn myDataGridViewColumn = new DataGridViewTextBoxColumn();
            myDataGridViewColumn.Name = strDataPropertyName;
            myDataGridViewColumn.HeaderText = strHeaderText;
            //myDataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            myDataGridViewColumn.DataPropertyName = strDataPropertyName;
            myDataGridViewColumn.Tag = objTag;
            myDataGridViewColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            if (nWidth == -1)
            {
                myDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                myDataGridViewColumn.Width = nWidth;
            }
            myDataGridView.Columns.Add(myDataGridViewColumn);
        }

        /****************************************************************
        ** �� �� ����ConvertData
        ** ������������DataGridViewת��ΪDataSet
        ** ���������dgvInstant �������� <����ʾ����>
        **           TableName  �ַ��� <���ݱ���>
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2012-3-17
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public static DataSet ConvertData(DataGridView dgvInstant,string TableName)
        {
            DataSet dsReturn = default(DataSet);
            if (null != dgvInstant)
            {
                if (null != dgvInstant.DataSource && null != (dgvInstant.DataSource as DataTable))
                {
                    dsReturn = ((DataTable)dgvInstant.DataSource).DataSet;
                    if (null != dsReturn)
                        return dsReturn.Copy();
                }
                dsReturn = new DataSet();
                dsReturn.Tables.Add(new DataTable(TableName));
                foreach (DataGridViewColumn column in dgvInstant.Columns)
                {
                    dsReturn.Tables[TableName].Columns.Add(null == column.Tag
                                                                     ? string.IsNullOrEmpty(column.DataPropertyName)
                                                                           ? column.Name
                                                                           : column.DataPropertyName
                                                                     : column.Tag.ToString());
                }
                List<object> list = new List<object>(dsReturn.Tables[TableName].Columns.Count);
                foreach (DataGridViewRow row in dgvInstant.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value);
                    }
                    dsReturn.Tables[TableName].Rows.Add(list.ToArray());
                    list.Clear();
                }
            }
            return dsReturn;
        }

        /****************************************************************
        ** �� �� ����Dgv2DataSet
        ** ������������DataGridViewת��ΪDataSet
        ** ���������dgvStatAnalyInf    �ؼ���   <��������>
        ** ������������ݼ� <ת��������ݼ�>
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2012-3-17
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public static DataSet Dgv2DataSet(DataGridView dgvStatAnalyInf)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add(new DataTable());
            foreach (DataGridViewColumn dgvc in dgvStatAnalyInf.Columns)
            {
                if (dgvc.Visible)
                {
                    dsData.Tables[0].Columns.Add(dgvc.HeaderText);
                }
            }
            foreach (DataGridViewRow dgvc in dgvStatAnalyInf.Rows)
            {
                ArrayList arr = new ArrayList();
                for (int i = 0; i < dgvStatAnalyInf.Columns.Count; i++)
                {
                    if (dgvStatAnalyInf.Columns[i].Visible)
                    {
                        arr.Add(dgvc.Cells[i].Value.ToString());
                    }
                }
                dsData.Tables[0].Rows.Add(arr.ToArray());
            }
            return dsData;
        }

        /****************************************************************
        ** �� �� �����ϲ�DataTable
        ** ������������DataGridViewת��ΪDataSet
        ** ���������dts �ؼ������� <������ݱ��>
        ** ����������ؼ��� <�ϲ���ı��>
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2012-3-17
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public static DataTable MergeDataTable(params DataTable [] dts)
        {
            DataTable dtResult = new DataTable();
            foreach (DataColumn dc in dts[0].Columns)
            {

                dtResult.Columns.Add(dc.ColumnName, dc.DataType);
            }
            foreach (DataTable dt in dts)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dtResult.Rows.Add(dr.ItemArray);
                }
            }
            return dtResult;
        }

        /****************************************************************
        ** �� �� ����RemoveBlankRow
        ** �����������Ƴ����������еĿհ���
        ** ���������myDataGridView �ؼ��� <��ʾ���ݵ���������>
        **           aObjParams  ���������� <��������>
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2012-3-17
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public static void RemoveBlankRow(DataGridView myDataGridView, params object[] aObjParams)
        {
            for (int i = Int32.Parse(aObjParams[0].ToString()); i < Int32.Parse(aObjParams[1].ToString()); i++)
            {
                bool bRemove = true;
                for (int j = Int32.Parse(aObjParams[2].ToString()); j < Int32.Parse(aObjParams[3].ToString()); j++)
                {
                    if ((myDataGridView.Rows[i].Cells[j].Value != null) && (myDataGridView.Rows[i].Cells[j].Value.ToString() != ""))
                    {
                        bool bExists = false;
                        for (int k = 4; k < aObjParams.Length; k++)
                        {
                            if (myDataGridView.Rows[i].Cells[j].Value.ToString() == aObjParams[k].ToString())
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists == false)
                        {
                            bRemove = false;
                            break;
                        }
                    }
                }
                if (bRemove == true)
                {
                    myDataGridView.Rows.RemoveAt(i);
                    i--;
                    aObjParams[1] = Int32.Parse(aObjParams[1].ToString()) - 1;
                }
            }
        }

        /****************************************************************
        ** �� �� ����InitDataGridView
        ** �������������������ʼ��
        ** ���������dgvTarget �ؼ��� <Ŀ����������>
        ** �����������
        ** �� �� ֵ����
        ** �� �� �ˣ���־ǿ
        ** ��    �ڣ�2012-3-17
        ** �� �� �ˣ�
        ** ��    �ڣ�
        ****************************************************************/
        public static void InitDataGridView(bool ReadOnly, bool AllowUserToAddRows, bool RowHeadersVisible,bool ColumnHeadersVisible, bool MultiSelect,bool AllowUserToResizeRows,bool AllowUserToResizeColumns,DataGridViewSelectionMode SelectionMode, DataGridView dgvTarget)
        {
            dgvTarget.ReadOnly = ReadOnly;
            dgvTarget.AllowUserToAddRows = AllowUserToAddRows;
            dgvTarget.RowHeadersVisible = RowHeadersVisible;
            dgvTarget.ColumnHeadersVisible = ColumnHeadersVisible;
            dgvTarget.SelectionMode = SelectionMode;
            dgvTarget.MultiSelect = MultiSelect;
            dgvTarget.AllowUserToResizeRows = AllowUserToResizeRows;
            dgvTarget.AllowUserToResizeColumns = AllowUserToResizeColumns;
           // dgvTarget.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
        }
    }
}
