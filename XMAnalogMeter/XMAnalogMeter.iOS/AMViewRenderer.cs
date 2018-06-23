using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XMAnalogMeter;
using XMAnalogMeter.iOS;
using CoreGraphics;

// FormsコントロールとRendererの対応を宣言
[assembly: ExportRenderer(typeof(AMView), typeof(AMViewRenderer))]
namespace XMAnalogMeter.iOS
{
    class AMViewRenderer : ViewRenderer<AMView, UIView>
    {
        double val = 0;

        protected override void OnElementChanged(ElementChangedEventArgs<AMView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var nativeControl = new UIView();
                SetNativeControl(nativeControl);
                UpdateValue();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


            if (e.PropertyName == AMView.ValueProperty.PropertyName)
            {
                UpdateValue();
            }
        }

        private void UpdateValue()
        {
            val = Element.Value;
            double val1 = Element.Value;
            if (val1 >= Element.maxValue)
            {
                val = Element.maxValue;
            }
            if (val1 < Element.minValue)
            {
                val = Element.minValue;
            }
            SetNeedsDisplay();

        }


        public override void Draw(CGRect rect)
        {
            base.Draw(rect);


            UIImage uim = UIImage.FromFile("meter1.png");
            uim.Draw(new CGRect(new CGPoint(0,0),new CGSize((float)Element.meterSize , (float)Element.meterSize)));

            using (CGContext g = UIGraphics.GetCurrentContext())
            {

                //原点(メーターの中心)
                double bX = Element.meterSize / 2;
             
                g.SetStrokeColor(UIColor.Blue.CGColor);//線色の指定（青色）
                g.SetLineWidth(4);//線の太さ
                g.SetFillColor(0, 0, 255, 1);//塗りつぶし色の指定（青色）

                double maxV = Element.maxValue; 
                double minV = Element.minValue;
                
                //Value 1 当たりの角度
                double xx = (Element.maxAngle - Element.minAngle )  / (maxV - minV);


                for (int i = (int)minV; i <= (int)maxV; i += (int)Element.tickValue )
                {
                    double r1 = bX * .85;
                    double r2 = bX * .65;
                    double r3 = bX * .55;
                    double kak1 =Element.minAngle + (i - minV) * xx;
                    double pX1 = -1 * r1 * Math.Sin(kak1 * (Math.PI / 180));
                    double pY1 = r1 * Math.Cos(kak1 * (Math.PI / 180));
                    double pX2 = -1 * r2 * Math.Sin(kak1 * (Math.PI / 180));
                    double pY2 = r2 * Math.Cos(kak1 * (Math.PI / 180));
                    double pX3 = -1 * r3 * Math.Sin(kak1 * (Math.PI / 180));
                    double pY3 = r3 * Math.Cos(kak1 * (Math.PI / 180));

                    string str1 = i.ToString();

                    //属性の生成
                    UIFont fnt = UIFont.FromName("Courier-Italic", 16f);




                    var attr = new UIStringAttributes
                    {
                        ForegroundColor = UIColor.White,//文字色（白色）
                        BackgroundColor = UIColor.Black,//背景色（オレンジ色）
                        Font = UIFont.FromName("Courier-Italic", 20f) //フォント Courier 35ポイント

                     };
                    NSString stn = new NSString(str1);
                    CGSize sz1 = stn.GetSizeUsingAttributes(attr);

                    stn.DrawString(new CGPoint(pX3 + bX - sz1.Width / 2, pY3 + bX - sz1.Height / 2), attr);



                    var pathT = new CGPath();
                    CGPoint p1t = new CGPoint(pX1 + bX, pY1 + bX);
                    CGPoint p2t = new CGPoint(pX2 + bX, pY2 + bX);

                    pathT.AddLines(new CGPoint[]{
                                 p1t,
                                 p2t,
                                  });
                    g.AddPath(pathT);
                    g.DrawPath(CGPathDrawingMode.FillStroke);

                }


           
                double r = bX * .85;
                double kak = Element.minAngle + (val - minV) * xx;
                double pX = -1 * r * Math.Sin(kak * (Math.PI / 180));
                double pY = r * Math.Cos(kak * (Math.PI / 180));

                g.SetStrokeColor(UIColor.Blue.CGColor);//線色の指定（青色）
                g.SetLineWidth(4);//線の太さ
                g.SetFillColor(255, 0, 0, 1);//塗りつぶし色の指定（薄い青色）

                var path = new CGPath();
                CGPoint p1 = new CGPoint(bX, bX);
                CGPoint p2 = new CGPoint(pX + bX, pY + bX);
                path.AddLines(new CGPoint[]{
                                p1,
                                p2,
                        });
                g.AddPath(path);
                g.DrawPath(CGPathDrawingMode.FillStroke);

                System.Diagnostics.Debug.WriteLine(">>> " + kak.ToString() + " " + pX.ToString() + " " + pY.ToString());


                //value string
                if (Element.viewvalu)
                {
                    NSString stn = new NSString(val.ToString() + Element.unitString);
                    var attr = new UIStringAttributes
                    {
                        ForegroundColor = UIColor.White ,//文字色
                        BackgroundColor = UIColor.Clear,//背景色
                        Font = UIFont.FromName("Courier-Italic", Element.valuestringSize) //フォント Courier 20ポイント
                    };
                    CGSize sz1 = stn.GetSizeUsingAttributes(attr);
                    stn.DrawString(new CGPoint(bX + bX * .1, bX+bX*.2), attr);



                }


            }



        }




    }
}