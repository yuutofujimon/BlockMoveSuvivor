using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

//NavMeshを使うときに書く
using UnityEngine.AI;

public class NavWalk : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player1Script player;

    //目的地の数と場所の設定
    public Transform[] points;

    //最初の目的地
    private int destPoint = 0;

    //アニメーション用
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
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
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
        // エージェントが現目標地点に近づいてきたら、
        // 次の目標地点を選択します
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        //アニメーションの切り替え
        animator.SetFloat("Move", agent.velocity.magnitude);

        if (Physics.Raycast(rayforward, out hit, 3.0f)&& hit.collider.name == "Cube11")
        {
            GotoNextPoint();
            //アニメーションの切り替え
            animator.SetFloat("Move", agent.velocity.magnitude);
            
        }

        if (Physics.Raycast(rayright, out hit, 3.0f) && hit.collider.name == "Cube11")
        {
                GotoNextPoint();
                //アニメーションの切り替え
                animator.SetFloat("Move", agent.velocity.magnitude);
        }

        if (Physics.Raycast(rayleft, out hit, 3.0f) && hit.collider.name == "Cube11")
        {
                GotoNextPoint();
                //アニメーションの切り替え
                animator.SetFloat("Move", agent.velocity.magnitude);
        }

        if (Physics.Raycast(rayback, out hit, 3.0f) && hit.collider.name == "Cube11")
        {
                GotoNextPoint();
                //アニメーションの切り替え
                animator.SetFloat("Move", agent.velocity.magnitude);
        }

    }

}