using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

// 指定したassemblyにinternal要素へのアクセスを許可する
[assembly: InternalsVisibleTo("XMAnalogMeter.iOS")]
namespace XMAnalogMeter
{
    public class AMView2 : View
    {
        // BindablePropertyを追加

        //Value　表示する値
        public static readonly BindableProperty ValueProperty =
                               BindableProperty.Create(nameof(Value), typeof(double), typeof(AMView2), (double)0,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).Value = (double)newValue);
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        //minValue 最小値
        public static readonly BindableProperty minValueProperty =
                               BindableProperty.Create(nameof(minValue), typeof(double), typeof(AMView2), (double)0,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).minValue = (double)newValue);
        public double minValue
        {
            get { return (double)GetValue(minValueProperty); }
            set { SetValue(minValueProperty, value); }
        }

        //maxValue　最大値
        public static readonly BindableProperty maxValueProperty =
                               BindableProperty.Create(nameof(maxValue), typeof(double), typeof(AMView2), (double)100,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).maxValue = (double)newValue);
        public double maxValue
        {
            get { return (double)GetValue(maxValueProperty); }
            set { SetValue(maxValueProperty, value); }
        }



        //unitString 表示単位
        public static readonly BindableProperty unitStringProperty =
                               BindableProperty.Create(nameof(unitString), typeof(string), typeof(AMView2), (string)"",
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).unitString = (string)newValue);
        public string unitString
        {
            get { return (string)GetValue(unitStringProperty); }
            set { SetValue(unitStringProperty, value); }
        }


        //meterSize メーターのサイズ
        public static readonly BindableProperty meterSizeProperty =
                               BindableProperty.Create(nameof(meterSize), typeof(double), typeof(AMView2), (double)150,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).meterSize = (double)newValue);
        public double meterSize
        {
            get { return (double)GetValue(meterSizeProperty); }
            set { SetValue(meterSizeProperty, value); }
        }



        //値表示
        public static readonly BindableProperty viewvalueProperty =
                               BindableProperty.Create(nameof(viewvalu), typeof(Boolean ), typeof(AMView2), (Boolean)true,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).viewvalu = (Boolean)newValue);
        public Boolean viewvalu
        {
            get { return (Boolean)GetValue(viewvalueProperty); }
            set { SetValue(viewvalueProperty, value); }
        }

        //ベースカラー
        public static readonly BindableProperty basecolorProperty =
                               BindableProperty.Create(nameof(basecolor), typeof(Color), typeof(AMView2), (Color)Color.LightGray ,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).basecolor = (Color)newValue);
        public Color  basecolor
        {
            get { return (Color)GetValue(basecolorProperty); }
            set { SetValue(basecolorProperty, value); }
        }


        //値カラー
        public static readonly BindableProperty valuecolorProperty =
                               BindableProperty.Create(nameof(valuecolor), typeof(Color), typeof(AMView2), (Color)Color.Cyan ,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).valuecolor = (Color)newValue);
        public Color valuecolor
        {
            get { return (Color)GetValue(valuecolorProperty); }
            set { SetValue(valuecolorProperty, value); }
        }

        //境界カラー
        public static readonly BindableProperty linecolorProperty =
                               BindableProperty.Create(nameof(linecolor), typeof(Color), typeof(AMView2), (Color)Color.Red,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).linecolor = (Color)newValue);
        public Color linecolor
        {
            get { return (Color)GetValue(linecolorProperty); }
            set { SetValue(linecolorProperty, value); }
        }

      
        //値の文字のサイズ（ポイント）
        public static readonly BindableProperty valuestringSizeProperty =
                               BindableProperty.Create(nameof(valuestringSize), typeof(float), typeof(AMView2), (float)20,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView2)bindable).valuestringSize = (float)newValue);
        public float valuestringSize
        {
            get { return (float)GetValue(valuestringSizeProperty); }
            set { SetValue(valuestringSizeProperty, value); }
        }

    }
}
