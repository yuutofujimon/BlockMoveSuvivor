using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Player1Script : MonoBehaviour
{
    private Rigidbody rigidBody; //Rigidbody コンポーネント
    private Animator animator; //アニメーターコンポーネント
    private float inputHorizontal; //横方向の入力
    private float inputVertical; //縦方向の入力
    private string answerTag = "Cube";
    public GameObject gameobject;
    public float pushDistance = 2.5f; //押す距離の値
    public float basePushForce = 10f;   //通常の押す力
    public float enhancedPushForce = 1000f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject cube2;
    [SerializeField] GameObject cube3;
    [SerializeField] GameObject cube4;
    [SerializeField] GameObject cube5;
    [SerializeField] GameObject cube6;
    [SerializeField] GameObject cube7;
    [SerializeField] GameObject cube8;
    [SerializeField] GameObject cube9;
    [SerializeField] GameObject cube10;
    [SerializeField] GameObject cube11;
    [SerializeField] GameObject cube12;
    [SerializeField] GameObject cube13;
    [SerializeField] GameObject cube14;
    [SerializeField] GameObject StageWall1;
    [SerializeField] GameObject StageWall2;
    [SerializeField] GameObject StageWall3;
    [SerializeField] GameObject StageWall4;
    [Tooltip("X軸方向に移動する振幅(0にすると移動しない)")]
    private float amplitudeX = 4.0f;
    [SerializeField]
    [Tooltip("Z軸方向に移動する振幅(0にすると移動しない)")]
    private float amplitudeZ = 4.0f;
    Rigidbody playerRigidbody;
    Player1Script player1;
    bool keyLook = false;
    bool flag = false;
    public Transform Cube;
    public float kickForce = 10f;
    // Start is called before the first frame update
    void Start()
    { 
        //コンポーネントを取得
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); //アニメーターのコンポーネントの取得
        //キューブのRigidbodyを取得
        Rigidbody cube1Rigidbody = cube.GetComponent<Rigidbody>();
        Rigidbody cube2Rigidbody = cube2.GetComponent<Rigidbody>();
        Rigidbody cube3Rigidbody = cube3.GetComponent<Rigidbody>();
        Rigidbody cube4Rigidbody = cube4.GetComponent<Rigidbody>();
        Rigidbody cube5Rigidbody = cube5.GetComponent<Rigidbody>();
        Rigidbody cube6Rigidbody = cube6.GetComponent<Rigidbody>();
        Rigidbody cube7Rigidbody = cube7.GetComponent<Rigidbody>();
        Rigidbody cube8Rigidbody = cube8.GetComponent<Rigidbody>();
        Rigidbody cube9Rigidbody = cube9.GetComponent<Rigidbody>();
        Rigidbody cube10Rigidbody = cube10.GetComponent<Rigidbody>();
        Rigidbody cube11Rigidbody = cube11.GetComponent<Rigidbody>();
        Rigidbody cube12Rigidbody = cube12.GetComponent<Rigidbody>();
        Rigidbody cube13Rigidbody = cube13.GetComponent<Rigidbody>();
        Rigidbody cube14Rigidbody = cube14.GetComponent<Rigidbody>();

        //プレイヤーのRigidBodyを取得
        Rigidbody playerRigidbody = this.GetComponent<Rigidbody>();
        // 初期状態でキューブを固定
        cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube2Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube3Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube11Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube12Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube13Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        cube14Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    public void Update()
    {
        float dis1 = Vector3.Distance(cube.transform.position, player.transform.position);
        float dis2 = Vector3.Distance(cube2.transform.position, player.transform.position);
        float dis3 = Vector3.Distance(cube3.transform.position, player.transform.position);
        float dis4 = Vector3.Distance(cube4.transform.position, player.transform.position);
        float dis5 = Vector3.Distance(cube5.transform.position, player.transform.position);
        float dis6 = Vector3.Distance(cube6.transform.position, player.transform.position);
        float dis7 = Vector3.Distance(cube7.transform.position, player.transform.position);
        float dis8 = Vector3.Distance(cube8.transform.position, player.transform.position);
        float dis9 = Vector3.Distance(cube9.transform.position, player.transform.position);
        float dis10 = Vector3.Distance(cube10.transform.position, player.transform.position);
        float dis = Vector3.Distance(cube11.transform.position, player.transform.position);
        float dis12 = Vector3.Distance(cube12.transform.position, player.transform.position);
        float dis13 = Vector3.Distance(cube13.transform.position, player.transform.position);
        float dis14 = Vector3.Distance(cube14.transform.position, player.transform.position);
        float Wall2dis4 = Vector3.Distance(cube14.transform.position, StageWall2.transform.position);
        Rigidbody cube1Rigidbody = cube.GetComponent<Rigidbody>();
        Rigidbody cube2Rigidbody = cube2.GetComponent<Rigidbody>();
        Rigidbody cube3Rigidbody = cube3.GetComponent<Rigidbody>();
        Rigidbody cube4Rigidbody = cube4.GetComponent<Rigidbody>();
        Rigidbody cube5Rigidbody = cube5.GetComponent<Rigidbody>();
        Rigidbody cube6Rigidbody = cube6.GetComponent<Rigidbody>();
        Rigidbody cube7Rigidbody = cube7.GetComponent<Rigidbody>();
        Rigidbody cube8Rigidbody = cube8.GetComponent<Rigidbody>();
        Rigidbody cube9Rigidbody = cube9.GetComponent<Rigidbody>();
        Rigidbody cube10Rigidbody = cube10.GetComponent<Rigidbody>();
        Rigidbody cube11Rigidbody = cube11.GetComponent<Rigidbody>();
        Rigidbody cube12Rigidbody = cube12.GetComponent<Rigidbody>();
        Rigidbody cube13Rigidbody = cube13.GetComponent<Rigidbody>();
        Rigidbody cube14Rigidbody = cube14.GetComponent<Rigidbody>();
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();


        //横方向と縦方向の入力を取得
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

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

        // Does the ray intersect any objects excluding the player layer

        //前方向
        if (Physics.Raycast(rayforward, out hit, 1.5f))
        {
            if (hit.collider.name == "Cube")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis1 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube2")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis2 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube3")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis3 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube4")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis4 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube5")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis5 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube6")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis6 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube7")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis7 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube8")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis8 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube9")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis9 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube10")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis10 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube11")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube12")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis12 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis12 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    cube12.gameObject.transform.Translate(0, 0, 10000);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube13")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis13 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis13 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    cube13.gameObject.transform.Translate(0, 0, 10000);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }

            else if (hit.collider.name == "Cube14")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis14 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis14 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Forward");
            }
        }



        //右方向
        if (Physics.Raycast(rayright, out hit, 1.5f))
        {
            if (hit.collider.name == "Cube")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis1 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube2")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis2 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube3")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis3 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube4")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis4 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube5")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis5 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube6")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis6 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube7")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis7 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube8")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis8 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube9")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis9 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube10")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis10 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube11")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube12")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis12 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis12 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube13")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis13 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis13 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }

            else if (hit.collider.name == "Cube14")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis14 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis14 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Right");
            }
        }



        if (Physics.Raycast(rayleft, out hit, 1.5f))
        {
            if (hit.collider.name == "Cube")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis1 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube2")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis2 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube3")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis3 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube4")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis4 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube5")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis5 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube6")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis6 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube7")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis7 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube8")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis8 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube9")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis9 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube10")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis10 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube11")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube12")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis12 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis12 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube13")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis13 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis13 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }

            else if (hit.collider.name == "Cube14")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis14 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis14 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Left");
            }
        }

        if(Physics.Raycast(rayback, out hit, 1.5f))
        {
            if (hit.collider.name == "Cube")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis1 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube2")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis2 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube3")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis3 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube4")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis4 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube5")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis5 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube6")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis6 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube7")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis7 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube8")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis8 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube9")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis9 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube10")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis10 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube Back");
            }

            else if (hit.collider.name == "Cube11")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube back");
            }

            else if (hit.collider.name == "Cube12")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis12 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis12 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube back");
            }

            else if (hit.collider.name == "Cube13")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis13 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis13 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube back");
            }

            else if (hit.collider.name == "Cube14")
            {
                //移動アニメーションの制御
                if (Input.GetKey(KeyCode.J) && dis14 < 2.8f)
                {
                    animator.SetBool("StanbyMode", true);
                    animator.SetBool("Run", false);

                }
                else if (Input.GetKey(KeyCode.K) && dis14 < 2.8f)
                {
                    animator.SetBool("Kick", true);
                    animator.SetBool("Run", false);
                    animator.SetBool("StanbyMode", false);
                    Debug.Log("Kick");
                }
                else
                {
                    animator.SetBool("StanbyMode", false);
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    animator.SetBool("Kick", false);
                }
                Debug.Log("Hit to Cube back");
            }

        }


            ////移動アニメーションの制御
            //if (Input.GetKey(KeyCode.J) && dis < 2.8f)
            //{
            //    animator.SetBool("StanbyMode", true);
            //    animator.SetBool("Run", false);

            //}
            //else
            //{
            //    animator.SetBool("StanbyMode", false);
            //    animator.SetBool("Push", false);
            //    animator.SetBool("Pull", false);
            //}

        if (inputVertical != 0)
        {
            //前方向
            //Cube
            if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis1 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube")
            {
                animator.SetBool("Push", true);
                cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube1Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis1 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube")
            {
                animator.SetBool("Pull", true);
                cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube1Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube2
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis2 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube2")
            {
                animator.SetBool("Push", true);
                cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube2Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis2 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube2")
            {
                animator.SetBool("Pull", true);
                cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube2Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube3
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis3 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube3")
            {
                animator.SetBool("Push", true);
                cube3Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube3Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis3 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube3")
            {
                animator.SetBool("Pull", true);
                cube3Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube3Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube4
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis4 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube4")
            {
                animator.SetBool("Push", true);
                cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube4Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis4 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube4")
            {
                animator.SetBool("Pull", true);
                cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube4Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube5
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis5 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube5")
            {
                animator.SetBool("Push", true);
                cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube5Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis5 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube5")
            {
                animator.SetBool("Pull", true);
                cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube5Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube6
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis6 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube6")
            {
                animator.SetBool("Push", true);
                cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube6Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis6 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube6")
            {
                animator.SetBool("Pull", true);
                cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube6Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube7
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis7 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube7")
            {
                animator.SetBool("Push", true);
                cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube7Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis7 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube7")
            {
                animator.SetBool("Pull", true);
                cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube7Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube8
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis8 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube8")
            {
                animator.SetBool("Push", true);
                cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube8Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis8 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube8")
            {
                animator.SetBool("Pull", true);
                cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube8Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube9
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis9 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube9")
            {
                animator.SetBool("Push", true);
                cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube9Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis9 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube9")
            {
                animator.SetBool("Pull", true);
                cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube9Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube10
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis10 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube10")
            {
                animator.SetBool("Push", true);
                cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube10Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis10 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube10")
            {
                animator.SetBool("Pull", true);
                cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube10Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube11
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube11")
            {
                animator.SetBool("Push", true);
                cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube11Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube11")
            {
                animator.SetBool("Pull", true);
                cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube11Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube12
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis12 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube12")
            {
                animator.SetBool("Push", true);
                cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube12Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis12 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube12")
            {
                animator.SetBool("Pull", true);
                cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube12Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube13
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis13 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube13")
            {
                animator.SetBool("Push", true);
                cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube13Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis13 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube13")
            {
                animator.SetBool("Pull", true);
                cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube13Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube14
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis14 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube14")
            {
                animator.SetBool("Push", true);
                cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube14Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis14 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube14")
            {
                animator.SetBool("Pull", true);
                cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube14Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }


            //後ろ方向
            //Cube1
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis1 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube")
            {
                animator.SetBool("Push", true);
                cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube1Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis1 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube")
            {
                animator.SetBool("Pull", true);
                cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube1Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube2
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis2 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube2")
            {
                animator.SetBool("Push", true);
                cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube2Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis2 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube2")
            {
                animator.SetBool("Pull", true);
                cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube2Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube3
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis3 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube3")
            {
                animator.SetBool("Push", true);
                cube3Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube3Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis3 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube3")
            {
                animator.SetBool("Pull", true);
                cube3Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube3Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube4
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis4 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube4")
            {
                animator.SetBool("Push", true);
                cube4Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube4Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis4 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube4")
            {
                animator.SetBool("Pull", true);
                cube4Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube4Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube5
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis5 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube5")
            {
                animator.SetBool("Push", true);
                cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube5Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis5 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube5")
            {
                animator.SetBool("Pull", true);
                cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube5Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube6
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis6 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube6")
            {
                animator.SetBool("Push", true);
                cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube6Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis6 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube6")
            {
                animator.SetBool("Pull", true);
                cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube6Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube7
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis7 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube7")
            {
                animator.SetBool("Push", true);
                cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube7Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis7 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube7")
            {
                animator.SetBool("Pull", true);
                cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube7Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube8
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis8 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube8")
            {
                animator.SetBool("Push", true);
                cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube8Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis8 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube8")
            {
                animator.SetBool("Pull", true);
                cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube8Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube9
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis9 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube9")
            {
                animator.SetBool("Push", true);
                cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube9Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis9 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube9")
            {
                animator.SetBool("Pull", true);
                cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube9Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube10
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis10 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube10")
            {
                animator.SetBool("Push", true);
                cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube10Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis10 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube10")
            {
                animator.SetBool("Pull", true);
                cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                cube10Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube11
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube11")
            {
                animator.SetBool("Push", true);
                cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube11Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube11")
            {
                animator.SetBool("Pull", true);
                cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube11Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube12
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis12 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube12")
            {
                animator.SetBool("Push", true);
                cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube12Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis12 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube12")
            {
                animator.SetBool("Pull", true);
                cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube12Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube13
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis13 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube13")
            {
                animator.SetBool("Push", true);
                cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube13Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis13 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube13")
            {
                animator.SetBool("Pull", true);
                cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube13Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }

            //Cube14
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis14 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube14")
            {
                animator.SetBool("Push", true);
                cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube14Rigidbody.transform.position += Vector3.back * 3 * Time.deltaTime; //前方に移動
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis14 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube14")
            {
                animator.SetBool("Pull", true);
                cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                cube14Rigidbody.transform.position += Vector3.forward * 3 * Time.deltaTime; //後ろに移動
                Debug.Log("Did Pull");
            }
            else
            {
                animator.SetBool("Run", true);
                cube11Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        else if (inputHorizontal != 0)
        {
                //右方向
                //Cube1
                if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis1 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube1")
                {
                    animator.SetBool("Push", true);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube1Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis1 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube1")
                {
                    animator.SetBool("Pull", true);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube1Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube2
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis2 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Push", true);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube2Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis2 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Pull", true);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube2Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube3
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis3 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Push", true);
                    cube3Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube3Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis3 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Pull", true);
                    cube3Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube3Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube4
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis4 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Push", true);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube4Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis4 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Pull", true);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube4Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube5
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis5 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Push", true);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube5Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis5 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Pull", true);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube5Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube6
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis6 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Push", true);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube6Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis6 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Pull", true);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube6Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube7
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis7 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Push", true);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube7Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis7 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Pull", true);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube7Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube8
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis8 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Push", true);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube8Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis8 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Pull", true);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube8Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube9
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis9 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Push", true);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube9Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis9 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Pull", true);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube9Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube10
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis10 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Push", true);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube10Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis10 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Pull", true);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube10Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube11
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Push", true);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube11Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Pull", true);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube11Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube12
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis12 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Push", true);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube12Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis12 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Pull", true);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube12Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube13
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis13 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Push", true);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube13Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis13 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Pull", true);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube13Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube14
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis14 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Push", true);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube14Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis14 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Pull", true);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube14Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }
                else
                {
                    animator.SetBool("Run", true);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                }


                //左方向
                //Cube1
                if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis1 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube1")
                {
                    animator.SetBool("Push", true);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube1Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis1 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube1")
                {
                    animator.SetBool("Pull", true);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube1Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube2
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis2 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Push", true);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube2Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis2 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Pull", true);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube2Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube3
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis3 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Push", true);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube1Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis3 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Pull", true);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube1Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube4
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis4 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Push", true);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube4Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis4 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Pull", true);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube4Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube5
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis5 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Push", true);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube5Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis5 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Pull", true);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube5Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube6
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis6 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Push", true);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube6Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis6 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Pull", true);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube6Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube7
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis7 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Push", true);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube7Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis7 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Pull", true);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube7Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube8
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis8 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Push", true);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube8Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis8 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Pull", true);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube8Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube9
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis9 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Push", true);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube9Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis9 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Pull", true);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube9Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube10
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis10 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Push", true);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube10Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis10 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Pull", true);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    cube10Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube11
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Push", true);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube11Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Pull", true);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube11Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube12
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis12 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Push", true);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube12Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis12 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Pull", true);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube12Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube13
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis13 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Push", true);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube13Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis13 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Pull", true);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube13Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }

                //Cube14
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis14 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Push", true);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube14Rigidbody.transform.position += Vector3.left * 3 * Time.deltaTime; //前方に移動
                }
                else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis14 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Pull", true);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube14Rigidbody.transform.position += Vector3.right * 3 * Time.deltaTime; //後ろに移動
                    Debug.Log("Did Pull");
                }
                else
                {
                    animator.SetBool("Run", true);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                }
        }

        if (inputHorizontal == 0 && inputVertical == 0)
         {

            if(Input.GetKey(KeyCode.J))
            {
                //前方向
                //Cube1
                if (dis1 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube2
                else if (dis2 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube3
                else if (dis3 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube3Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube4
                else if (dis4 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube5
                else if (dis5 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube6
                else if (dis6 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube7
                else if (dis7 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube8
                else if (dis8 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube9
                else if (dis9 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube10
                else if (dis10 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube11
                else if (dis < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube12
                else if (dis12 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube13
                else if (dis13 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube14
                else if (dis14 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                else if (Input.GetKey(KeyCode.K) && Wall2dis4 > 0.0f && Physics.Raycast(rayforward, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Kick", true);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    cube14Rigidbody.transform.position += Vector3.forward * 12 * Time.deltaTime; //前方に移動
                }
                //後ろ方向
                //Cube1
                else if (dis1 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube1")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube2
                else if (dis2 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube3
                else if (dis3 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube3Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube4
                else if (dis4 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube5
                else if (dis5 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube6
                else if (dis6 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube7
                else if (dis7 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube8
                else if (dis8 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube9
                else if (dis9 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube10
                else if (dis10 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube11
                else if (dis < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube12
                else if (dis12 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube13
                else if (dis13 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube14
                else if (dis14 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }

                //右方向
                //Cube1
                else if (dis1 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube2
                else if (dis2 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube3
                else if (dis3 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube3Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube4
                else if (dis4 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube5
                else if (dis5 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube6
                else if (dis6 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube7
                else if (dis7 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube7")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube7Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube8
                else if (dis8 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube9
                else if (dis9 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube10
                else if (dis10 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube11
                else if (dis < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube12
                else if (dis12 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube13
                else if (dis13 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube14
                else if (dis14 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }

                //左方向
                //Cube1
                else if (dis1 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube2
                else if (dis2 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube2")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube2Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube3
                else if (dis3 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube3")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube3Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube4
                else if (dis4 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube4")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube4Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube5
                else if (dis5 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube5")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube5Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube6
                else if (dis6 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube6")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube6Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube7
                else if (dis1 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube1Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube8
                else if (dis8 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube8")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube8Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube9
                else if (dis9 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube9")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube9Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube10
                else if (dis10 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube10")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube10Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube11
                else if (dis < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube11")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube11Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube12
                else if (dis12 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube12")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube12Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube13
                else if (dis13 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube13")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube13Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
                //Cube14
                else if (dis14 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f) && hit.collider.name == "Cube14")
                {
                    animator.SetBool("Push", false);
                    animator.SetBool("Pull", false);
                    cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log("Did not Pull");

                }
            }
            else
            {
                animator.SetBool("Run", false);
                cube11Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        //Cube1
        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis1 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube2
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis2 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube3
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis3 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube4
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis4 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube5
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis5 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube6
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis6 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube7
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis7 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube8
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis8 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube9
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis9 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube10
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis10 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube11
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube12
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis12 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube13
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis13 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        //Cube14
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A) && dis14 < 2.8f && Physics.Raycast(rayright, out hit, 1.5f))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKey(KeyCode.A)) //Aキーが押されたら
        {
            transform.position += Vector3.left * 5 * Time.deltaTime; //左に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        //Cube1
        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis1 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube2
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis2 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube3
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis3 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube4
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis4 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube5
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis5 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube6
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis6 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube7
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis7 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube8
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis8 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube9
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis9 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube10
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis10 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube11
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube12
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis12 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube13
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis13 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        //Cube14
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.D) && dis14 < 2.8f && Physics.Raycast(rayleft, out hit, 1.5f))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else if (Input.GetKey(KeyCode.D)) //Dキーが押されたら
        {
            transform.position += Vector3.right * 5 * Time.deltaTime; //右に移動
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        //Cube1
        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis1 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube2
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis2 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube3
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis3 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube4
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis4 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube5
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis5 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube6
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis6 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube7
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis7 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube8
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis8 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube9
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis9 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube10
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis10 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube11
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube12
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis12 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube13
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis13 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Cube14
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.W) && dis14 < 2.8f && Physics.Raycast(rayback, out hit, 1.5f))
        {
            transform.position += Vector3.forward * 3 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.W)) //Wキーが押されたら
        {
            transform.position += Vector3.forward * 5 * Time.deltaTime; //前に移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Cube1
        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis1 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube2
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis2 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube3
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis3 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube4
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis4 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube5
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis5 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube6
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis6 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube7
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis7 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube8
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis8 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube9
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis9 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube10
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis10 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube11
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube12
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis12 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube13
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis13 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Cube14
        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.S) && dis14 < 2.8f && Physics.Raycast(rayforward, out hit, 1.5f))
        {
            transform.position += Vector3.back * 3 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S)) //Sキーが押されたら
        {
            transform.position += Vector3.back * 5 * Time.deltaTime; //後ろに移動
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //DummyModel
        if(Physics.Raycast(rayforward, out hit, 0.5f)&& hit.collider.name == "DummyModel")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if (Physics.Raycast(rayright, out hit, 0.5f) && hit.collider.name == "DummyModel")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if (Physics.Raycast(rayleft, out hit, 0.5f) && hit.collider.name == "DummyModel")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if (Physics.Raycast(rayback, out hit, 0.5f) && hit.collider.name == "DummyModel")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }


        //DummyModel2
        if (Physics.Raycast(rayforward, out hit, 0.5f) && hit.collider.name == "DummyModel2")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if (Physics.Raycast(rayright, out hit, 0.5f) && hit.collider.name == "DummyModel2")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if (Physics.Raycast(rayleft, out hit, 0.5f) && hit.collider.name == "DummyModel2")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if (Physics.Raycast(rayback, out hit, 0.5f) && hit.collider.name == "DummyModel2")
        {
            player1 = gameObject.GetComponent<Player1Script>();
            player1.enabled = false;
            playerRigidbody.velocity = Vector3.zero;
            animator.SetBool("Death", true);
            Invoke(nameof(doDestroy), 1.8f);
        }

        if(Physics.Raycast(rayforward, out hit, 0.5f) && hit.collider.name == "StageWall2")
        {
            Invoke(nameof(OnCollisionEnter), 1.8f);
        }

    }

    void doDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody cube14Rigidbody = cube14.GetComponent<Rigidbody>();

        float Wall2dis4 = Vector3.Distance(cube14.transform.position, StageWall2.transform.position);
        Vector3 rayPosition = transform.position + new Vector3(0, 1f, 0);
        Debug.DrawRay(rayPosition, transform.TransformDirection(Vector3.forward) * 1.0f, Color.yellow);
        Ray rayforward = new Ray(rayPosition, Vector3.forward);
        Ray rayright = new Ray(rayPosition, Vector3.right);
        Ray rayleft = new Ray(rayPosition, Vector3.left);
        Ray rayback = new Ray(rayPosition, Vector3.back);
        RaycastHit hit;

        cube14Rigidbody.velocity = Vector3.zero;
        
        if (animator.GetBool("Push"))
        {

        }

        if(animator.GetBool("Pull"))
        {
            
        }

        Debug.Log("Hit");
        //Debug.Log(col.transform.position);
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.CompareTag("Cube"))
        {
            animator.SetBool("Kick", false);
        }
        if (animator.GetBool("Push"))
        {
            
        }

        if (animator.GetBool("Pull"))
        {
            
        }
    }      
}
