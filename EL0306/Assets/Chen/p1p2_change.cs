using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;  // 追加しましょう


public class p1p2_change : MonoBehaviour
{
    public int p1p2 = 1;


    public GameObject _P = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // オブジェクトからTextコンポーネントを取得
        TextMeshProUGUI score_text = _P.GetComponent<TextMeshProUGUI>();

        if (p1p2 == 1)
        {
            score_text.SetText("1P");
            score_text.color = new Color(222, 41, 22, 255);
        }
        if (p1p2 == 2)
        {
            score_text.SetText("2P");
            score_text.color = new Color(41, 222, 22, 255);
        }



    }
}
