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
    public partial class requestSign : System.Web.UI.Page
    {
        public String code;
        public String message;
        public SignReceipt result;

        /*
         * 패스 이용자에게 문서의 전자서명을 요청합니다.
         * https://developers.barocert.com/reference/pass/dotnet/sign/api#RequestSign
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 전자서명 요청 정보 객체
            Sign sign = new Sign();

            // 수신자 휴대폰번호 - 11자 (하이픈 제외)
            sign.receiverHP = Global.passcertService.encrypt("01012341234");
            // 수신자 성명 - 80자
            sign.receiverName = Global.passcertService.encrypt("홍길동");
            // 수신자 생년월일 - 8자 (yyyyMMdd)
            sign.receiverBirthday = Global.passcertService.encrypt("19700101");

            // 인증요청 메시지 제목 - 최대 40자
            sign.reqTitle = "패스써트 전자서명 인증요청 타이틀";
            // 전자서명 요청 메시지
            sign.reqMessage = Global.passcertService.encrypt("패스써트 전자서명 인증요청 내용");
            // 고객센터 연락처
            sign.callCenterNum = "1600-9854";
            // 인증요청 만료시간 - 최대 1,000(초)까지 입력 가능
            sign.expireIn = 1000;
            // 서명 원문 - 원문 2,800자 까지 입력가능
            sign.token = Global.passcertService.encrypt("전자서명테스트데이터");
            // 서명 원문 유형
            // 'TEXT' - 일반 텍스트, 'HASH' - HASH 데이터, 'URL' - URL 데이터
            // 원본데이터(originalTypeCode, originalURL, originalFormatCode) 입력시 'TEXT'사용 불가
            sign.tokenType = Global.passcertService.encrypt("URL");

            // 사용자 동의 필요 여부
            sign.userAgreementYN = true;
            // 사용자 정보 포함 여부
            sign.receiverInfoYN = true;

            // 원본유형코드
            // 'AG' - 동의서, 'AP' - 신청서, 'CT' - 계약서, 'GD' - 안내서, 'NT' - 통지서, 'TR' - 약관
            sign.originalTypeCode = "TR";
            // 원본조회URL
            sign.originalURL = "https://www.passcert.co.kr";
            // 원본형태코드
            // 'TEXT', 'HTML', 'DOWNLOAD_IMAGE', 'DOWNLOAD_DOCUMENT'
            sign.originalFormatCode = "HTML";

            // AppToApp 인증요청 여부
            // true - AppToApp 인증방식, false - Talk Message 인증방식
            sign.appUseYN = false;
            // ApptoApp 인증방식에서 사용
            // 통신사 유형('SKT', 'KT', 'LGU'), 대문자 입력(대소문자 구분)
            // sign.telcoType = "SKT";
            // ApptoApp 인증방식에서 사용
            // 모바일장비 유형('ANDROID', 'IOS'), 대문자 입력(대소문자 구분)
            // sign.deviceOSType = "IOS";

            try
            {
                result = Global.passcertService.requestSign(clientCode, sign);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
