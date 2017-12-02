using System;
using System.Collections.Generic;
using Common.Extensions;

namespace DayLibrary
{
    public class AOC2017_Day02: DayBase
    {
        private const string CommonInput = "493\t458\t321\t120\t49\t432\t433\t92\t54\t452\t41\t461\t388\t409\t263\t58\r\n" +
                                           "961\t98\t518\t188\t958\t114\t1044\t881\t948\t590\t972\t398\t115\t116\t451\t492\r\n" +
                                           "76\t783\t709\t489\t617\t72\t824\t452\t748\t737\t691\t90\t94\t77\t84\t756\r\n" +
                                           "204\t217\t90\t335\t220\t127\t302\t205\t242\t202\t259\t110\t118\t111\t200\t112\r\n" +
                                           "249\t679\t4015\t106\t3358\t1642\t228\t4559\t307\t193\t4407\t3984\t3546\t2635\t3858\t924\r\n" +
                                           "1151\t1060\t2002\t168\t3635\t3515\t3158\t141\t4009\t3725\t996\t142\t3672\t153\t134\t1438\r\n" +
                                           "95\t600\t1171\t1896\t174\t1852\t1616\t928\t79\t1308\t2016\t88\t80\t1559\t1183\t107\r\n" +
                                           "187\t567\t432\t553\t69\t38\t131\t166\t93\t132\t498\t153\t441\t451\t172\t575\r\n" +
                                           "216\t599\t480\t208\t224\t240\t349\t593\t516\t450\t385\t188\t482\t461\t635\t220\r\n" +
                                           "788\t1263\t1119\t1391\t1464\t179\t1200\t621\t1304\t55\t700\t1275\t226\t57\t43\t51\r\n" +
                                           "1571\t58\t1331\t1253\t60\t1496\t1261\t1298\t1500\t1303\t201\t73\t1023\t582\t69\t339\r\n" +
                                           "80\t438\t467\t512\t381\t74\t259\t73\t88\t448\t386\t509\t346\t61\t447\t435\r\n" +
                                           "215\t679\t117\t645\t137\t426\t195\t619\t268\t223\t792\t200\t720\t260\t303\t603\r\n" +
                                           "631\t481\t185\t135\t665\t641\t492\t408\t164\t132\t478\t188\t444\t378\t633\t516\r\n" +
                                           "1165\t1119\t194\t280\t223\t1181\t267\t898\t1108\t124\t618\t1135\t817\t997\t129\t227\r\n" +
                                           "404\t1757\t358\t2293\t2626\t87\t613\t95\t1658\t147\t75\t930\t2394\t2349\t86\t385";
        protected override string InputPart1 { get; } = CommonInput;
        protected override string InputPart2 { get; } = CommonInput;

        protected override void Part1(string input)
        {
            var arr = input.StringTo2ArrayOfArrays("\t");
            Console.WriteLine(CalcCheckSumMinMax(arr));
        }
        protected override void Part2(string input)
        {
            var arr = input.StringTo2ArrayOfArrays("\t");
            Console.WriteLine(CalcCheckSumDivRem(arr));
        }

        protected static int CalcCheckSumMinMax(IEnumerable<IEnumerable<string>> arr)
        {
            var sum = 0;
            foreach (var t in arr)
            {
                var max = 0;
                var min = int.MaxValue;
                foreach (var t1 in t)
                {
                    var no = int.Parse(t1);
                    if (no > max) max = no;
                    if (no < min) min = no;
                }
                sum += max - min;
            }
            return sum;
        }
        protected static int CalcCheckSumDivRem(IEnumerable<string[]> arr)
        {
            var sum = 0;

            foreach (var t in arr)
            {
                var max = 0;
                var min = 0;
                for (var j1 = 0; j1 < t.Length; j1++)
                {
                    for (var j2 = 0; j2 < t.Length; j2++)
                    {
                        if (j1 == j2) continue;
                        var no1 = int.Parse(t[j1]);
                        var no2 = int.Parse(t[j2]);
                        Math.DivRem(no1, no2, out var mod);
                        if (mod != 0 || no2 == 0) continue;
                        max = no1;
                        min = no2;
                        break;
                    }
                }
                sum += max / min;
            }
            return sum;
        }

    }

   
}
