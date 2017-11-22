using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermutationAndCombination;

namespace ChooseFive
{
    public class ChooseFunction
    {

        /// <summary>
        /// 任选2到任8的中奖判断
        /// </summary>
        /// <param name="Boon"></param> 开奖号码
        /// <param name="Choose"></param>有效性在传入参数前进行限制
        /// <param name="n"></param> 任选2~8玩法
        /// <returns></returns>
        public static string Judge_Disorder_2to8(int[] Boon, int[] Choose, int n)
        {
            int numberWin = 0;      //标记选中的号码个数
            int chooseWin = 0;      //中奖注数

            List<int[]> ListCombination = PermutationAndCombination<int>.GetCombination(Choose, n);     //选择Choose中的n组合方式

            foreach (int[] arr in ListCombination)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < Boon.Length; j++)
                    {
                        if (arr[i] == Boon[j])
                        {
                            numberWin += 1;
                            if (numberWin == n)
                            {
                                int[] arrBoon = arr;

                                chooseWin += 1;
                                numberWin = 0;
                            }
                        }
                    }
                }
                numberWin = 0;
            }



            return chooseWin > 0 ? "中奖" + chooseWin.ToString() + "注" + "\n(投注数:" + ListCombination.Count + ")" : "未中奖" + "\n(投注数:" + ListCombination.Count + ")";


        }

        /// <summary>
        /// 前一到三直选玩法中奖判断
        /// </summary>
        /// <param name="Boon"></param>
        /// <param name="Choose"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Judge_Preorder_1to3(int[] Boon, int[] Choose, int n)
        {
            int numberWin = 0;      //标记选中的号码个数       

            List<int[]> ListCombination = PermutationAndCombination<int>.GetPermutation(Choose, n);     //选择Choose中的n排列方式

            foreach (int[] arr in ListCombination)
            {
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] == Boon[i]) numberWin += 1;
                    if (numberWin == n) return "中奖" + "\n(投注数:" + ListCombination.Count + ")";
                }
                numberWin = 0;
            }
            return "未中奖" + "\n(投注数:" + ListCombination.Count + ")";
        }

        /// <summary>
        /// 前二三任选玩法中奖判断
        /// </summary>
        /// <param name="Boon"></param>
        /// <param name="Choose"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Judge_Predisorder_2to3(int[] Boon, int[] Choose, int n)
        {
            int numberWin = 0;      //标记选中的号码个数        
            int chooseWin = 0;      //中奖注数
            List<int[]> ListCombination = PermutationAndCombination<int>.GetCombination(Choose, n);     //选择Choose中的n排列方式

            foreach (int[] arr in ListCombination)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (arr[i] == Boon[j])
                        {
                            numberWin += 1;
                            if (numberWin == n)
                            {
                                chooseWin += 1;
                                numberWin = 0;
                            }
                        }
                    }
                }
                numberWin = 0;
            }
            return chooseWin > 0 ? "中奖" + chooseWin.ToString() + "注" + "\n(投注数:" + ListCombination.Count + ")" : "未中奖" + "\n(投注数:" + ListCombination.Count + ")";
        }

        /// <summary>
        /// 玩法集合选择
        /// </summary>
        /// <param name="Boon"></param>开奖号
        /// <param name="Choose"></param>选奖号
        /// <param name="playM"></param>玩法序号
        /// <returns></returns>
        public static string PlayMethodChoose(int[] Boon, int[] Choose, int playM)
        {
            ///总共12种种玩法
            ///1 任选二	01 02 03 04 05	01 05	选2个号码，猜中开奖号码任意2个数字	6元
            ///2 任选三 01 02 04    选3个号码，猜中开奖号码任意3个数字  19元
            ///3 任选四 01 02 04 05 选4个号码，猜中开奖号码任意4个数字  78元
            ///4 任选五 01 02 03 04 05  选5个号码，猜中开奖号码的全部5个数字 540元
            ///5 任选六 01 02 03 04 05 06   选6个号码，猜中开奖号码的全部5个数字 90元
            ///6 任选七 01 02 03 04 05 06 07    选7个号码，猜中开奖号码的全部5个数字 26元
            ///7 任选八 01 02 03 04 05 06 07 08 选8个号码，猜中开奖号码的全部5个数字 9元
            ///8 前一直选    01  选1个号码，猜中开奖号码第1个数字   13元
            ///9 前二直选    01 02   选2个号码与开奖的前2个号码相同且顺序一致   130元
            ///10 前二组选    02 01   选2个号码与开奖的前2个号码相同    65元
            ///11 前三直选    01 02 03    选3个号码与开奖的前3个号码相同且顺序一致   1170元
            ///12前三组选    02 01 03    选3个号码与开奖的前3个号码相同    195元
            //任选2到8玩法
            int n = playM + 1;
            switch (playM)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    return "任选" + n + "玩法:" + Judge_Disorder_2to8(Boon, Choose, n);
                case 8:
                    return "前一直选" + "玩法:" + Judge_Preorder_1to3(Boon, Choose, 1);
                case 9:
                    return "前二直选" + "玩法:" + Judge_Preorder_1to3(Boon, Choose, 2);
                case 10:
                    return "前二组选" + "玩法:" + Judge_Predisorder_2to3(Boon, Choose, 2);
                case 11:
                    return "前三直选" + "玩法:" + Judge_Preorder_1to3(Boon, Choose, 3);
                case 12:
                    return "前三组选" + "玩法:" + Judge_Predisorder_2to3(Boon, Choose, 3);
                default:
                    return "共12种玩法，选择无效";
            }

        }

    }
}


