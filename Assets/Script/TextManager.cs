using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening; // dotween 다운 필요

public class TextManager : MonoBehaviour
{
    public static TextManager instance;

    public Text text1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 매니저 존재");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //text1.DOText("내용적기", 시간); // 타자치는 효과

        //textFade.DOFade(1, 2); // 2초동안 페이드인(페이드아웃은 앞에를 0으로 바꾸기) 



    }


}
