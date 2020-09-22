using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Hanshu
    {
        public static Font Setmyfont(int x)        //使用外部字体
        {
            string fontpath = @".\database\font.ttf";        //字体路径
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontpath);
            if (x == 1)
            {
                Font font1 = new Font(pfc.Families[0], 10);
                return font1;       //正常字体
            }
            else if (x == 2)
            {
                Font font2 = new Font(pfc.Families[0], 10, FontStyle.Underline);
                return font2;       //有下划线
            }
            else
            {
                Font font3 = new Font(pfc.Families[0], 9, FontStyle.Underline);
                return font3;
            }
        }

        public static void Bind(ComboBox list, int itemHeight)      //修改comboname下拉列表高度
        {
            list.ItemHeight = itemHeight;
            list.DrawMode = DrawMode.OwnerDrawFixed;

            list.DrawItem += new DrawItemEventHandler(delegate (object sender, DrawItemEventArgs e)
            {
                if (e.Index < 0)
                {
                    return;
                }
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(list.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
            });
        }

        public static void ChangeKey(RichTextBox rBox, string key, Color color, Font font)      //改变特定字符串的字体及颜色
        {
            Regex regex = new Regex(key);
            MatchCollection collection = regex.Matches(rBox.Text);      //找出内容中所有的要替换的关键字
            foreach (Match match in collection)     //对所有的要替换颜色的关键字逐个替换颜色
            {          //设置开始位置，长度，颜色，字体
                rBox.SelectionStart = match.Index;
                rBox.SelectionLength = key.Length;
                rBox.SelectionColor = color;
                rBox.SelectionFont = font;
            }
        }

        public static LinkLabel Setlink(LinkLabel linkLabel, string linktext, string setlink, Point point, Color color)         //设置超链接控件
        {
            void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)     //linklabel的链接点击事件
            {
                LinkLabel link2 = new LinkLabel();
                link2.Text = setlink;           //设置链接地址
                Process.Start(link2.Text);      //用默认浏览器打开地址
            }
            linkLabel.Text = linktext;      //设置点击控件文字
            linkLabel.Location = point;     //设置点击控件位置
            linkLabel.BackColor = color;    //设置背景颜色
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);    //将linklable1的链接点击事件给点击控件
            return linkLabel;
        }
    }
}
