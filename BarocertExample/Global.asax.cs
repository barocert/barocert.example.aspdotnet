using Kakaocert;
using Passcert;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace Barocert.Example
{
    public class Global : System.Web.HttpApplication
    {
        // 카카오써트 서비스 객체 선언
        public static KakaocertService kakaocertService;
        
        // 카카오써트 링크아이디
        private string kakaoLinkID = "TESTER";
        // 카카오써트 비밀키
        private string kakaoSecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";
        

        // 패스써트 서비스 객체 선언
        public static PasscertService passcertService;

        // 패스써트 링크아이디
        private string passLinkID = "TESTER";
        // 패스써트 비밀키
        private string passSecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";

        protected void Application_Start(object sender, EventArgs e)
        {
            // 카카오써트 서비스 객체 초기화
            kakaocertService = new KakaocertService(kakaoLinkID, kakaoSecretKey);

            // 인증토큰 IP 제한기능 사용여부, true-사용, false-미사용, 기본값(true)
            kakaocertService.IPRestrictOnOff = true;

            // 카카오써트 API 서비스 고정 IP 사용여부, true-사용, false-미사용, 기본값(false)
            kakaocertService.UseStaticIP = false;

            // 로컬시스템 시간 사용여부, true-사용, false-미사용, 기본값(true)
            kakaocertService.UseLocalTimeYN = true;
            

            // 패스써트 서비스 객체 초기화
            passcertService = new PasscertService(passLinkID, passSecretKey);

            // 인증토큰 IP 제한기능 사용여부, true-사용, false-미사용, 기본값(true)
            passcertService.IPRestrictOnOff = true;

            // 패스써트 API 서비스 고정 IP 사용여부, true-사용, false-미사용, 기본값(false)
            passcertService.UseStaticIP = false;

            // 로컬시스템 시간 사용여부, true-사용, false-미사용, 기본값(true)
            passcertService.UseLocalTimeYN = true;
        }
    }
}