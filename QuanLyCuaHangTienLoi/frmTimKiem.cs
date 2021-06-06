﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTienLoi
{
    public partial class frmTimKiem : Form
    {
        private KetNoiDB ketNoiDB = new KetNoiDB();
        private string query;
        frmShowDialogQuestion _frmShowDialogQuestion;

        public frmTimKiem()
        {
            InitializeComponent();

            query = "SELECT * FROM Products";
            GetData(query);
        }

        public frmTimKiem(bool isVisible)
        {
            InitializeComponent();

            query = "SELECT * FROM Products";
            GetData(query);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetData(string query)
        {
            DataSet ds = ketNoiDB.GetDataSet(query);

            DataColumn MaSP = new DataColumn();
            MaSP.ColumnName = "MaSP";
            ds.Tables[0].Columns.Add(MaSP);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["MaSP"] = "SP" + ds.Tables[0].Rows[i]["ID"];
            }

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = ds.Tables[0];

            lblTongSo.Text = "Tổng số: " + ds.Tables[0].Rows.Count + " bản ghi.";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            string TenSP = txtTenSP.Text;
            string NhaCungCap = txtNhaCungCap.Text;
            int GiaTu = int.Parse(nudGiaTu.Value.ToString());
            int GiaDen = int.Parse(nudGiaDen.Value.ToString());

            if(MaSP.Equals("") && TenSP.Equals("") && NhaCungCap.Equals("") && GiaDen == 0)
            {
                _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Yêu cầu nhập một hoặc vài thông tin tìm kiếm!", "Thử lại", "");
                _frmShowDialogQuestion.Show();
            }
            else
            {
                if(GiaTu > GiaDen)
                {
                    _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Giá bán từ phải nhỏ hơn hoặc bằng giá nhập!", "Thử lại", "");
                    _frmShowDialogQuestion.Show();
                    return;
                }
                else
                {
                    bool check = true;
                    query = "SELECT * FROM Products WHERE ";
                        //ID = " + id[1] + " AND NameProduct = N'%" + TenSP + "%' AND Supplier = N'%" +
                        //NhaCungCap + "%' AND ( Price BETWEEN " + GiaTu + " AND " + GiaDen + " )";

                    if(MaSP != "")
                    {
                        string[] id = MaSP.Split('P');
                        query += "ID = " + id[1];
                        check = false;
                    }

                    if(TenSP != "")
                    {
                        if(!check) query += " AND NameProduct = N'%" + TenSP + "%'";
                        else query += " NameProduct LIKE N'%" + TenSP + "%'";
                        check = false;
                    }

                    if(NhaCungCap != "")
                    {
                        if (!check) query += " AND Supplier = N'%" + NhaCungCap + "%'";
                        else query += " Supplier LIKE N'%" + NhaCungCap + "%'";
                        check = false;
                    }

                    if(GiaDen > 0)
                    {
                        if (!check) query += " AND ( Price BETWEEN " + GiaTu + " AND " + GiaDen + " )";
                        else query += " ( Price BETWEEN " + GiaTu + " AND " + GiaDen + " )";
                    }

                    /*_frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", query, "Thử lại", "");
                    _frmShowDialogQuestion.Show();*/

                    if (ketNoiDB.GetValue(query) != null)
                    {
                        lblTimThay.Visible = true;
                        lblKhongTimThay.Visible = false;

                        GetData(query);
                    }
                    else
                    {
                        lblTimThay.Visible = false;
                        lblKhongTimThay.Visible = true;
                    }
                }
            }
        }

        private void btnHienThiToanBo_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM Products";
            GetData(query);
        }

        private void cboLoaiSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboLoaiSp.SelectedIndex > 0 && cboLoaiSp.SelectedIndex < cboLoaiSp.Items.Count)
            {
                query = "SELECT * FROM Products WHERE Type = N'" + cboLoaiSp.Text + "'";
                GetData(query);
            }
            else
            {
                query = "SELECT * FROM Products";
                GetData(query);
            }
        }
    }
}
