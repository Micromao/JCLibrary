using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseFive
{
   public static  class RandomNumber
    {
        //自动生成开奖号
        public  static int[] CreateBoonNumber()
        {
            int[] boonNumber=new int[5];
            Hashtable hashtable = new Hashtable();
            Random raNum = new Random();
            Thread.Sleep(20);

            for (int i=0;hashtable.Count<5;i++)
            {
             int   nValue = raNum.Next(1, 12);
                //  boonNumber[i]=nValue;
                if (!hashtable.ContainsValue(nValue)&&nValue!=0)
                {
                    hashtable.Add(i, nValue);
                    boonNumber[i] = nValue;
                }
                else
                {
                    i--;                  
                }
            }
                return boonNumber;
        }

        public static int[] CreateChooseNumber(int cNum)
        {
            int[] chooseNum = new int[cNum];

            Hashtable hashtable = new Hashtable();
            Random raNum = new Random();
            Thread.Sleep(20);


            for (int i = 0; hashtable.Count < cNum; i++)
            {
                int nValue = raNum.Next(1, 12);
                //  boonNumber[i]=nValue;
                if (!hashtable.ContainsValue(nValue) && nValue != 0)
                {
                    hashtable.Add(i, nValue);
                    chooseNum[i] = nValue;
                }
                else
                {
                    i--;
                }
            }
            return chooseNum;

        }
    }
}
