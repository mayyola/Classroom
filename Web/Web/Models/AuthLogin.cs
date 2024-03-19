using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{ 
    public class AuthLogin
    {
        public bool AuthId(string idtype) //驗證是不是電機系、電機電力、通訊所、電信學程的員工師生
        {

            switch (idtype)
            {
            case "1301":
            case "1361":
            case "1307":
            case "1362":
            case "3330":
            case "B301":
            case "M361":
            case "M307":
            case "M362":
            case "M301":
            case "P301":
            case "P307":
            return true;
                break;

             default:
             return  false;
             break;

            }

        }

        public string [] Accessory()
        {
            string [] Accessory = { "桌型電腦", "E化講桌", "投影機", "投影布幕", "無線麥克風", "視訊設備", "喇叭" };
            return Accessory;
        }

        public string[] Roomtype()
        {
          string[] Roomtype= { "會議室", "階梯教室", "電腦教室", "一般教室", "電工實驗室" };
            return Roomtype;
        }
        public string[] RoomNum() //學校教室顯示的教室號碼
        {
            string[] RoomNum = { "EC2007", "EC2010", "EC2018", "EC3009", "EC3010", "EC3012", "EC3013", "EC3014", "EC6011", "EC6016", "EC6018", "EC6023", "EC6019", "EC6010-1", "EC6015-1", "EC6015-2", "EC7040", "EC8037" }; //陣列
            return RoomNum;
        }



        public string[] Section() //節數
        {
            string[] Section = { "A", "1", "2", "3", "4", "B", "5", "6", "7", "8", "9", "C", "D", "E" };

            return Section;

        }

        public string[] Sectiontime() //節數時間
        {

            string[] Sectiontime = { "[07:00-07:50]", "[08:10-09:00]", "[09:10-10:00]", "[10:10-11:00]", "[11:10-12:00]", "[12:10-13:00]", "[13:10-14:00]", "[14:10-15:00]", "[15:10-16:00]", "[16:10-17:00]", "[17:10-18:00]", "[18:20-19:10]", "[19:15-20:05]", "[20:10-21:00]" };
            return Sectiontime;
        }

        public string WeekDay(int weeken) //驗證是不是電機系、電機電力、通訊所、電信學程的員工師生
        {
            string result;
            switch (weeken)
            {
            case 0:
            //case "Su":
            //case "Sun":
            result = "日";
            break;
            case 1:
            //case "Mo":
            //case "Mon":
            result = "一";
                break;
            case 2:
            //case "Tu":
           // case "Tue":
            result = "二";
                break;
            case 3:
            //case "We":
            //case "Wed":
            result = "三";
            break;
            case 4:
            //case "Th":
            //case "Thu":
            result = "四";
            break;
            case 5:
            //case "Fr":
            //case "Fri":
            result = "五";
            break;
            case 6:
            //case "Sa":
            //case "Sat":
            result = "六";
            break;

            default:

            result = "Null";
            break;
            }

            return result;

        }

       

        public string [] weekdaych()
        {

            string [] weekdaych = { "一", "二", "三", "四", "五", "六", "日" };

            return weekdaych;

        }

        /*public function LoanDate()

        {
     $showdate = array();
     $ttday = date("Y-m-d");
            for ($i = 0;$i < 14;$i++)
     {
     $addate = date("Y-m-d", strtotime($ttday.  '+'.$i.' days'));
     $weekday =$this->WeekDay(date("D", strtotime($addate)));
                array_push($showdate,$addate." ".$weekday);
            }
            return $showdate;
        }*/

        public string [] Usetype()
        {
           string[] Usetype = { "補課-Make up missed Course", "口試-Oral", "實驗課程-Experimental Course", "系所會議-Departmental Meeting", "廠商會議-Corporate Meeting", "Meeting", "教室維護-Maintenance Task", "考試使用-Examination", "環工所課程-IEE Course", "系學會活動-Student Union Activity", "演講活動-Speech Activity", "系所活動-Departmental Activity" };
           

            return Usetype;

        }

      /* function get_academic_year($date)
        {
    $newDate = date("Y-m-d", strtotime($date));
	
    $seprate_date = explode("-", $newDate);
    $yy =$seprate_date[0] - 1911;
    $mm = (int)$seprate_date[1];
    $dd =$seprate_date[2];

            if ($mm > 8) //原本是$mm>7
    {
    $yy =$yy;
            }
    else {
	$yy =$yy - 1;
            }

    $firstsem = strval($seprate_date[0] - 1)."-08-25";  //2022-8-31
	$firstsem1 = strval($seprate_date[0])."-08-25";  //2022-8-31
	$sencondsem = strval($seprate_date[0])."-01-20";
	$sencondsem1 = strval($seprate_date[0] + 1)."-01-20";//2023-2-1
	$thirdsem = strval($seprate_date[0])."-07-01";    //2023-7-1
                                                      //9-隔年1
            if ((($mm == 1)&& ($firstsem <=$date)&& ($date <=$sencondsem))|| (($mm > 8)&& ($firstsem1 <=$date)&& ($date <=$sencondsem1))) //原本是$mm>7 or $mm==1
     {
        $sem = 1;
            }
	//2-6
    else if (($sencondsem <=$date)&& ($date <=$thirdsem)){
    $sem = 2;
            }
	//7-8
    else
	{
	  $sem = 3;
            }
    $academicyear =$yy."-".$sem;
            return  $academicyear;
        }*/

       


        public string [] room_keyid()
        { 
            string[] Usekey = { "1", "2", "3", "4", "5", "A", "B", "C", "D", "E" };
            return Usekey;
        }
        /*public function advisor() //指導老師連線  應該用不到了 資料庫原本在10 現在都改到150
        {
          $wsdlUrl = "https://ee.nsysu.edu.tw/webservice/webservice/WebService1.asmx?WSDL";
          $client = new SoapClient($wsdlUrl, array('trace'=>true));
          $authlogin = $client->MemberData();
          $Advisor= $authlogin->MemberDataResult;
          return $Advisor;
        }*/

        public string formstatus(string key) //表單狀態
        {
            var formstatus = new Dictionary<string, string>
            {
               { "T", "通過(Approved)" },
               { "F", "未通過(Fail)" },
               { "R", "審核中(Pending)" }
            };

            return formstatus[key];
        }

        public string[] adminauth()
        {
            string[] authority ={"admin", "office", "st"};
            return authority;

        }
    }
}