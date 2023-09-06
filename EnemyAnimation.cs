using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animation>();
        if (gameObject.tag == "Moving")
        {
            anim["Run"].wrapMode = WrapMode.Loop;
            anim.Play("Run");
            anim["Run"].normalizedTime = Random.value;
        }
        else if (gameObject.tag == "Stationary")
        {
            anim["idle"].wrapMode = WrapMode.Loop;
            anim.Play("idle");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
