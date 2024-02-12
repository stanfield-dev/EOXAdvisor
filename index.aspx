<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EOXAdvisor.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EOX Advisor</title>
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="FormContainer">
        <form id="form1" runat="server">
            <div class="TextBoxTitle">
                <asp:Label ID="Label1" runat="server" Text="EOX Advisor" Font-Size="XX-Large"></asp:Label>
            </div>
            <div class="RowContainer">
                <asp:TextBox ID="TextBox1" class="TextBoxInput" TextMode="MultiLine" RunAt="server" Height="400px" Width="600px" 
                Text="Paste in 'show inventory' or a comma separated list of up to 20 PIDs..." style="margin-top: 1px" ></asp:TextBox>
            </div>
            <div class="BlankRow"></div>
            <div class="RowContainer">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" Font-Size="Larger" Height="54px" Width="151px" />
            </div>
        </form>
        <div class="RowContainer">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </div>
</body>
</html>
