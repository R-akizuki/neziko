using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    //1.�v���C���[�̃L�[���͂��󂯎��
    //2.�L�[���͂̕����Ɉړ�����
    //3.�ړ������ɍ��킹�ăA�j���[�V�������Đ�����
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
