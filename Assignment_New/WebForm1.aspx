<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Assignment_New.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inserting Players Information</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2><i>Please enter the players details to either populate the database or delete the contents.</i></h2>
     
        <table class="style1">
               <h3>
            <tr>
                <td>Players Name:</td>
                <td>
                    <asp:TextBox ID="PlayerName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Players Team</td>
                <td>
                    <asp:TextBox ID="PlayerTeam" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>ICC Ranking</td>
                <td>
                    <asp:TextBox ID="ICCRanking" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Best Score</td>
                <td>
                    <asp:TextBox ID="BestScore" runat="server"></asp:TextBox>
                </td>
            </tr>

                   
          </h3>
        </table>
         <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Delete" onclick="Button2_Click" />
          

    </div>
    </form>
</body>
</html>

