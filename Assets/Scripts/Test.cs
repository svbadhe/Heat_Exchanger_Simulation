using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Slider flowRateSlider;
    public InputField coldFlowRateInputField;
    //public float fillExtent;
    public Image hotWater1;
    public Image hotWater2;
    public Image hotWater3;
    public Image hotWater4;
    public Image hotWater5;
    public Image hotWater6;
    private Image hotWater;
    public Image coldWater1;
    public Image coldWater2;
    public Image coldWater3;
    public Image coldWater4;
    public Image coldWater5; //HeatExchanger filling
    public Image coldWater6;
    private Image coldWater;
    private bool update = true;

    float coldFlowRate = 0.01f;

    public void coldFlowRateInput()
    {
        coldFlowRate = float.Parse(coldFlowRateInputField.text) / 30000;
    }

    float hotFlowRate = 400/30000f ;

    public void flowRateSliderLinker()
    {
        hotFlowRate = flowRateSlider.value/30000;
    }

    void Initializer()
    {
        hotWater1.fillAmount = 0f;
        hotWater2.fillAmount = 0f;
        hotWater3.fillAmount = 0f;
        hotWater4.fillAmount = 0f;
        hotWater5.fillAmount = 0f;
        hotWater6.fillAmount = 0f;
        coldWater1.fillAmount = 0f;
        coldWater2.fillAmount = 0f;
        coldWater3.fillAmount = 0f;
        coldWater4.fillAmount = 0f;
        coldWater5.fillAmount = 0f;
    }
    //function to check if the limit is reched
    void LimitChecker1()
    {
        hotWater = hotWater1;
    }
    void LimitChecker2()
    {
        if (hotWater1.fillAmount == 1)
        {
            hotWater = hotWater2;
        }
    }
    void LimitChecker3()
    {
        if (hotWater2.fillAmount == 1)
        {
            hotWater = hotWater3;
        }
    }
    void LimitChecker4()
    {
        if (hotWater6.fillAmount == 1)
        {
            hotWater = hotWater4;
        }
    }
    void LimitChecker5()
    {
        if (hotWater3.fillAmount == 1)
        {
            hotWater = hotWater5;
        }
    }
    void LimitChecker6()
    {
        if (hotWater5.fillAmount == 1)
        {
            hotWater = hotWater6;
        }
    }
    void LimitChecker1c()
    {
        coldWater = coldWater1;
    }
    void LimitChecker2c()
    {
        if (coldWater1.fillAmount == 1)
        {
            coldWater = coldWater2;
        }
    }
    void LimitChecker3c()
    {
        if (coldWater2.fillAmount == 1)
        {
            coldWater = coldWater3;
        }
    }
    void LimitChecker4c()
    {
        if (coldWater3.fillAmount == 1)
        {
            coldWater = coldWater4;
        }
    }
    void LimitChecker5c()
    {
        if (coldWater3.fillAmount == 1)
        {
            coldWater = coldWater5;
        }
    }
    void LimitChecker6c()
    {
        if (coldWater5.fillAmount == 1)
        {
            coldWater = coldWater6;
        }
    }

    // Stops updating after a value
    void StopUpdating()
    {
        if (hotWater4.fillAmount == 1 && coldWater6.fillAmount == 1)
        {
            update = false;
        }
    }
    // Define the flow in thte pipes
    void HotFlowDefiner()
    {
        LimitChecker1();
        LimitChecker2();
        LimitChecker3();
        LimitChecker5();
        LimitChecker6();
        LimitChecker4();
        hotWater.fillAmount += hotFlowRate;
    }
    void ColdFlowDefiner()
    {
        LimitChecker1c();
        LimitChecker2c();
        LimitChecker3c();
        LimitChecker5c(); //HeatExchanger
        coldWater.fillAmount += coldFlowRate;
        LimitChecker4c();
        LimitChecker6c();
        coldWater.fillAmount += coldFlowRate;
    } 

    // Start is called before the first frame update
    void Start()
    {
        Initializer();
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            HotFlowDefiner();
            ColdFlowDefiner();
            StopUpdating();
        }
    }
}