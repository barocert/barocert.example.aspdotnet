<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requestCMS.aspx.cs" Inherits="Barocert.Navercert.Example.requestCMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Navercert SDK ASP.NET Example</title>
	<link href="../Example.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<div id="content">
	<p class="heading1">Response</p>
	<br/>
	<fieldset class="fieldset1">
		<legend>네이버 출금동의 요청</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>            
				<li>ReceiptID (접수아이디) : <%= result.receiptID%></li>
				<li>Scheme (앱스킴) :  <%= result.scheme %></li>
				<li>MarketURL (앱다운로드URL) :  <%= result.marketUrl %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>