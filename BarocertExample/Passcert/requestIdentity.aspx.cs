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
using Barocert;
using Barocert.Example;


namespace Passcert.Example.Example
{
    public partial class requestIdentity : System.Web.UI.Page
    {

        public String code;
        public String message;
        public IdentityReceipt result;

        /**
        * 패스 이용자에게 본인인증을 요청합니다.
        * https://developers.barocert.com/reference/pass/dotnet/identity/api#RequestIdentity
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 본인인증 요청 정보 객체
            Identity identity = new Identity();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            identity.receiverHP = Global.passcertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            identity.receiverName = Global.passcertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            identity.receiverBirthday = Global.passcertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            identity.reqTitle = "패스써트 본인인증 인증요청 타이틀";
            // 요청 메시지 - 최대 500자
            identity.reqMessage = Global.passcertService.encrypt("패스써트 본인인증 인증요청 내용");
            // 고객센터 연락처 - 최대 12자
            identity.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            identity.expireIn = 1000;
            // 서명 원문 - 최대 40자 까지 입력가능
            identity.token = Global.passcertService.encrypt("패스써트 본인인증 요청토큰");

            // 사용자 동의 필요 여부
            identity.userAgreementYN = true;
            // 사용자 정보 포함 여부
            identity.receiverInfoYN = true;

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            identity.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 통신사 유형('SKT', 'KT', 'LGU'), 대문자 입력(대소문자 구분)
            // identity.telcoType = "SKT";
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // identity.deviceOSType = "IOS";

            try
            {
                result = Global.passcertService.requestIdentity(clientCode, identity);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
