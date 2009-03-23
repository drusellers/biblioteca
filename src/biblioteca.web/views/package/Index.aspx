<%@ Import Namespace="biblioteca.web.views"%>
<%@ Page Inherits="biblioteca.web.views.HomeIndexView" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <div>
         <%= this.RenderPartial().Using<PackageInfo>().ForEachOf(Model.Packages) %>
    </div>
</div>
</asp:Content>