Thread, Task : 새 프로젝트로 콘솔 앱 만들어서 추가할 것
# 쓰레드(Thread)
  + [Thread](https://kukuta.tistory.com/361)
  + [ThreadPool](https://kukuta.tistory.com/362)
  + 쓰레드(Thread)
    - 프로세스 내부에서 생성되는 실제로 작업을 하는 주체(쓰레드)를 추가로 생성함으로써 하나의 프로세스(Main) 외에 여러가지 일을 동시에 수행하는 기능
    - 메인 프로세스와는 별개로 개별적인 리소스(컴퓨터상의 메모리)를 가지고 구동 - 비동기
```cs
internal class Chap49_Thread
{
    // 메인 프로세스를 종료시키기 위해서 ctr + F5 로 실행한다.
    #region <쓰레드가 공통으로 수행할 메서드>
    // 반환 결과와 인자를 가지지 않는 메서드
    private void subMethod()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("S : " + i);
            Thread.Sleep(1000);
        }
    }

    // 반환 결과가 업소 인자를 가지는 메서드
    private void ThreadMethod_Param(object obj)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{obj} : " + i);
            Thread.Sleep(1000);
        }
    }
    #endregion

    #region <기본 Thread 예문>
    public void RunThread()
    {
        // Thread의 생성과 Thread가 실행할 델리게이트 메서드 인수
        Thread myThread = new Thread(subMethod);
        myThread.Start();

        // Thread로 실행할 수 있는 메서드의 유형
        ////  =>
        // Thread mythread2 = new Thread(() =>
        // {
        //     for (int i = 0; i < 10; i++)
        //     {
        //         Console.WriteLine("S : " + i);
        //         Thread.Sleep(100);
        //     }
        // });
    }

    public void RunThread2()
    {
        // 인자를 받는 메서드를 실행하는 스레드
        Thread thr = new Thread(ThreadMethod_Param);

        // ThreadStart MyThread = new ThreadStart(() => Console.WriteLine("안녕하세요"));
        // 1. 리턴 타입이 void이다.
        // 2. 메소드의 인자가 없거나(ThreadStart), object 타입이어야 한다.(ParameterizedThreadStart)

        thr.Start("S");

        // Thread의 Name 부여
        thr.Name = "Test_Thread";
        Console.WriteLine(thr.Name);

        // 현재 Thread의 ID 확인하기
        Console.WriteLine(thr.ManagedThreadId);

        // Thread의 실행여부 확인.
        if (thr.IsAlive) // 스레드가 구동중이라면,
        {
            Console.WriteLine(thr.Name + " Start");
        }

        // 스레드 종료까지 대기
        // 스레드의 내용을 모두 수행한 후 메인 프로세스를 동작한다.
        // thr.Join(); => Join 메서드 : 현재 스레드 객체의 작업이 완료되거나 종료될 때까지 기본 스레드의 실행을 대기하도록 한다.

        thr.Abort(); // 생성 스레드 종료.

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("M : " + i);
            Thread.Sleep(100);
        }

        // Console.WriteLine("메인스레드 종료");
    }
    #endregion

    #region <Background Thread 예문>
    public void BackGroundRunThread()
    {
        // Background Thread로 설정시 메인스레드가 종료되면 서브 스레드가 동시에 종료된다.
        Thread myThread = new Thread(subMethod);
        myThread.IsBackground = true;   // 백그라운드 스레드로 설정
        myThread.Start();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("M : " + i);
            Thread.Sleep(100);
        }
        Console.WriteLine("메인스레드 종료");
    }
    #endregion

    #region <Thread Pool>
    public void RunThreadPool()
    {
        /* Thread가 생성 및 삭제될때 다음과 같은 과정이 실행된다.
        ### 스레드 생성 시 작업:
            1. 스레드의 실행 컨텍스트(레지스터 값, 스택 등)를 초기화.
            2. 스레드 우선순위 설정.
            3. 스레드 식별자 할당.
            4. 스레드 관련 자원 초기화.
        ### 스레드 소멸 시 작업:
            1. 스레드 실행 종료
            2. 스레드 자원 반납
            3. 스레드 관련 자원 정리

        스레드가 연속적으로 생성되고 삭제되는 경우, 오버헤드(시스템 자원과 CPU의 시간이 소비되는 현상)가 발생할 수 있다.

        스레드를 반복적으로 생성 및 삭제할 경우, ThreadPool을 이용할 수 있다.
        ### ThreadPool의 동작 원리:
            1. 초기화: 
                ThreadPool은 처음에 일정 수의 스레드를 생성하여 스레드 풀에 추가한다. 이때 생성되는 스레드의 수는 시스템의 코어 수나 설정에 따라 다르다. 
            2. 작업 추가:
                개발자가 ThreadPool에 작업을 추가하면 (ThreadPool.QueueUserWorkItem 메서드를 호출하여) ThreadPool은 작업을 큐에 저장한다.
            3. 작업 할당:
                ThreadPool은 큐에 저장된 작업을 순서대로 가져와서 사용 가능한 스레드 중 하나에게 작업을 할당한다. 스레드 풀에 있는 스레드들은 대기 상태로 있으며, 스레드 풀은 이들 중에서 작업을 처리할 스레드를 선택한다.
            4. 작업 실행:
                선택된 스레드가 해당 작업을 실행한다. 작업이 완료되면 스레드는 다시 스레드 풀에 자원을 반환한다.
            5. 스레드 재사용:
                스레드가 작업을 완료하면 스레드 풀에 다시 대기 상태로 들어가며, 스레드 풀은 이 스레드를 다시 사용하여 다음 작업을 처리한다.

            장점:
                - 재사용이 가능한 스레드의 집합을 생성하여 관리할 수 있다.(스레드 수행 후 삭제하지 않고 대기 상태로 둠)
                - 시스템 자원을 정해진만큼만 사용하기 때문에 효율적이다.

            단점:
                - 백그라운드에서 동작하므로 메인 스레드가 종료될 시 동시에 작업이 종료된다.
                - 스레드의 Name을 부여할 수 없다.
                - 추가한 스레드를 선택적으로 재사용 할 수 없다.
        */
        
        ThreadPool.QueueUserWorkItem(ThreadMethod_Param, "F");
        ThreadPool.QueueUserWorkItem(ThreadMethod_Param, "S");

        // 메인 프로세스가 끝나지 않도록 홀딩하기 위해서 ReadLine으로 처리
        Console.ReadLine();
    }
    #endregion
}
```