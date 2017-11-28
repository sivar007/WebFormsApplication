<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApplication._Default"  %>

<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        setTimeout(function () {
            document.getElementById('message').innerText = "Here are all of the global departments";
        }, 2000);
        
    </script>

</asp:Content>
<asp:Content runat="server" ID="HeaderContent" ContentPlaceHolderID="HeaderContent">
    Additional Header Content Added By Individual Application
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
        <h2 id="message"></h2>

        <div id="Div1" runat="server">


        </div>

  
</asp:Content>

<asp:Content runat="server" ID="FooterContent" ContentPlaceHolderID="FooterContent">
    Footer content added by individual application.
    </asp:Content>