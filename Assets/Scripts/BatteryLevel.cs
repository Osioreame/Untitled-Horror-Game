using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLevel : MonoBehaviour
{
    public Image batteryBar;
    public Text ratioText;
    public float charge = 100;
    private float maxCharge = 100;
    public FlashlightController flashlight;
    public PickUp pickup;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(flashlight.isFlashlightOn == true)
        {
            Deplete(0.01f);
        }
    }

    private void UpdateBattery()
    {
        float ratio = charge / maxCharge;
        batteryBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio*100).ToString("0")+"%";
    }
  
    void Deplete(float decrease)
    {
        
        charge -= decrease;

        if (charge <= 10) 
        {
            batteryBar.color = new Color32(255, 0, 0, 100);
            transform.Find("WhiteLight").gameObject.GetComponent<Light>().intensity = 3; 
        }

        if (charge < 0)
        {
            charge = 0;
            //Debug.Log("Battery dead");
            flashlight.isFlashlightOn = false;
        }

        UpdateBattery();

    }

    void Charge(float increase)
    {
        if (pickup.name == "Battery")
        {
            if (Input.GetKey("E")){
                charge += 15;
                pickup.enabled = false;
                UpdateBattery();
            }
        }
        
    }
}
