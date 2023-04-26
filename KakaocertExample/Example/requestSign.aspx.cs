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
    public partial class requestSign : System.Web.UI.Page
    {
        public String code;
        public String message;
        public SignReceipt result;

        /**
        * 카카오톡 사용자에게 전자서명을 요청합니다.(단건)
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023030000004";

            // 전자서명 요청 정보 객체
            Sign sign = new Sign();

            // 수신자 정보
            // 휴대폰번호,성명,생년월일 또는 Ci(연계정보)값 중 택 일
            sign.receiverHP = Global.kakaocertService.encrypt("01012341234");
            sign.receiverName = Global.kakaocertService.encrypt("홍길동");
            sign.receiverBirthday = Global.kakaocertService.encrypt("19700101");
            // sign.ci =kakaocertService.encrypt("");

            // 인증요청 메시지 제목 - 최대 40자
            sign.reqTitle = "전자서명단건테스트";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            sign.expireIn =1000;
            // 서명 원문 - 원문 2,800자 까지 입력가능
            sign.token = Global.kakaocertService.encrypt("전자서명단건테스트데이터");
            // 서명 원문 유형
            // TEXT - 일반 텍스트, HASH - HASH 데이터
            sign.tokenType = "TEXT";

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            sign.appUseYN = false;

            // App to App 방식 이용시, 호출할 URL
            // sign.returnURL "https://www.kakaocert.com";

            try
            {
                result = Global.kakaocertService.requestSign(clientCode, sign);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
