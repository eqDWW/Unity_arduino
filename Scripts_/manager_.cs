using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class manager_ : managerBate<manager_>
{

   [HideInInspector] public SerialController serialController;

    [SerializeField]
    private Text mainText;
    private string Nowstr;


    public bool isTinme = true;

    void Start()
    {   
        try
        {
            serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        }
        catch(Exception ex)
        {
            this.Addmessage(ex.ToString(),Color.red);
        }
    }

    #region ´òÓ¡
    public void Addmessage(string str)
    {
        DateTime downtime = DateTime.Now;      
        if (isTinme)
            Nowstr = downtime.ToString("yyyy-MM-dd HH:mm:ss") + "£º";
        else
            Nowstr = null;
       
        mainText.text += Nowstr+str+"\n"; 
    }
    public void Addmessage(string str, Color color)
    {
            DateTime downtime = DateTime.Now;
            if (isTinme)
                Nowstr = downtime.ToString("yyyy-MM-dd HH:mm:ss") + "£º";
            else
                Nowstr = null;
            str = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{str}</color>";
            mainText.text += Nowstr + str + "\n";        
    }

    #endregion
    //Çå¿Õ×´Ì¬À¸
    public void RemoveThis()
    {
        try
        {
            mainText.text = null;
            mainText.text += "\n";
        }
        catch(Exception ex)
        {
            this.Addmessage(ex.ToString(),Color.red);
        }
        
    }




}
