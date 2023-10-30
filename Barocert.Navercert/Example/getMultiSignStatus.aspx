<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getMultiSignStatus.aspx.cs" Inherits="Barocert.Navercert.Example.getMultiSignStatus" %>

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
		<legend>네이버 전자서명(복수) 상태확인</legend>
		<ul>
			<% if (!String.IsNullOrEmpty(code)) { %>
				<li>Response.code : <%= code %> </li>
				<li>Response.message : <%= message %></li>
			<% } else { %>
				<li>ClientCode (이용기관 코드) : <%=result.clientCode %></li>
				<li>ReceiptID (접수 아이디) : <%=result.receiptID %></li>
				<li>State (상태코드) : <%=result.state %></li>
				<li>ExpireIn (요청 만료시간) : <%=result.expireIn %></li>
				<li>CallCenterName (이용기관 명) : <%=result.callCenterName %></li>
				<li>CallCenterNum (이용기관 연락처) : <%=result.callCenterNum %></li>
				<li>ReqTitle (인증요청 메시지 제목) : <%=result.reqTitle %></li>
				<li>ReturnURL (복귀 URL) : <%=result.returnURL %></li>
				<% foreach (String tokenType in result.tokenTypes)
					{ %>
						<li>TokenType (원문 유형) : <%=tokenType%></li>
				<% } %>
				<li>DeviceOSType (모바일장비 유형) : <%=result.deviceOSType %></li>
				<li>ExpireDT (서명만료일시) : <%=result.expireDT %></li>
				<li>Scheme (앱스킴) : <%=result.scheme %></li>
				<li>AppUseYN (앱사용유무) : <%=result.appUseYN %></li>
			<% } %>
		</ul>
	</fieldset>
</div>
</body>
</html>
