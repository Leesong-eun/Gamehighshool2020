using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Durngeon2 : MonoBehaviour
{
    public Transform d_StartPoint;
    public PlayerController_Dungeon2 d_player;

    public Text d_ClearUI;
    public Text d_ScoreUI;

    public float d_Score;

    public bool m_isPlaying;

    private void Start()
    {
        GameStart1();

    }
    void Update()
    {
        //시간당 점수업
        if (m_isPlaying)
        {
            d_Score = d_Score + Time.deltaTime;
            d_ScoreUI.text = string.Format("Score : {0}", d_Score);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameStart1();
            }
        }
    }

    // Start is called before the first frame update
    public void GameStart1 ()
    {
        m_isPlaying = true;
        //출발지점에서 플레이어가 스폰
        d_player.gameObject.SetActive(true);
        d_player.transform.position = d_StartPoint.position;
        d_player.transform.rotation = d_StartPoint.rotation;
        //게임 클리어 메세지가 보이지 않는다.
        d_ClearUI.gameObject.SetActive(false);
        //게임 스코어 메세지가 보인다.
        d_ScoreUI.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void GameClear1()
    {
        m_isPlaying = false;
        //플레이어가 비활성화된다.
        d_player.gameObject.SetActive(false);
        //게임 클리어 메세지가 보인다.
        d_ClearUI.gameObject.SetActive(true);
        //게임 스코어 메세지가 보인다
        d_ScoreUI.gameObject.SetActive(true);

        //활성화된 적은 비활성화
        var enemisType1 = FindObjectsOfType<RotationBulletSpawner>();
        foreach (var enemy in enemisType1)
        {
            enemy.gameObject.SetActive(false);
        }

        var enemisType2 = FindObjectsOfType<RotationBulletSpawner>();
        foreach (var enemy in enemisType1)
        {
            enemy.gameObject.SetActive(false);
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject); //Destroy(게임오브젝트) 게임오브젝트를 제거하는 기능
        }

        //클리어 타임 바른 1,2,3위를 저장 표시하기
        float num1 = PlayerPrefs.GetFloat("Numl", 999);
        float num2 = PlayerPrefs.GetFloat("Num2", 999);
        float num3 = PlayerPrefs.GetFloat("Num3", 999);

        if (d_Score < num1)
        {
            num3 = num2;
            num2 = num1;
            num1 = d_Score;
        }
        else if (d_Score < num3)
        {
            num3 = num2;
            num2 = d_Score;
        }
        else if (d_Score < num3)
        {
            num3 = d_Score;
        }

        PlayerPrefs.SetFloat("Numl", num1);
        PlayerPrefs.SetFloat("Num2", num2);
        PlayerPrefs.SetFloat("Num3", num3);
        PlayerPrefs.Save();

        d_ClearUI.text = string.Format("Game Clear\n 1위 : {0}, 2위 : {1}, 3dnl : {2}", num1, num2, num3);
    }

    public void SetActivityAllGameObject(Type type, bool isActivity)
    {
        var objects = FindObjectsOfType(type);
        foreach (var obj in objects)
        {
            var gobj = (GameObject)obj;
            gobj.SetActive(false);
        }


        
    }

    public void ReturnToStartPoint1()
    {
        //플레이어를 출발지점으로 되돌린다.
        d_player.transform.position = d_StartPoint.position;
        d_player.transform.rotation = d_StartPoint.rotation;
    }
}
