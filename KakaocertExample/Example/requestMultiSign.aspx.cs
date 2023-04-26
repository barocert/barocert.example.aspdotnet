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

namespace Barocert.Example.Example
{
    public partial class requestMultiSign : System.Web.UI.Page
    {
        public String code;
        public String message;
        public MultiSignReceipt result;

        /**
        * 카카오톡 사용자에게 전자서명을 요청합니다.(복수)
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023030000004";

            // 전자서명 요청 정보 객체
            MultiSign multiSign = new MultiSign();

            // 수신자 정보
            // 휴대폰번호,성명,생년월일 또는 Ci(연계정보)값 중 택 일
            multiSign.receiverHP = Global.kakaocertService.encrypt("01054437896");
            multiSign.receiverName = Global.kakaocertService.encrypt("최상혁");
            multiSign.receiverBirthday = Global.kakaocertService.encrypt("19880301");
            // multiSign.ci = Global.kakaocertService.encrypt("");

            // 인증요청 메시지 제목 - 최대 40자
            multiSign.reqTitle = "전자서명복수테스트";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            multiSign.expireIn = 1000;

            // 개별문서 등록 - 최대 20 건
            // 개별 요청 정보 객체
            MultiSignTokens token = new MultiSignTokens();
            // 인증요청 메시지 제목 - 최대 40자
            token.reqTitle = "전자서명복수문서테스트1";
            // 서명 원문 - 원문 2,800자 까지 입력가능
            token.token = Global.kakaocertService.encrypt("전자서명복수테스트데이터1");
            multiSign.addToken(token);

            // 개별 요청 정보 객체
            MultiSignTokens token2 = new MultiSignTokens();
            // 인증요청 메시지 제목 - 최대 40자
            token2.reqTitle = "전자서명복수문서테스트2";
            // 서명 원문 - 원문 2,800자 까지 입력가능
            token2.token = Global.kakaocertService.encrypt("전자서명복수테스트데이터2");
            multiSign.addToken(token2);

            // 서명 원문 유형
            // TEXT - 일반 텍스트, HASH - HASH 데이터
            multiSign.tokenType = "TEXT";

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            multiSign.appUseYN = false;

            // App to App 방식 이용시, 에러시 호출할 URL
            // multiSign.returnURL = "https://www.kakaocert.com";

            try
            {
                result = Global.kakaocertService.requestMultiSign(clientCode, multiSign);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
