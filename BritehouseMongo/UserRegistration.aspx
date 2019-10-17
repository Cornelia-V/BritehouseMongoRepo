<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="BritehouseMongo.UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">    
<head runat="server">    
    <title>User Registration</title>    
    <meta charset="utf-8" />    
    <meta name="viewport" content="width=device-width, initial-scale=1" />    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>    
</head>    
<body>    
    <form id="form1" runat="server">    
        <div class="container">    
            <div class="row">    
            <div class="col-md-12 col-lg-12">    
            <div class="col-md-3"></div>    
            <div class="col-md-6">    
                 <h2 style="text-align:center;margin-top:10px;">User Registration</h2>    
            <div class="form-group">    
                <label for="email">Name:</label>    
                <asp:TextBox ID="Txtname" class="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>    
            </div>    
   
              <div class="form-group">    
                <label for="email">Region:</label>    
                <asp:TextBox ID="Txtregion" class="form-control" placeholder="Enter Region" runat="server"></asp:TextBox>    
            </div>    
            <div class="form-group">    
                <label for="email">Email:</label>    
                <asp:TextBox ID="Txtemail" class="form-control" placeholder="Enter email"  runat="server"></asp:TextBox>    
            </div>    
            <div class="form-group">    
                <label for="pwd">Password:</label>    
                <asp:TextBox ID="Txtpwd" class="form-control" TextMode="Password" placeholder="Enter password" runat="server"></asp:TextBox>    
            </div>    
             <div class="form-group" style="text-align:center">    
                 <asp:Button ID="Btnreg" runat="server" CssClass="btn btn-success" Text="Registration" OnClick="Btnreg_Click" />    
                 </div>    
            
            </div>    
            <div class="col-md-3"></div>    
    
                </div>    
            </div>    
            </div>    
    </form>    
</body>    
</html>    