using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyFirstCSharp.Lesson06_Intermediate
{

    /*
       Delegate (대리자)
       메서드 시그니처 를 정의하는 형식 
       메서드 시그니처 : 메서드 정의 시 메서드 를 다른 메서드 와 구분 할 수 있도록 해 주는 메서드 의 구성요소

       1. 메서드 시그니처 를 등록 후 델리게이트 가 같은 유형의 여러 메서드를 동시에 수행 할 수 있도록 해준다.
         ????- (추상화 클래스와 상속 클래스의 다형성 관계와 비슷한 개념)
         ????   메서드 시그니처 생성 후 구현 메서드 가 메서드시그니처 형태로 다형성 을 가질 수 있게 하는 기능 
       2. 메서드 를 은닉(Private) 후 델리게이트 가 수행할 수 있도록 할수있다. 
       
       메서드를 참조하는 델리게이트 를 인스턴스 화 후 델리게이트 객체의 호출로 메서드를 실행
     */

    //delegate [반환유형] [이름] ([인자])
    delegate int Calculation(int iValue1, int iValue2);

    public partial class Chap39_Delegate_AnonymousMethod : Form
    { 
        // 델리게이트 가 수행 할수 있는 메서드 생성 
        private int Plus(int iValue1, int iValue2)
        {
            return iValue1 + iValue2;
        }

        private int Minus(int iVale1, int iValue2)
        {
            return iValue2 - iVale1;
        }


        public Chap39_Delegate_AnonymousMethod()
        {
            InitializeComponent();
        }

        #region < 대리자 의 기본 용법 > 
        private void btnCallDelegeate_Click(object sender, EventArgs e)
        {
            // 대리자 호출 버튼 클릭 시 

            // Calculation 대리자 cal 객체 가 Plus 메서드 를 수행할수 있게 됨  
            Calculation cal = new Calculation(Plus); // 생성자를 통한 초기화 
            txtMessage.Text = cal(10, 20).ToString() + "\r\n";  // 30 
            

            // Calculation 대리자 cal2 객체 가 Plus 메서드 를 수행할수 있게 됨  
            Calculation cal2 = Minus; // 생성자 호출 없이 초기화 
            txtMessage.Text += cal2(10, 20).ToString(); // 10
        }
        #endregion  

        #region < 대리자의 응용 > 
        // 메서드 자체 를 인수로 전달해야 할 경우 사용. 
        private void btnCallDelegateMethod_Click(object sender, EventArgs e)
        {
            txtMessage.Text = Delegate_Method.SetValueSomeMethod(10, 20, Plus).ToString();
        }
        #endregion

        #region < 무명 메서드 Anonymous Method > 
        // 이름이 없는 메서드 
        // 일회성으로 호출 되고 소멸 될 메서드 

        private void btnAnonymousMethod_Click(object sender, EventArgs e)
        {  
            // delegate 형태 로 던져주는 무명 메서드 
            txtMessage.Text = Delegate_Method.SetValueSomeMethod(10, 20, delegate (int x, int y) { return x + y; }).ToString();

            // 간단한 형식으로 무명 메서드 를 전달 (람다식) - 다음 Chap 에서 설명
            // 컴파일러 가 SetValueSomeMethod 의 인자 iValue1,2 를 보고 반환 형태를 유추함.
            txtMessage.Text += Delegate_Method.SetValueSomeMethod(10, 20, (x, y) => x + y).ToString();
            
        }

        #endregion

    }  
    
    class Delegate_Method
    {
        public static int SetValueSomeMethod(int iValue1, int iValue2, Calculation cal)
        {   
            return cal(iValue1, iValue2);
        }
    }
}
