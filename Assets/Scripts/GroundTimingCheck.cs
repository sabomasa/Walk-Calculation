using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTimingCheck : MonoBehaviour {

    bool Syototsu = false;
    bool start = false;
    int countR = 0; int countL = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            start = true;
        if(start == true)
            if(Syototsu == false)
                this.transform.Translate(0, 0.01f, 0);
        //this.transform.Translate(0, 0.01f, 0);

    }


    void Calibrate_GroundPositionY()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            while(Syototsu == false)
            {
                this.transform.Translate(0, 0.01f, 0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RightFoot" || other.tag == "LeftFoot")
        {
            Debug.Log("R : " + countR  + "     L : " + countL);
            Syototsu = true;
            if(other.tag == "RightFoot")
            {
                countR += 1;
            }
            else if(other.tag == "LeftFoot")
            {
                countL += 1;
            }
        }
            
    }

}
