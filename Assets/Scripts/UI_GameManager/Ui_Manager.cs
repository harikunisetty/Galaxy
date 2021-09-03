using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Manager : MonoBehaviour
{
    public static Ui_Manager Instance;

    [SerializeField] Text killCountTxt;
  
    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;

        killCountTxt.text = "KillCount:00";
    }

    public void KillCountUI()
    {
        killCountTxt.text = "KillCount: " + GameManager.Instance.KillCount.ToString();
    }
}
