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
    public partial class frmNhanVienThanhToanSp : Form
    {
        private KetNoiDB ketNoiDB = new KetNoiDB();
        private string query;
        private string State = "Reset";
        frmShowDialogQuestion _frmShowDialogQuestion;

        string idStaff;

        public frmNhanVienThanhToanSp(string username)
        {
            InitializeComponent();

            query = "SELECT ID FROM Staffs WHERE Username = '" + username + "'";
            idStaff = ketNoiDB.GetValue(query);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CalculatorPrice()
        {
            long price = 0;
            for (int i = 0; i < dgvProducts.RowCount - 1; i++)
            {
                DataGridViewRow selected = dgvProducts.Rows[i];
                price += long.Parse(selected.Cells["Price"].Value.ToString()) * long.Parse(selected.Cells["Amount"].Value.ToString());

            }
            lblThanhTien.Text = price.ToString();
        }

        public void ResetData()
        {
            txtTimKiem.Text = "";
            dgvProduct.DataSource = null;
            nudSoLuong.Value = 0;
            lblTimThay.Visible = false;
            lblKhongTimThay.Visible = false;

            CalculatorPrice();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string[] id = txtTimKiem.Text.Trim().Split('P');
            if (id.Length < 2)
            {
                lblTimThay.Visible = false;
                lblKhongTimThay.Visible = true;
                dgvProduct.DataSource = null;
                return;
            }
            if (id[1] == "")
            {
                lblTimThay.Visible = false;
                lblKhongTimThay.Visible = true;
                dgvProduct.DataSource = null;
                return;
            }
            query = "SELECT * FROM Products WHERE Id = " + id[1];

            if (ketNoiDB.GetValue(query) != null)
            {
                DataSet ds = ketNoiDB.GetDataSet(query);
                lblTimThay.Visible = true;
                lblKhongTimThay.Visible = false;

                DataColumn colID = new DataColumn();
                colID.ColumnName = "MaSanPham";
                ds.Tables[0].Columns.Add(colID);

                ds.Tables[0].Rows[0]["MaSanPham"] = "SP" + id[1];

                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = ds.Tables[0];
            }
            else
            {
                lblTimThay.Visible = false;
                lblKhongTimThay.Visible = true;
                dgvProduct.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lblTimThay.Visible)
            {
                if(nudSoLuong.Value == 0)
                {
                    _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Chưa chọn số lượng. Vui lòng thử lại!", "Thử lại", "");
                    _frmShowDialogQuestion.Show();
                }
                else if(nudSoLuong.Value > int.Parse(dgvProduct.Rows[0].Cells["RemainAmount"].Value.ToString()))
                {
                    _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Số lượng mua vượt quá số lượng còn lại trong cửa hàng. Vui lòng thử lại!", "Thử lại", "");
                    _frmShowDialogQuestion.Show();
                }
                else
                {
                    DataGridViewRow selected = dgvProduct.Rows[0];
                    string MaSP = selected.Cells["MaSanPham"].Value.ToString();
                    string TenSP = selected.Cells["TenSP"].Value.ToString();
                    string NhaCungCap = selected.Cells["NhaCungCap"].Value.ToString();
                    string LoaiSP = selected.Cells["LoaiSP"].Value.ToString();
                    string GiaBan = selected.Cells["GiaBan"].Value.ToString();

                    dgvProducts.Rows.Add(1);
                    int RowIndex = dgvProducts.Rows.Count - 2;

                    dgvProducts[0, RowIndex].Value = MaSP;
                    dgvProducts[1, RowIndex].Value = TenSP;
                    dgvProducts[2, RowIndex].Value = NhaCungCap;
                    dgvProducts[3, RowIndex].Value = LoaiSP;
                    dgvProducts[4, RowIndex].Value = GiaBan;
                    dgvProducts[5, RowIndex].Value = nudSoLuong.Value.ToString();

                    _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Thêm thành công!", "Tiếp tục", "");
                    _frmShowDialogQuestion.Show();

                    ResetData();
                }
            }
            else
            {
                _frmShowDialogQuestion = new frmShowDialogQuestion("Thông báo", "Chưa chọn sản phẩm để thêm. Vui lòng tìm kiếm và thử lại!", "Thử lại", "");
                _frmShowDialogQuestion.Show();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int Rowindex = dgvProducts.CurrentCell.RowIndex;
            DataGridViewRow selected = dgvProducts.Rows[Rowindex];

            string tenSp = selected.Cells["NameProduct"].Value.ToString();
            if (tenSp != "" && Rowindex >= 0 && Rowindex < dgvProducts.Rows.Count - 1)
            {
                _frmShowDialogQuestion = new frmShowDialogQuestion("Xoá", "Bạn có muốn xóa sản phẩm " + tenSp + " trong danh mục không? ", "Có", "Không");
                var x = _frmShowDialogQuestion.ShowDialog();
                if (x == DialogResult.Yes)
                {
                    int RowIndex = dgvProducts.CurrentCell.RowIndex;
                    dgvProducts.Rows.RemoveAt(RowIndex);
                }
            }
            else
            {
                _frmShowDialogQuestion = new frmShowDialogQuestion("Xoá", "Bạn chưa chọn sản phẩm muốn xóa!", "Thử lại", "");
                _frmShowDialogQuestion.Show();
            }

            ResetData();
        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvProducts.Rows.Count <= 1)
            {
                btnXoa.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
            }
        }

        private void dgvProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvProducts.Rows.Count <= 1)
            {
                btnXoa.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            _frmShowDialogQuestion = new frmShowDialogQuestion("Question", "Bạn có chắc chắn thanh toán các sản phẩm trên " +
                "và lưu vào hóa đơn mua hàng?", "Có", "Không");
            var x = _frmShowDialogQuestion.ShowDialog();
            if (x != DialogResult.Yes) return;

            string time = Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy HH:mm:ss");
            query = "INSERT INTO Bill(IDStaff, DateCheckIn, TotalPrices, Type) VALUES(" + idStaff + ", '" + time + "', " + int.Parse(lblThanhTien.Text) + ", 0)";
            ketNoiDB.ThucThiCauLenh(query);
            query = "SELECT ID FROM Bill WHERE DateCheckIn = '" + time + "' AND TotalPrices = " + int.Parse(lblThanhTien.Text) + " AND Type = 0";
            string idBill = ketNoiDB.GetValue(query);

            for (int i = 0; i < dgvProducts.RowCount - 1; i++)
            {
                DataGridViewRow selected = dgvProducts.Rows[i];
                string MaSP = selected.Cells["MaSP"].Value.ToString();
                string[] id = MaSP.Split('P');
                int soLuong = int.Parse(selected.Cells["Amount"].Value.ToString());
                int gia = int.Parse(selected.Cells["Price"].Value.ToString());

                query = "SELECT RemainAmount FROM Products WHERE ID = " + id[1];
                int remainAmount = int.Parse(ketNoiDB.GetValue(query));
                query = "UPDATE Products SET RemainAmount = " + (remainAmount - soLuong) + " WHERE ID = " + id[1];
                ketNoiDB.ThucThiCauLenh(query);

                query = "INSERT INTO BillInfo(IDBill, IDProduct, Amount, Price) VALUES(" + idBill + ", " + id[1] + ", " + soLuong + ", " + gia + ")";
                ketNoiDB.ThucThiCauLenh(query);
            }

            _frmShowDialogQuestion = new frmShowDialogQuestion("Thành công", "Thanh toán sản phẩm thành công! Đã thêm dữ liệu vào hóa đơn thanh toán!", "Đồng ý", "");
            _frmShowDialogQuestion.Show();

            dgvProduct.DataSource = null;
            dgvProducts.DataSource = new DataSet();
        }
    }
}
