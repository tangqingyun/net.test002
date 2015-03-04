using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidyCode
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCode();
            }
        }

        public void ShowCode()
        {
            //对象实例化
            Validate GifValidate = new Validate();

            #region 对验证码进行设置(不进行设置时,将以默认值生成)
            //验证码位数，不小于4位
            GifValidate.ValidateCodeCount = 4;
            //验证码字体型号(默认13)
            GifValidate.ValidateCodeSize = 13;
            //验证码图片高度,高度越大,字符的上下偏移量就越明显
            GifValidate.ImageHeight = 23;
            //验证码字符及线条颜色(需要参考颜色类)
            GifValidate.DrawColor = System.Drawing.Color.BlueViolet;
            //验证码字体(需要填写服务器安装的字体)
            GifValidate.ValidateCodeFont = "Arial";
            //验证码字符是否消除锯齿
            GifValidate.FontTextRenderingHint = false;
            //定义验证码中所有的字符(","分离),似乎暂时不支持中文
            GifValidate.AllChar = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";
            #endregion

            //输出图像(Session名称)
            GifValidate.OutPutValidate("GetCode");
        }


    }
}
