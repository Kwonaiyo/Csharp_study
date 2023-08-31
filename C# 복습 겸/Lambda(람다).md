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
    
    
}
```
