using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchVolcanoScript : MonoBehaviour {

    public Canvas canvas;
    public GameObject ticket;
    public bool InstanceVar = false;
    public bool InstanceVarRenderTicket = true;
    
    void awake()
    {
        ticket.GetComponent<Renderer>().enabled = false;
        canvas.GetComponent<Canvas>().enabled = false;
    }

	void Update ()
    {
        //    if (InstanceVarRenderTicket.Equals(true))
        //    {
        //        ticket.GetComponent<Renderer>().enabled = false;
        //        canvas.GetComponent<Canvas>().enabled = false;

        //        InstanceVarRenderTicket = false;
        //    }


        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                // Debug.Log("Something Hit");
                if (raycastHit.collider.name == this.gameObject.name)
                {
                    Debug.Log("wolf");
                    if (InstanceVar.Equals(true))
                    {
                        InstanceVar = false;
                    }
                    else
                    {
                        InstanceVar = true;
                    }

                    if (InstanceVar.Equals(true))
                    {
                        ticket.GetComponent<Renderer>().enabled = true;
                        canvas.GetComponent<Canvas>().enabled = true;
                    }
                    else
                    {
                        ticket.GetComponent<Renderer>().enabled = false;
                        canvas.GetComponent<Canvas>().enabled = false;
                    }
                }

                Debug.Log(InstanceVar);
                //OR with Tag

                //if (raycastHit.collider.CompareTag("SoccerTag"))
                //{
                //    Debug.Log("Soccer Ball clicked");
                //}
            }
        }
    }
}
