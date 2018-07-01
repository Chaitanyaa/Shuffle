using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Threading;
namespace PP
{
    class shuffle
    {
        Random rnd = new Random();
        FileStream fs;
        SoundPlayer sp;
        int[] a = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[,] grid = new int[3, 3];
        int[,] wgrid = new int[3, 3];
        int r, c, count = 0, m = 1,hkp;
        int x, y,z;
        string name,hg1,sc1,hg2,hg3,sc2,sc3;
        ConsoleKeyInfo key;
        public shuffle(int para1)
        {
            x = para1;
            for (int i = 0; i <x-2; i++)
            {
                int j = rnd.Next(0, x-1);
                int tmp = a[j];
                a[j] = a[i + 1];
                a[i + 1] = tmp;
            }
        }
        public void assign(int para1,int para2,int ch1)
        {
            int i = 0, l = 1;
            y = para1;
            z = para2;
          /*  switch(ch1)
            {
                case 1:
                    fs = new FileStream("D://Highscorer.txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    hg1 = sr.ReadLine();
                    sc1 = sr.ReadLine();
                    sr.Close();
                    break;
                case 2:
                    fs = new FileStream("D://H2.txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr1 = new StreamReader(fs);
                    hg2 = sr1.ReadLine();
                    sc2 = sr1.ReadLine();
                    sr1.Close();
                    break;
                case 3:
                    fs = new FileStream("D://H3.txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr2 = new StreamReader(fs);
                    hg3 = sr2.ReadLine();
                    sc3 = sr2.ReadLine();
                    sr2.Close();
                    break;

            }
            */

            for (int p = 0; p < para1; p++)
            {
                for (int q = 0; q < para2; q++)
                {
                    grid[p, q] = a[i];
                    if (a[i] == 0)
                    {
                        r = p;
                        c = q;
                    }
                    i++;
                }
            }
            for (int p = 0; p < para1; p++)
            {
                for (int q = 0; q < para2; q++)
                {
                    wgrid[p, q] = l;
                    l++;
                }
            }
            wgrid[y-1,z-1] = 0;
        }

        public void display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Keypresses:{0}                                           Highscorer :{1}({2})",count,hg1,sc1);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                        *~*~*~*~*~*~*~*~*~*~*");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int p = 0; p < y; p++)
            {
                Console.Write("                     ");
                for (int q = 0; q < z; q++)
                {
                    Console.Write("      {0}", grid[p, q]);

                }
                //Console.Write("                ");
                //for (int q = 0; q < z; q++)
                //{
                //    Console.Write("      {0}", wgrid[p, q]);

                //}
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                        *~*~*~*~*~*~*~*~*~*~*");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(47, 15);
            Console.WriteLine("*Use W,A,S,D keys to control");
            Console.SetCursorPosition(47, 17);
            Console.WriteLine("*Press R to return to main menu");
            if (m == y*z)
            {
                Console.WriteLine();
                sp = new SoundPlayer("C:\\Users\\Admin\\Desktop\\yes.wav");
                Console.WriteLine("Congrats...U win!!!");
                sp.Play();
                fs = new FileStream("D://Highscores.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                sr.ReadLine();
                hkp = int.Parse(sr.ReadLine());
                sr.Close();
                if (count < hkp)
                {
                    Console.WriteLine("Enter ur Name:");
                    name = Console.ReadLine();
                    fs = new FileStream("D://Highscores.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(name);
                    sw.WriteLine(count);
                    sw.Close();
                    fs.Close();
                    Console.ReadLine();
                }
                else
                {
                    Console.ReadLine();
                }
            }

        }
        public void play()
        {
            int e = 0;
           // sp = new SoundPlayer("C:\\Users\\Admin\\Desktop\\button-16.wav");
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter ur move:");
                Console.WriteLine();
                Console.WriteLine("      W       ");
                Console.WriteLine();
                Console.WriteLine(" A    S    D  ");
                key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'a':
               //         sp.Play();
                        count++;
                        if (c - 1 < 0)
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r, c + z-1];
                            grid[r, c + (z-1)] = tmp;
                            c = c + (z-1);
                            Console.Clear();
                            display();
                        }
                        else
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r, c - 1];
                            grid[r, c - 1] = tmp;
                            c = c - 1;
                            Console.Clear();
                            display();
                        }
                        check();
                        break;
                    case 'd':
                 //       sp.Play();
                        count++;
                        if (c + 1 > z-1)
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r, c - (z-1)];
                            grid[r, c - (z-1)] = tmp;
                            c = c - (z-1);
                            Console.Clear();
                            display();
                            
                        }
                        else
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r, c + 1];
                            grid[r, c + 1] = tmp;
                            c = c + 1;
                            Console.Clear();
                            display();
                        }
                        check();
                        break;
                    case 'w':
                   //     sp.Play();
                        count++;
                        if (r - 1 < 0)
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r + (y-1), c];
                            grid[r + (y-1), c] = tmp;
                            r = r + (y-1);
                            Console.Clear();
                            display();
                           
                        }
                        else
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r - 1, c];
                            grid[r - 1, c] = tmp;
                            r = r - 1;
                            Console.Clear();
                            display();
                        }
                        check();
                        break;
                    case 's':
                     //   sp.Play();
                        count++;
                        if (r + 1 > y-1)
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r - (y-1), c];
                            grid[r - (y-1), c] = tmp;
                            r = r - (y-1);
                            Console.Clear();
                            display();
                           
                        }
                        else
                        {
                            int tmp = grid[r, c];
                            grid[r, c] = grid[r + 1, c];
                            grid[r + 1, c] = tmp;
                            r = r + 1;
                            Console.Clear();
                            display();
                        }
                        check();
                        break;
                    case 'r': e = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                if (check()||e==1)
                {
                    break;
                }

            } while (true);
            Console.Clear();
            display();
        }
        bool check()
        {
            if (r == y-1 && c == z-1)
            {
                m = 0;
                for (int p = 0; p < y; p++)
                {
                    for (int q = 0; q < z; q++)
                    {
                        if (grid[p, q] == wgrid[p, q])
                        {
                            m++;
                        }
                    }
                }
            }
            if (m == y*z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      public void gen1()
        {
            Random rnd=new Random();
            for (int i = 0;; i++)
            {
                Thread.Sleep(50);
                Console.SetCursorPosition(rnd.Next(47, 126), rnd.Next(4, 13));
                Console.Write("");
            }
        }
      public void show()
      {
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine("         Thank you for playing this game                                                                              ");
          Console.WriteLine("                                                                                          ");
          Console.WriteLine("                Developed By                                                                           ");
          Console.WriteLine("                             Sai Chaitanya                                                             ");
          Console.WriteLine("                                V Ganesh Sairam Reddy                                                       ");
          Console.WriteLine("                                                                                          ");
          Console.ReadLine();
      }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int tmpr=0,tmpc=0,end=0,ch1=0;
            ConsoleKeyInfo stin;
            ConsoleKeyInfo ch;
            shuffle s=new shuffle(10);
        End:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  .-')     ('-. .-.                                                    ('-.   ");
            Console.WriteLine("                                                 ( OO ).  ( OO )  |                                                  _(  OO)  ");
            Console.WriteLine("                                               (_)---|_) ,--. ,--.  ,--. ,--.      ,------.    ,------.  ,--.      (,------. ");
            Console.WriteLine("                                                |  *  _ | |* | |* |  |* | | *|   ('-| *.---' ('-| *.---'  |* |.-')   |* .---' ");
            Console.WriteLine("                                                |  :` `.  |   .|  |  |  | | .-') (OO|(_|     (OO|(_|      |  | OO )  |  |     ");
            Console.WriteLine("                                                 '..`''.) |   *   |  |  |_|( OO )|  |  '--.  |  |  '--.   |  |`-' | (|  '--.  ");
            Console.WriteLine("                                                .-._)   | |  .-.  |  |  | | `-' ||_)|* .--'  |_)|* .--'  (|  '---.'  | *.--'  ");
            Console.WriteLine("                                                |     * | | *| | *| (' *'-'(_.-'   ||  |_)     ||  |_)    |   *  |   |  `---. ");
            Console.WriteLine("                                                 `-----'  `--' `--'   `-----'       `--'        `--'      `------'   `------' ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                                                                                1).Quick Match                                        ");
            Console.WriteLine();
            Console.WriteLine("                                                                                2).Custom Match                                       ");
            Console.WriteLine();
            Console.WriteLine("                                                                                3).Credits                                              ");
            ThreadStart th1 = new ThreadStart(s.gen1);
            Thread t1 = new Thread(th1);
            t1.Start();
            stin = Console.ReadKey(true);
            switch (stin.KeyChar)
            {
                case '1':
                    t1.Abort();
                    Console.Clear();
                    s = new shuffle(10);
                    s.assign(3,3,3);
                    s.display();
                    s.play();
                    if (end == 0)
                    {
                        goto End;
                    }
                    break;
                case '2':
                    t1.Abort();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    Console.WriteLine("Select the desired order:");
                    Console.WriteLine();
                    //Console.Write("1).2x2\t");
                    Console.Write("1).2x3\t");
                    Console.Write("2).3x2\t");
                    Console.Write("3).3x3\t");
                    ch = Console.ReadKey(true);
                    switch (ch.KeyChar)
                    {
                        case '1':
                            tmpr = 2;
                            tmpc = 3;
                            ch1 = 1;
                            break;
                        case '2':
                            tmpr = 3;
                            tmpc = 2;
                            ch1 = 2;
                            break;
                        case '3':
                            tmpr = 3;
                            tmpc = 3;
                            ch1 = 3;
                            break;
                    }
                    s = new shuffle(tmpr*tmpc+1);
                    s.assign(tmpr,tmpc,ch1);
                    s.display();
                    s.play();
                        if(end==0)
                        {
                            goto End;
                        }
                    break;
                case '3':
                    t1.Abort();
                    s.show();
                    end = 1;
                    break;
            }
           
        }
    }
}
