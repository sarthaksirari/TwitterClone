<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication11.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script src="//code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function visible()
    {
            var clientId = "<%= Image1.ClientID %>";
            var obj = document.getElementById(clientId);
            obj.style.visibility = "hidden";
    }

    function showpreview(input)
    {
        if (input.files && input.files[0])
        {
            var clientId = "<%= Image1.ClientID %>";
            var obj = document.getElementById(clientId);
            obj.style.visibility = "visible";
            var reader = new FileReader();
            reader.onload = function (e)
            {
                $('#Image1').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
</script>
</head>
<body onload="visible();" >
<form id="form1" runat="server">
<div>
<asp:Image ID="Image1" runat="server" Height="299px"  Width="299px" BorderStyle="None" />
<asp:FileUpload ID="fuimage" runat="server" onchange="showpreview(this);" />
    <br />
    <br />
    <br />
<asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
</div>
</form>
</body>
</html>