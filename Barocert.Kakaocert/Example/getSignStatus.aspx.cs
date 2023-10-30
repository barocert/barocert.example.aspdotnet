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
     * 전자서명(단건) 요청 후 반환받은 접수아이디로 인증 진행 상태를 확인합니다.
     * https://developers.barocert.com/reference/kakao/dotnet/sign/api-single#GetSignStatus
     */
    public partial class getSignStatus : System.Web.UI.Page
    {
        public String code = null;
        public String message = null;
        public SignStatus result = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023040000001";

            // 요청시 반환받은 접수아이디
            String receiptId = "02310300230400000010000000000002";

            try
            {
                result = Global.kakaocertService.getSignStatus(clientCode, receiptId);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
