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
    public partial class getMultiSignStatus : System.Web.UI.Page
    {
        public string code = null;
        public string message = null;
        public MultiSignStatus result = null;

        /*
         * 전자서명(복수) 요청 후 반환받은 접수아이디로 인증 진행 상태를 확인합니다.
         * https://developers.barocert.com/reference/naver/dotnet/sign/api-multi#GetMultiSignStatus
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // navercert 이용기관코드, navercert 파트너 사이트에서 확인
            string clientCode = "023090000021";

            // 요청시 반환받은 접수아이디
            string receiptID = "02312080230900000210000000000003";

            try
            {
                result = Global.navercertService.getMultiSignStatus(clientCode, receiptID);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
