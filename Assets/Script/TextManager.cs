using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening; // dotween �ٿ� �ʿ�

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
            Debug.LogWarning("���� �ΰ� �̻��� �Ŵ��� ����");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //text1.DOText("��������", �ð�); // Ÿ��ġ�� ȿ��

        //textFade.DOFade(1, 2); // 2�ʵ��� ���̵���(���̵�ƿ��� �տ��� 0���� �ٲٱ�) 



    }


}
