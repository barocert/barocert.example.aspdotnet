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

namespace Kakaocert.Example.Example
{
    public partial class requestCMS : System.Web.UI.Page
    {

        public String code;
        public String message;
        public CMSReceipt result;

        /**
        * 카카오톡 사용자에게 자동이체 출금동의 전자서명을 요청합니다.
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023040000001";

            // 출금동의 요청 정보 객체
            CMS cms = new CMS();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            cms.receiverHP = Global.kakaocertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            cms.receiverName = Global.kakaocertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            cms.receiverBirthday= Global.kakaocertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            cms.reqTitle = "인증요청 메시지 제공란";

            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            cms.expireIn = 1000;

            // 청구기관명 - 최대 100자
            cms.requestCorp = Global.kakaocertService.encrypt("청구기관명란");
            // 출금은행명 - 최대 100자
            cms.bankName = Global.kakaocertService.encrypt("출금은행명란");
            // 출금계좌번호 - 최대 32자
            cms.bankAccountNum = Global.kakaocertService.encrypt("9-4324-5117-58");
            // 출금계좌 예금주명 - 최대 100자
            cms.bankAccountName = Global.kakaocertService.encrypt("예금주명 입력란");
            // 출금계좌 예금주 생년월일 - 8자
            cms.bankAccountBirthday = Global.kakaocertService.encrypt("19930112");
            // 출금유형
            // CMS - 출금동의용, FIRM - 펌뱅킹, GIRO - 지로용
            cms.bankServiceType = Global.kakaocertService.encrypt("CMS"); // CMS, FIRM, GIRO

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            cms.appUseYN = false;

            // App to App 방식 이용시, 에러시 호출할 URL
            cms.returnURL = "https://www.kakaocert.com";

            

            try
            {
                result = Global.kakaocertService.requestCMS(clientCode, cms);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
