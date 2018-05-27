using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XMAnalogMeter
{
	public partial class MainPage : ContentPage
	{
        int v = 0;
		public MainPage()
		{
			InitializeComponent();
		}

        void btn_click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Clicked");
            analogmeter.Value = v++;

        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            double tMin = analogmeter.minValue;
            double tMax = analogmeter.maxValue;
            double tCN = (tMax - tMin) / 100;

            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {

                    Device.BeginInvokeOnMainThread(() => {
                        analogmeter.Value = tMin + i * tCN;
                    });

                    System.Threading.Thread.Sleep(10);
                }

            }
           );
            System.Threading.Thread.Sleep(200);
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {

                    Device.BeginInvokeOnMainThread(() => {
                    analogmeter.Value = tMax - i * tCN;
                    });

                    System.Threading.Thread.Sleep(5);
                }

            }
            );
            System.Threading.Thread.Sleep(100);

            analogmeter.Value = 0;


        }

    }
}
