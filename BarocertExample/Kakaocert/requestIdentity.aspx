﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requestIdentity.aspx.cs" Inherits="Kakaocert.Example.Example.requestIdentity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>barocert SDK ASP.NET Example</title>
	<link href="../Example.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<div id="content">
	<p class="heading1">카카오 본인인증 요청 API SDK Example</p>
	<br/>
	<fieldset class="fieldset1">
		<legend>카카오 본인인증 요청</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>            
				<li>ReceiptID (접수아이디) : <%= result.receiptID%></li>
				<li>Scheme (앱스킴) :  <%= result.scheme %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>