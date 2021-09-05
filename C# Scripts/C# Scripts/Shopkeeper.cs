using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shopkeeper : MonoBehaviour
{

    int timesIdled = 0;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateIdleCount()
    {
        timesIdled += 1;
        animator.SetInteger("Times Idled", timesIdled);
    }

    public void SetIdleCountToZero()
    {
        timesIdled = 0;
        animator.SetInteger("Times Idled", timesIdled);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
