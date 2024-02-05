using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10;

    public AudioSource aud;
    float timer;

    private void Start()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
    }

    public void Move(Transform target)
    {
        Vector3 point = target.position;
        point.y = transform.position.y;

        transform.DOMove(point, Vector3.Distance(target.position, transform.position) * moveSpeed);
    }

    Vector3 lastFramePosition;

    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
}
