using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChooseFive;
using System.Windows;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using CsharpHttpHelper;
using HtmlAgilityPack;
using System.Collections;
using Newtonsoft.Json;
using ArrangeThreeNS;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDisorderX()
        {
            int[] Boon = new int[] { 1, 2, 3, 4, 5 };
            int[] choose = new int[] { 1, 2, 3, 6, 7, 8, 9 };
            string mesBoon = ChooseFunction.Judge_Disorder_2to8(Boon, choose, 3);
            Console.WriteLine(mesBoon);

        }
        
        [TestMethod]
        public void TestPreorder3()
        {
            int[] Boon = new int[] { 1, 2, 3, 4, 5 };
            int[] choose = new int[] { 1, 2, 6, 7, 8, 9 };
            string mesBoon = ChooseFunction.Judge_Preorder_1to3(Boon, choose, 3);          
            Console.WriteLine(mesBoon);

        }
        [TestMethod]
        public void Test_Predisorder3()
        {
            int[] Boon = new int[] { 1, 2, 3, 4, 5 };
            int[] choose = new int[] { 1, 2, 6, 7, 8, 9 };
          
            string mesBoon = ChooseFunction.Judge_Predisorder_2to3(Boon, choose, 2);
            Console.WriteLine(mesBoon);

        }

        [TestMethod]
        public void Test_PlayMethod()
        {
            int[] Boon = new int[] { 1, 2, 3, 4, 5 };
            int[] Choose = new int[] { 1, 2, 3, 6, 7 };
            string mesBoon = ChooseFunction.PlayMethodChoose(Boon, Choose,11);
            Console.WriteLine(mesBoon);
        }

        [TestMethod]
        public void Test_Three()
        {
            int[] Boon    = new int[] { 1, 2, 3 };
            int[] Choose1 = new int[] { 1, 2, 3 ,4, 6, 7, 8, 9};
            string mesBoon2 = ArrangeThree.DisorderThree(Boon, Choose1);
            string mesBoon3 = ArrangeThree.DisorderSix(Boon, Choose1);
            Console.WriteLine("组选3" + mesBoon2);
            Console.WriteLine("组选6" + mesBoon3);
        }
        [TestMethod]
        public void Test_SumThree()
        {
            int[] Boon = new int[] { 1, 2, 3 };
            int[] Choose1 = new int[] { 1, 2, 3, 4, 6, 7, 8, 9 };
            string mesBoon = ArrangeThree.SumOrderThree(Boon, Choose1,1);
            Console.WriteLine( mesBoon);
        }
        [TestMethod]
        public void Test_OrderNew()
        {
            int[] Boon = new int[] { 1, 2, 3 };
            int[] h = new int[] { 1, 2, 3 };
            int[] d = new int[] { 1, 2 };
            int[] u = new int[] { 1 };
            string mesBoon = ArrangeThree.OrderThreeNew(Boon,h,d,u);
            Console.WriteLine(mesBoon);
        }


        //自动抽奖测试
        #region 


        [TestMethod]
        public void TestCreateBoonNumber()
        {
            int[] boonNumber = new int[5];

            //耗时计算
            Stopwatch stopWatch = new Stopwatch();

            for (int k = 0; k < 20; k++)
            {
                stopWatch.Start();
                boonNumber = RandomNumber.CreateBoonNumber();
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(boonNumber[i] + " ");
                }

                Thread.Sleep(2);
                stopWatch.Stop();
                Console.WriteLine("------" + stopWatch.Elapsed.TotalMilliseconds);
            }
        }

        [TestMethod]
        public void TestCreateChooseNumber()
        {
            Random rChooseNum = new Random();
            int cNum = rChooseNum.Next(1, 12);

            int[] chooseNum = new int[cNum];

            chooseNum = RandomNumber.CreateChooseNumber(cNum);
            for (int i = 0; i < cNum; i++)
            {
                Console.Write(chooseNum[i] + " ");
            }

        }

        [TestMethod]
        public void TestLottey()
        {
            Random rChooseNum = new Random();
            Thread.Sleep(20);
            int cNum = rChooseNum.Next(3, 12);

            int[] chooseNum = new int[cNum];
            int[] boonNum = new int[5];

            chooseNum = RandomNumber.CreateChooseNumber(cNum);
            for (int i = 0; i < cNum; i++)
            {
                Console.Write(chooseNum[i] + " ");
            }
            Console.WriteLine();



            boonNum = RandomNumber.CreateBoonNumber();
            for (int i = 0; i < 5; i++)
            {
                Console.Write(boonNum[i] + " ");
            }
            Console.WriteLine();
            //判断是否中奖
            string mesBoon = ChooseFunction.Judge_Disorder_2to8(boonNum, chooseNum, 3);
            Console.WriteLine(mesBoon);

        }


     
        [TestMethod]
        public void TestCaipai()
        {
            //从网易彩票上获取开奖号
            //http://caipiao.163.com/award/getAwardNumberInfo.html?gameEn=hljd11&cache=1510560975998&period=17111350
            string period = "17111410";
            DateTime nowTime = System.DateTime.Now;
            string timePerid = nowTime.ToString("yyMMdd"); // int32.parse(nowTime.ToString("yy"));
            
            int issueNum = ((nowTime.Hour - 8)*60 - 5 + nowTime.Minute)/ 10;
            string issue = issueNum.ToString();

            period = timePerid + issue;                   


            HttpHelper helper = new HttpHelper();
            HttpItem item = new HttpItem();
            HtmlDocument doc = new HtmlDocument();
            item.URL = $@"http://caipiao.163.com/award/getAwardNumberInfo.html?gameEn=hljd11&cache=1510560975998&period={period}";

            var result = helper.GetHtml(item);
            Console.WriteLine(result.Html);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(result.Html);

            string awardNumber = obj.awardNumberInfoList[0].winningNumber;
            int[] boonNumber = new int[5];
            for(int i=0;i<5;i++)
            {
                boonNumber[i] = Int32.Parse( awardNumber.Split(' ')[i]);
                Console.WriteLine(obj.awardNumberInfoList[0].period);
                Console.Write(boonNumber[i] + " ");
            }

        }
    }

    public class Rootobject
    {
        public Awardnumberinfolist[] awardNumberInfoList { get; set; }
        public string status { get; set; }
    }

    public class Awardnumberinfolist
    {
        public string daXiaoBi { get; set; }
        public string firstXt { get; set; }
        public string geWei { get; set; }
        public string hezhi { get; set; }
        public string houSan { get; set; }
        public string jiOuBi { get; set; }
        public string period { get; set; }
        public string secondXt { get; set; }
        public string shiWei { get; set; }
        public string winningNumber { get; set; }
        public string xingTai { get; set; }
    }
    #endregion

}
