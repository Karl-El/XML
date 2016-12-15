<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageniaizel.aspx.cs" Inherits="EDP.pageniaizel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap-3.css" rel="stylesheet" type="text/css" />
    <link href="css/checkbox.css" rel="stylesheet" type="text/css" />
    <link href="css/site.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-3.1.1.js" type="text/javascript"></script>
    <script src="js/tether.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container">
            <div class="row">
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <div class=" text-center">
                                <asp:LinkButton ID="lnkbtn_ClearFilter" runat="server" CssClass="btn btn-danger" Font-Size="Small"><i class="fa fa-times"></i> Clear Filter</asp:LinkButton>
                            </div>
                            <asp:RadioButtonList ID="rdbtnlst_Brand" runat="server" CssClass="radio radio-info" AutoPostBack="True" Font-Size="Small" Font-Overline="False" CellPadding="-1" CellSpacing="1">
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-9">
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <div class="form-inline">
                                <div class="pull-left">
                                    <label style="font-size: small" class="control-label">Product Found:</label>
                                    <asp:Label CssClass="control-label" ID="lbl_NumFound" runat="server" Text='' Font-Size="Small">100</asp:Label>
                                </div>
                                <div class="pull-right">
                                    <label style="font-size: small" class="control-label">View: </label>
                                    <asp:DropDownList ID="drpdwnlst_View" runat="server" CssClass="form-control" AutoPostBack="true" Font-Size="Small">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass=" btn btn-info"><</asp:LinkButton>
                                        </span>
                                        <asp:Label ID="TextBox1" runat="server" CssClass=" form-control">10</asp:Label>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass=" btn btn-info">></asp:LinkButton>
                                        </span>
                                    </div>
                                    <div class="input-group">
                                        <asp:TextBox ID="txt_Search" runat="server" CssClass=" form-control" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnbtn_Search" runat="server" CssClass=" btn btn-success">Search</asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <label style="font-size: small">Search Keyword:</label>
                            <asp:Label CssClass="form-control-label" ID="lbl_KeyWordSearch" runat="server" Text='' Font-Size="Small">Leptep</asp:Label>
                        </div>
                    </div>
                    <div class="panel  panel-default">
                        <div class="panel-body">
                            <div class="col-sm-3" style="text-align: center">
                                <br />
                                <asp:Image ID="img_Prod" runat="server" AlternateText="No Image" Height="100" Width="100" ImageUrl="~/images/box.gif" CssClass="img-thumbnail" /><br />
                                <br />
                                <br />
                                <asp:CheckBox ID="chkbx_Compare" runat="server" Text="Compare" CssClass=" checkbox checkbox-success" />
                            </div>
                            <div class="col-sm-6">
                                <h5>
                                    <asp:Label CssClass="form-control-label" ID="lbl_ProdName" runat="server" Text="Label" Font-Bold="true">Microsoft Surface Book - Tablet - with detachable keyboard - Core i7 6600U / 2.6 GHz - Win 10 Pro 64-bit - 16 GB RAM - 512 GB SSD - 13.5" touchscreen 3000 x 2000 - GF 940M</asp:Label>
                                </h5>
                                <asp:Label CssClass="form-control-label" ID="lbl_ProdDesc" runat="server" Text="Label" Font-Size="Small">Microsoft Surface Book - Tablet - with detachable keyboard - Core i7 6600U / 2.6 GHz - Win 10 Pro 64-bit - 16 GB RAM - 512 GB SSD - 13.5" touchscreen 3000 x 2000 - GF 940M</asp:Label>
                                <p>
                                    <label style="font-size: small">Availability:</label>
                                    <asp:Label CssClass="form-control-label" ID="lbl_StockDesc" runat="server" Text="Label" Font-Size="Small" ForeColor="#009900">In stock. Usually ships next business day.</asp:Label>
                                </p>
                                <p>
                                    <label style="font-size: small">Manufacturer:</label>
                                    <asp:Label CssClass="form-control-label" ID="lbl_Manufact" runat="server" Text="Label" Font-Size="Small">Dell</asp:Label>
                                </p>
                            </div>
                            <div class="col-sm-3">
                                <br />
                                <asp:Label CssClass="form-control-label" ID="lbl_FinalPrice" runat="server" Text="Label" Font-Bold="True">$2,699.00</asp:Label>
                                <br />
                                <br />
                                <asp:DropDownList ID="drpdwnlst_Quantity" runat="server" CssClass="form-control" Width="100">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                </asp:DropDownList><br />
                                <asp:LinkButton ID="lnkbtn_AddToCart" runat="server" CssClass="btn btn-primary" Font-Size="Small"><i class="fa fa-shopping-cart"></i>  Add to Cart</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <hr />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
