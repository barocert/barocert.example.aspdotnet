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
    public partial class requestIdentity : System.Web.UI.Page
    {

        public String code;
        public String message;
        public IdentityReceipt result;

        /**
        * 네이버 이용자에게 본인인증을 요청합니다.
        * https://developers.barocert.com/reference/naver/dotnet/identity/api#RequestIdentity
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Navercert 이용기관코드, Navercert 파트너 사이트에서 확인
            String clientCode = "023090000021";

            // 본인인증 요청 정보 객체
            Identity identity = new Identity();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            identity.receiverHP = Global.navercertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            identity.receiverName = Global.navercertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            identity.receiverBirthday = Global.navercertService.encrypt("19700101");

            // 고객센터 연락처 - 최대 12자
            identity.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            identity.expireIn = 1000;

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            identity.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // identity.deviceOSType = "IOS";
            // ApptoApp 인증방식에서 사용
            // 호출할 URL
            // identity.returnURL = "navercert://sign";
            
            try
            {
                result = Global.navercertService.requestIdentity(clientCode, identity);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
