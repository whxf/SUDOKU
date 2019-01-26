using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SUDOKU
{
    public partial class Form1 : Form
    {
        private PictureBox[] picBox = new PictureBox[82];//picturebox
        private Button[] buttonNum = new Button[10];//button
        private PictureBox[] numC = new PictureBox[10];//灰色背景蓝字
        private PictureBox[] numO = new PictureBox[10];//灰色背景黑字
        private PictureBox[] buttonNumH = new PictureBox[10];//蓝色背景黄子
        private PictureBox[] buttonNumO = new PictureBox[10];//蓝色背景白字
        private List<string> Easy = new List<string>();//用来存放简单题目
        private List<string> Medium = new List<string>();//用来存放中等题目
        private List<string> Hard = new List<string>();//用来存放难题
        public Form3 form = new Form3();//错误窗口
        private int[,] numberPanel = new int[10,10];//记录数字盘上的数字
        private int[,] numColor = { {9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },
            {9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 },{9,9,9,9,9,9,9,9,9,9 }};//记录数字的style种类，1.灰底黑字，2.灰底蓝字，3.灰框，4.蓝框，5.蓝底白字
        private int[] controlPanel = new int[10];//记录数字选择框的数字

        public Form1()
        {
            InitializeComponent();
            InitPicBox(); //用来初始化所有的PictureBox控件
            InitNumber_c();//用来初始化number_c数组
            InitNumber_o();//用来初始化number_o数组
            InitButton();//用来初始化所有的Button控件
            InitButtonH();//用来初始化ButtonH图片数组
            InitButtonO();//用来初始化ButtonO图片数组
            InitEasyQ();//初始化简单题目
            InitMediumQ();//初始化中等题目
            InitHardQ();//初始化难题
        }

       //初始化picturebox&&click
        private void InitPicBox()
        {
            picBox[1] = pictureBox1;
            picBox[2] = pictureBox2;
            picBox[3] = pictureBox3;
            picBox[4] = pictureBox4;
            picBox[5] = pictureBox5;
            picBox[6] = pictureBox6;
            picBox[7] = pictureBox7;
            picBox[8] = pictureBox8;
            picBox[9] = pictureBox9;
            picBox[10] = pictureBox10;
            picBox[11] = pictureBox11;
            picBox[12] = pictureBox12;
            picBox[13] = pictureBox13;
            picBox[14] = pictureBox14;
            picBox[15] = pictureBox15;
            picBox[16] = pictureBox16;
            picBox[17] = pictureBox17;
            picBox[18] = pictureBox18;
            picBox[19] = pictureBox19;
            picBox[20] = pictureBox20;
            picBox[21] = pictureBox21;
            picBox[22] = pictureBox22;
            picBox[23] = pictureBox23;
            picBox[24] = pictureBox24;
            picBox[25] = pictureBox25;
            picBox[26] = pictureBox26;
            picBox[27] = pictureBox27;
            picBox[28] = pictureBox28;
            picBox[29] = pictureBox29;
            picBox[30] = pictureBox30;
            picBox[31] = pictureBox31;
            picBox[32] = pictureBox32;
            picBox[33] = pictureBox33;
            picBox[34] = pictureBox34;
            picBox[35] = pictureBox35;
            picBox[36] = pictureBox36;
            picBox[37] = pictureBox37;
            picBox[38] = pictureBox38;
            picBox[39] = pictureBox39;
            picBox[40] = pictureBox40;
            picBox[41] = pictureBox41;
            picBox[42] = pictureBox42;
            picBox[43] = pictureBox43;
            picBox[44] = pictureBox44;
            picBox[45] = pictureBox45;
            picBox[46] = pictureBox46;
            picBox[47] = pictureBox47;
            picBox[48] = pictureBox48;
            picBox[49] = pictureBox49;
            picBox[50] = pictureBox50;
            picBox[51] = pictureBox51;
            picBox[52] = pictureBox52;
            picBox[53] = pictureBox53;
            picBox[54] = pictureBox54;
            picBox[55] = pictureBox55;
            picBox[56] = pictureBox56;
            picBox[57] = pictureBox57;
            picBox[58] = pictureBox58;
            picBox[59] = pictureBox59;
            picBox[60] = pictureBox60;
            picBox[61] = pictureBox61;
            picBox[62] = pictureBox62;
            picBox[63] = pictureBox63;
            picBox[64] = pictureBox64;
            picBox[65] = pictureBox65;
            picBox[66] = pictureBox66;
            picBox[67] = pictureBox67;
            picBox[68] = pictureBox68;
            picBox[69] = pictureBox69;
            picBox[70] = pictureBox70;
            picBox[71] = pictureBox71;
            picBox[72] = pictureBox72;
            picBox[73] = pictureBox73;
            picBox[74] = pictureBox74;
            picBox[75] = pictureBox75;
            picBox[76] = pictureBox76;
            picBox[77] = pictureBox77;
            picBox[78] = pictureBox78;
            picBox[79] = pictureBox79;
            picBox[80] = pictureBox80;
            picBox[81] = pictureBox81;
            //循环让每一个picturebox使用相同的点击事件
            //通过委托来实现给所有picturebox控件添加相同的事件，详见课件10 delegate
            for (int i = 2; i <= 81; i++)
            {
                picBox[i].Click += new EventHandler(pictureBox1_Click);
            }
        }

        //初始化（灰底蓝字），出现的问题：注意picturebox的初始化，要new
        private void InitNumber_c()
        {
            for(int i = 0; i < numC.Length; i++)
            {
                numC[i] = new PictureBox();
            }
            numC[1].Image = SUDOKU.Properties.Resources._1_c;
            numC[2].Image = SUDOKU.Properties.Resources._2_c;
            numC[3].Image = SUDOKU.Properties.Resources._3_c;
            numC[4].Image = SUDOKU.Properties.Resources._4_c;
            numC[5].Image = SUDOKU.Properties.Resources._5_c;
            numC[6].Image = SUDOKU.Properties.Resources._6_c;
            numC[7].Image = SUDOKU.Properties.Resources._7_c;
            numC[8].Image = SUDOKU.Properties.Resources._8_c;
            numC[9].Image = SUDOKU.Properties.Resources._9_c;
        }

        //初始化（灰底黑字）
        private void InitNumber_o()
        {
            for (int i = 0; i < numO.Length; i++)
            {
                numO[i] = new PictureBox();
            }
            numO[1].Image = SUDOKU.Properties.Resources._1_o;
            numO[2].Image = SUDOKU.Properties.Resources._2_o;
            numO[3].Image = SUDOKU.Properties.Resources._3_o;
            numO[4].Image = SUDOKU.Properties.Resources._4_o;
            numO[5].Image = SUDOKU.Properties.Resources._5_o;
            numO[6].Image = SUDOKU.Properties.Resources._6_o;
            numO[7].Image = SUDOKU.Properties.Resources._7_o;
            numO[8].Image = SUDOKU.Properties.Resources._8_o;
            numO[9].Image = SUDOKU.Properties.Resources._9_o;
        }

        //初始化数字按钮
        private void InitButton()
        {
            buttonNum[1] = button1;
            buttonNum[2] = button2;
            buttonNum[3] = button3;
            buttonNum[4] = button4;
            buttonNum[5] = button5;
            buttonNum[6] = button6;
            buttonNum[7] = button7;
            buttonNum[8] = button8;
            buttonNum[9] = button9;
            for(int i = 2; i <= 9; i++)
            {
                buttonNum[i].Click += new EventHandler(button1_Click);
                buttonNum[i].MouseEnter += new EventHandler(button1_MouseEnter);
                buttonNum[i].MouseLeave += new EventHandler(button1_MouseLeave);
            }
        }

        //初始化（蓝底黄字）
        private void InitButtonH()
        {
            for (int i = 0; i < buttonNumH.Length; i++)
            {
                buttonNumH[i] = new PictureBox();
            }
            buttonNumH[1].Image = SUDOKU.Properties.Resources._1_h;
            buttonNumH[2].Image = SUDOKU.Properties.Resources._2_h;
            buttonNumH[3].Image = SUDOKU.Properties.Resources._3_h;
            buttonNumH[4].Image = SUDOKU.Properties.Resources._4_h;
            buttonNumH[5].Image = SUDOKU.Properties.Resources._5_h;
            buttonNumH[6].Image = SUDOKU.Properties.Resources._6_h;
            buttonNumH[7].Image = SUDOKU.Properties.Resources._7_h;
            buttonNumH[8].Image = SUDOKU.Properties.Resources._8_h;
            buttonNumH[9].Image = SUDOKU.Properties.Resources._9_h;
        }

        //初始化（蓝底白字）
        private void InitButtonO()
        {
            for (int i = 0; i < buttonNumO.Length; i++)
            {
                buttonNumO[i] = new PictureBox();
            }
            buttonNumO[1].Image = SUDOKU.Properties.Resources._1_b;
            buttonNumO[2].Image = SUDOKU.Properties.Resources._2_b;
            buttonNumO[3].Image = SUDOKU.Properties.Resources._3_b;
            buttonNumO[4].Image = SUDOKU.Properties.Resources._4_b;
            buttonNumO[5].Image = SUDOKU.Properties.Resources._5_b;
            buttonNumO[6].Image = SUDOKU.Properties.Resources._6_b;
            buttonNumO[7].Image = SUDOKU.Properties.Resources._7_b;
            buttonNumO[8].Image = SUDOKU.Properties.Resources._8_b;
            buttonNumO[9].Image = SUDOKU.Properties.Resources._9_b;
        }

        //初始化简单题目
        private void InitEasyQ()
        {
            FileStream fs = new FileStream("../../Q_A/Easy.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fs))
            {
                string ques = "";
                while((ques = reader.ReadLine())!="")
                {
                       Easy.Add(ques);
                }
            }
        }

        //初始化中等题目
        private void InitMediumQ()
        {
            FileStream fs = new FileStream("../../Q_A/Medium.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fs))
            {
                string ques = "";
                while ((ques = reader.ReadLine()) != "")
                {
                    Medium.Add(ques);
                }
            }
        }

        //初始化难题
        private void InitHardQ()
        {
            FileStream fs = new FileStream("../../Q_A/Hard.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fs))
            {
                string ques = "";
                while ((ques = reader.ReadLine()) != "")
                {
                    Hard.Add(ques);
                }
            }
        }

        //比较两个图片是否相同
        public static bool CompareByBase64String(Bitmap b1, Bitmap b2)
        {
            string _b1Base64String, _b2Base64String;
            System.IO.MemoryStream _ms = new System.IO.MemoryStream();
            try
            {
                b1.Save(_ms, ImageFormat.Png);
                _b1Base64String = Convert.ToBase64String(_ms.ToArray());
                _ms.Position = 0;

                b2.Save(_ms, ImageFormat.Png);
                _b2Base64String = Convert.ToBase64String(_ms.ToArray());
            }
            finally
            {
                _ms.Close();
            }
            return _b1Base64String.Equals(_b2Base64String);
        }

        //判断是否正确
       private bool isRIght(int x,int y) 
        {
            int loc_x = x;//获取当前picbox的位置
            int loc_y = y;

            //找出当前所表示的数字
            int num = numberPanel[loc_x,loc_y];

            //找出行正确性
            for(int n = 1;n <= 9; n++)
            {
                if (n == loc_y) continue;
                else if (numberPanel[loc_x, n] == num) return false;
            }

            //检验所在列的正确性
            for (int n = 1; n <= 9; n++)
            {
                if (n == loc_x) continue;
                else if (numberPanel[n,loc_y] == num) return false;
            }

            //检验所在小方块中的正确性
            int k = (loc_x - 1) / 3 * 3 + 1;//3*3的小区域的行坐标
            int j = (loc_y - 1) / 3 * 3 + 1;//3*3的小区域的列坐标
            for(int m = k; m < k + 3; m++)
            {
                for(int n = j; n < j + 3; n++)//循环遍历3*3小区域
                {
                    if (m == loc_x && n == loc_y) continue;
                    else if (numberPanel[m, n] == num) return false;
                }
            }
            return true;
        }


        //picBox点击事件
        //参数sender表示触发事件的控件，e表示触发的事件是什么，具体可以百度下事件触发机制    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //C#中对象参数赋值都是采用引用的方式，相当于是C++中的"指针"赋值
            //声明一个picturebox的"指针"，指向这个触发事件的控件
            //C#中没有指针，为了便于理解可以这样想。
            //因为sender和picturebox类型不同，赋值需要强制转换

            PictureBox picturebox = (PictureBox)sender;

            //如果点击的是灰色块
            if (CompareByBase64String((Bitmap)picturebox.Image, SUDOKU.Properties.Resources.blank))
            {
                int loc = 0;
                for (int k = 1; k <= 81; k++)
                {
                    if (picturebox.Equals(picBox[k])) { loc = k; break; }
                }
                //将其他蓝色变成灰色的
                for (int i = 1; i <= 9; i++)
                {
                    for(int j = 1; j <= 9; j++)
                    {
                        if (numColor[i, j] == 4)
                        {
                            picBox[(i - 1) * 9 + j].Image = SUDOKU.Properties.Resources.blank;
                            numColor[i, j] = 3;
                        }
                        else if (numColor[i, j] == 5)
                        {
                            picBox[(i - 1) * 9 + j].Image = numC[numberPanel[i, j]].Image;
                            numColor[i, j] = 2;
                        }
                    }
                }
                int x = (loc - 1) / 9 + 1; int y = loc % 9;
                if (y == 0) y = 9;
                numColor[x, y] = 4;
                //将这个变成蓝色的
                picturebox.Image = SUDOKU.Properties.Resources.blank_s;
            }
            //如果选中的是蓝色填充数字，就将数字变为蓝色选中数字
            else
            {
                //将其他的蓝色去除
                int loc = 0;
                for (int k = 1; k <= 81; k++)
                {
                    if (picturebox.Equals(picBox[k])) { loc = k;break; }
                }
                for (int i = 1; i <= 9; i++)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        if (numColor[i, j] == 4)
                        {
                            picBox[(i - 1) * 9 + j].Image = SUDOKU.Properties.Resources.blank;
                            numColor[i, j] = 3;
                        }
                        else if (numColor[i, j] == 5)
                        {
                            picBox[(i - 1) * 9 + j].Image = numC[numberPanel[i, j]].Image;
                            numColor[i, j] = 2;
                        }
                    }
                }
                //将这个变为蓝色的
                int x = (loc - 1) / 9 + 1;int y = loc % 9;
                if (y == 0) y = 9;
                if (numColor[x, y] == 1) { }
                else if (numberPanel[x, y] > 0)
                {
                    numColor[x, y] = 5;
                    picturebox.Image = buttonNumO[numberPanel[x, y]].Image;
                }
                else if(numColor[x, y]<9)
                {
                    numColor[x, y] = 4;
                    picBox[(x - 1) * 9 + y].Image = SUDOKU.Properties.Resources.blank_s;
                }
                
            }
        }

        //数字button鼠标放在上面事件
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int key = 0;
            //找到这个button对应的数字，注意：因为这个被“重载”所以不能简单的改变数字
            for(int i = 1; i <= 9; i++)
            {
                if (button.Equals(buttonNum[i]))
                {
                    key = i;
                    break;
                }
            }
            button.Image = buttonNumH[key].Image;
        }

        //数字button鼠标离开事件
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int key = 0;
            //和鼠标进入一样，这个也应注意这个问题
            for (int i = 1; i <= 9; i++)
            {
                if (button.Equals(buttonNum[i]))
                {
                    key = i;
                    break;
                }
            }
            button.Image = buttonNumO[key].Image;
        }

        //数字button鼠标点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int x = 0, y = 0;
            int num = 0;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (numColor[i, j] == 4 || numColor[i,j] == 5)
                    {
                        x = i;y = j;
                        for(int k = 1; k <= 9; k++)
                        {
                            if (button.Equals(buttonNum[k]))
                            {
                                num = k;break;
                            }
                        }
                        picBox[(i - 1) * 9 + j].Image = buttonNumO[num].Image;
                        numberPanel[i, j] = num;
                        numColor[i, j] = 5;
                        i += 9;j += 9;
                    }
                }
            }
            if (x==0||y==0) return;//防止出错
            //如果是正确的填蓝色的字（c）错误的填红色的字（w）
            else if (!isRIght(x,y))
            {
                picBox[(x - 1) * 9 + y].Image = SUDOKU.Properties.Resources.blank_s;
                numberPanel[x, y] = 0;
                numColor[x, y] = 4;
                form = new Form3();
                form.Show();//显示错误窗口
                Timer timer = new Timer();//初始化计时器
                timer.Interval = 1000;//定时1s
                timer.Tick += new EventHandler(tick);//动作
                timer.Start();//开始计时器
            }
                //picBox[loc].Image = numW[num].Image;
            //每次判断是否赢了
            if(win())
            {
                MessageBox.Show("太棒了！You Win!");
            }
        }

        //关闭窗口，计时器停止
        private void tick(object sender, EventArgs e)
        {
            form.Dispose();
            ((Timer)sender).Stop();
        }

        //单击清除键
        private void button_delete_Click(object sender, EventArgs e)
        {
            //遍历找到要删除的位置
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (numColor[i, j] == 5)
                    {
                        numColor[i, j] = 4;
                        numberPanel[i, j] = 0;
                        picBox[(i - 1) * 9 + j].Image = SUDOKU.Properties.Resources.blank_s;
                    }
                }
            }
        }

        //单击重做键
        private void button_reform_Click(object sender, EventArgs e)
        {
            //如果那个数字不是灰底黑字的块，那么就把它变成小灰块
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (numColor[i, j]>1&& numColor[i, j]<=5)
                    {
                        numColor[i, j] = 3;
                        numberPanel[i, j] = 0;
                        picBox[(i - 1) * 9 + j].Image = SUDOKU.Properties.Resources.blank;
                    }
                }
            }
        }

        //判断游戏输赢
        private bool win()
        {
            //没有灰色的空，没有蓝色的空，没有灰色的空，没有w的
            for(int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    if (numColor[i, j] == 3 || numColor[i, j] == 4) return false;
                }
            }
            return true;
        }

         //菜单测试键，展示测试的题目
        private void Test_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //读入文件的方法
            FileStream fs = new FileStream("../../Q_A/Test.txt", FileMode.Open);
            int i = 0;
            using (StreamReader reader = new StreamReader(fs))
            {
                for(int k = 1; k <= 9; k++)
                {
                    for(int j = 1; j <= 9; j++)
                    {
                        i = (k - 1) * 9 + j;
                        int num = reader.Read() - 48;//每次读入一个字符,ask码的转换
                        if (num==1) picBox[i].Image = SUDOKU.Properties.Resources._1_o;
                        else if (num==2) picBox[i].Image = SUDOKU.Properties.Resources._2_o;
                        else if (num==3) picBox[i].Image = SUDOKU.Properties.Resources._3_o;
                        else if (num==4) picBox[i].Image = SUDOKU.Properties.Resources._4_o;
                        else if (num==5) picBox[i].Image = SUDOKU.Properties.Resources._5_o;
                        else if (num==6) picBox[i].Image = SUDOKU.Properties.Resources._6_o;
                        else if (num==7) picBox[i].Image = SUDOKU.Properties.Resources._7_o;
                        else if (num==8) picBox[i].Image = SUDOKU.Properties.Resources._8_o;
                        else if (num==9) picBox[i].Image = SUDOKU.Properties.Resources._9_o;
                        else if (num==0) picBox[i].Image = SUDOKU.Properties.Resources.blank;
                        numberPanel[k, j] = num;
                        if (num > 0) numColor[k, j] = 1;
                        else numColor[k, j] = 3;
                    }
                }
            }
        }

        //菜单简单题目，展示简单的题目
        private void Easy_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random ra = new Random();
            int len = Easy.Count;
            int choice = ra.Next() % len;
            int cnt = 0;
            int i = 0;
            for (int k = 1; k <= 9; k++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    i = (k - 1) * 9 + j;
                    if (Easy[choice][cnt] == '1') picBox[i].Image = SUDOKU.Properties.Resources._1_o;
                    else if (Easy[choice][cnt] == '2') picBox[i].Image = SUDOKU.Properties.Resources._2_o;
                    else if (Easy[choice][cnt] == '3') picBox[i].Image = SUDOKU.Properties.Resources._3_o;
                    else if (Easy[choice][cnt] == '4') picBox[i].Image = SUDOKU.Properties.Resources._4_o;
                    else if (Easy[choice][cnt] == '5') picBox[i].Image = SUDOKU.Properties.Resources._5_o;
                    else if (Easy[choice][cnt] == '6') picBox[i].Image = SUDOKU.Properties.Resources._6_o;
                    else if (Easy[choice][cnt] == '7') picBox[i].Image = SUDOKU.Properties.Resources._7_o;
                    else if (Easy[choice][cnt] == '8') picBox[i].Image = SUDOKU.Properties.Resources._8_o;
                    else if (Easy[choice][cnt] == '9') picBox[i].Image = SUDOKU.Properties.Resources._9_o;
                    else if (Easy[choice][cnt] == '0') picBox[i].Image = SUDOKU.Properties.Resources.blank;
                    numberPanel[k, j] = Easy[choice][cnt++] - '0';
                    if (numberPanel[k, j] > 0) numColor[k, j] = 1;
                    else numColor[k, j] = 3;
                }
            }
        }

        //菜单中等题目，展示中等的题目
        private void Medium_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random ra = new Random();
            int len = Medium.Count;
            int choice = ra.Next() % len;
            int cnt = 0;
            int i = 0;
            for (int k = 1; k <= 9; k++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    i = (k - 1) * 9 + j;
                    if (Medium[choice][cnt] == '1') picBox[i].Image = SUDOKU.Properties.Resources._1_o;
                    else if (Medium[choice][cnt] == '2') picBox[i].Image = SUDOKU.Properties.Resources._2_o;
                    else if (Medium[choice][cnt] == '3') picBox[i].Image = SUDOKU.Properties.Resources._3_o;
                    else if (Medium[choice][cnt] == '4') picBox[i].Image = SUDOKU.Properties.Resources._4_o;
                    else if (Medium[choice][cnt] == '5') picBox[i].Image = SUDOKU.Properties.Resources._5_o;
                    else if (Medium[choice][cnt] == '6') picBox[i].Image = SUDOKU.Properties.Resources._6_o;
                    else if (Medium[choice][cnt] == '7') picBox[i].Image = SUDOKU.Properties.Resources._7_o;
                    else if (Medium[choice][cnt] == '8') picBox[i].Image = SUDOKU.Properties.Resources._8_o;
                    else if (Medium[choice][cnt] == '9') picBox[i].Image = SUDOKU.Properties.Resources._9_o;
                    else if (Medium[choice][cnt] == '0') picBox[i].Image = SUDOKU.Properties.Resources.blank;
                    numberPanel[k, j] = Medium[choice][cnt++]-'0';
                    if (numberPanel[k, j] > 0) numColor[k, j] = 1;
                    else numColor[k, j] = 3;
                }
            }
        }

        //菜单难题，展示难的题目
        private void Hard_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random ra = new Random();
            int len = Hard.Count;
            int choice = ra.Next() % len;
            int cnt = 0;
            int i = 0;
            for (int k = 1; k <= 9; k++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    i = (k - 1) * 9 + j;
                    if (Hard[choice][cnt] == '1') picBox[i].Image = SUDOKU.Properties.Resources._1_o;
                    else if (Hard[choice][cnt] == '2') picBox[i].Image = SUDOKU.Properties.Resources._2_o;
                    else if (Hard[choice][cnt] == '3') picBox[i].Image = SUDOKU.Properties.Resources._3_o;
                    else if (Hard[choice][cnt] == '4') picBox[i].Image = SUDOKU.Properties.Resources._4_o;
                    else if (Hard[choice][cnt] == '5') picBox[i].Image = SUDOKU.Properties.Resources._5_o;
                    else if (Hard[choice][cnt] == '6') picBox[i].Image = SUDOKU.Properties.Resources._6_o;
                    else if (Hard[choice][cnt] == '7') picBox[i].Image = SUDOKU.Properties.Resources._7_o;
                    else if (Hard[choice][cnt] == '8') picBox[i].Image = SUDOKU.Properties.Resources._8_o;
                    else if (Hard[choice][cnt] == '9') picBox[i].Image = SUDOKU.Properties.Resources._9_o;
                    else if (Hard[choice][cnt] == '0') picBox[i].Image = SUDOKU.Properties.Resources.blank;
                    numberPanel[k, j] = Hard[choice][cnt++] - '0';
                    if (numberPanel[k, j] > 0) numColor[k, j] = 1;
                    else numColor[k, j] = 3;
                }
            }
        }

        //菜单帮助-游戏说明
        private void Help_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();//弹出游戏说明的窗口
            form.Show();
        }

        
    }
}
