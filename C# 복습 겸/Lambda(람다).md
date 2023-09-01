# 람다(Lambda)
무명 메서드 대신 동일한 역할을 하는 람다식<br>
대리자 또는 식 트리 형식을 만드는데 사용할 수 있는 익명함수<br>
무명 메서드를 간단하게 표현하기 위해 사용하는 문법<br>
```cs
public partial class Chap40_Lambda : Form
{
    public Chap40_Lambda()
    {
        InitializeComponent();
    }
    
    delegate int Calculation(int iValue1, int iValue2);

    class Delegate_Method
    {
        public static int SetValueSomeMethod(int iValue1, int iValue2, Calculation cal)
        {
            return cal(iValue1, iValue2);
        }
    }

    #region <람다의 표현 1>
    private void btnLambda_Click(object sender, EventArgs e)
    {
        // 람다식의 기본 형태 :
        // (인수 목록)=>로직(식)

        txtMessage.Text += Delegate_Method.SetValueSomeMethod(50, 10, (int x, int y) => {return x - y;}).ToString();  // int x, int y 인자의 유형과 리턴 타입을 { return x - y; }로 명명해줘야 하는데

        txtMessage.Text += Delegate_Method.SetValueSomeMethod(50, 10, (x, y) => x - y).ToString();  // 람다식에서는 형식 유추가 가능하도록 기능화되어 있어 명시적으로 설정해 줄 필요가 없게 되었다.
        // (x, y) : Delegate에서 int iValue1, int iValue2로 설정해둠.

        // 이전 챕터의 델리게이트에 등록한 메서드 Delegate_Method.SetValueSomeMethod
        txtMessage.Text += Delegate_Method.SetValueSomeMethod(10, 20, (x, y) => x + y).ToString();
    }
    #endregion

    #region <람다의 표현 2>
    delegate double Calculation(int iValue);

    private void btnLambda2_Click(object sender, EventArgs e)
    {
        // 인자가 하나일때는 ()를 표시하지 않아도 된다.
        Calculation cal = x => x * 100;
        txtMessage.Text = cal(20).ToString();
    }
    #endregion

    #region <람다의 표현 3>
    private void btnLambda3_Click(object sender, EventArgs e)
    {
        // 식이 여러 줄일 경우에는 {}로 로직을 구현할 수 있다.
        Calculation2 cal = x =>
        {
            double AddTex = x * 0.9;

            // 람다식의 반환값의 형식은 대리자의 반환 형식과 일치해야한다.
            return AddTex;
        };

        // ==> 위의 무명메서드는 아래처럼 표현할 수 있다.
        Calculation2 cal2 = DoMult;
        
        txtMessage.Text = cal(12500).ToString() + "\r\n";
        txtMessage.Text = cal2(12500).ToString() + "\r\n";
    }

    private double DoMult(int iValue)
    {
        double AddTex = iValue * 0.9;
        return AddTex;
    }
    #endregion

    #region <람다의 표현 4>
    delegate void Calculation3();
    private void btnLambda4_Click(object sender, EventArgs e)
    {
        // 인자와 인수가 없는 대리자를 정의할 시 람다식도 인수와 반환 식을 작성하지 않아도 된다.
        Calculation3 cal = () => txtxMessage.Text = "() => {}의 표현 람다식";
        cal();

        Calculation3 cal2 = DoMethod;
        cal2();
    }

    public void DoMethod()
    {
        txtMessage.Text = "() => {}의 표현 람다식";
    }
    #endregion
}
```

### Action과 Func
+ 미리 정의되어 있는 대리자
+ 대리자를 간략하게 표현할 수 있도록 해주는 문법 기능<br>
+ Action
  - 반환 형식 없이(void) 인자만 가지고 있는 메서드 시그니처 대리자 형식
+ Func
  - 인자를 받고 결과 값을 반환하는 델리게이트
```cs
#region <Lambda Action 1>
private void btnAction_Click(object sender, EventArgs e)
{
    ActionMethod_A("Action 메서드를 호출합니다.", () => txtMessage.Text = "");
    // ActionMethod_A()에 "Action 메서드를 호출합니다." 라는 문구를 인자로 던질테니 message라는 인자로 받아 txtMessage.text에 표현하세요. 라는 의미
}

private void ActionMethod_A(string Message, Action action)
{
    action();
}
// ==> 위 ActionMethod_A의 action 인자는 아래의 대리자 구문이 간략히 표현된 결과이다.
// delegate void DelegateTest(string Message);
// private void ActionMethod_D(string Message, DelegateTest Action)
// {
//     Action(Message);
// }
#endregion

#region <Lambda Action 2>
// 인자가 여러개인 Action
// ex) Action<string, int>
// => delegate void (string sValue, int iValue);

private void btnAction2_Click(object sneder, EventArgs e)
{
    ActionMethod2("전달받은 값은 : ", 500, (sValue, iValue) => txtMessage.Text = sValue + iValue.ToString());
}

private void ActionMethod2(string Message, int iValue, Action<string, int> Action)
{
    Action(Message, iValue);
}
#endregion

#region <인자를 받고 결과값을 반환하는 델리게이트, Func>
// Func<인자 타입1, 인자 타입2, 반환 타입>
// * 마지막 부분은 반드시 반환 타입 :: Func<N개의 인자 유형, 반환 데이터 형식>

// ex) Func<string, int, string>
// => delegate string (string sValue, int iValue);

private void btnFunc_Click(object sender, EventArgs e)
{
    FuncMethod("Func 대리자에 값을 등록합니다. : ", 500, (sMessage, iValue) => sMessage + iValue);

    // FuncMethod()에 "Func 대리자에 값을 등록합니다. : " 라는 문구와 정수 500을 던져줄테니 각각 sMessage는 string, iValue는 int 형식으로 인자를 받아서 문자열로 합친 후 string 형식으로 반환해줘!
}

delegate 
```