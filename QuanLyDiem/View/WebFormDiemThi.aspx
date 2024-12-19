<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDiemThi.aspx.cs" Inherits="QuanLyDiem.View.WebFormDiemThi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <H1>Thêm - Sửa - Xóa Điểm Thi </H1>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Mã điểm thi"></asp:Label>
            <asp:TextBox ID="txbMaDT" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Mã môn"></asp:Label>
            <asp:TextBox ID="txbMaMon" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Mã sinh viên"></asp:Label>
            <asp:TextBox ID="txbMaSV" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Điểm chuyên cần"></asp:Label>
            <asp:TextBox ID="txbDiemCC" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Điểm giữa kì"></asp:Label>
            <asp:TextBox ID="txbDiemGK" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Điểm thi"></asp:Label>
            <asp:TextBox ID="txbDiemThi" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label7" runat="server" Text="Điểm tổng kết"></asp:Label>
            <asp:TextBox ID="txbDiemTK" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnInsert" runat="server" Text="Thêm" OnClick="btnInsert_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnUpdate_Click" />
        </div>
        <div>
    <asp:GridView ID="dgvMonHoc" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvMonHoc_RowCommand" OnRowDeleting="dgvMonHoc_RowDeleting" OnRowEditing="dgvMonHoc_RowEditing">
        <Columns>
            <asp:BoundField DataField="MaDT" HeaderText="Mã điểm thi" />
            <asp:BoundField DataField="MaMon" HeaderText="Mã môn" />
            <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" />
            <asp:BoundField DataField="DiemCC" HeaderText="Điểm chuyên cần" />
            <asp:BoundField DataField="DiemGK" HeaderText="Điểm giữa kì" />
            <asp:BoundField DataField="DiemThi" HeaderText="Điểm thi" />
            <asp:BoundField DataField="DiemTK" HeaderText="Điểm tổng kết" />
            <asp:CommandField ButtonType="Button" HeaderText="Sửa" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Xóa" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>
</div>
    </form>
</body>
</html>
