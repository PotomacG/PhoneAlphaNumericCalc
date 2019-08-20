<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoneEntry.ascx.cs" Inherits="WebApplication1.PhoneEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div>
    <asp:Label ID="lblEnter" runat="server" Font-Bold="true" Font-Size="Large" Text="Please enter a 7 or 10 digit phone number: " />&nbsp;&nbsp;
    <asp:TextBox ID="txtPhone" runat="server" AutoCompleteType="Disabled" MaxLength="9" Width="110px"></asp:TextBox>
    <ajaxToolkit:MaskedEditExtender ID="MEE1" runat="server" TargetControlID="txtPhone" Mask="(999) 999-9999" />
    &nbsp;&nbsp;<asp:Button ID="btnCalc" runat="server" Text="Calculate" OnClick="btnCalc_Click" />
    <span style="margin-left: 100px">
        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
    </span>

    <div id="divResults" runat="server" visible="false">
        <br />
        <br />
        <asp:Label ID="lblCount" runat="server" ForeColor="Navy" Font-Bold="true" Font-Size="Large" />
        <br />
        <asp:GridView ID="gvResults" Width="160px" runat="server" CellPadding="2" GridLines="None"
            ForeColor="Black" Font-Names="Arial" Font-Size="11pt" AllowPaging="true" PageSize="30"
            OnPageIndexChanging="gvResults_PageIndexChanging" RowStyle-Font-Names="Consolas">
            <HeaderStyle ForeColor="White" BackColor="White" />
            <RowStyle BackColor="LightGray" ForeColor="Black" HorizontalAlign="Right" />
            <AlternatingRowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</div>
