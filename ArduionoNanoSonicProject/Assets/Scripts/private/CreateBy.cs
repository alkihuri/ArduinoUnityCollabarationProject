using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBy : MonoBehaviour
{
    // Start is called before the first frame update
    public string YouName;
     float stopWatch;
     Text stopWatch_text;
    void Start()
    {
        stopWatch_text = GameObject.Find("StopWatch").GetComponent<Text>();
        stopWatch = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStates.gameIsOn)
            stopWatch +=  Time.deltaTime;
        else
        {
            Destroy(stopWatch_text);
            GetComponent<Text>().enabled = true;
        }

        stopWatch_text.text = stopWatch.ToString("#.##");
        string result = "\nResult " + stopWatch.ToString("#.##");
        if(YouName.Length>0)
        {
            GetComponent<Text>().text = "Created by " + YouName + result;
        }
        else
        {
            GetComponent<Text>().text = "Created by noname" + result;
        }
    }
}
