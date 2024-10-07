using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationEventHandler : MonoBehaviour
{
    protected Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }


}
