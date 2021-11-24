using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform bat;

    public Animator animator;

    bool onUse;
    float timer = 0f;
    void Start()
    {
        //bat = GetComponentsInChildren<Transform>()[0];
        onUse = false;
        bat.gameObject.SetActive(onUse);
        animator.SetBool("Bat", onUse);
        animator.SetLayerWeight(1,onUse ? 0f: 1f);
        animator.SetLayerWeight(2,!onUse ? 0f: 1f);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && timer > 0.3f)
        {
            onUse = !onUse;
            bat.gameObject.SetActive(onUse);
            animator.SetBool("Bat", onUse);
            animator.SetLayerWeight(1,onUse ? 0f: 1f);
            animator.SetLayerWeight(2,!onUse ? 0f: 1f);
            timer = 0;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f && timer > 0.3f)
        {
            onUse = !onUse;
            bat.gameObject.SetActive(onUse);
            animator.SetBool("Bat", onUse);
            animator.SetLayerWeight(1,onUse ? 0f: 1f);
            animator.SetLayerWeight(2,!onUse ? 0f: 1f);
            timer = 0;
        }
    }
}
