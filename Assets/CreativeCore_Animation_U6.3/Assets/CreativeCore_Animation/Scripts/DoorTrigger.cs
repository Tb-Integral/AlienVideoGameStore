using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("IsPlayerClosely", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("IsPlayerClosely", false);
    }
}
