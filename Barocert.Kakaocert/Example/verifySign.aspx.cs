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
     * 완료된 전자서명을 검증하고 전자서명값(signedData)을 반환 받습니다.
     * 카카오 보안정책에 따라 검증 API는 1회만 호출할 수 있습니다. 재시도시 오류가 반환됩니다.
     * 전자서명 완료일시로부터 10분 이후에 검증 API를 호출하면 오류가 반환됩니다.
     * https://developers.barocert.com/reference/kakao/dotnet/sign/api-single#VerifySign
     */
    public partial class verifySign : System.Web.UI.Page
    {
        
        public String code = null;
        public String message = null;
        public SignResult result = null;


        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023040000001";

            // 요청시 반환받은 접수아이디
            String receiptId = "02310300230400000010000000000002";

            try
            {
                result = Global.kakaocertService.verifySign(clientCode, receiptId);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }

    }
}
