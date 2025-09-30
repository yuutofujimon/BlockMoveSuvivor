using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲーム全体を管理するマネージャースクリプトクラス
public class GameManagerScript : MonoBehaviour
{
    //キューブ用変数
    [SerializeField] GameObject[] cubeObjects = new GameObject[10];
    //キューブスクリプト用の変数
    CubeScript[] cubeScripts = new CubeScript[10];
    //ゲームステータス用変数
    int gameStatus = 0;
    //時間管理用変数
    float myTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //キューブスクリプトを取得
        for (int i = 0; i< cubeObjects.Length; i++)
        {
            cubeScripts[i] = cubeObjects[i].GetComponent<CubeScript>();
        }

    }

    //初期設定用メソッド
    void doInit()
    {
        //キューブを配置
        for(int i = 0; i < cubeObjects.Length; i++)
        {
            cubeScripts[i].doSetPos(i);
            //キューブのイージング設定
            cubeScripts[i].doSetEasing();
        }
        //ステータス更新
        gameStatus++;
    }

    //イージング用メソッド
    void doEasing()
    {
        for (int i = 0; i < 10; i++)
        {
            cubeScripts[i].doEasing(i);
        }
        if(doWait(2.0f) == true)
        {
            //ステータスを更新
            gameStatus++;
        }
    }

    //インゲーム用メソッド
    void doInGame()
    {
        //スペースキーの入力確認
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < cubeScripts.Length; i++)
            {
                cubeScripts[i].doSetAnim();
            }
        }
        //キューブのアニメーション
        for(int i = 0; i < cubeObjects.Length; i++)
        {
            cubeScripts[i].doAnim(i);
        }
    }

    //アウトゲーム用メソッド
    void doOutGame()
    {
        //ステータス処理
        switch (gameStatus)
        {
            case 0:
                doInit();//初期設定
                break;
            case 1:
                doEasing();//イージング
                break;
            case 2:
                doInGame();//インゲーム
                break;
            default:
                break;

        }
    }

    //時間待機用メソッド
    bool doWait(float inTime)
    {
        myTime += Time.deltaTime;
        if(myTime > inTime)
        {
            myTime = 0.0f;
            return true;
        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        //アウトゲーム
        doOutGame();
    }
}
