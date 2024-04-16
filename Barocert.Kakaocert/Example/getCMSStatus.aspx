<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getCMSStatus.aspx.cs" Inherits="Barocert.Kakaocert.Example.getCMSStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Barocert ASP.NET Example</title>
	<link href="../Example.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<div id="content">
	<p class="heading1">Response</p>
	<br/>
	<fieldset class="fieldset1">
		<legend>카카오 자동이체 출금동의 상태확인</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>ReceiptID (접수 아이디) : <%=result.receiptID %></li>
				<li>ClientCode (이용기관 코드) : <%=result.clientCode %></li>
				<li>State (상태) : <%=result.state %></li>
				<li>RequestDT (서명요청일시) : <%=result.requestDT %></li>
				<li>ViewDT (서명조회일시) : <%=result.viewDT %></li>
				<li>CompleteDT (서명완료일시) : <%=result.completeDT %></li>
				<li>ExpireDT (서명만료일시) : <%=result.expireDT %></li>
				<li>VerifyDT (서명검증일시) : <%=result.verifyDT %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>
