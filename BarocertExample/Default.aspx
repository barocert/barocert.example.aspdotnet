<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BarocertExample._Default" %>

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
		<legend>카카오 본인인증 API</legend>
		<ul>
			<li><a href="Kakaocert/requestIdentity.aspx">requestIdentity</a> - 본인인증 요청</li>
			<li><a href="Kakaocert/getIdentityStatus.aspx">getIdentityStatus</a> - 본인인증 서명상태 확인</li>
			<li><a href="Kakaocert/verifyIdentity.aspx">verifyIdentity</a> - 본인인증 서명검증</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>카카오 전자서명 API</legend>
		<ul>
			<li><a href="Kakaocert/requestSign.aspx">requestSign</a> - 전자서명 요청(단건)</li>
			<li><a href="Kakaocert/getSignStatus.aspx">getSignState</a> - 전자서명 서명상태 확인(단건)</li>
			<li><a href="Kakaocert/verifySign.aspx">verifySign</a> - 전자서명 서명검증(단건)</li>
			<li><a href="Kakaocert/requestMultiSign.aspx">requestMultiSign</a> - 전자서명 요청(복수)</li>
			<li><a href="Kakaocert/getMultiSignStatus.aspx">getMultiSignState</a> - 전자서명 서명상태 확인(복수)</li>
			<li><a href="Kakaocert/verifyMultiSign.aspx">verifyMultiSign</a> - 전자서명 서명검증(복수)</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>카카오 자동이체 출금동의 API</legend>
		<ul>
			<li><a href="Kakaocert/requestCMS.aspx">requestCMS</a> - 자동이체 출금동의 요청</li>
			<li><a href="Kakaocert/getCMSStatus.aspx">getCMSState</a> - 자동이체 출금동의 서명상태 확인</li>
			<li><a href="Kakaocert/verifyCMS.aspx">verifyCMS</a> - 자동이체 출금동의 서명검증</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>카카오 간편로그인 API</legend>
		<ul>
			<li><a href="Kakaocert/verifyLogin.aspx">verifyLogin</a> - 간편로그인 서명검증</li>
		</ul>
	</fieldset>
	
	
	<br/>
	<fieldset class="fieldset1">
		<legend>패스 본인인증 API</legend>
		<ul>
			<li><a href="Passcert/requestIdentity.aspx">requestIdentity</a> - 본인인증 요청</li>
			<li><a href="Passcert/getIdentityStatus.aspx">getIdentityStatus</a> - 본인인증 서명상태 확인</li>
			<li><a href="Passcert/verifyIdentity.aspx">verifyIdentity</a> - 본인인증 서명검증</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>패스 전자서명 API</legend>
		<ul>
			<li><a href="Passcert/requestSign.aspx">requestSign</a> - 전자서명 요청</li>
			<li><a href="Passcert/getSignStatus.aspx">getSignState</a> - 전자서명 서명상태 확인</li>
			<li><a href="Passcert/verifySign.aspx">verifySign</a> - 전자서명 서명검증</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>패스 자동이체 출금동의 API</legend>
		<ul>
			<li><a href="Passcert/requestCMS.aspx">requestCMS</a> - 자동이체 출금동의 요청</li>
			<li><a href="Passcert/getCMSStatus.aspx">getCMSState</a> - 자동이체 출금동의 서명상태 확인</li>
			<li><a href="Passcert/verifyCMS.aspx">verifyCMS</a> - 자동이체 출금동의 서명검증</li>
		</ul>
	</fieldset>
	<br/>
	<fieldset class="fieldset1">
		<legend>패스 간편로그인 API</legend>
		<ul>
			<li><a href="Passcert/requestLogin.aspx">requestLogin</a> - 간편로그인 요청</li>
			<li><a href="Passcert/getLoginStatus.aspx">getLoginState</a> - 간편로그인 서명상태 확인</li>
			<li><a href="Passcert/verifyLogin.aspx">verifyLogin</a> - 간편로그인 서명검증</li>
		</ul>
	</fieldset>
</div>
</body>
</html>
