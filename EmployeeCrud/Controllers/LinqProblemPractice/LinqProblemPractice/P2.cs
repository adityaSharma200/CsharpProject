using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProblemPractice
{
    public class P2
    {
        
        public static void Main(string[] args)
        {
            //Longest Prfix
            //string[] strs = { "flower", "flogth", "flow" };
            //Console.WriteLine(Demo(strs));

            //plusOne1
            //int[] nums = {};
            //nums = PlusOne2(nums); 
            //foreach (int i in nums)
            //{
            //    Console.Write(i);
            //}

            //ClimbingStairs
            //int step1 = 1;
            //int step2 = 2;
            //int stepsToClimb = 3;
            //Console.WriteLine(ClimbingStairs(step1, step2, stepsToClimb));

            //BinaryConversion
            //string bin1 = "1010";
            //string bin2 = "1011";
            //int ans = ConFromBinToDec(bin1)+ConFromBinToDec(bin2);
            //Console.WriteLine(ConFromDecToBin(ans));
            int a = 5;
            int res;
            Demo(a,out res);
            Console.WriteLine(res);
        }
        public static  void Demo(int b ,out int a)
        {
            a = b * b;
           
        }

        public static int[] PlusOne2(int[] num)
        {
            if (num.Length == 0)
            {
                return num;
            }
            string str = "";
            for (int i = 0; i < num.Length; i++)
            {
                str = str + num[i];
            }
            int resnum = Convert.ToInt32(str) + 1;
            int j = num.Length - 1;
            while (resnum != 0)
            {

                int temp = resnum % 10;
                if (j < 0)
                {
                    int[] a = new int[num.Length + 1];
                    a[0] = 1;
                    return a;

                }
                num[j] = temp;

                resnum = resnum / 10;
                j--;
            }
            return num;

        }


        //public static string Demo(string[] strs)
        //{
        //    string ans = string.Empty;
        //    string firstElement = strs[0];
        //    for (int i = 0; i < firstElement.Length; i++)
        //    {
        //        bool isSame = true;
        //        for (int j = 1; j < strs.Length; j++)
        //        {
        //            if (firstElement[i] != strs[j][i])
        //            {
        //                return ans;
        //            }
        //        }
        //        if(isSame)
        //        {
        //            ans = ans + firstElement[i];
        //        }

        //    }
        //    return ans;
        //}
        public static int[] PlusOne1(int[] nums)
        {

            if (nums.Length == 0)
            {
                return nums;
            }
            int lastPosition = nums.Length - 1;
            int temp = lastPosition;
            for (int i = lastPosition; i >= 0; i--)
            {
                if (nums[i] == 9)
                {
                    lastPosition--;
                    nums[i] = 0;
                }
                else
                {
                    break;
                }
            }
            if (temp == lastPosition)
            {
                nums[temp] = nums[temp] + 1;
                return nums;
            }
            else if (nums.Length - nums.Length == lastPosition + 1)
            {
                int[] temp2 = new int[nums.Length + 1];
                temp2[0] = 1;
                return temp2;
            }
            else
            {
                nums[lastPosition] = nums[lastPosition] + 1;
                return nums;
            }

        }
        public static int ClimbingStairs(int step1, int step2, int stepsToClimb)
        {
            int ans = 0;
            Dictionary<string, int> StepsCounter = new Dictionary<string, int>();
            StepsCounter.Add("Step1", 0);
            StepsCounter.Add("Step2", 0);
            while (stepsToClimb != 0)
            {
                if (stepsToClimb - step1 >= 0)
                {
                    int count = StepsCounter["Step1"];
                    StepsCounter["Step1"] = ++count;
                    stepsToClimb = stepsToClimb - step1;
                }
                if (stepsToClimb - step2 >= 0)
                {
                    int count = StepsCounter["Step2"];
                    StepsCounter["Step2"] = ++count;
                    stepsToClimb = stepsToClimb - step2;
                }
            }
            ans = (step1 * StepsCounter["Step1"]) + (step2 * StepsCounter["Step2"]);
            return ans;

        }
        public static int ConFromBinToDec(string num)
        {
            int ans = 0;
            int temp = Convert.ToInt16(num);
            int i = 0;
            while (temp != 0)
            {
                int digit = temp % 10;
                ans = ans + (digit * (int)(Math.Pow(2, i++)));
                temp = temp / 10;
            }
            return ans;
        }
        public static string ConFromDecToBin(int num)
        {
            string res = string.Empty;
            while (num != 0)
            {
                int digit = num % 2;
                res = digit+res;
                num = num / 2;
            }
           
            return res;
        }

    }
}
