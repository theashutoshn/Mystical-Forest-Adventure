using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSpin : MonoBehaviour
{
    [SerializeField] private Vector3 defaultPos;
    public float _speed;
    private float _stopSpinTime,countTime;


    void Start()
    {
        defaultPos = transform.localPosition;
    }

    void SpinItenm()
    {
        _stopSpinTime = Random.Range(10,12);
        _speed = Random.Range(4,7);
        StartCoroutine(SpinRouitne());
    }
    IEnumerator SpinRouitne()
    {
        countTime =Time.time;
        while((Time.time-countTime)<_stopSpinTime)
        {
            yield return null;
            if((Time.time - countTime)>_stopSpinTime-3 && _speed>=0.2)
            {
                _speed -= 0.1f;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y -1 * _speed, transform.position.z);
            if(transform.position.y <= 261.2f)
            {
                transform.localPosition = defaultPos;
            }
        }
    }
}
