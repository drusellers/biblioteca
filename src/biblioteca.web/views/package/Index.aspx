﻿<%@ Page Inherits="biblioteca.web.views.HomeIndexView" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.RenderPartial().Using<PackageInfo>().WithoutListWrapper().WithoutItemWrapper().ForEachOf(Model.Packages) %>
</asp:Content>