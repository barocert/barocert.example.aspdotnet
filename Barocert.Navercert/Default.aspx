<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Barocert.Navercert._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title>Barocert API SDK ASP.NET Example</title>
	<link href="./Example.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="content">
	<p class="heading1">Barocert SDK ASP.NET Example.</p>
	<br/>
	<fieldset class="fieldset1">
		<legend>네이버 본인인증 API</legend>
		<ul>
			<li><a href="Example/requestIdentity.aspx">requestIdentity</a> - 본인인증 요청</li>
			<li><a href="Example/getIdentityStatus.aspx">getIdentityStatus</a> - 본인인증 서명상태 확인</li>
			<li><a href="Example/verifyIdentity.aspx">verifyIdentity</a> - 본인인증 서명검증</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>네이버 전자서명 API</legend>
		<ul>
			<li><a href="Example/requestSign.aspx">requestSign</a> - 전자서명 요청(단건)</li>
			<li><a href="Example/getSignStatus.aspx">getSignState</a> - 전자서명 서명상태 확인(단건)</li>
			<li><a href="Example/verifySign.aspx">verifySign</a> - 전자서명 서명검증(단건)</li>
			<li><a href="Example/requestMultiSign.aspx">requestMultiSign</a> - 전자서명 요청(복수)</li>
			<li><a href="Example/getMultiSignStatus.aspx">getMultiSignState</a> - 전자서명 서명상태 확인(복수)</li>
			<li><a href="Example/verifyMultiSign.aspx">verifyMultiSign</a> - 전자서명 서명검증(복수)</li>
		</ul>
	</fieldset>
</div>
</body>
</html>
