<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="textEditor._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">

        function getFiles() {

            //debuging to make sure it gets in function
            document.getElementById("txtbx_editingArea").innerHTML = "Got Here";

            $.ajax({
                type: "GET",
                url: "Default.aspx/testPage",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                //dataType: "json",
                success: function (response) {
                    //var files = JSON.parse(response.d);
                    document.getElementById("txtbx_editingArea").innerHTML = "Responce Succesfull";
                },
                failure: function (msg) {
                    document.getElementById("txtbx_editingArea").innerHTML = "Responce fail";
                }
            });
        }
    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="lstbx_fileSelection" runat="server" Width="465px"></asp:ListBox>
                <br />
                <asp:Button ID="btn_Open" runat="server" OnClientClick="getFiles()" Text="Open" />
                <br />
                <br />
                <asp:TextBox ID="txtbx_editingArea" runat="server" Height="281px" TextMode="MultiLine" Width="468px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Lbl_FileName" runat="server" Text="File Name"></asp:Label>
                <br />
                <asp:TextBox ID="txtbx_SaveAs" runat="server" Width="250px"></asp:TextBox>
                <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>


