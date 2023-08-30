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
    public partial class requestCMS : System.Web.UI.Page
    {

        public String code;
        public String message;
        public CMSReceipt result;

        /*
         * 패스 이용자에게 자동이체 출금동의를 요청합니다.
         * hhttps://developers.barocert.com/reference/pass/dotnet/cms/api#RequestCMS
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 출금동의 요청 정보 객체
            CMS cms = new CMS();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            cms.receiverHP = Global.passcertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            cms.receiverName = Global.passcertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            cms.receiverBirthday = Global.passcertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            cms.reqTitle = "패스써트 출금동의 인증요청 타이틀";
            // 요청 메시지 - 최대 500자
            cms.reqMessage = Global.passcertService.encrypt("패스써트 출금동의 인증요청 내용");
            // 고객센터 연락처 - 최대 12자
            cms.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            cms.expireIn = 1000;

            // 출금은행명 - 최대 100자
            cms.bankName = Global.passcertService.encrypt("국민은행");
            // 출금계좌번호 - 최대 32자
            cms.bankAccountNum = Global.passcertService.encrypt("9-****-5117-58");
            // 출금계좌 예금주명 - 최대 100자
            cms.bankAccountName = Global.passcertService.encrypt("홍길동");
            // 출금유형 
            // CMS - 출금동의, OPEN_BANK - 오픈뱅킹
            cms.bankServiceType = Global.passcertService.encrypt("CMS");
            // 출금액
            cms.bankWithdraw = Global.passcertService.encrypt("1,000,000원");

            // 사용자 동의 필요 여부
            cms.userAgreementYN = true;
            // 사용자 정보 포함 여부
            cms.receiverInfoYN = true;

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            cms.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 통신사 유형('SKT', 'KT', 'LGU'), 대문자 입력(대소문자 구분)
            // cms.telcoType = "SKT";
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // cms.deviceOSType = "IOS";

            try
            {
                result = Global.passcertService.requestCMS(clientCode, cms);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
