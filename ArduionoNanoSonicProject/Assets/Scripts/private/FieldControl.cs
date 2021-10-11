using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldControl : MonoBehaviour
{
     
    GameObject SpaceFighter = null;
    GameObject endText = null ;
    GameObject EndPoint = null ;
    GameObject canvas= null;
    GameObject endImage = null;
    
    // Start is called before the first frame update
    void Start()
    {
        EndPoint = GameObject.Find("ZeroPoint");
        SpaceFighter = GameObject.Find("SpaceFighter");
 
        endText = GameObject.Find("CanvasEnd/Image");
        canvas = GameObject.Find("CanvasEnd");
    }
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if(SpaceFighter != null)
                SpaceFighter.GetComponent<Player_Battleship>().enabled = false;
            if (endText != null)
            {
                endText.GetComponent<Animator>().enabled = true;
                endText.GetComponent<Image>().enabled = true;
            }
        }
       finally
        {

        }
    }
    float timer = 0.25f; 
    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (canvas != null)
                
            timer -= Time.deltaTime;
            if (timer < 0 && SpaceFighter != null )
            {
                canvas.GetComponent<Canvas>().enabled = true;
                if (SpaceFighter != null)
                    SpaceFighter.GetComponent<Player_Battleship>().enabled = false;
                if (endText != null)
                    endText.GetComponent<Animator>().enabled = true;
                GameStates.gameIsOn = false;
                SpaceFighter.GetComponent<Rigidbody>().isKinematic = true;
                SpaceFighter.transform.position = Vector3.Lerp(SpaceFighter.transform.position, EndPoint.transform.position, 0.05f);
                SpaceFighter.transform.rotation = Quaternion.Lerp(SpaceFighter.transform.rotation, EndPoint.transform.rotation, 0.05f);
            }
        }
        finally
        {

        }
         
    }
    private void OnTriggerExit(Collider other)
    {
        if (SpaceFighter != null)
            SpaceFighter.GetComponent<Player_Battleship>().enabled = true;  
    }
    // Update is called once per frame
    // Movement speed in units per second.
    public float speed = 1.0F;
 
    void Update()
    { 
         
            if(Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
    }
}
