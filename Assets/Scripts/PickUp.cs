using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Dest;
    public bool isPicked;
    public int firstPick; 
    public GameObject textCanvas;
    public GameObject pickupText;

     void OnMouseDown()
    {
        isPicked = true;
        firstPick++;
        ShowText();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = Dest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        Debug.Log(this.name);

        if(this.name == "Flashlight")
        {
            Debug.Log("Picked flashlight");
            
        }

        
    }

     void OnMouseUp()
    {
        isPicked = false;
        GetComponent<BoxCollider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        pickupText.SetActive(false);

    }

    void ShowText()
    {
        if((isPicked == true) && (firstPick==1)) //If the item picked is the first item to be picked, show text
        {
            pickupText = textCanvas.transform.GetChild(0).gameObject;
            pickupText.SetActive(true);
        }
        else
        {
            pickupText.SetActive(false);
        }
    }
}
