<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="s.aspx.cs" Inherits="EDP.s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class=" row">
            <div class="col-sm-3 col-xs-12">
                <div class="panel panel-danger">
                    <div class="panel-body" style="text-align: center">
                        <asp:LinkButton ID="lnkbtn_ClearFilter" runat="server" CssClass="btn btn-outline-danger" Font-Size="Small"><i class="fa fa-times"></i> Clear Filter</asp:LinkButton>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View
                    </div>
                    <div class="panel-body">
                        <asp:DropDownList ID="drpdwnlst_View" runat="server" CssClass="form-control" AutoPostBack="true" Font-Size="Small" OnSelectedIndexChanged="drpdwnlst_View_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Brand
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="pnl_rdBrand" runat="server" ScrollBars="Auto" Height="150">
                            <asp:RadioButtonList ID="rdbtnlst_Brand" runat="server" CssClass="radio radio-info" AutoPostBack="True" Font-Size="Small" Font-Overline="False" CellPadding="-1" CellSpacing="1">
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="col-sm-9 col-xs-12">
                <%--<div class="panel panel-default">
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
                                <asp:Label CssClass="control-label" ID="lbl_ProdName" runat="server" Text="Label" Font-Bold="true">Microsoft Surface Book - Tablet - with detachable keyboard - Core i7 6600U / 2.6 GHz - Win 10 Pro 64-bit - 16 GB RAM - 512 GB SSD - 13.5" touchscreen 3000 x 2000 - GF 940M</asp:Label>
                            </h5>
                            <asp:Label CssClass="control-label" ID="lbl_ProdDesc" runat="server" Text="Label" Font-Size="Small">Microsoft Surface Book - Tablet - with detachable keyboard - Core i7 6600U / 2.6 GHz - Win 10 Pro 64-bit - 16 GB RAM - 512 GB SSD - 13.5" touchscreen 3000 x 2000 - GF 940M</asp:Label>
                            <p>
                                <label style="font-size: small">Availability:</label>
                                <asp:Label CssClass="control-label" ID="lbl_StockDesc" runat="server" Text="Label" Font-Size="Small" ForeColor="#009900">In stock. Usually ships next business day.</asp:Label>
                            </p>
                            <p>
                                <label style="font-size: small">Manufacturer:</label>
                                <asp:Label CssClass="control-label" ID="lbl_Manufact" runat="server" Text="Label" Font-Size="Small">Dell</asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-3">
                            <br />
                            <asp:Label CssClass="control-label" ID="lbl_FinalPrice" runat="server" Text="Label" Font-Bold="True">$2,699.00</asp:Label>
                            <br />
                            <br />
                            <asp:DropDownList ID="drpdwnlst_Quantity" runat="server" CssClass="form-control" Width="100">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                            </asp:DropDownList><br />
                            <asp:LinkButton ID="lnkbtn_AddToCart" runat="server" CssClass="btn btn-outline-primary" Font-Size="Small"><i class="fa fa-shopping-cart"></i>  Add to Cart</asp:LinkButton>
                        </div>
                    </div>
                </div>--%>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:ListView ID="lstvw_Prodinfo" runat="server" OnPagePropertiesChanging="lstvw_Prodinfo_PagePropertiesChanging" OnItemDataBound="lstvw_Prodinfo_ItemDataBound">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: center">
                                        <br />
                                        <asp:Image ID="img_Prod" runat="server" AlternateText="No Image" Height="100" Width="100" ImageUrl='<%# Eval("ProdImgURl")%>' CssClass="img-thumbnail" /><br />
                                        <br />
                                        <br />
                                        <asp:CheckBox ID="chkbx_Compare" runat="server" Text="Compare" CssClass=" checkbox checkbox-success" />
                                    </div>
                                    <div class="col-sm-6">
                                        <h5>
                                            <asp:Label CssClass="control-label" ID="lbl_ProdName" runat="server" Text='<%# Eval("ProdName")%>' Font-Bold="true"></asp:Label>
                                        </h5>
                                        <asp:Label CssClass="control-label" ID="lbl_ProdDesc" runat="server" Text='<%# Eval("ProdDesc") %>' Font-Size="Small"></asp:Label>
                                        <p>
                                            <label style="font-size: small">Availability:</label>
                                            <asp:Label CssClass="control-label" ID="lbl_StockDesc" runat="server" Text='<%# Eval("ProdAvailDesc")%>' Font-Size="Small" ForeColor="#009900"></asp:Label>
                                        </p>
                                        <p>
                                            <label style="font-size: small">Manufacturer:</label>
                                            <asp:Label CssClass="control-label" ID="lbl_Manufact" runat="server" Text='<%# Eval("ProdManufact")%>' Font-Size="Small"></asp:Label>
                                        </p>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Label CssClass="control-label" ID="lbl_FinalPrice" runat="server" Text='<%# Eval("ProdFinPrice")%>' Font-Bold="True"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:DropDownList ID="drpdwnlst_Quantity" runat="server" CssClass="form-control" Width="100">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                        </asp:DropDownList><br />
                                        <asp:LinkButton ID="lnkbtn_AddToCart" runat="server" CssClass="btn btn-outline-primary" Font-Size="Small"><i class="fa fa-shopping-cart"></i>  Add to Cart</asp:LinkButton>
                                    </div>
                                </div>
                                <hr />
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:Repeater ID="rptrProdInfo" runat="server">
                        </asp:Repeater>
                        <asp:PlaceHolder ID="plchldr_Prod" runat="server"></asp:PlaceHolder>
                        <br />
                        <asp:DataPager ID="dtdpgr_ProdInfo" runat="server" PageSize="5" PagedControlID="lstvw_Prodinfo">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="True" ButtonCssClass="btn btn-info btn-sm" />
                                <asp:NumericPagerField NumericButtonCssClass="label label-success" CurrentPageLabelCssClass="badge" />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn btn-info btn-sm" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
