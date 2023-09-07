using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리-이 경우에는 게임 도중 씬 재시작
using System.Globalization;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임오버 상태

    void Start()
    {
        //생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        //게임오버가 아닌 동안
        if (!isGameover)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
            ///여기서 timeText는 Time Text 게임 오브젝트의 Text 컴포넌트를 받는 변수명. 뒤에 .text 붗여서 필드를 가리킴.
            ///간단한 숫자 표현을 위해 (int) 추가.
        }
        else
        {
            //게임오버 상태에서 R 키를 누른 경우
            if (Input.GetKey(KeyCode.R))
            {
                //SampleScene 씬을 로드-유니티 내장 씬 관리자
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    //현재 게임을 게임오버 상태로변경하는 메서드
    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTIme 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }
        // 최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
