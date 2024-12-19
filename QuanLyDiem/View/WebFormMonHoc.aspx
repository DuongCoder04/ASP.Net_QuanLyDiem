<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMonHoc.aspx.cs" Inherits="QuanLyDiem.View.WebFormMonHoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <H1>Thêm - Sửa - Xóa Môn Học </H1>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Mã môn"></asp:Label>
            <asp:TextBox ID="txbMaMon" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Tên môn"></asp:Label>
            <asp:TextBox ID="txbTenMon" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnInsert" runat="server" Text="Thêm" OnClick="btnInsert_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnUpdate_Click" />
        </div>
        <div>
            <asp:GridView ID="dgvMonHoc" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvMonHoc_RowCommand" OnRowDeleting="dgvMonHoc_RowDeleting" OnRowEditing="dgvMonHoc_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MaMon" HeaderText="Mã môn" />
                    <asp:BoundField DataField="TenMon" HeaderText="Tên môn" />
                    <asp:CommandField ButtonType="Button" HeaderText="Sửa" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Xóa" ShowDeleteButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
