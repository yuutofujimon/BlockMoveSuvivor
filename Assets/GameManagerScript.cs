using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[���S�̂��Ǘ�����}�l�[�W���[�X�N���v�g�N���X
public class GameManagerScript : MonoBehaviour
{
    //�L���[�u�p�ϐ�
    [SerializeField] GameObject[] cubeObjects = new GameObject[10];
    //�L���[�u�X�N���v�g�p�̕ϐ�
    CubeScript[] cubeScripts = new CubeScript[10];
    //�Q�[���X�e�[�^�X�p�ϐ�
    int gameStatus = 0;
    //���ԊǗ��p�ϐ�
    float myTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //�L���[�u�X�N���v�g���擾
        for (int i = 0; i< cubeObjects.Length; i++)
        {
            cubeScripts[i] = cubeObjects[i].GetComponent<CubeScript>();
        }

    }

    //�����ݒ�p���\�b�h
    void doInit()
    {
        //�L���[�u��z�u
        for(int i = 0; i < cubeObjects.Length; i++)
        {
            cubeScripts[i].doSetPos(i);
            //�L���[�u�̃C�[�W���O�ݒ�
            cubeScripts[i].doSetEasing();
        }
        //�X�e�[�^�X�X�V
        gameStatus++;
    }

    //�C�[�W���O�p���\�b�h
    void doEasing()
    {
        for (int i = 0; i < 10; i++)
        {
            cubeScripts[i].doEasing(i);
        }
        if(doWait(2.0f) == true)
        {
            //�X�e�[�^�X���X�V
            gameStatus++;
        }
    }

    //�C���Q�[���p���\�b�h
    void doInGame()
    {
        //�X�y�[�X�L�[�̓��͊m�F
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < cubeScripts.Length; i++)
            {
                cubeScripts[i].doSetAnim();
            }
        }
        //�L���[�u�̃A�j���[�V����
        for(int i = 0; i < cubeObjects.Length; i++)
        {
            cubeScripts[i].doAnim(i);
        }
    }

    //�A�E�g�Q�[���p���\�b�h
    void doOutGame()
    {
        //�X�e�[�^�X����
        switch (gameStatus)
        {
            case 0:
                doInit();//�����ݒ�
                break;
            case 1:
                doEasing();//�C�[�W���O
                break;
            case 2:
                doInGame();//�C���Q�[��
                break;
            default:
                break;

        }
    }

    //���ԑҋ@�p���\�b�h
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
        //�A�E�g�Q�[��
        doOutGame();
    }
}
