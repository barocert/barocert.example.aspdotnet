﻿/*
* 패스써트 API ASP.NET SDK Example
*
* ASP.NET SDK 연동환경 설정방법 안내 : https://developers.barocert.com/guide/kakao/identity/dotnet/getting-started/tutorial
* 업데이트 일자 : 2023-10-30
* 연동기술지원 연락처 : 1600-9854
* 연동기술지원 이메일 : code@linkhubcorp.com
*
* <테스트 연동개발 준비사항>
* 32, 34번 라인에 선언된 링크아이디(LinkID)와 비밀키(SecretKey)를
* 가입시 메일로 발급받은 인증정보를 참조하여 변경합니다.
*/

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace Barocert.Kakaocert
{
    public class Global : System.Web.HttpApplication
    {
        // 카카오써트 서비스 객체 선언
        public static KakaocertService kakaocertService;
        
        // 카카오써트 링크아이디
        private string LinkID = "TESTER";
        // 카카오써트 비밀키
        private string SecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";
       
        protected void Application_Start(object sender, EventArgs e)
        {
            // 카카오써트 서비스 객체 초기화
            kakaocertService = new KakaocertService(LinkID, SecretKey);

            // 인증토큰 IP 제한기능 사용여부, true-사용, false-미사용, 기본값(true)
            kakaocertService.IPRestrictOnOff = true;

            // 카카오써트 API 서비스 고정 IP 사용여부, true-사용, false-미사용, 기본값(false)
            kakaocertService.UseStaticIP = false;
        }
    }
}