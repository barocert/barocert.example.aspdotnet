﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requestCMS.aspx.cs" Inherits="Kakaocert.Example.Example.requestCMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Kakaocert SDK ASP.NET Example</title>
	<link href="../Example.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<div id="content">
	<p class="heading1">Response</p>
	<br/>
	<fieldset class="fieldset1">
		<legend>카카오 자동이체 출금동의 요청</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>ReceiptId (접수아이디) : <%= result.receiptID%></li>
				<li>Scheme (앱스킴) :  <%= result.scheme %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>