﻿using System;
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
    public partial class verifyIdentity : System.Web.UI.Page
    {
        public String code = null;
        public String message = null;
        public IdentityResult result = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 본인인증 요청시 반환된 접수아이디를 통해 본인인증 서명을 검증합니다. 
             * 검증하기 API는 완료된 전자서명 요청당 1회만 요청 가능하며, 사용자가 서명을 완료후 유효시간(10분)이내에만 요청가능 합니다.
             * https://developers.barocert.com/reference/kakao/java/identity/api#VerifyIdentity
             */

            // Kakaocert 이용기관코드, Kakaocert 파트너 사이트에서 확인
            String clientCode = "023030000004";

            // 요청시 반환받은 접수아이디
            String receiptId = "02304270230300000040000000000001";

            try
            {
                result = Global.kakaocertService.verifyIdentity(clientCode, receiptId);
            }
            catch (BarocertException ex)
            {
                code = ex.code.ToString();
                message = ex.Message;
            }
        }
    }
}
