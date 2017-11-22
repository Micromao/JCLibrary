using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermutationAndCombination;

namespace ArrangeThreeNS
{
    public class ArrangeThree
    {
        //直选3中奖判断-new
        public static string OrderThreeNew(int[] Boon, int[] Hundred,int[] Decade ,int[] Unit)     
        {
            int numberWin = 0;      //标记选中的号码个数    
            int n = Boon.Length;
        
            //选号的组合方式
            List<int[]> listSum = new List<int[]>(new int { });
            for(int h=0;h<Hundred.Length;h++)
            {
                for(int d=0;d<Decade.Length;d++)
                {
                    for(int u=0;u<Unit.Length;u++)
                    {
                        int[] listCopy = new int[] {Hundred[h], Decade[d], Unit[u] };
                        listSum.Add(listCopy);

                    }
                }
            }

         //   int[] Choose = new int[] { };
         //   List<int[]> ListPermutation = PermutationAndCombination<int>.GetPermutation(Choose, 3);

            foreach (int[] arr in listSum)
            {
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] == Boon[i]) numberWin += 1;
                    if (numberWin == n) return "中奖" + "\n(投注数:" + listSum.Count + ")";
                }
                numberWin = 0;
            }
            return "未中奖" + "\n(投注数:" + listSum.Count + ")";
        }
        //组选6中奖判断
        public static string DisorderSix(int[] Boon, int[] Choose)
        {
            int numberWin = 0;      //标记选中的号码个数    
            int n = Boon.Length;

            //选号的组合方式
            List<int[]> ListCombination = PermutationAndCombination<int>.GetCombination(Choose,3);     //选择Choose中的n排列方式

            foreach (int[] arr in ListCombination)
            {
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] == Boon[i])
                      {
                        numberWin += 1;
                        if (numberWin == n)
                        {                               
                            return "中奖"+ "\n(投注数:" + ListCombination.Count + ")"; 
                        }
                    }                                      
                }
                numberWin = 0;
            }
            return "未中奖" + "\n(投注数:" + ListCombination.Count + ")";
        }

        //组合3中奖判断: 组合数另外计算 listSum
        public static string DisorderThree(int[] Boon, int[] Choose)
        {

            int numberWin = 0;      //标记选中的号码个数    
            int n = Boon.Length;

            //选号的组合方式
            List<int[]> ListCombination = PermutationAndCombination<int>.GetCombination(Choose,2);
            //组三的复注选号列表

            List<int[]> listSum = new List<int[]>(new int { });
            List<int[]> ListThree = PermutationAndCombination<int>.GetPermutation(Choose,2);
            foreach(int [] list in ListThree)
            {
                int[] listCopy = new int[] { list[0],list[0],list[1]};
                listSum.Add(listCopy);
            }
            Console.WriteLine(listSum.Count);
            //组三中奖，若开奖号未出现重号，则不可能开出组三奖
            bool signThree = (Boon[0] - Boon[1]) == 0 || (Boon[0] - Boon[2]) == 0;
            if (signThree==true)
            {
                return "未中奖"+ "\n(投注数:" + ListCombination.Count*2 + ")";
            }

            //组三中奖判断，用组合2的顺序，逐个对应中奖号的百位，十位，个位
            foreach (int[] arr in ListCombination)
            {
                for (int i = 0; i < n; i++)
                {
                    for(int j = 0;j < 2;j++)
                    { 
                        if (arr[j] == Boon[i])
                        {
                            numberWin += 1;                            
                         }
                        if (numberWin == n)
                        {
                            return "中奖" + "\n(投注数:" + listSum.Count + ")";
                        }
                    }
                    numberWin = 0;
                }              
            }
            return "未中奖" + "\n(投注数:" + listSum.Count + ")";
        }

        //和值：直选3
        public static string SumOrderThree(int[] Boon, int[] ChooseSum,int playMethod)
        {
            //playMethod: 1-直选，2-组选三，3-组选六
            int sumBoon = Boon[0] + Boon[1] + Boon[2];
            bool isBoon = false;

            //玩法判断
            string playMethodName = "";
            switch (playMethod)
            {
                case 1:
                    playMethodName = "直选三和值：";
                    break;
                case 2:
                    playMethodName = "组选三和值：";
                    break;
                case 3:
                    playMethodName = "组选六和值: ";
                    break;
                default:
                    return "玩法选择异常";
            }
            foreach (int Choose_i in ChooseSum)
            {
                isBoon = (Choose_i - sumBoon) == 0;
                if (isBoon) return playMethodName + "中奖";                
            } 
            return playMethodName + "未中奖";
        }

    }
}
