using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uMessage : MonoBehaviour
{

    public Transform silderParentl;
    public Transform smityParent;





    //切换模式
    public void modelhand(int index)
    {
        switch (index)
        {
            case 0:
                silderParentl.gameObject.SetActive(false);
                smityParent.gameObject.SetActive(true);
                break;
            case 1:
                silderParentl.gameObject.SetActive(true);
                smityParent.gameObject.SetActive(false);
                break;
        }
    }


    #region 滑块
    //滑块
    public void shlie_b(float value)
    {
        value = (int)value;
        manager_.instance.Addmessage('b'+ value.ToString());
        manager_.instance.serialController.SendSerialMessage('b'+ value.ToString());
        print('b' + value.ToString());
    }
    public Slider slider;
    public void shlie_b()
    {
        slider.value = (int)slider.value;
        manager_.instance.Addmessage('b' + slider.value.ToString());
        manager_.instance.serialController.SendSerialMessage('b' + slider.value.ToString());
        print('b' + slider.value.ToString());
    }
    #endregion
    //时间记录toggle
    public void istoggle(bool istoggle)
    {
        manager_.instance.isTinme = istoggle;
    }
    //重置消息
    public void Remove_()
    {
        manager_.instance.RemoveThis();
    }



}
