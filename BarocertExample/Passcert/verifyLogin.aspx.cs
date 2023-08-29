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
using Barocert;
using Barocert.Example;


namespace Passcert.Example.Example
{
    public partial class verifyLogin : System.Web.UI.Page
    {

        public String code = null;
        public String message = null;
        public LoginResult result = null;


        /*
         * 완료된 전자서명을 검증하고 전자서명값(signedData)을 반환 받습니다.
         * 검증 함수는 간편로그인 요청 함수를 호출한 당일 23시 59분 59초까지만 호출 가능합니다.
         * 간편로그인 요청 함수를 호출한 당일 23시 59분 59초 이후 검증 함수를 호출할 경우 오류가 반환됩니다.
         * https://developers.barocert.com/reference/pass/dotnet/login/api#VerifyLogin
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 요청시 반환받은 접수아이디
            String receiptId = "02308280230700000140000000000004";

            // 검증 요청 정보
            LoginVerify loginVerify = new LoginVerify();
            // 간편로그인 검증 요청 휴대폰번호 - 11자 (하이픈 제외)
            loginVerify.receiverHP = Global.passcertService.encrypt("01012341234");
            // 간편로그인 검증 요청 성명 - 최대 80자
            loginVerify.receiverName = Global.passcertService.encrypt("홍길동");

            try
            {
                result = Global.passcertService.verifyLogin(clientCode, receiptId, loginVerify);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }

    }
}
