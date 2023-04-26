using Kakaocert;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace Kakaocert.Example
{
    public class Global : System.Web.HttpApplication
    {
        // 링크아이디
        private string LinkID = "LINKHUB_BC";

        // 비밀키
        private string SecretKey = "npCAl0sHPpJqlvMbrcBmNagrxkQ74w9Sl0A+M++kMCE=";

        // kakaocert 서비스 객체 선언
        public static KakaocertService kakaocertService;

        protected void Application_Start(object sender, EventArgs e)
        {
            // kakaocert 서비스 객체 초기화
            kakaocertService = new KakaocertService(LinkID, SecretKey);

            // 인증토큰 IP 제한기능 사용여부, 권장(true)
            kakaocertService.IPRestrictOnOff = true;

            // 카카오써트 API 서비스 고정 IP 사용여부, true-사용, false-미사용, 기본값(false)
            kakaocertService.UseStaticIP = false;

            // 로컬시스템 시간 사용 여부 true(사용), false(기본값) - 미사용
            kakaocertService.UseLocalTimeYN = true;
        }
    }
}