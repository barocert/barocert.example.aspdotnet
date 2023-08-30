<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getSignStatus.aspx.cs" Inherits="Barocert.Kakaocert.Example.getSignStatus" %>

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
		<legend>카카오 전자서명(단건) 상태확인</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>ReceiptID (접수 아이디) : <%=result.receiptID %></li>
				<li>ClientCode (이용기관 코드) : <%=result.clientCode %></li>
				<li>State (상태코드) : <%=result.state %></li>
				<li>ExpireIn (요청 만료시간) : <%=result.expireIn %></li>
				<li>CallCenterName (이용기관 명) : <%=result.callCenterName %></li>
				<li>CallCenterNum (이용기관 연락처) : <%=result.callCenterNum %></li>
				<li>ReqTitle (인증요청 메시지 제목) : <%=result.reqTitle %></li>
				<li>AuthCategory (인증분류) : <%=result.authCategory %></li>
				<li>ReturnURL (복귀 URL) : <%=result.returnURL %></li>
				<li>TokenType (원문 구분) : <%=result.tokenType %></li>
				<li>RequestDT (서명요청일시) : <%=result.requestDT %></li>
				<li>ViewDT (서명조회일시) : <%=result.viewDT %></li>
				<li>CompleteDT (서명완료일시) : <%=result.completeDT %></li>
				<li>ExpireDT (서명만료일시) : <%=result.expireDT %></li>
				<li>VerifyDT (서명검증일시) : <%=result.verifyDT %></li>
				<li>Scheme (앱스킴) : <%=result.scheme %></li>
				<li>AppUseYN (앱사용유무) : <%=result.appUseYN %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>
