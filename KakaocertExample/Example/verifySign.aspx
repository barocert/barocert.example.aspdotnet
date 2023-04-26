﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verifySign.aspx.cs" Inherits="Barocert.Example.Example.verifySign" %>

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
		<legend>전자서명 서명검증</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>receiptID (접수아이디) : <%= result.receiptID%></li>
				<li>State (상태) : <%= result.state%></li>
                <li>signedData (전자서명 데이터 전문) : <%= result.signedData%></li>
				<li>Ci (연계정보) : <%= result.ci%></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>