<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormSinhVien.aspx.cs" Inherits="QuanLyDiem.View.WebFormSinhVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <H1>Thêm - Sửa - Xóa Sinh Viên </H1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Mã sinh viên"></asp:Label>
        <asp:TextBox ID="txbMaSV" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Họ tên"></asp:Label>
        <asp:TextBox ID="txbHoTen" runat="server"></asp:TextBox>
    </div>
    <div>
    <asp:Label ID="Label3" runat="server" Text="Ngày sinh"></asp:Label>
    <asp:TextBox ID="txbNgaySinh" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="Label4" runat="server" Text="Ghi chú"></asp:Label>
    <asp:TextBox ID="txbGhiChu" runat="server"></asp:TextBox>
</div>
    <div>
        <asp:Button ID="btnInsert" runat="server" Text="Thêm" OnClick="btnInsert_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnUpdate_Click" />
    </div>
    <div>
        <asp:GridView ID="dgvSinhVien" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvSinhVien_RowCommand" OnRowDeleting="dgvSinhVien_RowDeleting" OnRowEditing="dgvSinhVien_RowEditing">
            <Columns>
                <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" />
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
                <asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" />
                <asp:CommandField ButtonType="Button" HeaderText="Sửa" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                <asp:CommandField ButtonType="Button" HeaderText="Xóa" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
</form>
</body>
</html>
