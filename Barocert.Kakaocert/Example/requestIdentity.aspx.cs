﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Barocert.Kakaocert.Example
{
    /*
     * 카카오톡 이용자에게 본인인증을 요청합니다.
     * https://developers.barocert.com/reference/kakao/dotnet/identity/api#RequestIdentity
     */
    public partial class requestIdentity : System.Web.UI.Page
    {

        public string code;
        public string message;
        public IdentityReceipt result;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            string clientCode = "023040000001";

            // 본인인증 요청 정보 객체
            Identity identity = new Identity();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            identity.receiverHP = Global.kakaocertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            identity.receiverName = Global.kakaocertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            identity.receiverBirthday = Global.kakaocertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            identity.reqTitle = "본인인증 요청 메시지 제목";
            // 커스텀 메시지 - 최대 500자
            identity.extraMessage = Global.kakaocertService.encrypt("본인인증 커스텀 메시지");
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            identity.expireIn = 1000;
            // 서명 원문 - 최대 40자 까지 입력가능
            identity.token = Global.kakaocertService.encrypt("본인인증 요청 원문");

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            identity.appUseYN = false;

            // App to App 방식 이용시, 호출할 URL
            identity.returnURL = "https://www.kakaocert.com";

            try
            {
                result = Global.kakaocertService.requestIdentity(clientCode, identity);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
