using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp
{
    public partial class Chap51_abstraction : Form
    {

        #region <0. 추상 화의 정의 와 abstract> 
        /* 
           추상화
           구현해야 하는 기능을 정의만 해 둔다. 추상적으로 기능에 대한 구체적인 로직은 존재 하지 않는 형태. 
           추상 클래스를 상속 받는 클래스는 추상 클래스에 서 정의한 기능을 구현 한다.
           

           * 추상 클래스 의 상속 을 구현 하는 이유 ?
             프로그램 설계 시 설계자가 생각할때는 반드시 구현 해야 하는 기능 이 있는데  (조회, 저장, 삭제, 추가 메서드 등)
             개발자 들이 개발을 할때 일부 기능 을 제외하고 구현 할 수 있는 가능성이 있으며
             개발자 들 마다 각각 다른 명칭(조회 = Search(), Find() ...) 으로 기능을 구현 할 수 있는 경우가 생긴다.
             
             설계자가 생각한 필수 기능(조회,저장 등) 과 기능에 대한 명칭(조회 = Search())을 상속 받아 각 클래스 의 목적 별로 구현 하여
             시스템의 개발에 대한 일관성 을 지키고,  필수 기능 누락 상황을 예방 할 수 있다. 
 
 
         abstract : 메서드 멤버의 재정의 기능 (Override)
         1. 상속 받는 클래스 에서 반드시 구현해야 하는 기능 
         2. 클래스 멤버 중 하나 라도 abstract 형식이면 클래스는 abstract 형식 이어야 한다. (기능 정의의 클래스임을 표현하기 위함)
         3. 메서드의 기능만 정의 하되 구현은 상속 받은 클래스에서 한다. 
            . 메서드의 본문 을 구현 할 수 없다.
         4. abstract 클래스 는 일반 함수 및 필드 멤버를 가질 수 있다.
         5. abstract 클래스 는 인스턴스 화 할수 없다. (기능정의 와 상속이 주 목적)

         **** 상속 받을 클래스 에서 반드시 구현해야 하지만 누락 할 수 있는 가능성이 있는 기능을 
              반드시 구현 하도록 하기 위하여 사용


         virtual  메서드 멤버의 재정의 기능 (Override)
         1. 상속 받는 클래스에서 반드시 구현 하지 않아도 되는 기능
         2. Virtual 메서드가 있더라도 클래스가 Virtual 을 선언 할 필요는 없다. 
         3. 추상적인 기능을 구현후 상속받은 클래스에서 이어서 구현 할 수 있다. 
        */


        public Chap51_abstraction()
        {
            InitializeComponent(); 
            
        }



        #endregion

        #region < 2. 상속 클래스의 기능 실행 및 업 캐스팅 > 
        private void btnabstract_Click(object sender, EventArgs e)
        {
            // abstract 클래스 는 인스턴스 화 할수 없다. (기능정의 와 상속이 주 목적)
            // ToolBar sa = new ToolBar(); 

            //ItemMaster im = new ItemMaster();
            //im.DoInquire();   // ItemMaster 클래스에서 반드시 구현해야 하는 기능을 적용하여 실행.
            //im.DoSave();      // ItemMaster 클래스에서 반드시 구현해야 하는 기능을 적용하여 실행.
            //im.FindNow();     // ToolBar 클래스에서 범용으로 적용된 기능을 실행
            //im.DoPrint();     // ItemMaster 클래스에서 별도로 구현한 메서드 

            // 추상 클래스의 업캐스팅
            // 부모 클래스의 기능 중 자식 클래스가 Override 한 기능을 부모 클래스의 객체로 형변환후 실행 할 수 있다.
            ToolBar tb = new ItemMaster();
            tb.DoInquire();
            tb.DoSave();
            tb.FindNow();
            //tb.DoPrint(); // 부모의 클래스는 자식 클래스가 따로 구현 한 메서드는 실행 할 수 없다. 

        }

        // 업캐스팅을 왜 쓰는 것일까...?
        // 3 과 같이 ToolBar 클래스를 상속 받는 클래스가 여러개 있을경우
        // 품목 조회, 사용자 조회, 작업장 조회 버튼을 클릭 하면 각각 의 조회 기능을 실행 해야 하는 경우

        #endregion

        #region < 4. 업 캐스팅을 통한 추상 메서드 기능 호출. > 
        // 아래 3개의 메서드 는 불필요한 로직이 반복 되어 
        // 메서드 하나로 줄인다.
        //private void btnItemSearch_Click(object sender, EventArgs e)
        //{
        //    ItemMaster IM = new ItemMaster();
        //    IM.DoInquire(); // 품목 정보 조회 기능 실행.
        //}
        //private void btnUserSearch_Click(object sender, EventArgs e)
        //{
        //    사용자 정보 조회 기능
        //    UserMaster UM = new UserMaster();
        //    UM.DoInquire(); // 사용자 정보 조회 기능 실행
        //}

        //private void btnCustSearch_Click(object sender, EventArgs e)
        //{
        //    WorkcenterMaster CM = new WorkcenterMaster();
        //    CM.DoInquire(); // 고객 정보 조회 기능 실행
        //}



        // 리펙토링 : 프로그램 구현에 영향을 주지 않고 간결 하고 효율적인 코드로 꾸미는 작업.
        // 코드 리펙토링 1 번째 단계 
        //private void MenuSearch(object sender, EventArgs e)
        //{
        //    Button button =  sender as Button;
        //    if (button.Name == "btnUserSearch")
        //    {
        //        // 사용자 정보 조회 기능 
        //        UserMaster UM = new UserMaster();
        //        UM.DoInquire(); // 사용자 정보 조회 기능 실행
        //    }

        //    if (button.Name == "btnCustSearch")
        //    {
        //        // 고객 정보 조회 기능
        //        WorkcenterMaster CM = new WorkcenterMaster();
        //        CM.DoInquire(); // 고객 정보 조회 기능 실행
        //    }

        //    if (button.Name == "btnItemSearch")
        //    {

        //        // 품목 정보 조회 기능
        //        ItemMaster IM = new ItemMaster();
        //        IM.DoInquire(); // 품목 정보 조회 기능 실행.
        //    }
        //}



        // 코드 리펙터링 2 번째 단계 
        // 버튼에 Tag 를 두어 클래스를 가변적으로 생성. 
        //private void MenuSearch(object sender, EventArgs e)
        //{
        //    // 1. 버튼의 객체를 생성.
        //    Button button = (Button)sender;
        //    // 2. 찾으려는 클래스의 네임스페이스와 이름.
        //    string sClassName = $"MyFirstCSharp.{button.Tag}";
        //    // 3. 문자열로 클래스를 찾기. 
        //    Type type = Type.GetType(sClassName);
        //    // 4. 해당 클래스 를 인스턴스 화 하기. 
        //    object instence = Activator.CreateInstance(type);

        //    // 품목, 사용자, 고객 클래스 3개중에 하나
        //    // is : instecnce 객체가 itemmaster 클래스로 변환될수 있다면 (true/false)
        //    // if(instence is ItemMaster) 

        //    // as : instence 객체 가 Itemmaster 클래스로 변환 될수 있다면
        //    // 변환하고(ItemMaster IM Stack 메모리에 주소 를 전달하라)
        //    // 안되다면 null을 반환하라
        //    ItemMaster IM = instence as ItemMaster;
        //    if (IM != null)
        //    {
        //        IM.DoInquire(); // 품목마스터 클래스의 조회 기능을 실행.
        //    }

        //    WorkcenterMaster CM = instence as WorkcenterMaster;
        //    if (CM != null)
        //    {
        //        CM.DoInquire(); // 고객 마스터 클래스의 조회 기능을 실행.
        //    }

        //    UserMaster UM = instence as UserMaster;
        //    if (UM != null)
        //    {
        //        UM.DoInquire(); // 사용자 마스터 클래스의 조회 기능을 실행.
        //    }
        //    // 해당 클래스에 있는 기능을 호출 하기 위해서는 
        //    // 해당 클래스 의 객체를 선언 해야 한다. 
        //    // 만약 100 개의 화면이 있을경우 100개의 로직을 구현해 내야 한다.
        //    // 코드가 간결해지지 못하고 확장성 과 유지보수성이 떨어진다.
        //}



        // 코드 리펙터링 3 번째 단계 
        // 다형성을 통한 추상클래스 를 상속 받는 클래스 를 업캐스팅 (패턴).
        private void MenuSearch(object sender, EventArgs e)
        {
            // 1. 버튼의 객체를 생성.
            Button button = (Button)sender;
            // 2. 찾으려는 클래스의 네임스페이스와 이름.
            string sClassName = $"MyFirstCSharp.{button.Tag}";
            // 3. 문자열로 클래스를 찾기. 
            Type type = Type.GetType(sClassName);
            // 4. 해당 클래스 를 인스턴스 화 하기. 
            object instence = Activator.CreateInstance(type);

            // 다형성 을 구현하기 위한 기능 UPCasting
            // UPCasting 을 통한 다형성 등장. 
            // UPCasting : 부모 클래스 로 부터 구현을 정의 받은 기능을 
            //             자식클래스에서 구현하고 자식클래스가 부모 클래스로 형변환 되면서
            //             자식클래스의 기능을 부모 클래스의 객체 가 구현 할 수 있도록 하는 기능. 
            ToolBar TempMenu = instence as ToolBar;
            if (TempMenu != null)
            {
                TempMenu.DoInquire();
            }

            // 다형성 => UPCasting 기능을 통하여 구현.
            //- 어떤 객체의 속성이나 기능이 상황에 따라 여러 가지 형태를 가질 수 있는 성질
            //- 추상 클래스를 상속 받은 자식 클래스들이 부모의 클래스 로 업캐스팅 되어
            //  부모 클래스 형태로
            //  자식 클래스에서 구현한 부모 클래스의 기능을 동작 하도록 제어 하는 방법
            //  자식 클래스들의 기능 구현해야 할때 자식 객체를 N 개 객체화 할 필요가 없게 되므로
            //  코딩을 간결하게 표현 할 수 있다.


            // 추상 클래스 의 상속 과 다형성(업 캐스팅) 의 패턴. 
            // 추상클래스를 상속 받은 자식 클래스의 수가 많을때 에도 
            // 부모 클래스의 기능을 상속 받아 구현한 자식 클래스의 기능을 부모 클래스의 객체로 호출 할 수 있으므로
            // 코드가 간결해 지고
            // 확장성(자식 클래스가 N 개라도 다형성 코드를 수정 할 필요가 없다) 및
            // 유지 보수성(메서드 명칭을 변경 시 다형성 코드 만 수정 하면 됨) 이 확대 된다.

        }
        #endregion
    } 
    #region < 1. 추상 클래스 의 생성 및 상속 >
    // 화면마다 다르게 구현해야 하는 툴바의 기능. 

    public abstract class ToolBar
    { 
        public abstract void DoInquire(); // 반드시 구현해야 하는 메서드 1
        public abstract void DoSave();     // 반드시 구현해야 하는 메서드2 

        public virtual void DoPrint()
        {
            // 상속을 하여 재정의 하지만 반드시 구현 하지 않아도 되는 매서드 
            // virtual
            // 공통으로 처리 할 수 있는 로직을 메서드에서 구현 후 상속 을 주어 
            // 상속 받은 클래스 에서 그 클래스만의 특징 적인 기능을 이어서 구현 하거나 (base)
            // 메서드의 이름만 재정의 하여 사용 할 수 있다. 
            MessageBox.Show("1 로직 처리");
            MessageBox.Show("2 로직 처리");
        }
        public void FindNow() // ToolBar 를 상속받는 클래스 가 범용으로 사용할 일반 메서드.
        {
            MessageBox.Show("현재 시각을 표현합니다.");
        }
    }

    // 툴바 의 기능을 상속 받은 ItemMaster
    public class ItemMaster : ToolBar
    {
        // 부모의 일반 함수 를 오버라이딩 함.
        public override void DoInquire()
        {
            MessageBox.Show("조건에 맞는 품목 을 검색 합니다.");
        }
        public override void DoSave()
        {
            MessageBox.Show("품목 데이터를 저장 합니다.");
        }
        public override void DoPrint()
        {
        
            MessageBox.Show("3 초직 처리");
        }
        public void Print()
        {
            // Itemmaster의 메서드
            MessageBox.Show("화면을 출력합니다.");
        }
    }
    #endregion
     
    #region < 3. 추상클래스를 상속 받는 추가 화면들 > 
    class UserMaster : ToolBar
    {
        // 부모의 일반 함수 를 오버라이딩 함.
        public override void DoInquire()
        {
            MessageBox.Show("사용자 를 검색");
        }
        public override void DoSave()
        {
            MessageBox.Show("사용자 를 추가");
        }
    }

    class WorkcenterMaster : ToolBar
    {
        // 부모의 일반 함수 를 오버라이딩 함.
        public override void DoInquire()
        {
            MessageBox.Show("작업장 검색");
        }
        public override void DoSave()
        {
            MessageBox.Show("작업장 추가");
        }
    }
    #endregion  
}
