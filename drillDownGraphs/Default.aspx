<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
     <asp:Chart ID="chtPatients" runat="server" BackColor="AliceBlue">
         <Titles>
        <asp:Title Font="Times New Roman, 20pt, style=Bold" Name="PatientsTitle" 
            Text="Number of Current Patients on Each Floor" BackColor="AliceBlue">
        </asp:Title>
    </Titles>

        <Series>            
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" >
                <AxisX Title="Floor" TitleFont="Microsoft Sans Serif, 12pt">
                    
                    <LabelStyle Font="Arial, 12pt" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    </div>
    </form>
</body>
</html>
