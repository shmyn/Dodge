using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��-�� ��쿡�� ���� ���� �� ����ۤ�
using System.Globalization;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���ӿ��� ����

    void Start()
    {
        //���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        //���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
            ///���⼭ timeText�� Time Text ���� ������Ʈ�� Text �ʵ��� ��ũ��Ʈ �� �ؽ�Ʈ ������ �ƴϿ���~
            ///������ ���� ǥ���� ���� (int) �߰�.
        }
        else
        {
            //���ӿ��� ���¿��� R Ű�� ���� ���
            if (Input.GetKey(KeyCode.R))
            {
                //SampleScene ���� �ε�-����Ƽ ���� �� ������
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    //���� ������ ���ӿ��� ���·κ����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTIme Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }
        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
