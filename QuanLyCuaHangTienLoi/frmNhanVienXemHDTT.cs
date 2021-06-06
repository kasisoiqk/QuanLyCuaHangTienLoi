using System;
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
    public partial class frmNhanVienXemHDTT : Form
    {
        private KetNoiDB ketNoiDB = new KetNoiDB();
        private string query;
        frmShowDialogQuestion _frmShowDialogQuestion;

        public frmNhanVienXemHDTT()
        {
            InitializeComponent();

            query = "SELECT * FROM Bill INNER JOIN Staffs ON Bill.IDStaff = Staffs.ID";
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

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["MaHD"] = "HD" + ds.Tables[0].Rows[i]["ID"];
                ds.Tables[0].Rows[i]["Date"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateCheckIn"]).ToString("dd/MM/yyyy");
                ds.Tables[0].Rows[i]["Time"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateCheckIn"]).ToString("HH:mm:ss");
                ds.Tables[0].Rows[i]["NhanVienTT"] = ds.Tables[0].Rows[i]["Lastname"].ToString() + " " + ds.Tables[0].Rows[i]["Firstname"].ToString();
            }

            dgvBills.AutoGenerateColumns = false;
            dgvBills.DataSource = ds.Tables[0];

            lblTongSo.Text = "Tổng số: " + ds.Tables[0].Rows.Count + " bản ghi.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Yêu cầu nhập mã hóa đơn để tìm kiếm!", "Thử lại", "");
                _frmShowDialogQuestion.Show();
            }
            else
            {
                string[] id = txtTimKiem.Text.Split('D');
                if(id.Length <= 1)
                {
                    _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Không tìm thấy!", "Thử lại", "");
                    _frmShowDialogQuestion.Show();
                    return;
                }
                if (id[1] == "") return;
                query = "SELECT * FROM Bill INNER JOIN Staffs ON Bill.IDStaff = Staffs.ID WHERE Bill.ID = " + id[1];
                if(ketNoiDB.GetValue(query) != null)
                {
                    GetData(query);
                }
                else
                {
                    _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Không tìm thấy!", "Thử lại", "");
                    _frmShowDialogQuestion.Show();
                }
            }
        }

        private void chbThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (chbThoiGian.Checked) {
                query = "SELECT * FROM Bill INNER JOIN Staffs ON Bill.IDStaff = Staffs.ID AND (DateCheckIn BETWEEN '" + 
                    Convert.ToDateTime(dtpThoiGianTu.Value).ToString("MM/dd/yyyy HH:mm:ss") +
                     "' AND '" + Convert.ToDateTime(dtpThoiGianDen.Value).ToString("MM/dd/yyyy HH:mm:ss") + "')";
                GetData(query);
            }
        }

        private void dtpThoiGianTu_ValueChanged(object sender, EventArgs e)
        {
            chbThoiGian_CheckedChanged(sender, e);
        }

        private void dtpThoiGianDen_ValueChanged(object sender, EventArgs e)
        {
            chbThoiGian_CheckedChanged(sender, e);
        }

        private void dgvBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            if (RowIndex >= 0 && RowIndex < dgvBills.Rows.Count - 1)
            {
                string MaHD = dgvBills.Rows[RowIndex].Cells["MaHD"].Value.ToString();
                lblMaHD.Text = MaHD;

                string[] id = MaHD.Split('D');
                query = "SELECT * FROM BillInfo INNER JOIN Products ON BillInfo.IDProduct = Products.ID WHERE BillInfo.IDBill = " + id[1];

                DataSet ds = ketNoiDB.GetDataSet(query);

                DataColumn MaSP = new DataColumn();
                MaSP.ColumnName = "MaSP";
                ds.Tables[0].Columns.Add(MaSP);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["MaSP"] = "SP" + ds.Tables[0].Rows[i]["IDProduct"];
                }

                dgvBillInfo.AutoGenerateColumns = false;
                dgvBillInfo.DataSource = ds.Tables[0];
            }
        }
    }
}
