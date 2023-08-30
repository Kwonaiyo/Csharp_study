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

      /*
        상속
        클래스 에 있는 기능을 물려 주어(부모 클래스)
        상속 받은 클래스(자식 클래스) 는 부모 클래스의 기능을 모두 사용 할 수 있으면서
        추가로 더 많은 기능을 구현 하여 적용 할 수 있도록 하는 기능.
     */ 
    public partial class Chap16_Inheritance : Form
    {


        public Chap16_Inheritance()
        {
            InitializeComponent();
        }
         

        #region < 상속 > 
     
        class Parents
        {
            public string sParants = "부모 전역 문자열 변수";
            private string sPriParent = "부모 전역 문자열 private 변수";
            public void ParentsMethod()
            {
                MessageBox.Show("부모 클래스의 메서드를 호출합니다.");
            }
        }

        // Parents 클래스를 상속 받은 Child 클래스.
        class Chid : Parents
        {
            public string sChild = "자식 전역 문자열 변수";
            public void ChildMethod()
            {
                MessageBox.Show("자식 클래스의 메서드를 호출 하였습니다.");
            }
        }
        private void btnInheritance_Click(object sender, EventArgs e)
        {
            Chid child = new Chid();
            MessageBox.Show(child.sParants); // 부모 전역 변수 호출 가능.
            //child.sPriParent //부모 클래스의 프라이빗 멤버는 접근 할 수 없다.
            MessageBox.Show(child.sChild);   // 자신 전역 변수 호출
            child.ParentsMethod();    // 부모 메서드 호출 가능 
            child.ChildMethod();      // 자신 메서드 호출 
        }
        #endregion

        #region < 랜덤 클래스의 상속 > 
        private void btnRandomInhe_Click(object sender, EventArgs e)
        {
            MyRandom myrandom = new MyRandom();
            int iResult = 0;
            iResult = myrandom.Next(0, 100); // Random 클래스의 next 기능을 이용하여 난수 리턴.
            iResult = myrandom.ReturnRandomNum(); // 0~ 10 까지의 난수 반환받는 기능 
        }
        // 상속의 사용 예제
        class MyRandom : Random
        {
            // random 클래스를 상속 
            public int ReturnRandomNum()
            {
                // base : 부모 클래스를 지칭. 
                return base.Next(0, 11);
            }
        }

        // sealed 를 통하여 상속 에 대한 접근을 제한 할 수있다.
        //class Mystring : String
        //{

        //}

        // sealed 클래스의 생성 
        //sealed  class SealedClass
        //{

        //}
        // sealed 부모 클래스를 상속 받지 못함.
        //class MyClass : SealedClass
        //{

        //}
        #endregion

        #region < Shdoing > 
        private string sMessage = "Hello";
        private void btnShdoing_Click(object sender, EventArgs e)
        {
            // 섀도잉
            // 동일한 클래스의 전역 변수가 지역변수 와 이름이 같을 때 현재 흐름에 가까운 변수로 처리 하는 상태.
            string sMessage = "World";
            MessageBox.Show(sMessage);

            // sMessage가 전역변수로는 Hello 로 초기화 되어있고
            // 지역변수 로는 World 가 초기화 되어있을경우 
            // 메세지 박스는 지역변수 를 표현한다. 
            // 전역 변수 가 지역변수 에게 가려졌다고 하여 섀도잉 이라고 한다.
        }
        #endregion

        #region < Hiding > 
        private void btnHiding_Click(object sender, EventArgs e)
        {
            new ClassHiding().ParentsMethod();
        }

        // Hiding
        // Parents 클래스 를 상속 받은 ClassHiding 클래스 에서
        // Parents 클래스 에있는 메서드 ParentsMethod() 의 이름과 같은 메서드 를 구현 할 경우 
        // 상속 받은 ClassHiding 클래스 의 메서드 ParentsMethod() 기능이 동작하여 부모 클래스의 메서드 나 필드가 숨겨진다 하여 하이딩 이라고 한다.
        class ClassHiding : Parents
        {

            // 1. Hiding
            //public void ParentsMethod()
            //{
            //    MessageBox.Show("부모 클래스의 메서드 가 하이딩 되어 자식 클래스 메서드의 내용이 표현 됩니다.");
            //}


            //// 2. New 를 통한 자식 클래스만의 메서드 임을 표시
            //public new void ParentsMethod()
            //{
            //    MessageBox.Show("new : 자식 클래스 의 메서드 임을 선언합니다.");
            //}

            //// 3. override 를 통한 자식 클래스만의 메서드 임을 표시(추상화 와 다형성은 다음챕터에서 설명)
            //public override void ParentsMethod()
            //{
            //    MessageBox.Show("override : abstract 또는 virtual 메서드를 상속 받을 경우 부모 클래스의 메서드를 재 정의 함을 선언합니다. ");
            //}
        }
        #endregion
    }

}

