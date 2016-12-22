<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="s.aspx.cs" Inherits="EDP.s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-inline">
                            <div class="pull-right">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="View: " CssClass="control-label" Font-Bold="true"></asp:Label>
                                    <asp:DropDownList ID="drpdwnlst_View" runat="server" CssClass="form-control" AutoPostBack="true" Font-Size="Small" OnSelectedIndexChanged="drpdwnlst_View_SelectedIndexChanged">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group"></div>
                                <div class="form-group">
                                    <asp:Label ID="lbl_MinPage" runat="server" Text="Min " CssClass="control-label" Font-Bold="true"></asp:Label>
                                    <label>-</label>
                                    <asp:Label ID="lbl_MaxPage" runat="server" Text="Max " CssClass="control-label" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="of " CssClass="control-label"></asp:Label>
                                    <asp:Label ID="lbl_NumFound" runat="server" Text="1100 " CssClass="control-label" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="form-group"></div>
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkbtn_Prev" runat="server" OnClick="lnkbtn_Prev_Click" CssClass=" btn btn-outline-success"><i class="fa fa-chevron-left" aria-hidden="true"></i>  </asp:LinkButton>
                                        <%--<asp:Label ID="lbl_CurrentPage" runat="server" CssClass=" form-control"></asp:Label>--%>
                                            <%--<asp:LinkButton ID="lnk_GoToPage" runat="server" CssClass=" btn btn-outline-primary"><i class="fa fa-share" aria-hidden="true"></i>  Go To</asp:LinkButton>--%>
                                            <asp:LinkButton ID="lnkbtn_Nxt" runat="server" OnClick="lnkbtn_Nxt_Click" CssClass=" btn btn-outline-success"><i class="fa fa-chevron-right" aria-hidden="true"></i>  </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class=" row">
            <div class="col-sm-3 col-xs-12">
                <div class="panel panel-danger">
                    <div class="panel-body" style="text-align: center">
                        <asp:LinkButton ID="lnkbtn_ClearFilter" runat="server" CssClass="btn btn-outline-danger" Font-Size="Small"><i class="fa fa-times"></i> Clear Filter</asp:LinkButton>
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
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:ListView ID="lstvw_Prodinfo" runat="server" OnItemDataBound="lstvw_Prodinfo_ItemDataBound">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: center">
                                        <br />
                                        <asp:Image ID="img_Prod" runat="server" AlternateText="No Image" Height="100" Width="100" ImageUrl='<%# Eval("ProdImgURl")%>' CssClass=" img-rounded" /><br />
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
                                            <asp:Label CssClass="control-label" ID="lbl_StockDesc" runat="server" Text='<%# Eval("ProdAvailDesc")%>' Font-Size="Small"></asp:Label>
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
                                        <asp:LinkButton ID="lnkbtn_AddToCart" runat="server" CssClass="btn btn-outline-primary" Font-Size="Small" Text='<%# Eval("ProdBtnTxt")%>'></asp:LinkButton>
                                    </div>
                                </div>
                                <hr />
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:Repeater ID="rptrProdInfo" runat="server">
                        </asp:Repeater>
                        <asp:PlaceHolder ID="plchldr_Prod" runat="server"></asp:PlaceHolder>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
