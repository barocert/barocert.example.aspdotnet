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
    public partial class verifyIdentity : System.Web.UI.Page
    {
        public string code = null;
        public string message = null;
        public IdentityResult result = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 완료된 전자서명을 검증하고 전자서명값(signedData)을 반환 받습니다.
             * 반환받은 전자서명값(signedData)과 [1. RequestIdentity] 함수 호출에 입력한 Token의 동일 여부를 확인하여 이용자의 본인인증 검증을 완료합니다.
             * 네이버 보안정책에 따라 검증 API는 1회만 호출할 수 있습니다. 재시도시 오류가 반환됩니다.
             * https://developers.barocert.com/reference/naver/dotnet/identity/api#VerifyIdentity
             */

            // Navercert 이용기관코드, Navercert 파트너 사이트에서 확인
            string clientCode = "023090000021";

            // 요청시 반환받은 접수아이디
            string receiptID = "02312080230900000210000000000001";

            try
            {
                result = Global.navercertService.verifyIdentity(clientCode, receiptID);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
