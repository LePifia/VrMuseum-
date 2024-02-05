using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    static TargetManager instance;
    public static TargetManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public Player player;
    public TargetMarker1 firstTarget;

    TargetMarker1 currentTarget;

    void Start()
    {
        OnLoadComplete(firstTarget);
    }

    public void OnLoadComplete(TargetMarker1 target)
    {
        Debug.Log("Player is going to " + target.name + " ");
        target.fill.fillAmount = 1;
        target.IsPlayerOnPoint = true;

        if (currentTarget != null)
            currentTarget.IsPlayerOnPoint = false;

        currentTarget = target;
        SetPlayerPosition(target.transform);
    }

    void SetPlayerPosition(Transform target)
    {
        player.Move(target);
    }
}
