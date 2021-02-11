using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp
{
    [Activity(Label = "CalculatorActivity")]
    public class CalculatorActivity : Activity
    {
        EditText _firstField;
        EditText _secondField;
        TextView _answerText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.calculator_layout);

            _firstField = FindViewById<EditText>(Resource.Id.firstField);
            _secondField = FindViewById<EditText>(Resource.Id.secondField);
            _answerText = FindViewById<TextView>(Resource.Id.answerText);
            var calcButton = FindViewById<Button>(Resource.Id.asdasd);
            calcButton.Click += CalcButton_Click;
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            _answerText.Text = (int.Parse(_firstField.Text) + int.Parse(_secondField.Text)).ToString();
        }
    }
}