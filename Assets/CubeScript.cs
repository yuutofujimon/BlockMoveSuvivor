using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


//キューブ用スクリプトクラス
public class CubeScript : MonoBehaviour
{
    //初期位置用変数
    Vector3 initPos = new Vector3(0.0f, 0.5f, -4.0f);
    //イージング用変数
    Vector3 aPos, bPos;
    float t = 0.0f;
    //アニメーション用変数
    Vector3 aScale, bScale;
    bool isAnim = false;
    public Transform Cube;
    public GameObject gameobject;
    private Animator animator; //アニメーターコンポーネント
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
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] array = new GameObject[10];


    }

    //イージング設定用メソッド
    public void doSetEasing()
    {
        aPos = transform.position;
        bPos = aPos + Vector3.down * 50.0f;
        t = 0.0f;
    }

    //イージング用メソッドのオーバーロード
    public void doEasing(int inIndex)
    {
        t += Time.deltaTime;
        if(t > 1.0f + inIndex * 0.1f)
        {
            t = 1.0f + inIndex * 0.1f;
        }
        if(t > inIndex * 0.1f)
        {
            aPos += Vector3.down * 20.0f * Time.deltaTime;
            transform.position = Vector3.Lerp(aPos, bPos, t - inIndex * 0.1f);
        }
    }

    //イージング用メソッド
    public void doEasing()
    {
        t += Time.deltaTime;
        if(t > 1.0f)
        {
            t = 1.0f;
        }
        aPos += Vector3.up * 10.0f * Time.deltaTime;
        transform.position = Vector3.Lerp(aPos, bPos, t);
    }

    //初期設定用メソッドのオーバーロード
    public void doSetPos(int inIndex)
    {
        transform.position = new Vector3(14.52f, 51.32f, inIndex * 2.58f - 2.6f);
    }

    //配置用メソッド
    public void doSetPos()
    {
        transform.position = initPos;
    }

    //アニメーション設定
    public void doSetAnim()
    {
        if(isAnim == false)
        {
            isAnim = true;
            aScale = new Vector3(2.58f, 2.58f, 2.58f) * 1.5f;
            bScale = new Vector3(2.58f, 2.58f, 2.58f);
            t = 0.0f;
        }
    }

    //アニメーション用メソッド
    public void doAnim(int inIndex)
    {
        //アニメーション用のフラグの確認
        if(isAnim ==true)
        {
            t += Time.deltaTime * 2.0f;
            if(t > 1.0f + inIndex * 0.1f)
            {
                t = 1.0f + inIndex * 0.1f;
                isAnim = false;
            }
            if( t > inIndex * 0.1f)
            {
                transform.localPosition = Vector3.Lerp(aScale, bScale, t - inIndex * 0.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector3 rayPosition = transform.position + new Vector3(0, 1f, 0);
        Ray rayforward = new Ray(rayPosition, Vector3.forward);
        Ray rayright = new Ray(rayPosition, Vector3.right);
        Ray rayleft = new Ray(rayPosition, Vector3.left);
        Ray rayback = new Ray(rayPosition, Vector3.back);
        RaycastHit hit;
        float Wall2dis4 = Vector3.Distance(cube14.transform.position, StageWall2.transform.position);
        if (Input.GetKey(KeyCode.K) && Wall2dis4 > 0.0f && !Physics.Raycast(rayforward, out hit, 2.0f))
        {

            cube14Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            cube14Rigidbody.transform.position += Vector3.forward * 4 * Time.deltaTime; //前方に移動
        }
        else
        {
            Invoke(nameof(OnCollisionEnter), 1.8f);
        }

    }
    void CubeGravity()
    {
        GetComponent<Rigidbody>().useGravity = true;
        FixedJoint fj = this.gameObject.GetComponent<FixedJoint>();
        fj.connectedBody = gameobject.GetComponent<Rigidbody>();
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

        return;
    }

    void OnCollisionExit(Collision col)
    {
       
    }
}
