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

namespace Barocert.Navercert.Example
{
    public partial class requestCMS : System.Web.UI.Page
    {

        public string code;
        public string message;
        public CMSReceipt result;

        /*
         * 네이버 이용자에게 자동이체 출금동의를 요청합니다.
         * https://developers.barocert.com/reference/naver/dotnet/cms/api#RequestCMS
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Navercert 이용기관코드, Navercert 파트너 사이트에서 확인
            string clientCode = "023090000021";

            // 출금동의 요청 정보 객체
            CMS cms= new CMS();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            cms.receiverHP = Global.navercertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            cms.receiverName = Global.navercertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            cms.receiverBirthday = Global.navercertService.encrypt("19700101");

            // 인증요청 메시지 제목
            cms.reqTitle = "출금동의 요청 메시지 제목";
            // 인증요청 메시지
            cms.reqMessage = Global.navercertService.encrypt("출금동의 요청 메시지");
            // 고객센터 연락처 - 최대 12자
            cms.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            cms.expireIn = 1000;

            // 청구기관명
            cms.requestCorp = Global.navercertService.encrypt("청구기관");
            // 출금은행명
            cms.bankName = Global.navercertService.encrypt("출금은행");
            // 출금계좌번호
            cms.bankAccountNum = Global.navercertService.encrypt("123-456-7890");
            // 출금계좌 예금주명
            cms.bankAccountName = Global.navercertService.encrypt("홍길동");
            // 출금계좌 예금주 생년월일
            cms.bankAccountBirthday = Global.navercertService.encrypt("19700101");

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            cms.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // cms.deviceOSType = "IOS";
            // AppToApp 방식 이용시, 호출할 URL
            // "http", "https"등의 웹프로토콜 사용 불가
            // cms.returnURL = "navercert://cms";
            
            try
            {
                result = Global.navercertService.requestCMS(clientCode, cms);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
