using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
    //Text Linkers
    [SerializeField] public Text setValue;
    [SerializeField] public Text flowRate; 
    [SerializeField] public Text tHotInlet;
    [SerializeField] public Text tHotOutlet;
    [SerializeField] public Text tColdInlet;
    [SerializeField] public Text tColdOutlet;

    //Inputs
    public InputField coldFlowRateInput;
    public Slider hotFlowRateSlider;
    public Slider setValueSlider;

    //Values of the flow rates
    private float hotFlowRateValue;
    private float coldFlowRateValue;

    //These are numbers, not text
    private float thin; 
    private float thout;
    private float tcin;
    private float tcout;
    private float roomTemp = 298; //kelvin 
    private float hi;
    private float c1 = 16.744f ; // temporary value 
    private float c2; // temporary value (Mh * Cph)/(Mc * Cpc)
    private float c3 = 200; // temporary value (Mh * Cph)/(ui * Ai)

 
    //Button funtions
    public void FlowRate()
    {
        flowRate.text = hotFlowRateSlider.value.ToString();
    }
    public void SetValue()
    {
        setValue.text = setValueSlider.value.ToString();
    }

    void Initializer()
    {
        //Goes in start 
    }

    void thoutCalculator()
    {
        thout = tcin + ((thin - tcin) / ((c2 + 1) * Mathf.Exp((c2 + 1) / c3)));
        tHotOutlet.text = System.Math.Round(thout,2).ToString();
    }
    void tcoutCalculator()
    {
        tcout = tcin + (c2 * (thin - thout));
        tColdOutlet.text = System.Math.Round(tcout, 2).ToString();
    }

    void Start()
    {
        coldFlowRateValue = float.Parse(coldFlowRateInput.text);
    }

    void Update()
    {
        coldFlowRateValue = float.Parse(coldFlowRateInput.text);
        hotFlowRateValue = hotFlowRateSlider.value;
        tHotInlet.text = setValueSlider.value.ToString();
        tColdInlet.text = roomTemp.ToString();
        thin = setValueSlider.value;
        tcin = roomTemp;
        hi = c1 * hotFlowRateValue; // constant includes the conversion from lph to m/s
        //hi = Ui
        c2 = 0.775f * hotFlowRateValue/coldFlowRateValue;
        c3 = 6845 * Mathf.Pow(hotFlowRateValue,(2/3));
        thoutCalculator();   //sieder-tate
        tcoutCalculator();   //sieder-tate
    }
}
