<%@ Page Language="C#" AutoEventWireup="true" CodeFile="patients.aspx.cs" Inherits="patients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
       <h1> <asp:Label ID="h1" runat="server" Text="Label"></asp:Label></h1>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CHDBConnectionString %>" SelectCommand="Select Patients.PatientID, FirstName, LastName, AdmissionDate, PrimaryDiagnosis, Room, Bed From Patients Join Admissions on Patients.PatientID = Admissions.PatientId where Admissions.DischargeDate is NULL and Admissions.NursingUnitID = @nursingUnitId">
            <SelectParameters>
                <asp:QueryStringParameter Name="nursingUnitId" QueryStringField="nursing_unit_id" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="gvPatients" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="AdmissionDate" HeaderText="AdmissionDate" SortExpression="AdmissionDate" />
                <asp:BoundField DataField="PrimaryDiagnosis" HeaderText="PrimaryDiagnosis" SortExpression="PrimaryDiagnosis" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="Bed" HeaderText="Bed" SortExpression="Bed" />
            </Columns>
            <HeaderStyle BackColor="#0099CC" />
        </asp:GridView>
    </div>
        <p><a href ="Default.aspx">Home</a></p>
    </form>
</body>
</html>
