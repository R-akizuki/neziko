using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    //1.プレイヤーのキー入力を受け取る
    //2.キー入力の方向に移動する
    //3.移動方向に合わせてアニメーションを再生する
    CharacterController controller;

    Vector3 movedirection = Vector3.zero;

    public float speed = 0f;
    Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical")>0.0f)
        {
            movedirection.z = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            movedirection.z = 0.0f;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * 3f, 0);

        if(Input.GetButton("Jump"))
        {
            movedirection.y = 1f;
            animator.SetTrigger("Jump");
        }

        Vector3 globaldirecion = transform.TransformDirection(movedirection);
        controller.Move(globaldirecion);
        animator.SetBool("run", movedirection.z > 0f);
    }
}
