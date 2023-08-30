using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Task
{
    /* Task :
       ThreadPool 의 기능 을 보완하기 위해 사용되는 비동기 스레드 기능 
       1. 백그라운드 속성의 스레드 (메인 스레드 종료 시 소멸)
       2. 기본적으로 스레드 풀 을 사용
       3. 결과 값을 리턴 받을 수 있음 (*) 

       - Task 가 수행하는 메서드 시그니처 (대리자)
       - 반환 값이 없고 인자가 없는 대리자 (Action)
       - 반환 값이 없고 Object 인자가 1개 존재 하는 대리자 (Action<object>)
       - 반환 결과가 존재 하고 인자 가 없는 대리자 (Func<[반환형식]>)
       - 반환 결과가 존재 하고 인자가 1개 존재하는 대리자 (Func<object, [반환형식]>
    */


    internal class Program
    {
        static void Main(string[] args)
        { 
            // Task 를 호출 할 부분 
            new Task_Func().RunTask2();
             

            // Task  와 같이 구동 될 메인 프로세스 로직
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" M : " + i );
                Thread.Sleep(600);
            } 
            
        }
    }


    #region < Task 가 Action 델리게이트 를 수행하는 예제 > 
    // Action 반환 형이 없는 델리게이트 메서드 시그니쳐(메서드 형식)

    class TaskTest_Action
    {
        // 인자 가 없는 함수 . 
        private void TaskMethod_1()
        {
            Console.WriteLine("인자가 없는 Task 메서드 입니다.");
        }

        // 인자 가 있는 함수 
        // (Thread 와 Task 가 실행하는 메서드의 인자는 Object 형식의 단일 인자만 가능하다)
        private void TaskMethod_2(object obj)
        {
            Console.WriteLine($"{obj} 인자를 가지는 Task 메서드 2 입니다.");
        }


        public void RunTask()
        {
            // Task 의 실행
            Task task = new Task(TaskMethod_1);
            task.Start();
        }

        public void RunTask2()
        {
            // Task 의 실행
            Task task = new Task(TaskMethod_2,"오브젝트");
            task.Start();

            Thread thread = new Thread(TaskMethod_2);
            thread.Start("오브젝트");
        } 
    }
    #endregion 

    #region < Task 의 Wait > 
    // Task 를 종료 할때까지 Wait

    class TestTask_Wait
    {
        private void ShowCount()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  스레드 의 {i} 번째 표현");
                Thread.Sleep(500);
            }
        }

        public void RunWaitTask()
        {
            Task task = new Task(ShowCount);
            
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Task 와 동시에 실행됩니다.");
            
            
            task.Start();
            
            // Task 를 홀딩 동기적으로 프로그램을 수행. 
            task.Wait();
            
            
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Task 를 모두 기다린 후 실행 됩니다.");
        }
    }
    #endregion


    #region <Task 가 Func 대리자를 수행 비동기 프로세스의 결과 값을 반환 받음 ** >
    class Task_Func
    {
        // 인자 가 없는 int 반환 메서드  . 
        private int TaskMethod_1()
        {
            return 10;
        }

        // 인자 가 있는 string 반환 메서드 
        private string TaskMethod_2(object obj)
        {
            return $"{obj} 인자를 가지는 Task 메서드 2 입니다.";
        }


        public void RunTask()
        {
            // 인자를 받지 않는 int 반환 메서드 Task 수행
            Func<int> func = TaskMethod_1;
            Task<int> task = new Task<int>(func);
            
            // => 
            //<int> task1 = new Task<int>(() => 10);

            task.Start();

            // Task 의 결과 를 받아와 표현
            // *** 결과를 받기 위하여 스레드가 대기함.
            Console.WriteLine(task.Result);
        }






        public void RunTask2()
        {
            // 인자(object) 를 받는 int 반환 메서드 Task 수행
            Func<object, string> func = TaskMethod_2;
            Task<string> task = new Task<string>(func, "OBJECT");
            // => 
            //Task<string> task = new Task<string>(objcet => objcet + "입니다" , "OBJCET");

            task.Start();

            // Task 의 결과 를 받아와 표현
            // *** 결과를 받기 위하여 스레드가 대기함.
            Console.WriteLine(task.Result);

            // Task<반환형> ([Func], [object]) 형태 고정 이므로 인자를 여러개 받는 메서드는 Task 로 등록 할 수 없다.
            //Func<int, double, bool, List<int>> func3 = TaskMethod;
        }
    }
    #endregion


    #region < 반환 을 하는 Task 제너릭 클래스 만들어 보기 > 
    // Task 기능과는 별개의 Generic 클래스 만들어 보기. 
    class TaskTest_GenericClass
    {

        #region < 인자를 받지 않는 결과 반환 Task >
        public void RunTask()
        {
            // 반환값을 가지는 Task
            _Task<int> task = new _Task<int>(() =>
            {
                for (int i = 0; i <10;i++)
                {
                    Thread.Sleep(500);
                }
                return 100;
            });
            task.Start();
            Console.WriteLine(task.result.ToString()); 
        } 

        class _Task<Result>
        {
            private Task<Result> _task;
            private Func<Result> _func;

            public Result _result;
            public Result result
            {
                get
                {
                    _task.Wait();
                    if (_task.IsCompleted)
                        return _task.Result;
                    else return default(Result);
                }
            }

            public _Task(Func<Result> func)
            {
                _func = func;
            }

            public void Start()
            {
                _task = new Task<Result>(_func);
                _task.Start(); // 별도의 스레드가 동작 (백그라운드) 
                //_result = 100;
            }
        }
        #endregion 


        #region < Object 인자를 받는 결과 반환 Task > 
        public void RunTask_Param()
        {
            _Task_Param<string> task2 = new _Task_Param<string>
                ((init) =>
                {
                    for (int i = 0; i < (int)init; i++)
                    {
                        Console.Write(i + "...");Thread.Sleep(500);
                    }
                    return $"{init} 문자열 반환";
                }, 10);
            
            
            task2.Start();

            Console.WriteLine(task2.result); // 결과 를 받을 때 까지 대기

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + "M ...");
                Thread.Sleep(200);
            }

            Console.ReadLine();
        }




        class _Task_Param<Result>
        {
            private Task<Result> _task;
            private Func<object, Result> _func;
            private object _obj;
            public Result result
            {
                get
                {
                    _task.Wait();
                    if (_task.IsCompleted)
                        return _task.Result;
                    else return default(Result);
                }
            }

            public _Task_Param(Func<object, Result> func, object obj)
            {
                _func = func;
                _obj = obj;
            }

            public void Start()
            {
                Func<object, Result> func1 =
                    ((init) =>
                    {
                        for (int i = 0; i < (int)init; i++)
                        {
                            Console.Write(i + "..."); Thread.Sleep(500);
                        }
                        
                        return default(Result);
                    });


                Func<Result> func = () => func1(_obj);


                _task = new Task<Result>(func);
                _task.Start();
            }
        }
        #endregion
    }
    #endregion


}
