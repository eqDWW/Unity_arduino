using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class sliderThis : MonoBehaviour
{

    int valueSlider = 0;
    Slider slider;
    //���Ʊ��
    public char thisName;
    private void Start()
    {
        slider = GetComponent<Slider>();
        valueSlider = (int)GetComponent<Slider>().value;
        slider.onValueChanged.AddListener((float value) => { valueSlider = (int)value; });
    }

    public void upEvent()
    {
        //��������
        try
        {
            manager_.instance.serialController.SendSerialMessage(thisName + valueSlider.ToString());
            manager_.instance.Addmessage(thisName + valueSlider.ToString());
            print(thisName + valueSlider.ToString());
        }
        catch(Exception e)
        {
            manager_.instance.Addmessage(e.ToString());
        }
    }





}
