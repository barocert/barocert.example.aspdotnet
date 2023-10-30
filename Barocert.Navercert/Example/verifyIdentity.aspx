<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verifyIdentity.aspx.cs" Inherits="Barocert.Navercert.Example.verifyIdentity" %>

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
		<legend>네이버 본인인증 검증</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>ReceiptID (접수아이디) : <%= result.receiptID%></li>
				<li>State (상태) : <%= result.state%></li>
				<li>SignedData (전자서명 데이터 전문) : <%= result.signedData%></li>
				<li>Ci (연계정보) : <%= result.ci%></li>
				<li>ReceiverName (수신자 성명) : <%=result.receiverName%></li>
				<li>ReceiverYear (수신자 출생년도) : <%=result.receiverYear%></li>
				<li>ReceiverDay (수신자 출생월일) : <%=result.receiverDay%></li>
				<li>ReceiverHP (수신자 휴대폰번호) : <%=result.receiverHP%></li>
				<li>ReceiverGender (수신자 성별) : <%=result.receiverGender%></li>
				<li>ReceiverEmail (수신자 이메일) : <%=result.receiverEmail%></li>
				<li>ReceiverForeign (외국인 여부) : <%=result.receiverForeign%></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>