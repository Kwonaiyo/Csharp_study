using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Task
{
    internal class Chap49_Thread
    {
        // 메인 프로세스 를 종료 시키기 위하여 ctr + F5 로 실행 한다.

        // Thread : https://kukuta.tistory.com/361
        // ThreadPool : https://kukuta.tistory.com/362 

        // 스레드 (Thread : 프로세스 내부에서 생성되는 실제로 작업을 하는 주체(스레드) 를 추가 생성 함으로서 
        //                  하나의 프로세스(Main) 외에  여러가지 일을 동시에 수행 하는 기능
        //                  메인 프로세스와는 별개로 개별적인 리소스(컴퓨터상의 메모리 1.4M ) 를 가지고 구동 - 비동기)



        #region < 스레드 가 공통 으로 수행할 메서드 > 
        // 반환 결과 와 인자 를 가지지 않는 메서드
        private void subMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("S : " + i);
                Thread.Sleep(1000);
            }
        }

        // 반환 결과 가 없고 인자를 가지는 메서드
        private void ThreadMethod_Param(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{obj} : " + i);
                Thread.Sleep(1000);
            }
        }
        #endregion 


        #region < 기본 Thread 예문 > 
        public void RunThread()
        {
            // Thread 의 생성 과 Thread 가 실행할 델리게이트 메서드 인수 
            Thread myThread = new Thread(subMethod);
            myThread.Start();

            // Thread 로 실행 할 수 있는 메서드 의 유형 

            ////// =>
            //Thread mythread2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("S : " + i);
            //        Thread.Sleep(100);
            //    }
            //});
        }
        public void RunThread2()
        {
            // 인자 를 받는 메서드를 실행하는 스레드
            Thread thr = new Thread(ThreadMethod_Param);

            // ThreadStart MyThread = new ThreadStart(() => Console.WriteLine("안녕하세요"));
            // 1. 리턴 타입이 void다.
            // 2. 메소드의 인자가 없거나(ThreadStart), object 타입이어야 한다.(ParameterizedThreadStart)

            thr.Start("S");

            // Thread 의 Name 부여 
            thr.Name = "Test_Thread";
            Console.WriteLine(thr.Name);

            //// 현재 스레드의 ID 확인하기. 
            Console.WriteLine(thr.ManagedThreadId);


            //// 스레드의 실행여부 확인.
            if (thr.IsAlive) // 스레드가 구동 중이라면. 
            {
                Console.WriteLine(thr.Name + " Start");
            }

            //스레드 종료 까지 대기
            // 스레드의 내용을 모두 수행 한 후 메인 프로세스 를 동작 한다.
            //thr.Join();

            
            thr.Abort(); // 생성 스래드 종료. 
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("M : " + i);
                Thread.Sleep(100);
            }
            //Console.WriteLine("메인스레드 종료");
        }
        #endregion

        #region < Backgroud Thread 예문 > 
        public void BackGroundRunThread()
        {
            // BackGround Thread 로 설정 시 메인 스레드 종료 되면 
            // 서브 스레드가 동시에 종료된다
            Thread myThread = new Thread(subMethod);
            myThread.IsBackground = true;
            myThread.Start();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("M : " + i);
                Thread.Sleep(100);
            }
            Console.WriteLine("메인스레드 종료");
        }
        #endregion 

        #region < Thread Pool >   
        public void RunThreadPool()
        {
            /* Thread 가 생성 및 삭제 될때 다음과 같은 과정이 실행된다. 

               스레드 생성 시 작업:
               스레드의 실행 컨텍스트(레지스터 값, 스택 등)를 초기화
               스레드 우선순위 설정
               스레드 식별자 할당
               스레드 관련 자원 초기화
               스레드 소멸 시 작업:
               
               스레드 실행 종료
               스레드의 자원 반납
               스레드 관련 자원 정리
            
               Thread 가 연속적으로 생성되고 삭제 되는 경우 
               오버 헤드(시스템 자원 과 CPU 의 시간이 소비되는 현상.) 가 발생  
               
               스레드를 반복적으로 생성 및 삭제 할 경우 ThreadPool 을 이용할 수 있다. 
               ThreadPool 의 동작 원리 
               1. 초기화: ThreadPool은 처음에 일정 수의 스레드를 생성하여 스레드 풀에 추가
                          이때 생성하는 스레드의 수는 시스템의 코어 수나 설정에 따라 다름.

               2. 작업 추가: 개발자가 ThreadPool에 작업을 추가하면 
                             (ThreadPool.QueueUserWorkItem 메서드를 호출하여) 
                             ThreadPool은 작업을 큐에 저장.

               3. 작업 할당: ThreadPool은 큐에 저장된 작업을 순서대로 가져와서 
                             사용 가능한 스레드 중 하나에게 작업을 할당. 
                             스레드 풀에 있는 스레드들은 대기 상태로 있으며, 
                             ThreadPool은 이들 중에서 작업을 처리할 스레드를 선택

               4. 작업 실행: 선택된 스레드가 해당 작업을 실행합니다. 
                             작업이 완료되면 스레드는 다시 스레드 풀에 반환.

               5. 스레드 재사용: 스레드가 작업을 완료하면 스레드 풀에 다시 대기 상태로 들어가며, 
                                 ThreadPool은 이 스레드를 다시 사용하여 다음 작업을 처리. 


               장점 : 재사용이 가능한 스레드의 집합을 생성 하여 관리 할 수 있다. 
                     (스레드 수행 후 삭제하지 않고 대기 상태로 둠)
                     시스템 자원을 정해진 만큼만 사용하므로 효율적 . 

               단점 : . 백그라운드 에서 동작하므로 메인 스레드 종료 시 동시에 작업이 종료 된다. 
                      . 스레드 의 Name 을 부여 할 수 없다. 
                      . 추가한 스레드 를 선택적으로 재 사용 할 수 없다. 
            */
            ThreadPool.QueueUserWorkItem(ThreadMethod_Param, "F");
            ThreadPool.QueueUserWorkItem(ThreadMethod_Param, "S");


            // 메인 프로세스가 끝나지 않도록 홀딩하기 위하여 ReadLine 으로 처리
            Console.ReadLine(); 
        } 
        #endregion 
    }
}
