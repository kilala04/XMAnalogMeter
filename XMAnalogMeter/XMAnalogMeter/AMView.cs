using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

// 指定したassemblyにinternal要素へのアクセスを許可する
[assembly: InternalsVisibleTo("XMAnalogMeter.iOS")]
namespace XMAnalogMeter
{
    public class AMView : View
    {



        // BindablePropertyを追加

        //Value　表示する値
        public static readonly BindableProperty ValueProperty =
                               BindableProperty.Create(nameof(Value), typeof(double), typeof(AMView), (double)0,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).Value = (double)newValue);
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        //minValue 最小値
        public static readonly BindableProperty minValueProperty =
                               BindableProperty.Create(nameof(minValue), typeof(double), typeof(AMView), (double)0,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).minValue = (double)newValue);
        public double minValue
        {
            get { return (double)GetValue(minValueProperty); }
            set { SetValue(minValueProperty, value); }
        }

        //maxValue　最大値
        public static readonly BindableProperty maxValueProperty =
                               BindableProperty.Create(nameof(maxValue), typeof(double), typeof(AMView), (double)100,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).maxValue = (double)newValue);
        public double maxValue
        {
            get { return (double)GetValue(maxValueProperty); }
            set { SetValue(maxValueProperty, value); }
        }


        //minAngle value=minValue のときの角度（真下が0）
        public static readonly BindableProperty minAngleProperty =
                               BindableProperty.Create(nameof(minAngle), typeof(double), typeof(AMView), (double)0,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).minAngle = (double)newValue);
        public double minAngle
        {
            get { return (double)GetValue(minAngleProperty); }
            set { SetValue(minAngleProperty, value); }
        }



        //maxAngle value=MaxValue のときの角度（真下が360）
        public static readonly BindableProperty maxAngleProperty =
                               BindableProperty.Create(nameof(maxAngle), typeof(double), typeof(AMView), (double)270,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).maxAngle = (double)newValue);
        public double maxAngle
        {
            get { return (double)GetValue(maxAngleProperty); }
            set { SetValue(maxAngleProperty, value); }
        }


        //tickValue 目盛間隔
        public static readonly BindableProperty tickValueProperty =
                               BindableProperty.Create(nameof(tickValue), typeof(double), typeof(AMView), (double)10,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).tickValue = (double)newValue);
        public double tickValue
        {
            get { return (double)GetValue(tickValueProperty); }
            set { SetValue(tickValueProperty, value); }
        }


        //meterSize メーターのサイズ
        public static readonly BindableProperty meterSizeProperty =
                               BindableProperty.Create(nameof(meterSize), typeof(double), typeof(AMView), (double)150,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).meterSize = (double)newValue);
        public double meterSize
        {
            get { return (double)GetValue(meterSizeProperty); }
            set { SetValue(meterSizeProperty, value); }
        }

        //値表示
        public static readonly BindableProperty viewvalueProperty =
                               BindableProperty.Create(nameof(viewvalu), typeof(Boolean), typeof(AMView), (Boolean)true,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).viewvalu = (Boolean)newValue);
        public Boolean viewvalu
        {
            get { return (Boolean)GetValue(viewvalueProperty); }
            set { SetValue(viewvalueProperty, value); }
        }

        //値の文字のサイズ（ポイント）
        public static readonly BindableProperty valuestringSizeProperty =
                               BindableProperty.Create(nameof(valuestringSize), typeof(float), typeof(AMView), (float)20,
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).valuestringSize = (float)newValue);
        public float valuestringSize
        {
            get { return (float)GetValue(valuestringSizeProperty); }
            set { SetValue(valuestringSizeProperty, value); }
        }


        //unitString 表示単位
        public static readonly BindableProperty unitStringProperty =
                               BindableProperty.Create(nameof(unitString), typeof(string), typeof(AMView), (string)"",
                                                       propertyChanged: (bindable, oldValue, newValue) =>
                                                          ((AMView)bindable).unitString = (string)newValue);
        public string unitString
        {
            get { return (string)GetValue(unitStringProperty); }
            set { SetValue(unitStringProperty, value); }
        }







    }
}
