# Delegate, AnonymousMethod(대리자, 무명메서드)
1. Delegate(대리자)
- 메서드 시그니처를 정의하는 형식
  + 메서드 시그니처 : 메서드 정의 시 메서드를 다른 메서드와 구분할 수 있도록 해주는 메서드의 구성요소.
  + 메서드 시그니처를 등록 후 델리게이트가 같은 유형의 여러 메서드를 동시에 수행할 수 있도록 해준다.
    - 추상화 클래스와 상속 클래스의 다형성 관계와 비슷한 개념.
    - 메서드 시그니처 생성 후 구현 메서드가 메서드 시그니처 형태로 다형성을 가질 수 있게 하는 기능.
  + 메서드를 참조하는 델리게이트를 인스턴스화한 후 델리게이트 객체의 호출로 메서드를 실행한다.  
    
2. 대리자 선언 방법  
delegate [반환유형] [이름]([인자1], [인자2], ...)

```cs
delegate int Calculation(int iValue1, int iValue2);

class Delegate_Method
{
    public static int SetValueSomeMethod(int iValue1, int iValue2, Calculation cal)
    {
        return cal(iValue1, iValue2);
    }
}

public partial class Delegate_AnonymousMethod : Form
{
    // 델리게이트가 수행할 수 있는 메서드 생성
    private int Plus(int iValue1, int iValue2)
    {
        return iValue1 + iValue2;
    }

    private int Minus(int iValue1, int iValue2)
    {
        return iValue2 - iValue1;
    }

    public Delegate_AnonymousMethod()
    {
        InitializeComponent();
    }

    public static int SetValueSomeMethod(int iValue1, int iValue2, Calculation cal)
    {
        return cal(iValue1, iValue2);
    }
}
```

- 대리자의 기본 용법
```cs
public partial class Delegate_AnonhymousMethod : Form
{
    private void btnCallDelegate_Click(object sender,   EventArgs e)
    {
        // 대리자 호출 버튼 클릭 시 실행되는 로직

        // Calculation 대리자 cal 객체가 Plus 메서드를  수행할 수 있게 됨.
        Calculation cal = new Calculation(Plus);
        textMessage.Text = cal(10, 20).ToString() +     "\r\n"; // => 30

        // Calculation 대리자 cal2 객체가 Minus 메서드를    수행할 수 있게 됨
        Calculation cal2 = new Calculation(Minus);
        textMessage.Text += cal(10, 20).ToString(); // =>   10
    }
}
```  

- 대리자의 응용
```cs
public partial class Delegate_AnonymousMethod : Form
{
    // 메서드 자체를 인수로 전달해야 할 경우 사용
    private void btnCallDelegateMethod_Click(object sender, EventArgs e)
    {
        txtMessage.Text = Delegate_Method.SetValueSomeMethod(10, 20, Plus).ToString();
    }
}
```  

- 무명 메서드(Anonymous Method)
  + 이름이 없는 메서드
  + 일회성으로 호출되고 소멸될 메서드
```cs
public partial class Delegate_AnonymousMethod : Form
{
    private void btnAnonymousMethod_Click(object sender, EventArgs e)
    {
        // delegate 형태로 던져주는 무명 메서드
        txtMessage.Text = Delegate_Method.SetValueSomeMethod(10, 20, delegate(int x, int y){return x+y;}).ToString();

        // 간단한 형식으로 무명메서드를 전달한다. (람다식)
        // 컴파일러가 SetValueSomeMethod의 인자 iValue1, iValue2를 보고 반환 형태를 유추한다.
        txtMessage.Text += Delegate_Method.SetValueSomeMethod(10, 20, (x, y)=>x+y).ToString();
    }
}
```






