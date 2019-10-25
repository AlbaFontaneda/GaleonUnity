using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobController : MonoBehaviour
{
    // Start is called before the first frame update
    private NativeArray<int> result;
    private JobHandle handle;
    private JobHandle secondHandle;
    private bool init = false;
    private int num = 3000;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //LaunchJob();
            LaunchJobParallel();
        }

        if (init)
        {
            if (secondHandle.IsCompleted)
            {
                secondHandle.Complete();
                init = false;
                for (int i = 0; i < num; ++i)
                {
                    Debug.Log(result[i]);
                }
                result.Dispose();
            }

        }
    }


    protected void LaunchJobParallel()
    {
        init = true;
        result = new NativeArray<int>(num, Allocator.Persistent);

        FibonacciJob fibJob = new FibonacciJob(num, ref result);
        CalcWithFinbonacciParallel calcWitJob = new CalcWithFinbonacciParallel(2, arr: ref result);

        handle = fibJob.Schedule();
        secondHandle = calcWitJob.Schedule(num, 100, handle);
    }

    protected void LaunchJob()
    {
        init = true;
        result = new NativeArray<int>(num, Allocator.Persistent);

        FibonacciJob fibJob = new FibonacciJob(num, ref result);
        CalcWithFibonacciJob calc = new CalcWithFibonacciJob(2, ref result);

        handle = fibJob.Schedule();
        secondHandle = calc.Schedule(handle);

    }
}
