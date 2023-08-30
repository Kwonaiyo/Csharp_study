using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp.Lesson06_Intermediate
{
    // 무명 메서드 대신 동일한 역할을 하는 '람다' 식
    // 대리자 또는 식 트리 형식을 만드는데 사용할 수 있는 익명함수 
    // 무명 메서드 를 간단히 표현 하기 위해 사용하는 문법.

    public partial class Chap40_Lambda : Form
    {   
        public Chap40_Lambda()
        {
            InitializeComponent();
        }


        class Delegate_Method
        {
            public static int SetValueSomeMethod(int iValue1, int iValue2, Calculation cal)
            {
                return cal(iValue1, iValue2);
            }
        }


        #region < 람다의 표현 1 > 
        private void btnLambda_Click(object sender, EventArgs e)
        {

            // 람다 식의 기본 형태 
            // (인수 목록) => 로직(식)

            txtMessage.Text += Delegate_Method.SetValueSomeMethod(50, 10, (int x, int y) => { return x - y; }).ToString();
            // int x , int y  인자의 유형과 리턴 타입을 { return x - y; } 로 명명을 해주어야 하는데 

            txtMessage.Text += Delegate_Method.SetValueSomeMethod(50, 10, (x, y) => x - y).ToString();
            // 람다식에서는 형식 유추가 가능하도록 기능화 되어 있어 명시적으로 설정해 줄 필요가 없게 되었다.
            // (x, y) : 델리게이트 에서 int iValue1,2 로 설정해 둠. 

            // 이전 챕터의 델리게이트 에 등록한 메서드 Delegate_Method.SetValueSomeMethod
            txtMessage.Text += Delegate_Method.SetValueSomeMethod(10, 20, (x, y) => x + y).ToString();

            
        }
        #endregion

        #region < 람다의 표현 2 > 
        delegate double Calculation2(int iValue);
        private void btnLambda2_Click(object sender, EventArgs e)
        {
            // 인자 가 하나 일때는 () 를 표시 하지 않아도 된다.
            Calculation2 cal = x => x * 100;
            txtMessage.Text = cal(20).ToString();
        }
        #endregion

        #region < 람다의 표현 3 >

        private void btnLambda3_Click(object sender, EventArgs e)
        {
            // 식이 여러 줄일 경우는 { } 로 로직을 구현 할 수 있다. 
            Calculation2 cal = x =>
            {
                double AddTex  = x * 0.9;

                // 람다식의 반환값의 형식은 대리자의 반환 형식과 일치해야 한다.
                return AddTex; 
            };

            // ==> 위의 무명 메서드는 아래 처럼 표현 할 수 있다.
            Calculation2 cal2 = DoMult;


            txtMessage.Text = cal(12500).ToString() + "\r\n";
            txtMessage.Text += cal2(12500).ToString() + "\r\n";

        }


        private double DoMult(int ivalue)
        {
            double AddTex = ivalue * 0.9;
            return AddTex;
        }
        #endregion 

        #region < 람다의 표현 4 > 
        delegate void Calculation3();
        private void btnLambda4_Click(object sender, EventArgs e)
        {
            // 인자와 인수 가 없는 대리자 정의 시 람다식 도 인수와 반환 식을 작성 하지 않아도 된다
            Calculation3 cal = () => txtMessage.Text = "() => {} 의 표현 람다식";
            cal();

            Calculation3 cal2  = DoMethod;
            cal();
        }

        public void DoMethod()
        {
            txtMessage.Text = "() => {} 의 표현 람다식";
        }
        #endregion


        // Action 과 Func 
        // 미리 정의 되어 있는 대리자 
        // 대리자를 간략하게 표현 할수 있도록 해주는 문법 기능.

        #region < Lambda Action  1 >
        // Action 
        // 반환 형식이 없이(void) 인자만 가지고 있는 메서드 시그니처 대리자 형식
        private void btnAction_Click(object sender, EventArgs e)
        {
            ActionMethod_A("Action 메서드를 호출합니다.", () => txtMessage.Text = "");
            // ActionMetho() 에
            // "Action 메서드를 호출합니다." 라는 문구를 던져줄테니
            // message 라는 인자로 받아 txtMessage.text 에 표현하세요 
        }

        private void ActionMethod_A(string Message, Action Action)
        {
            Action();
        }

        //// ==> 위 ActionMethod_A 의 Action 인자 는 아래의 대리자 구문이 간략 히 표현된 결과이다.
        //delegate void DelegateTest(string Message); 
        //private void ActionMethod_D(string Message, DelegateTest Action)
        //{
        //    Action(Message);
        //}
        #endregion


        #region < Lambda Action  2 > 
        // 인자가 여러개인 Action  
        // ex>  Action<string,int>
        // => delegate void (string sValue, int iValue);

        private void btnAction2_Click(object sender, EventArgs e)
        {
            ActionMethod2("전달받은 값은 : ", 500, (sValue, iValue) => txtMessage.Text = sValue + iValue.ToString());


        }
        private void ActionMethod2(string Message, int iValue, Action<string,int> Action)
        {
            Action(Message,iValue);
        }

        #endregion 


        #region < 인자를 받고 결과 값을 반환하는 델리게이트 Func > 
        // Func<인자 타입1, 인자 타입2, 반환 타입>  
        // * 마지막 부분은 반드시 반환 타입 Func< N 개의 인자 유형 , 반환 데이터유형 >

        // ex> Func<string, int, string>
        // => delegate string (string sValue, int iValue);
        private void btnFunc_Click(object sender, EventArgs e)
        {
            FuncMethod("Func 대리자에 값을 등록 합니다. : ", 500, (sMessage, iValue) =>  sMessage +  iValue);

            // FuncMethod() 에
            // "Func 대리자에 값을 등록 합니다. : " 라는 문구 와 500 정수 값을 던져줄테니
            // 각각  sMessage 는 string, iValue 는 int  형으로 인자를 받아 문자열로 합친후  string 형으로 반환해 주세요
        }

        delegate string Calcual3(string sValue, int iValue);

        private void FuncMethod(string Message, int iValue, Calcual3 func)
        {
            string sResult = func(Message, iValue);
            txtMessage.Text = sResult;
        }

        //private void FuncMethod(string Message, int iValue , Func<string,int,string> func)
        //{
        //    string sResult = func(Message, iValue);
        //    txtMessage.Text =  sResult;
        //}
        #endregion


        #region < 인자를 받지않고 결과 값을 반환하는 델리게이트 Func > 
        // Func<인자 타입1, 인자 타입2, 반환 타입>  
        // * 마지막 부분은 반드시 반환 타입 Func< N 개의 인자 유형 , 반환 데이터유형 >

        // ex> Func<string, int, string>
        // => delegate string (string sValue, int iValue);
        private void btnFunc_Click_2(object sender, EventArgs e)
        {
            FuncMethod_2("Func 대리자에 값을 등록 합니다. : ", 500, () => "10" + "입니다" );

            // FuncMethod() 에
            // "Func 대리자에 값을 등록 합니다. : " 라는 문구 와 500 정수 값을 던져줄테니
            // 각각  sMessage 는 string, iValue 는 int  형으로 인자를 받아 문자열로 합친후  string 형으로 반환해 주세요
        }

        private void FuncMethod_2(string Message, int iValue, Func<string> func)
        {
            string sResult = func();
            txtMessage.Text = sResult;
        }
        #endregion




        #region < Where 메서드 를 이용한 Func 대리자, 람다 호출  >

        // Where ()
        // 조건을 만족 시키는 결과 를 추출 하여 열거형 데이터 로 반환.
        private void btnFuncWhere_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int> { 1,2,3,4,5,6,7,8,9,10}; // 개체 이니셜라이져.
            // 1. Func 대리자를 만들어 Where 인자에 보내 결과 가져오기
            Func<int, bool> func = (n) => n % 2 == 0;
            List<int> ResultList = list.Where(func).ToList();  

            txtMessage.Text = "---------- Func 로 결과 를 반환 ------------\r\n";
            foreach (int item in ResultList)
            {
                txtMessage.Text += item.ToString() + ",";
            }



            // 2. Func 대리자에 담길 메서드를 람다로 만들어 Where 인자에 보내기.
            List<int> ResultList_ = list.Where(n => n % 2 == 0).ToList();  

            txtMessage.Text += "---------- 람다 로 결과 를 반환 ------------\r\n";
            foreach (int item in ResultList_)
            {
                txtMessage.Text += item.ToString() + ",";
            }
        }
        #endregion 
    }
}
