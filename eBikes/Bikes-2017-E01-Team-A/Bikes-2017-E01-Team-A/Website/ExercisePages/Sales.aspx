<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sales.aspx.cs" Inherits="Sales" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron">
        <h1 style="">Product Catalog</h1>
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <div class="row">
        <div class="col-md-12">
             <script>
                function nextButton(anchorRef) {
                    $('a[href="' + anchorRef + '"]').tab('show');
                }
            </script>
            <%-- Navigational Tabs--%>
            <ul class="nav nav-tabs">
                <li class="active"><a href="#intro" data-toggle="tab">Introduction  <span aria-hidden="true" class="glyphicon glyphicon-ok"></span></a></li>
                <li class="active"><a href="#browse" data-toggle="tab">Browse  <span aria-hidden="true" class="glyphicon glyphicon-gift"></span></a></li>
                <li><a href="#cart" data-toggle="tab">Your Cart  <span aria-hidden="true" class="glyphicon glyphicon-shopping-cart"></span></a></li>
                <li><a href="#info" data-toggle="tab">Shipping/Billing Info  <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></a></li>
                <li><a href="#confirm" data-toggle="tab">Place Order  <span aria-hidden="true" class="glyphicon glyphicon-ok"></span></a></li>
            </ul>
      </div>
        </div>
            <div id="intro" class="tab-pane fade in active">
    <h1>Sales</h1>
    <h3> By : Vamsee Kuppa</h3>
    <pre>
        Hello, I am Vamsee Krishna Kuppa. I have devloped 
        and created this page up my instrucotr's instructions.
        I have used some additional stylesheets and some other 
        styles for the exact positioning of the Webitems.
    </pre>
       </div>
             <%--  End of Introduction Page--%>
              <div id="browse" class="tab-pane fade in active">
                    <h3>Browse</h3>
                    <p>Browse by category</p>
                    <hr class="my-2">
                    <div class="row">
                        <div class="col-md-3">
                            <ul class="nav nav-pills nav-stacked">
                                <li><asp:LinkButton ID="LinkButtonAllCat" runat="server" OnClick="LinkButtonAllCat_Click" CommandArgument="-1">All</asp:LinkButton>
                                    <ul class="nav nav-pills nav-stacked">
                                        <asp:Repeater ID="RepeaterListCategories" runat="server"
                                            DataSourceID="ODS_CategoryList">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton ID="GetCat_Item" runat="server" OnCommand="GetCatItem_Command" 
                                                            CommandName="CatItemBtnClick" CommandArgument='<%# Eval("CategoryID") %>'>
                                                            <%# Eval("CategoryName") %><span class="badge pull-right"><%# Eval("qtyOfParts") %></span>
                                                        </asp:LinkButton>
                                                    </li>
                                                    <br>
                                                    </br>
                                                </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <!--Stock Items Table-->
                        <div class="col-md-9">
                            <asp:HiddenField ID="HiddenFieldCatID" runat="server" /><%--This is used to pass parameter to the ODS--%>
                            <div class="productItem">
                                <asp:GridView ID="GridViewParts" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_ListPart"
                                    AllowPaging="True" CssClass="table" GridLines="None" CellSpacing="-1" OnSelectedIndexChanged="GridViewParts_SelectedIndexChanged">
                                    <PagerStyle CssClass="pagination-gridview" />

                                    <Columns>
                                        <asp:BoundField DataField="SellingPrice" HeaderText="Price" SortExpression="SellingPrice" DataFormatString="{0:C2}"></asp:BoundField>
                                        <asp:BoundField DataField="Description" HeaderText="Product" SortExpression="Description"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxATCQuantity" runat="server" CssClass="form-control" placeholder="QTY." Text="1"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=''>
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonAddStkItm" runat="server" Text="Add" 
                                                    OnClick="ButtonAddStkItm_Click" CommandArgument='<%# Eval("PartID") %>' CssClass="btn btn-default"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <!---->
                    </div>
                </div>                       
             <div id="cart" class="tab-pane fade">
                    <h3>Cart</h3>
                    <p>View and edit your cart</p>
                    <hr class="my-2">

                    <asp:Label ID="LabelToViewCart" runat="server" Text="You must be logged in as a customer first to view your cart!"></asp:Label>
                    <asp:GridView ID="GridViewEditCart" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_ListCartItems"
                        AllowPaging="True" CssClass="table" GridLines="None" CellSpacing="-1">
                                    <PagerStyle CssClass="pagination-gridview" />
                        <Columns>
                            <asp:BoundField DataField="sciID" HeaderText="sciID" SortExpression="sciID" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product"></asp:BoundField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <div class="input-group" style="max-width: 200px;" >
                                        <span class="input-group-btn">
                                            <asp:Button ID="ButtonDeleteSCI" runat="server" Text="X" 
                                                OnClick="ButtonDeleteSCI_Click" CommandArgument='<%# Eval("prtID") %>' CssClass="btn btn-secondary" />
                                        </span>
                                        <asp:TextBox ID="TextBoxSCIQuantity" runat="server" CssClass="form-control" placeholder="QTY." Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="ButtonUpdateSCI" runat="server" Text="Update" 
                                                OnClick="ButtonUpdateSCI_Click" CommandArgument='<%# Eval("prtID") %>' CssClass="btn btn-secondary" />
                                        </span>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:C2}"></asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:C2}"></asp:BoundField>
                        </Columns>
                        <emptydatatemplate>
                            Your cart is empty...
                        </emptydatatemplate> 
                    </asp:GridView>
                </div>
     <div id="info" class="tab-pane fade">
                    <h3>Purchase Info</h3>
                    <p>Please enter your shipping and billing information</p>
                    <hr class="my-2">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Billing</h4>
                        </div>
                        <div class="panel-body">
                            <fieldset disabled>
                                <div class="form-group">
                                    <label for="bname">Name:</label>
                                    <input type="text" class="form-control" id="bname">
                                </div>
                                <div class="form-group">
                                    <label for="bemail">Email:</label>
                                    <input type="email" class="form-control" id="bemail">
                                </div>
                                <div class="form-group">
                                    <label for="bemail">Address:</label>
                                    <input type="text" class="form-control" id="baddress">
                                </div>
                                <div class="form-group">
                                    <label for="bphone">Phone:</label>
                                    <input type="text" class="form-control" id="bphone">
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Shipping</h4>
                        </div>
                        <div class="panel-body">
                            <fieldset disabled>
                                <div class="form-group">
                                    <label for="bname">Name:</label>
                                    <input type="text" class="form-control" id="bname">
                                </div>
                                <div class="form-group">
                                    <label for="bemail">Email:</label>
                                    <input type="email" class="form-control" id="bemail">
                                </div>
                                <div class="form-group">
                                    <label for="bemail">Address:</label>
                                    <input type="text" class="form-control" id="baddress">
                                </div>
                                <div class="form-group">
                                    <label for="bphone">Phone:</label>
                                    <input type="text" class="form-control" id="bphone">
                                </div>
                            </fieldset>
                        </div>
                    </div>

                    <button type="button" class="btn btn-primary">Save</button>

                </div>
             <div id="confirm" class="tab-pane fade">
                    <h3>Confirm Order</h3>
                    <p>Confirm and pay</p>
                    <hr class="my-2">

                    <asp:Label ID="LabelToViewCart2" runat="server" Text="Please log on as an online customer first!"></asp:Label>
                    <asp:GridView ID="GridViewConfirmCart" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_ListCartItems"
                        AllowPaging="True" CssClass="table" GridLines="None" CellSpacing="-1">
                                    <PagerStyle CssClass="pagination-gridview" />
                        <Columns>
                            <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product"></asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <div class="input-group pull-right" style="max-width: 320px;">
                        <asp:TextBox ID="TextBoxDiscount" runat="server" CssClass="form-control" placeholder="Coupon Code"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="ButtonApplyDiscount" runat="server" Text='Apply' OnClick="ButtonApplyDiscount_Click" CssClass="btn btn-default" />
                        </span>
                    </div>
                    <div style="clear:both;"></div>

                    <div class="orderTotals" style="text-align: right; margin-bottom:5px;">
                        <h4>
                            SubTotal: <asp:Label ID="LabelSubTotal" runat="server" Text="$0"></asp:Label></h4>
                        <h4>
                            Discount: <asp:Label ID="LabelGST" runat="server" Text="$0"></asp:Label></h4>
                        <h4>
                            Discount: <asp:Label ID="LabelDiscount" runat="server" Text="$0"></asp:Label></h4>
                        <h4>
                            Total: <asp:Label ID="LabelTotal" runat="server" Text="$0"></asp:Label></h4>
                    </div>

                    <div class="alert alert-warning">
                        <strong>Warning! </strong><asp:Label ID="LabelOutOfParts" runat="server" Text="None"></asp:Label>
                    </div>

                    <fieldset class="form-group">
                        <h4>Credit or Debit</h4>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios1" value="option1" checked>
                                Credit
                            </label>
                        </div>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios2" value="option2">
                                Debit
                            </label>
                        </div>
                       
                    </fieldset>

                    <asp:Button ID="ButtonSubmitAll" runat="server" Text="ConfirmAll" />
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Confirm Available Stock" />
                </div>
     
     <asp:HiddenField ID="HiddenFieldCartCusID" runat="server" />
    <asp:ObjectDataSource ID="ODS_CategoryList" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Category_ListAll" 
        TypeName="eBikesSystem.BLL.CategoryController">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_ListPart" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Part_ListBy" TypeName="eBikesSystem.BLL.CategoryController">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenFieldCatID" PropertyName="Value" DefaultValue="-1" Name="categoryID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_ListCartItems" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="List_SCI" TypeName="eBikesSystem.BLL.CartController">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenFieldCartCusID" PropertyName="Value" Name="cusID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>