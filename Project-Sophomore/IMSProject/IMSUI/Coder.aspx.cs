using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;

namespace IMSUI
{
    public partial class Coder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DecodeQrCode(GetQRCodeByZXingNet("难受", 500, 500));
            }
        }
        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="strMessage">要生成二维码的字符串</param>
        /// <param name="width">二维码图片宽度</param>
        /// <param name="height">二维码图片高度</param>
        /// <returns></returns>
        //private Bitmap GetQRCodeByZXingNet(String strMessage, Int32 width, Int32 height)
        //{
        //    Bitmap result = null;
        //    try
        //    {
        //        BarcodeWriter barCodeWriter = new BarcodeWriter();
        //        barCodeWriter.Format = BarcodeFormat.QR_CODE;
        //        barCodeWriter.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
        //        barCodeWriter.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H);
        //        barCodeWriter.Options.Height = height;
        //        barCodeWriter.Options.Width = width;
        //        barCodeWriter.Options.Margin = 0;
        //        ZXing.Common.BitMatrix bm = barCodeWriter.Encode(strMessage);
        //        result = barCodeWriter.Write(bm);
        //    }
        //    catch (Exception ex)
        //    {
        //        //异常输出
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 解码二维码
        ///// </summary>
        ///// <param name="barcodeBitmap">待解码的二维码图片</param>
        ///// <returns>扫码结果</returns>
        //private string DecodeQrCode(Bitmap barcodeBitmap)
        //{
        //    BarcodeReader reader = new BarcodeReader();
        //    reader.CharacterSet = "UTF-8";
        //    var result = reader.Decode(barcodeBitmap);
        //    return (result == null) ? null : result.Text;
        //}
    }
}