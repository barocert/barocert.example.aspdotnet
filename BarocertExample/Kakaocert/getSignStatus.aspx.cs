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
    public partial class getSignStatus : System.Web.UI.Page
    {
        public String code = null;
        public String message = null;
        public SignStatus result = null;


        /**
        * 전자서명 요청시 반환된 접수아이디를 통해 서명 상태를 확인합니다. (단건)
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023030000004";

            // 요청시 반환받은 접수아이디
            String receiptId = "02304270230300000040000000000003";

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
