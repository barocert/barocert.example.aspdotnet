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
    public partial class requestMultiSign : System.Web.UI.Page
    {
        public string code;
        public string message;
        public MultiSignReceipt result;

        /*
         * 네이버 이용자에게 복수(최대 50건) 문서의 전자서명을 요청합니다.
         * https://developers.barocert.com/reference/naver/java/sign/api-multi#RequestMultiSign
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Navercert 이용기관코드, Navercert 파트너 사이트에서 확인
            string clientCode = "023090000021";

            // 전자서명(복수) 요청 정보 객체
            MultiSign multiSign = new MultiSign();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            multiSign.receiverHP = Global.navercertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            multiSign.receiverName = Global.navercertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            multiSign.receiverBirthday = Global.navercertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            multiSign.reqTitle = "전자서명(복수) 요청 메시지 제목";
            // 고객센터 연락처 - 최대 12자
            multiSign.callCenterNum = "1600-9854";
            // 요청 메시지 - 최대 500자
            multiSign.reqMessage = Global.navercertService.encrypt("전자서명(복수) 요청 메시지 내용");
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            multiSign.expireIn = 1000;
            
            // 개별문서 등록 - 최대 50건
            // 개별 요청 정보 객체
            MultiSignTokens token = new MultiSignTokens();
            // 서명 원문 유형
            // TEXT - 일반 텍스트, HASH - HASH 데이터
            token.tokenType = "TEXT";
            // 서명 원문 - 최대 2,800자까지 입력가능
            token.token = Global.navercertService.encrypt("전자서명(복수) 요청 원문 1");
            // 서명 원문 유형
            // token.tokenType = "HASH";
            // 서명 원문 유형이 HASH인 경우, 원문은 SHA-256, Base64 URL Safe No Padding을 사용
            // token.token = Global.navercertService.encrypt(Global.navercertService.sha256_base64url("전자서명(복수) 요청 원문 1"));
            multiSign.addToken(token);

            // 개별문서 등록 - 최대 50건
            // 개별 요청 정보 객체
            MultiSignTokens token2 = new MultiSignTokens();
            // 서명 원문 유형
            // TEXT - 일반 텍스트, HASH - HASH 데이터
            token2.tokenType = "TEXT";
            // 서명 원문 - 최대 2,800자까지 입력가능
            token2.token = Global.navercertService.encrypt("전자서명(복수) 요청 원문 2");
            // 서명 원문 유형
            // token2.tokenType = "HASH";
            // 서명 원문 유형이 HASH인 경우, 원문은 SHA-256, Base64 URL Safe No Padding을 사용
            // token2.token = Global.navercertService.encrypt(Global.navercertService.sha256_base64url("전자서명(복수) 요청 원문 2"));
            multiSign.addToken(token2);

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - 푸시(Push) 인증방식
            multiSign.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // multiSign.deviceOSType = "IOS";
            // AppToApp 방식 이용시, 호출할 URL
            // "http", "https"등의 웹프로토콜 사용 불가
            // multiSign.returnURL = "navercert://sign";
            
            try
            {
                result = Global.navercertService.requestMultiSign(clientCode, multiSign);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
