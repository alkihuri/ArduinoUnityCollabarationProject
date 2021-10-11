using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ArduinoDataHandler : MonoBehaviour
{
    [SerializeField] Transform _simulationBullshit;
    [SerializeField] SampleMessageListener mes;
    [SerializeField , Range(0,10) ] float dis; 
    [SerializeField, Range(0, 10)] float prevdis;

    [SerializeField, Range(-1, 1)] public float Horizontal;
    Vector3 _startPos; 
    // Start is called before the first frame update
    void Start()
    {
        _startPos = _simulationBullshit.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dis = System.Convert.ToSingle(mes.data);
        prevdis = dis - 10;
        if(prevdis > -10 && prevdis <10)
        {
            Horizontal = prevdis / 10;
        }
    }
}
