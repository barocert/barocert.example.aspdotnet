<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getIdentityStatus.aspx.cs" Inherits="Barocert.Passcert.Example.getIdentityStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Passcert SDK ASP.NET Example</title>
	<link href="../Example.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<div id="content">
	<p class="heading1">Response</p>
	<br/>
	<fieldset class="fieldset1">
		<legend>패스 본인인증 상태확인</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>ClientCode (이용기관 코드) : <%=result.clientCode %></li>
				<li>ReceiptID (접수 아이디) : <%=result.receiptID %></li>
				<li>State (상태) : <%=result.state %></li>
				<li>RequestDT (서명요청일시) : <%=result.requestDT %></li>
				<li>CompleteDT (서명완료일시) : <%=result.completeDT %></li>
				<li>ExpireDT (서명만료일시) : <%=result.expireDT %></li>
				<li>RejectDT (서명거절일시) : <%=result.rejectDT %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>
