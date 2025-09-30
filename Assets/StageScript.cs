using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    [SerializeField] GameObject cube11;
    private GameObject[,] gameObjectArray = new GameObject[7, 13];
    private Vector3[,] PositionArray = new Vector3[7, 13];
    public GameObject tilePrefab; // �}�X�p�̃v���n�u��Inspector�Ŏw��
    public string csvFileName = "MapData"; // CSV�t�@�C�����i�g���q�s�v�j
    // Start is called before the first frame update
    void Start()
    {
        int height = gameObjectArray.GetLength(0);
        int width = gameObjectArray.GetLength(1);

        //�X�e�[�W�̒��S�����_�ɗ���悤�ɃI�t�Z�b�g���v�Z
        float offsetX = -(width * 2.4f) / 2.0f + 2.4f / 2.0f;
        float offsetZ = -(height * 2.4f) / 2.0f + 2.4f / 2.0f;

    }

    void GenerateMapFromCSV(string fileName)
    {
        // Resources�t�H���_����CSV��ǂݍ���
        TextAsset csvFile = Resources.Load<TextAsset>(fileName);
        if (csvFile == null)
        {
            Debug.LogError($"CSV�t�@�C�� {fileName} ��������܂���I");
            return;
        }

        // CSV���s���Ƃɕ���
        string[] lines = csvFile.text.Split('\n');

        for (int y = 0; y < lines.Length; y++)
        {
            // �s���J���}�ŕ������Ēl���擾
            string[] values = lines[y].Trim().Split(',');

            for (int x = 0; x < values.Length; x++)
            {
                // �l�� "1" �̏ꍇ�̂݃}�X�𐶐�
                if (values[x] == "1")
                {
                    // �}�X�i�^�C���j�𐶐�
                    Vector3 position = new Vector3(x, 0, -y); // ��: X-Z���ʂɔz�u
                    Instantiate(tilePrefab, position, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
