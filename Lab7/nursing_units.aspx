<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nursing_units.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="chtFloor" runat="server" BackColor="AliceBlue">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="Floor" TitleFont="Microsoft Sans Serif, 12pt">
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                
                <asp:Title Font="Microsoft Sans Serif, 20.25pt" Name="Title1">
                </asp:Title>
                
            </Titles>
        </asp:Chart>
    </div>
        <p><a href="Default.aspx">Back</a></p>
    </form>
</body>
</html>
