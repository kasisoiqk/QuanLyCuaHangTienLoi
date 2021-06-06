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
    public partial class frmXemDoanhThu : Form
    {
        private KetNoiDB ketNoiDB = new KetNoiDB();
        private string query;
        frmShowDialogQuestion _frmShowDialogQuestion;

        public frmXemDoanhThu()
        {
            InitializeComponent();

            query = "SELECT * FROM Bill LEFT JOIN Staffs ON Bill.IDStaff = Staffs.ID";
            GetData(query);
        }

        public void GetData(string query)
        {
            DataSet ds = ketNoiDB.GetDataSet(query);

            DataColumn MaHD = new DataColumn();
            MaHD.ColumnName = "MaHD";
            ds.Tables[0].Columns.Add(MaHD);

            DataColumn Date = new DataColumn();
            Date.ColumnName = "Date";
            ds.Tables[0].Columns.Add(Date);

            DataColumn Time = new DataColumn();
            Time.ColumnName = "Time";
            ds.Tables[0].Columns.Add(Time);

            DataColumn NhanVienTT = new DataColumn();
            NhanVienTT.ColumnName = "NhanVienTT";
            ds.Tables[0].Columns.Add(NhanVienTT);

            DataColumn LoaiGD = new DataColumn();
            LoaiGD.ColumnName = "LoaiGD";
            ds.Tables[0].Columns.Add(LoaiGD);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["MaHD"] = "HD" + ds.Tables[0].Rows[i]["ID"];
                ds.Tables[0].Rows[i]["Date"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateCheckIn"]).ToString("dd/MM/yyyy");
                ds.Tables[0].Rows[i]["Time"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateCheckIn"]).ToString("HH:mm:ss");
                ds.Tables[0].Rows[i]["NhanVienTT"] = ds.Tables[0].Rows[i]["Lastname"].ToString() + " " + ds.Tables[0].Rows[i]["Firstname"].ToString();
                if (ds.Tables[0].Rows[i]["NhanVienTT"].ToString() == " ") ds.Tables[0].Rows[i]["NhanVienTT"] = "Quản lý";
                if(ds.Tables[0].Rows[i]["Type"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["LoaiGD"] = "Nhập kho";
                }
                else if (ds.Tables[0].Rows[i]["Type"].ToString() == "2")
                {
                    ds.Tables[0].Rows[i]["LoaiGD"] = "Xuất kho";
                }
                else
                {
                    ds.Tables[0].Rows[i]["LoaiGD"] = "Bán hàng";
                }
            }

            dgvBills.AutoGenerateColumns = false;
            dgvBills.DataSource = ds.Tables[0];

            lblTongSo.Text = "Tổng số: " + ds.Tables[0].Rows.Count + " bản ghi.";
        }
    }
}