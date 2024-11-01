using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class machineManager : managerBate<machineManager>
{

    [SerializeField] private Transform[] machineTrans;

    public Vector2 bMinMax;
    public Vector2 rMinMax;
    public Vector2 fMinMax;
    public Vector2 cMinMax;

    public Volume volume;
    public float volumeSpeed;

    Coroutine addCoroutine;
    Coroutine ShimeCoroutine;

 
    public void RotateMove(char cahr, int value)
    {
        Quaternion targetRotation;
        switch (cahr)
        {
            case 'b':
                  value = Mathf.Clamp(value, (int)bMinMax.x, (int)bMinMax.y);
                 targetRotation = Quaternion.Euler(machineTrans[0].eulerAngles.x, value, machineTrans[0].eulerAngles.z);
                RotateAlongXAxis(machineTrans[0], targetRotation);
                break;
            case 'r':
                value = Mathf.Clamp(value, (int)rMinMax.x, (int)rMinMax.y);
                targetRotation = Quaternion.Euler(machineTrans[1].eulerAngles.x, machineTrans[1].eulerAngles.y, value);
                RotateAlongXAxis(machineTrans[1], targetRotation);
                break;
            case 'f':
                value = Mathf.Clamp(value, (int)fMinMax.x, (int)fMinMax.y);
                targetRotation = Quaternion.Euler(machineTrans[2].eulerAngles.x, machineTrans[2].eulerAngles.y, value);
                RotateAlongXAxis(machineTrans[2], targetRotation);
                break;
            case 'c':
                value = Mathf.Clamp(value, (int)cMinMax.x, (int)cMinMax.y);
                var linti = value / 180;
                Vector3 moveTarget = new Vector3(machineTrans[3].position.x, machineTrans[3].position.y, linti);
                Vector3 moveTarget_2 = new Vector3(machineTrans[4].position.x, machineTrans[4].position.y,- linti);
               // MoveSmoothlyAlongXAxis(machineTrans[3], moveTarget);
               // MoveSmoothlyAlongXAxis(machineTrans[4], moveTarget_2);
                break;

        }
    }


    void RotateAlongXAxis(Transform trans, Quaternion targetAngle)
    {    
        // 使用DOTween来平滑地旋转到目标角度
        trans.DORotate(targetAngle.eulerAngles, 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).OnComplete(() => { StartCoroutine(IncreaseValueSmoothly_(0)); }); 
    }

    #region 移动(改)
    /*void MoveSmoothlyAlongXAxis(Transform trans,Vector3 targetver)
    {

        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(
            trans.DOMove(targetver, 1f) // 移动时间为1秒
            .SetEase(Ease.Linear) // 使用线性插值
        )
        .OnComplete(() => { });
    }*/
    #endregion

    public void Addvolume()
    {
        addCoroutine=StartCoroutine(IncreaseValueSmoothly(1));
    }
    public void Shimevolume()
    {
        ShimeCoroutine=StartCoroutine(IncreaseValueSmoothly_(0));
    }




    IEnumerator IncreaseValueSmoothly(float target)
    {
        while (volume.weight<1)
        {
            volume.weight += Time.deltaTime* volumeSpeed;
            yield return null;
        }
    }
    IEnumerator IncreaseValueSmoothly_(float target)
    {
        StopCoroutine(addCoroutine);
        while (volume.weight >0)
        {
            volume.weight -= Time.deltaTime* volumeSpeed;
            yield return null;
        }
    }
}

