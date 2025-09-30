using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

//NavMesh���g���Ƃ��ɏ���
using UnityEngine.AI;

public class NavWalk : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player1Script player;

    //�ړI�n�̐��Əꏊ�̐ݒ�
    public Transform[] points;

    //�ŏ��̖ړI�n
    private int destPoint = 0;

    //�A�j���[�V�����p
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GotoNextPoint();
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    void doDestroy()
    {
        
    }

    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ��܂�
        if (points.Length == 0)
            return;

        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ肵�܂�
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ肵�A
        // �K�v�Ȃ�Ώo���n�_�ɂ��ǂ�܂�
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        Vector3 rayPosition = transform.position + new Vector3(0, 1f, 0);
        Debug.DrawRay(rayPosition, transform.TransformDirection(Vector3.forward) * 1.0f, Color.yellow);
        Ray rayforward = new Ray(rayPosition, Vector3.forward);
        Ray rayright = new Ray(rayPosition, Vector3.right);
        Ray rayleft = new Ray(rayPosition, Vector3.left);
        Ray rayback = new Ray(rayPosition, Vector3.back);
        RaycastHit hit;
        // �G�[�W�F���g�����ڕW�n�_�ɋ߂Â��Ă�����A
        // ���̖ڕW�n�_��I�����܂�
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        //�A�j���[�V�����̐؂�ւ�
        animator.SetFloat("Move", agent.velocity.magnitude);

        if (Physics.Raycast(rayforward, out hit, 3.0f)&& hit.collider.name == "Cube11")
        {
            GotoNextPoint();
            //�A�j���[�V�����̐؂�ւ�
            animator.SetFloat("Move", agent.velocity.magnitude);
            
        }

        if (Physics.Raycast(rayright, out hit, 3.0f) && hit.collider.name == "Cube11")
        {
                GotoNextPoint();
                //�A�j���[�V�����̐؂�ւ�
                animator.SetFloat("Move", agent.velocity.magnitude);
        }

        if (Physics.Raycast(rayleft, out hit, 3.0f) && hit.collider.name == "Cube11")
        {
                GotoNextPoint();
                //�A�j���[�V�����̐؂�ւ�
                animator.SetFloat("Move", agent.velocity.magnitude);
        }

        if (Physics.Raycast(rayback, out hit, 3.0f) && hit.collider.name == "Cube11")
        {
                GotoNextPoint();
                //�A�j���[�V�����̐؂�ւ�
                animator.SetFloat("Move", agent.velocity.magnitude);
        }

    }

}