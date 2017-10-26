using Android.App;
using Android.Widget;
using Android.OS;
using System;
using static Android.Views.View;
using Android.Views;

namespace AndroidFieldsCalc
{
    [Activity(Label = "AndroidFieldsCalc", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnClickListener
    {
        public void OnClick(View v)
        {
            TextView aTxt = FindViewById<TextView> (Resource.Id.editTextA);
            TextView opTxt = FindViewById<TextView> (Resource.Id.editTextOp);
            TextView bTxt = FindViewById<TextView> (Resource.Id.editTextB);
            TextView resTxt = FindViewById<TextView> (Resource.Id.editTextRes);

            int a = Int32.Parse(aTxt.Text);
            int b = Int32.Parse(bTxt.Text);
            char op = Convert.ToChar(opTxt.Text);
            try
            {
                resTxt.Text = calc(a, b, op).ToString();
            }
            catch (DivideByZeroException)
            {
                resTxt.Text = "∞";
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            FindViewById<Button>(Resource.Id.buttonRes).SetOnClickListener(this);            

        }

        private int calc(int a, int b, char op)
        {
            int res = 0;
            if (op == '+')
                res = a + b;
            if (op == '-')
                res = a - b;
            if (op == '*')
                res = a * b;
            if (op == '/')
                if (b == 0)
                    throw new DivideByZeroException();
                else
                    res = a / b;
            return res;

            //∞
        }
    }
}

