using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Find_manager : MonoBehaviour
{


    public InputField field;
    public Button findButton;

  

    public void findButtonHind()
    {
        string str = field.text;
        char ticar = str[0];
        if (ticar == 'b' || ticar == 'r' || ticar == 'f' || ticar == 'c')
        {
            //发送数据到串口
            field.text = null;
            manager_.instance.serialController.SendSerialMessage(str);
            machineManager.instance.RotateMove(ticar, int.Parse(str.Substring(1)));
            manager_.instance.Addmessage(str);
            machineManager.instance.Addvolume();
        }
        else
        {
          
            manager_.instance.Addmessage("命令错误，请重新输入！", Color.red);
            field.text = null;
        }

    }







}
