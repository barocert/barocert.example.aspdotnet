﻿/*
* Barocert NAVER API Java SDK JSP Example
*
* 업데이트 일자 : 2024-04-16
* 연동기술지원 연락처 : 1600-9854
* 연동기술지원 이메일 : code@linkhubcorp.com
*         
* <테스트 연동개발 준비사항>
*   1) API Key 변경 (연동신청 시 메일로 전달된 정보)
*       - LinkID : 링크허브에서 발급한 링크아이디
*       - SecretKey : 링크허브에서 발급한 비밀키
*   2) SDK 환경설정 필수 옵션 설정
*       - IPRestrictOnOff : 인증토큰 IP 검증 설정, true-사용, false-미사용, (기본값:true)
*       - UseStaticIP : 통신 IP 고정, true-사용, false-미사용, (기본값:false)
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

namespace Barocert.Navercert
{
    public class Global : System.Web.HttpApplication
    {
        // 네이버써트 서비스 객체 선언
        public static NavercertService navercertService;

        // 링크아이디
        private string LinkID = "TESTER";
        
        // 비밀키
        private string SecretKey = "SwWxqU+0TErBXy/9TVjIPEnI0VTUMMSQZtJf3Ed8q3I=";

        protected void Application_Start(object sender, EventArgs e)
        {
            // 네이버써트 서비스 객체 초기화
            navercertService = new NavercertService(LinkID, SecretKey);

            // 인증토큰 IP 검증 설정, true-사용, false-미사용, (기본값:true)
            navercertService.IPRestrictOnOff = true;

            // 통신 IP 고정, true-사용, false-미사용, (기본값:false)
            navercertService.UseStaticIP = false;
        }
    }
}