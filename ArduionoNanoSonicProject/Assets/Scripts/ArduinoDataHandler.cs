using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ArduinoDataHandler : MonoBehaviour
{
    [SerializeField] Transform _simulationBullshit;
    [SerializeField] SampleMessageListener mes;
    private float dis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            dis = System.Convert.ToSingle(mes.data.Split(':').ToList().Last().Split(' ')[0]);
        }
        catch
        {
            dis = 0;
        }
        _simulationBullshit.transform.position = _simulationBullshit.transform.position + _simulationBullshit.transform.forward * dis;
    }
}
