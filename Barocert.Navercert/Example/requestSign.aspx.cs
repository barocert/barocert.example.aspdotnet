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
    public partial class requestSign : System.Web.UI.Page
    {
        public String code;
        public String message;
        public SignReceipt result;

        /*
         * 네이버 이용자에게 단건(1건) 문서의 전자서명을 요청합니다.
         * https://developers.barocert.com/reference/naver/dotnet/sign/api-single#RequestSign
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // Navercert 이용기관코드, Navercert 파트너 사이트에서 확인
            String clientCode = "023090000021";

            // 전자서명 요청 정보 객체
            Sign sign = new Sign();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            sign.receiverHP = Global.navercertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            sign.receiverName = Global.navercertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            sign.receiverBirthday = Global.navercertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            sign.reqTitle = "전자서명(단건) 요청 메시지 제목";
            // 고객센터 연락처
            sign.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            sign.expireIn = 1000;
            // 전자서명 요청 메시지
            sign.reqMessage = Global.navercertService.encrypt("전자서명(단건) 요청 메시지 내용");
            // 서명 원문 - 원문 2,800자 까지 입력가능
            sign.token = Global.navercertService.encrypt("전자서명테스트데이터");
            // 서명 원문 유형
            // 'TEXT' - 일반 텍스트, 'HASH' - HASH 데이터
            sign.tokenType = "TEXT";

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            sign.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // sign.deviceOSType = "IOS";
            // ApptoApp 인증방식에서 사용
            // 에러시 호출할 URL
            // sign.returnURL = "navercert://sign";

            try
            {
                result = Global.navercertService.requestSign(clientCode, sign);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
