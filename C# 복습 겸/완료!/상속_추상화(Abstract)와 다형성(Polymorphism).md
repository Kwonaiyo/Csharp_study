# 추상화(Abstract)와 다형성(Polymorphism)
### 1. 추상화
구현해야 하는 기능을 정의만 해 둔다. 기능에 대한 구체적인 로직은 존재하지 않는 형태(추상적).  
추상 클래스를 상속받는 클래스에서 추상 클래스에서 정의해놓은 기능을 구체적으로 구현한다.

  + 추상클래스의 상속을 구현하는 이유?
  프로그램 설계 시 설계자가 생각한 반드시 구현해야하는 기능이 있는데(ex: 조회, 저장, 삭제 메서드 등) 각 개발자들이 개발을 할 때 일부 기능을 제외하고 구현할 가능성 및 개발자들마다 다른 이름으로 명칭을 사용하여 기능을 구현할 가능성이 매우 크다.  
  따라서 구현해야하는 필수 기능들과 그 기능들에 대한 명칭(EX::: 조회 : Search, 저장 : Save, 삭제 : Delete)을 상속받아 각 클래스의 목적에 맞게 구현하게 함으로써 시스템 개발에 대한 일관성을 지키고, 꼭 구현되어야 하는 기능들의 누락을 방지할 수 있다.  
### 2. abstract : 메서드 멤버의 재정의 기능(override)
1. 상속받는 클래스에서 반드시 구현해야 하는 기능
2. 클래스 멤버 중 하나라도 abstract 형식을 사용했다면 그 클래스또한 abstract 형식이어야 한다.
3. 메서드의 기능만 정의하되 구현은 상속받는 클래스에서 한다(abstract 클래스 내에서 abstract 메서드의 본문을 구현할 수 없다.)
4. abstract 클래스는 일반함수 및 필드멤버를 가질 수 있다.
5. abstract 클래스는 인스턴스화 할 수 없다.(기능정의 및 상속이 주 목적)
   => 상속받을 클래스에서 반드시 구현해야 하지만 누락될 수 있는 가능성이 있는 기능을 반드시 구현하도록 하기위해서 사용.

### 3. virtual : 메서드 멤버의 재정의 기능(override)
1. 상속받는 클래스에서 반드시 구현하지 않아도 되는 기능
2. virtual 메서드가 있더라도 클래스가 virtual을 선언할 필요는 없다.
3. virtual 메서드에 추상적인 기능을 구현 후 상속받은 클래스에서 이어서 구현할 수 있다. 

#### 1. 추상 클래스의 생성 및 상속
```cs
public partial class Abstraction : Form
{
    public Abstraction()
    {
        InitializeComponent();
    }

    public abstract class ToolBar
    {
        public abstract void DoInquire(); // 반드시 구현해야 하는 메서드1
        public abstract void DoSave(); // 반드시 구현해야 하는 메서드2

        public virtual void DoPrint()
        {
            // 상속하여 재정의할 수 있지만 반드시 구현하지는 않아도 되는 메서드
            // virtual로 선언된 메서드에서 공통으로 처리할 수 있는 로직을 구현 후 상속해 줌으로써 상속받은 클래스에서 그 클래스만의 특징적인 기능을 이어서 구현하거나 메서드의 이름만 재정의하여 사용할 수 있다. 
            MessageBox.Show("1번 로직 처리.");
            MessageBox.Show("2번 로직 처리.");
        }

        public void FindNow() // ToolBar를 상속받는 클래스가 범용으로 사용할 일반 메서드. 
        {
            MessageBox.Show("현재 시각을 표현합니다.");
        }
    }

    // ToolBar 클래스를 상속받은 ItemMaster 클래스.
    public class ItemMaster : ToolBar
    {
        public override DoInquire()
        {
            MessageBox.Show("조건에 맞는 품목을 검색합니다.");
        }

        public override DoSave()
        {
            MessageBox.Show("품목 데이터를 저장합니다.");
        }
        // DoInquire()와 DoSave() 메서드는 구현하지 않으면 에러가 발생한다.

        public override void DoPrint()
        {
            MessageBox.Show("3번 로직 처리.");
        }
        // DoPrint() 메서드는 필수로 구현해야 하는 항목은 아니다. -> 구현하지 않아도 에러가 발생하지는 않는다.

        public void Print()
        {
            // ItemMaster의 메서드
            MessageBox.Show("프린트 로직 실행.");
        }
    }
}
```

#### 2. 상속 클래스의 기능 실행 및 업캐스팅
```cs
public partial class Abstraction : Form
{
    private void btnAbstract_Click(object sender, EventArgs e)
    {
        // Toolbar tb = new Toolbar(); => 에러 발생! abstract 클래스(Toolbar)는 인스턴스화 할 수 없다.

        ItemMaster im = new ItemMaster();
        im.DoInquire();
        im.DoSave();
        im.FindNow();
        im.DoPrint();

        // 추상 클래스의 업캐스팅
        // 자식 클래스(ItemMaster)를 부모 클래스(Toolbar)의 객체로 형변환한 후 부모 클래스에서 자식 클래스가 Override한 기능을  사용할 수 있다.
        Toolbar tb = new ItemMaster();
        tb.DoInquire();
        tb.DoSave();
        tb.FindNow();
        // tb.DoPrint(); => 에러발생! 부모 클래스는 자식 클래스가 따로 구현한 메서드는 실행할 수 없다.  
    }
}
```
업캐스팅을 쓰는 이유..?  
1. Toolbar 클래스를 상속받는 클래스가 여러개 있을 경우.
2. 품목 조회, 사용자 조회, 작업장 조회 버튼을 클릭하면 각각의 조회 기능을 실행해야 하는 경우.

#### 3. 추상클래스를 상속받는 추가 화면들
```cs
class UserMaster : ToolBar
{
    // 부모의 일반 함수를 오버라이딩함.
    public override void DoInquire()
    {
        MessageBox.Show("사용자를 검색");
    }

    public override void DoSave()
    {
        MessageBox.Show("사용자를 추가");
    }
}

class WorkcenterMaster : ToolBar
{
    // 부모의 일반 함수를 오버라이딩함.
    public override void DoInqurie()
    {
        MessageBox.Show("작업장 검색");
    }

    public override void DoSave()
    {
        MessageBox.Show("작업장 추가");
    }
}
```

#### 4. 업캐스팅을 통한 추상 메서드 기능 호출.
```cs
// 아래 3개의 메서드는 불필요한 로직이 반복되어 메서드 하나로 줄인다. 
// private void btnItemSearch_Click(object sender, EventArgs e)
// {
//     ItemMaster IM = new ItemMaster();
//     IM.DoInquire();  // 품목 정보 조회 기능 실행
// }
// private void btnUserSearch_Click(object sender, EvnetArgs e)
// {
//     // 사용자 정보 조회 기능
//     UserMaster UM = new UserMaster();
//     UM.DoInquire();  // 사용자 정보 조회 기능 실행
// }
// private void btnCustSearch_Click(object sender, EventArgs e)
// {
//     WorkcenterMaster CM = new WorkcenterMaster();
//     CM.DoInquire();  // 고객 정보 조회 기능 실행
// }

// 리팩토링 : 프로그램 구현에 영향을 주지 않고 간결하고 효율적인 코드로 꾸미는 작업.
// 코드 리팩토링 첫번째 단계
// private void MenuSearch(object sender, EventArgs e)
// {
//     Buttton button = sender as Button;
//     if (buttoon.Name == "btnUserSearch")
//     {
//         // 사용자 정보 조회 기능
//         UserMaster UM = new UserMaster();
//         UM.DoInquire(); // 사용자 정보 조회 기능 실행
//     }
//     if (button.Name == "btnCustSearch")
//     {
//         // 고객 정보 조회 기능
//         WorkcenterMaster CM = new WorkcenterMaster();
//         CM.DoInquire(); // 고객 정보 조회 기능 실행
//     }
//     if (button.Name == "btnItemSearch")
//     {
//         // 품목 정보 조회 기능
//         ItemMaster IM = new ItemMaster();
//         IM.DoInquire(); // 품목 정보 조회 기능 실행
//     }
// } // => 그러나 여전히 코드가 길고 중복되는 부분이 있다.

// 코드 리팩토링 두번째 단계
// private void MenuSearch(object sender, EventArgs e)
// {
//     // 1. 버튼의 객체를 생성한다
//     Button button = (Button)sender;
//     // 2. 찾으려는 클래스의 네임스페이스(MyFirstCSharp)와 이름
//     // 클래스 이름은 button의 Tag에 저장해둔다.
//     string sClassName = $"MyFirstCSharp.{button.Tag}";
//     // 3. 문자열로 클래스를 찾기
//     Type type = Type.GetType(sClassName)
//     // 4. 해당 클래스를 인스턴스화 하기.
//     object instance = Activator.CreateInstance(type);
// }

//     // 품목, 사용자, 고객 클래스 3개 중 하나
//     // is : instance 객체가 ItemMaster 클래스로 변환될 수 있다면 (True/False)
//     // if(instance is ItemMaster)

//     // as : instance 객체가 ItemMaster 객체로 변환될 수 있다면 변환하고(ItemMaster IM Stack 메모리에 주소를 전달하라) 안된다면 null을 반환
//     ItemMaster IM = instance as ItemMaster;
//     if (IM != null)
//     {
//         IM.DoInquire(); // 품목마스터 클래스의 조회 기능을 실행.
//     }

//     UserMaster UM = instance as UserMaster;
//     if (UM != null)
//     {
//         UM.DoInquire(); // 사용자마스터 클래스의 조회 기능을 실행.
//     }
//     // 해당 클래스에 있는 기능을 호출하기 위해서는 해당 클래스의 객체를 선언해야 한다.
//     // 만일 100개의 화면이 있을 경우 100개의 로직을 구현해야 한다. 코드가 간결해지지 못하고 확장성 및 유지보수성이 떨어진다.

// 코드 리팩토링 세번째 단계
// 다형성을 통한 추상클래스를 상속받는 클래스를 업캐스팅(패턴)
private void MenuSearch(object sender, EventArgs e)
{
    // 1. 버튼의 객체를 생성.
    Button button = (Button)sender;
    // 2. 찾으려는 클래스의 네임스페이스(MyFirstCSharp)와 이름.
    // 클래스의 이름을 버튼의 태그 속성에 넣어준다.
    string sClassName = $"MyFistCSharp.{button.Tag}";
    // 3. 문자열로 클래스를 찾기.
    Type type = Type.GetType(sClassName);
    // 4. 해당 클래스를 인스턴스화하기.
    object instance = Activator.CreateInsatance(type);

    // 다형성을 구현하기 위한 기능 UpCasting
    // UpCasting을 통한 다형성 등장.
    // UpCasting : 부모 클래스로부터 구현을 정의받은 기능을 자식클래스에서 구현하고 자식클래스가 부모클래스로 형변환 되면서 자식클래스의 기능을 부모클래스의 객체가 구현할 수 있도록 하는 기능.
    ToolBar TempMenu = instance as ToolBar;
    if (TempMenu != null)
    {
        TempMenu.DoInquire();
    }

    // 다형성 => UpCasting 기능을 통하여 구현
    // 어떤 객체의 속성이나 기능이 상황에 따라 여러 가지 형태를 가질 수 있는 성질
    // 추상클래스를 상속받은 자식 클래스들이 부모의 클래스로 업캐스팅되어 부모 클래스 형태로 자식 클래스에서 구현한 부모 클래스의 기능을 동작하도록 제어하는 방법.
    // 자식 클래스들의 기능을 구현해야 할 때 자식 객체를 N개씩 객체화 할 필요가 없게되어 코드를 간결하게 표현할 수 있다. 

    // 추상클래스의 상속과 다형성(업캐스팅)의 패턴
    // 추상클래스를 상속받은 자식클래스의 수가 많을때에도 부모 클래스의 기능을 상속받아 구현한 자식클래스의 기능을 부모클래스의 객체로 호출할 수 있으므로 코드가 간결해지고 확장성(자식클래스가 N개라도 다형성 코드를 수정할 필요가 없다) 및 유지보수성(메서드 명칭을 변경 시 다형성 코드만 수정하면 됨)이 확대된다.
}
```