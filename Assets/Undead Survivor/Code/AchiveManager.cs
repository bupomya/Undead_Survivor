using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    public GameObject uiNotice;


    enum Archive
    {
        UnlockPotato,
        UnlockBean
    }
    Archive[] achives;

    WaitForSecondsRealtime wait;

    private void Awake()
    {
        achives = (Archive[]) Enum.GetValues(typeof(Archive));
        wait = new WaitForSecondsRealtime(5);

        if(!PlayerPrefs.HasKey("MyData"))
            Init();
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach(Archive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }

    }

    void Start()
    {
        UnlockCharacter();
    }

    void UnlockCharacter()
    {
        for(int i = 0; i < lockCharacter.Length; i++)
        {
            string achiveName = achives[i].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            lockCharacter[i].SetActive(!isUnlock);
            unlockCharacter[i].SetActive(isUnlock);
        }
    }

    
    void LateUpdate()
    {
        foreach(Archive archive in achives)
        {
            CheckArchive(archive);
        }
    }

    void CheckArchive(Archive archive)
    {
        bool isAchive = false;

        switch (archive)
        {
            case Archive.UnlockPotato:
                isAchive = GameManager.instance.kill >= 10;
                break;
            case Archive.UnlockBean:
                isAchive = GameManager.instance.gameTime == GameManager.instance.maxGameTime;
                break;
        }

        if (isAchive && PlayerPrefs.GetInt(archive.ToString()) == 0)
        {
            PlayerPrefs.SetInt(archive.ToString(), 1);

            for (int i = 0; i < uiNotice.transform.childCount; i++)
            {
                bool isActive = i == (int)archive;
                uiNotice.transform.GetChild(i).gameObject.SetActive(isActive);
            }

            StartCoroutine(NoticeRoutine());
        }
    }

    IEnumerator NoticeRoutine()
    {
        uiNotice.SetActive(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUp);

        yield return wait;

        uiNotice.SetActive(false);
    }
}
