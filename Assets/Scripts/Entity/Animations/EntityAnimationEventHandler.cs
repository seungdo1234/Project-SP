using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationEventHandler : MonoBehaviour
{
    protected Animator anim;

    public float AnimationProgressTime => anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public bool IsMatchTag(string tag)
    {
        AnimatorStateInfo curInfo = anim.GetCurrentAnimatorStateInfo(0);
        return curInfo.IsTag(tag);
    }
}
