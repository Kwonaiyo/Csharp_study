using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadControl
{

    // https://kukuta.tistory.com/366?category=993856



    class MyClass
    {
        static void Main(string[] args)
        {
            // 메인 프로세스 를 종료 시키기 위하여 ctr + F5 로 실행 한다. 
            new TaskTest_AsyncAwait().RunTask();
        }
    }



    #region < ContinueWith 를 통한 연속 Task 메서드 실행의 단점..  > 
    class TaskTest_Continuewith
    { 
        public void RunTask()
        {
            Task<int> task = Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"Sub_Thread Running {i}... ");
                    result += 1;
                }
                return result;
            });

            // 연속 작업을 위해 ContinueWith 기능 사용시 메서드 또는 (무명메서드) 를 호출해야 하는 번거로움이 있다. 
            Action<Task<int>> action = (taskresult) => Console.WriteLine($"{taskresult.Result} 의 결과값을 표현합니다.");
            task.ContinueWith(action);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine($"Main_Thread Running {i}... ");
            }
            Console.ReadLine();
        }
    }
    #endregion



    #region < AsyncAwait 를 통한 연속 Task 메서드 실행  >  
    // Continue() 처럼 별도의 메서드를 만들어 호출하는 방식이 아닌
    // 마치 동기적 흐름처럼 프로그래밍하면서 비동기 프로그램을 구현하는 문법

    class TaskTest_AsyncAwait
    {
        // Task 의 결과를 받아 다음 내용을 진행할 로직 메서드 생성. 
        private async void AsyncMethod()
        {
            Task<int> task = Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine($"Sub_Thread Running {i}... ");
                    result += 1;
                }
                return result;
            });

             int Task_Result = await task;

            Console.WriteLine($"await 를 통한 비동기 결과 후 바로 실행 문 {Task_Result}");
        } 
        public void RunTask()
        {
            
            // 서브 브로세스 가 실행 할 로직
            AsyncMethod();
            
            
            // 메인 프로세스 가 실행 할 로직
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Main_Thread Running {i}... ");
            }
            Console.ReadLine();
        }

        /*
          Sub_Thread Running 0...
          Sub_Thread Running 1...
          Main_Thread Running 0...
          Sub_Thread Running 2...
          Sub_Thread Running 3...
          Sub_Thread Running 4...
          Main_Thread Running 1...
          Main_Thread Running 2...
          await 를 통한 비동기 결과 후 바로 실행 문 5
          Main_Thread Running 3...
          Main_Thread Running 4...
        */
    }
    #endregion

    #region < 반환 값이 있는 비동기 메서드 async Task<int> > 
    class TaskTest_ReturnAsyncMethod
    {
        public async Task<int> TaskMethod()
        {
            int ThreadId = 0;
            Task task =  Task.Run(() =>
            {
                ThreadId = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{ThreadId} TaskMethod is Running.. {i}");
                    Thread.Sleep(500);
                }
            });

            await task;
            // await 를 수행 후 서브 스레드가 뒤이어 수행할 로직 
            Console.WriteLine($"{ThreadId} 스레드 가 모든 로직을 완료 하였습니다.");
            return ThreadId;
        }

        public void RunTask()
        {
            // 1서브 스레드 생성 및 실행 
            Task<int> task = TaskMethod();

            // 2서브 스레드 생성 및 실행 
            TaskMethod(); 

            // 메인 프로세스 는 서브 스레드 와 관계없이 수행
            Console.WriteLine($"Main Thread {Thread.CurrentThread.ManagedThreadId} is Close");
        }

        /*
         Main Thread 1 is Close
         5 TaskMethod is Running.. 0
         3 TaskMethod is Running.. 0
         5 TaskMethod is Running.. 1
         3 TaskMethod is Running.. 1
         5 TaskMethod is Running.. 2
         3 TaskMethod is Running.. 2
         5 TaskMethod is Running.. 3
         3 TaskMethod is Running.. 3
         5 TaskMethod is Running.. 4
         3 TaskMethod is Running.. 4
        */


        public void RunTask2()
        {
            // 1서브 스레드 생성 및 실행 
            Task<int> task = TaskMethod();

            Console.WriteLine(task.Result + "Thread Is Close");

            // 2서브 스레드 는 1서브 스레드 가 모든 로직을 수행 후 생성 된다.
            TaskMethod();

            // 메인 프로세스 도 1 서브 스레드가 모든 로직을 수행 후 진행된다.
            Console.WriteLine($"Main Thread {Thread.CurrentThread.ManagedThreadId} is Close");
            Console.ReadLine();
        }
        /*
           3 TaskMethod is Running.. 0
           3 TaskMethod is Running.. 1
           3 TaskMethod is Running.. 2
           3 TaskMethod is Running.. 3
           3 TaskMethod is Running.. 4
           3 스레드 가 모든 로직을 완료 하였습니다.
           3Thread Is Close
           4 TaskMethod is Running.. 0
           Main Thread 1 is Close
           4 TaskMethod is Running.. 1
           4 TaskMethod is Running.. 2
           4 TaskMethod is Running.. 3
           4 TaskMethod is Running.. 4
           4 스레드 가 모든 로직을 완료 하였습니다.

        */
    }
    #endregion















    #region < 비동기 메서드 연속  !!!!!!!!!!!!!!!!! 확인 필요 !!!!!!!!!!!!!!!!!> 

    // 위의 예제를 그대로 가져와서 
    class TaskTest_ReturnAsyncMethod_2
    {
        public async Task<int> TaskMethod()
        {
            int ThreadId = 0;
            await Task.Run(() =>
            {
                ThreadId = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{ThreadId} TaskMethod is Running.. {i}");
                    Thread.Sleep(500);
                }
            });
            return ThreadId;
        }

        public void RunTask()
        {
            // 각 Task 에 대한 결과 값을 받아와 처리 할 때.
            Console.WriteLine($"Main Thread {Thread.CurrentThread.ManagedThreadId} 이 시작합니다.");

            // Resut 를 받아와서 처리하는 부분이 있다면.
            int Task1Result = TaskMethod().Result;
            Console.WriteLine($"{Task1Result} Thread 가 종료 되었습니다. ");
            int Task2Result = TaskMethod().Result;
            Console.WriteLine($"{Task2Result} Thread 가 종료 되었습니다. ");

            Console.WriteLine($"Main Thread {Thread.CurrentThread.ManagedThreadId} 이 종료 되었습니다.");
            Console.ReadLine();
        }

        /* 비동기 가 의미가 없는 동기적 결과가 도출 된다.
         
         Main Thread 1 이 시작합니다.
         3 TaskMethod is Running.. 0
         3 TaskMethod is Running.. 1
         3 TaskMethod is Running.. 2
         3 TaskMethod is Running.. 3
         3 TaskMethod is Running.. 4
         3 Thread 가 종료 되었습니다.
         4 TaskMethod is Running.. 0
         4 TaskMethod is Running.. 1
         4 TaskMethod is Running.. 2
         4 TaskMethod is Running.. 3
         4 TaskMethod is Running.. 4
         4 Thread 가 종료 되었습니다.
         Main Thread 1 이 종료 되었습니다.

        */
    }





    class TaskTest_AsyncMethod
    {
        private async Task async_TaskMethod()
        {
            // await 를 통한 비동기 처리 를 연속으로 적용 시 동기적으로 실행 됨.
            await Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"A TaskMethod {Thread.CurrentThread.ManagedThreadId} is Running.. {i}");
                    Thread.Sleep(500);
                    result += i;
                }
            });

            await Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"B TaskMethod {Thread.CurrentThread.ManagedThreadId} is Running.. {i}");
                    Thread.Sleep(500);
                    result += i;
                }
            });

            await Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"C TaskMethod {Thread.CurrentThread.ManagedThreadId} is Running.. {i}");
                    Thread.Sleep(500);
                    result += i;
                }
            }); 

        }

        public void RunTask()
        {
            async_TaskMethod();
            Console.ReadLine();
        }

        /*
            A , B , C 의 Task 가 동기적으로 실행 된다.    

            A TaskMethod 3 is Running.. 0
            A TaskMethod 3 is Running.. 1
            A TaskMethod 3 is Running.. 2
            B TaskMethod 4 is Running.. 0
            B TaskMethod 4 is Running.. 1
            B TaskMethod 4 is Running.. 2
            C TaskMethod 3 is Running.. 0
            C TaskMethod 3 is Running.. 1
            C TaskMethod 3 is Running.. 2

            * ThreadPool 이 C Task 를 처리 하면서 다시 3번의 ThreadId 를 부여 받는것을 확인 할 수있다.
        */
         
    }


    class TaskTest_AsyncMethod_2
    {
        private async Task async_TaskMethod()
        {
            // .ConfigureAwait(false) 를 통하여 비동기 스레드 로 실행 설정
            await Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"A TaskMethod {Thread.CurrentThread.ManagedThreadId} is Running.. {i}");
                    Thread.Sleep(500);
                    result += i;
                }
            }).ConfigureAwait(false);

            await Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"B TaskMethod {Thread.CurrentThread.ManagedThreadId} is Running.. {i}");
                    Thread.Sleep(500);
                    result += i;
                }
            }).ConfigureAwait(false);

            await Task.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"C TaskMethod {Thread.CurrentThread.ManagedThreadId} is Running.. {i}");
                    Thread.Sleep(500);
                    result += i;
                }
            }).ConfigureAwait(false);

            //

        }

        public void RunTask()
        {
            //// ConfigureAwait(false) 함수를 이용하면 독립적인 ThreadPool 에서 Task 를 실행한다. 
            async_TaskMethod();
            Console.ReadLine();
        }

        /*
            A , B , C 의 Task 가 동기적으로 실행 된다.    

            A TaskMethod 3 is Running.. 0
            A TaskMethod 3 is Running.. 1
            A TaskMethod 3 is Running.. 2
            B TaskMethod 4 is Running.. 0
            B TaskMethod 4 is Running.. 1
            B TaskMethod 4 is Running.. 2
            C TaskMethod 3 is Running.. 0
            C TaskMethod 3 is Running.. 1
            C TaskMethod 3 is Running.. 2

            * ThreadPool 이 C Task 를 처리 하면서 다시 3번의 ThreadId 를 부여 받는것을 확인 할 수있다.
        */

    }


    #endregion  


}
