using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public bool isFlashlightOn;
    public float flashlightRange = 5;
    public EnemyFollow enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray flashlightRay = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.forward * flashlightRange);


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (isFlashlightOn == true)
        {
            transform.Find("WhiteLight").gameObject.GetComponent<Light>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Flashlight off");
                isFlashlightOn = false;

                if (Physics.Raycast(flashlightRay, out hit, flashlightRange))
                {
                    if (hit.collider.tag =="Enemy")
                    {
                        enemy.SlowEnemy();
                    }
                }

            }
        }
        else
        {
            transform.Find("WhiteLight").gameObject.GetComponent<Light>().enabled = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Flashlight on");
                isFlashlightOn = true;
            }
        }
        
        
    }
}
