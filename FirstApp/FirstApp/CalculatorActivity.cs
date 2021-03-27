
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace firstApp {
    [Activity(Label = "Calculator")]
    public class CalculatorActivity :Activity {
        EditText _firstNumber;
        EditText _secondNumber;
        TextView _answerText;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.calculator_layout);


            _firstNumber = FindViewById<EditText>(Resource.Id.first_number);
            _secondNumber = FindViewById<EditText>(Resource.Id.second_number);
            _answerText = FindViewById<TextView>(Resource.Id.answer_text);
            var calculateButton = FindViewById<Button>(Resource.Id.calculate_numbers);

            RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);


            int answer;


            calculateButton.Click += delegate {

                RadioButton chosenRadioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);

                switch(chosenRadioButton.Text) {
                    case "Add":
                        answer = int.Parse(_firstNumber.Text) + int.Parse(_secondNumber.Text);
                        break;
                    case "Deduct":
                        answer = int.Parse(_firstNumber.Text) - int.Parse(_secondNumber.Text);
                        break;
                    case "Divide":
                        answer = int.Parse(_firstNumber.Text) / int.Parse(_secondNumber.Text);
                        break;
                    case "Multiply":
                        answer = int.Parse(_firstNumber.Text) * int.Parse(_secondNumber.Text);
                        break;
                    default:
                        answer = 0;
                        break;
                }

                _answerText.Text = answer.ToString();

            };
        }
    }
}
