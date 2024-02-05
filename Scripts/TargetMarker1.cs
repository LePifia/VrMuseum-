using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMarker1 : MonoBehaviour
{
    [SerializeField] float timeLook = 3f;

    float timer;

    public Image fill;

    bool lookingTarget = false;

    bool isPlayerOnPoint = false;
    public bool IsPlayerOnPoint
    {
        get { return isPlayerOnPoint; }
        set { isPlayerOnPoint = value; }
    }
    void Start()
    {
        fill.fillAmount = 0;
    }

    void Update()
    {
        if (isPlayerOnPoint)
            return;

        if (lookingTarget)
            timer += Time.deltaTime;
        else timer = 0;

        fill.fillAmount = timer / timeLook;


        if (fill.fillAmount < 1)
            return;

        isPlayerOnPoint = true;
        TargetManager.Instance.OnLoadComplete(this);
    }

    public void LookingTarget(bool value)
    {
        lookingTarget = value;
    } 
}
