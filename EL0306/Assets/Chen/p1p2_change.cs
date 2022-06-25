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
            score_text.color = new Color32(255, 97, 83, 255);
            score_text.SetText("1P");
            
        }
        if (p1p2 == 2)
        {
            score_text.color = new Color32(139, 180, 255, 255);
            score_text.SetText("2P");
            
        }



    }
}
