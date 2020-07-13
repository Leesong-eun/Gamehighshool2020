using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Durngeon : MonoBehaviour
{
    public Transform m_StartPoint;
    public PlayerController_Dungeon2 m_player;

    public Text m_ClearUI;
    public Text m_ScoreUI;

    public void Start()
    {
        GameStart();
    }
    public void GameStart ()
    {
        //출발지점에서 플레이어가 스폰
        m_player.gameObject.SetActive(true);
        m_player.transform.position = m_StartPoint.position;
        m_player.transform.rotation = m_StartPoint.rotation;
        //게임 클리어 메세지가 보이지 않는다.
        m_ClearUI.gameObject.SetActive(false);
        //게임 스코어 메세지가 보인다.
        m_ScoreUI.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void GameClear()
    {
        //플레이어가 비활성화된다.
        //게임 클리어 메세지가 보인다.
        m_ClearUI.gameObject.SetActive(true);
        //게임 스코어 메세지가 보인다
        m_ScoreUI.gameObject.SetActive(true);
    }

    public void ReturnToStartPoint ()
    {
        //플레이어를 출발지점으로 되돌린다.
    }
}
