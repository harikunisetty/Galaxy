using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    private int killCount;
    public int KillCount { get => killCount; }
    public static GameManager Instance;
    void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    public void UpdateKillCount()
    {
        killCount++;

        Ui_Manager.Instance.KillCountUI();
    }
}