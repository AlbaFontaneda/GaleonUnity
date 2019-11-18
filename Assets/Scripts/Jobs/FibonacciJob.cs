using System.Collections;
using Unity.Collections;
using Unity.Jobs;

public struct FibonacciJob : IJob
{
    private int n;
    private NativeArray<int> nativeArray;

    public FibonacciJob(int a_n, ref NativeArray<int> arr)
    {
        n = a_n;
        nativeArray = arr;
    }

    public void Execute()
    {
        int aux, a, b;
        b = 1;
        a = 0;

        for (int i = 0; i < n; ++i)
        {
            aux = a;
            a = b;
            b = aux + a;
            nativeArray[i] = a;
        }
    }
}
