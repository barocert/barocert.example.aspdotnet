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
    public partial class verifyCMS : System.Web.UI.Page
    {
        public String code = null;
        public String message = null;
        public CMSResult result = null;

        /*
         * 완료된 전자서명을 검증하고 전자서명값(signedData)을 반환 받습니다.
         * 검증 함수는 자동이체 출금동의 요청 함수를 호출한 당일 23시 59분 59초까지만 호출 가능합니다.
         * 자동이체 출금동의 요청 함수를 호출한 당일 23시 59분 59초 이후 검증 함수를 호출할 경우 오류가 반환됩니다.
         * https://developers.barocert.com/reference/pass/dotnet/cms/api#VerifyCMS
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // Passcert 이용기관코드, Passcert 파트너 사이트에서 확인
            String clientCode = "023070000014";

            // 요청시 반환받은 접수아이디
            String receiptId = "02310300230700000140000000000010";

            // 출금동의 검증 요청 정보
            CMSVerify cmsVerify = new CMSVerify();
            // 출금동의 검증 요청자 휴대폰번호 - 11자 (하이픈 제외)
            cmsVerify.receiverHP = Global.passcertService.encrypt("01012341234");
            // 출금동의 검증 요청자 성명 - 최대 80자
            cmsVerify.receiverName = Global.passcertService.encrypt("홍길동");

            try
            {
                result = Global.passcertService.verifyCMS(clientCode, receiptId, cmsVerify);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
