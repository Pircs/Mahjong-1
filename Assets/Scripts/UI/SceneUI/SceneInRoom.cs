﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SceneInRoom : SceneBase {

    Dictionary<int, Text> playersName = new Dictionary<int, Text>();
    Dictionary<int, Image> playersBack = new Dictionary<int, Image>();

    private Text roomName;

    private Image BgImage;

    public override void OnInit()
    {
        setSkinPath("UI/Scenes/" + SceneState.SceneInRoom.ToString());
        base.OnInit();
    }

    protected override void OnInitData()
    {
        for (int i = 1; i < 5; i++)
        {
            playersBack[i - 1] = skin.transform.Find("playerback" + i).GetComponent<Image>();
            playersName[i - 1] = playersBack[i - 1].transform.Find("Name").GetComponent<Text>();
        }
        BgImage = skin.transform.Find("BgImage").GetComponent<Image>();
        roomName = skin.transform.Find("roomName").GetComponent<Text>();
    }

    protected override void OnUpdate()
    {
        if (GameSetting.Instance.RoomData)
        {
            GameSetting.Instance.RoomData = false;
            playernum = 0;
            UpdateData(0, GameSetting.Instance.player1);
            UpdateData(1, GameSetting.Instance.player2);
            UpdateData(2, GameSetting.Instance.player3);
            UpdateData(3, GameSetting.Instance.player4);
            roomName.text = "房间:" + GameSetting.Instance.roomName;
            if (playernum == 4)
            {
                playernum = 0;
                BgImage.gameObject.SetActive(true);
                Invoke("Switch", 2f);
            }
        }
    }

    int playernum = 0;

    private void UpdateData(int id, string name)
    {
        if (!name.Equals("1"))
        {
            playernum++;
            playersName[id].text = name;
            playersName[id].gameObject.SetActive(true);
            playersBack[id].GetComponent<XTween>().isBig = true;
            playersBack[id].GetComponent<XTween>().isSmall = false;
        }
        else
        {
            playersName[id].text = "";
            playersName[id].gameObject.SetActive(false);
            playersBack[id].GetComponent<XTween>().isBig = false;
            playersBack[id].GetComponent<XTween>().isSmall = true;
        }
    }

    private void Switch()
    {
        Debug.Log("Go");
    }
}