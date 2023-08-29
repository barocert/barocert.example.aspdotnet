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
    public partial class getSignStatus : System.Web.UI.Page
    {
        public String code = null;
        public String message = null;
        public SignStatus result = null;


        /*
         * 전자서명 요청 후 반환받은 접수아이디로 인증 진행 상태를 확인합니다.
         * 상태확인 함수는 전자서명 요청 함수를 호출한 당일 23시 59분 59초까지만 호출 가능합니다.
         * 전자서명 요청 함수를 호출한 당일 23시 59분 59초 이후 상태확인 함수를 호출할 경우 오류가 반환됩니다.
         * https://developers.barocert.com/reference/pass/dotnet/sign/api#GetSignStatus
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 요청시 반환받은 접수아이디
            String receiptId = "02308280230700000140000000000002";

            try
            {
                result = Global.passcertService.getSignStatus(clientCode, receiptId);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
