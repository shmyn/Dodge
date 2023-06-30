using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ ź���� ���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�

    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0f�� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ������ spawnAfterMin�� spawnRateMax ���̿��� ���� ����//int���� f���ؾ� �Ҽ���o
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController ������Ʈ�� ���� ����� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform; 
        ///PlayerController playerController = FindObjectOfType<PlayerController>();
        ///target = playerController.transform;
        ///�� �� �ڵ带 �� �ٷ� ��ģ ��.
    }

    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate) {
            //������ �ð��� ����
            timeAfterSpawn = 0f;

            //bulletPrefab�� ��������
            //transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            //������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }

    }
}
