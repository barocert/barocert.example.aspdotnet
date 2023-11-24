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

namespace Barocert.Kakaocert.Example
{
    /*
     * 카카오톡 이용자에게 복수(최대 20건) 문서의 전자서명을 요청합니다.
     * https://developers.barocert.com/reference/kakao/dotnet/sign/api-multi#RequestMultiSign
     */
    public partial class requestMultiSign : System.Web.UI.Page
    {
        public string code;
        public string message;
        public MultiSignReceipt result;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            string clientCode = "023040000001";

            // 전자서명 요청 정보 객체
            MultiSign multiSign = new MultiSign();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            multiSign.receiverHP = Global.kakaocertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            multiSign.receiverName = Global.kakaocertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            multiSign.receiverBirthday = Global.kakaocertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            multiSign.reqTitle = "전자서명(복수) 요청 메시지 제목";
            // 상세 설명 - 최대 500자
            multiSign.extraMessage = "전자서명(복수) 상세 설명";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            multiSign.expireIn = 1000;

            // 개별문서 등록 - 최대 20 건
            // 개별 요청 정보 객체
            MultiSignTokens token = new MultiSignTokens();
            // 인증요청 메시지 제목 - 최대 40자
            token.signTitle = "전자서명(복수) 서명 요청 제목 1";
            // 서명 원문 - 원문 2,800자 까지 입력가능
            token.token = Global.kakaocertService.encrypt("전자서명(복수) 요청 원문 1");
            multiSign.addToken(token);

            // 개별 요청 정보 객체
            MultiSignTokens token2 = new MultiSignTokens();
            // 인증요청 메시지 제목 - 최대 40자
            token2.signTitle = "전자서명(복수) 서명 요청 제목 2";
            // 서명 원문 - 원문 2,800자 까지 입력가능
            token2.token = Global.kakaocertService.encrypt("전자서명(복수) 요청 원문 2");
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
