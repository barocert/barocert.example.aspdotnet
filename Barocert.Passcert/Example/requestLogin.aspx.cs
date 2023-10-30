using System;
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

namespace Barocert.Passcert.Example
{
    public partial class requestLogin : System.Web.UI.Page
    {
        public String code;
        public String message;
        public LoginReceipt result;

        /*
         * 패스 이용자에게 간편로그인을 요청합니다.
         * https://developers.barocert.com/reference/pass/dotnet/login/api#RequestLogin
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 간편로그인 요청 정보 객체
            Login login = new Login();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            login.receiverHP = Global.passcertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            login.receiverName = Global.passcertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            login.receiverBirthday = Global.passcertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            login.reqTitle = "간편로그인 요청 메시지 제목";
            // 요청 메시지 - 최대 500자
            login.reqMessage = Global.passcertService.encrypt("간편로그인 요청 메시지 내용");
            // 고객센터 연락처 - 최대 12자
            login.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            login.expireIn = 1000;
            // 서명 원문 - 최대 40자 까지 입력가능
            login.token = Global.passcertService.encrypt("간편로그인 요청 원문");

            // 사용자 동의 필요 여부
            login.userAgreementYN = true;
            // 사용자 정보 포함 여부
            login.receiverInfoYN = true;

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            login.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 통신사 유형('SKT', 'KT', 'LGU'), 대문자 입력(대소문자 구분)
            // login.telcoType = "SKT";
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // login.deviceOSType = "IOS";

            try
            {
                result = Global.passcertService.requestLogin(clientCode, login);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
