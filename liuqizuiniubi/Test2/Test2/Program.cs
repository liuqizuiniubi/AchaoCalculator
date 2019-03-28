using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace Test2
{
    public class Program
    {
        //将运算字符存入数组中
        public static char[] O = { '+', '-', '*', '/' };
        //生成等式
        public static string ABC()
        {
            Random rd = new Random();
            string result = null;
            int a = (int)rd.Next(0, 101);//随机生成数
            int b = (int)rd.Next(2, 4);
            result = result + a;
            for (int i = 0; i < b; i++)
            {
                int c = (int)rd.Next(0, 101);
                int d = (int)rd.Next(0, 4);
                result = result + O[d] + c;
            }
            return result;
        }

        //对应答案
        public static string BCD(string a)
        {

            DataTable dt = new DataTable();
            object ob = null;//计算结果 关键点    
            ob = dt.Compute(a, "");
            //不能使结果为负数和小数
            while (ob.ToString().Contains(".") || a.Contains("/0") || int.Parse(ob.ToString()) < 0)
            {

                a = ABC();
                ob = dt.Compute(a, "");
            }

            return a + "=" + ob.ToString();
        }

        public static void Main(string[] args)
        {

            string result = null;
            Console.Write("请输入生成题的数量：");
            int i = int.Parse(Console.ReadLine());
            for (int j = 0; j < i; j++)
            {
                result = result + BCD(ABC()) + "\r\n";
                //随机种子变换,生成不一样的数
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine(result);
            //将结果写入.txt文件中
            StreamWriter streamWriter = new StreamWriter("E:\\subject.txt");
            streamWriter.Write(result);
            streamWriter.Close();

        }

    }
}
