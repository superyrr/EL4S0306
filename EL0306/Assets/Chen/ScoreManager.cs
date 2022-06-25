using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;  // 追加しましょう

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null;
    public int C_Count = 0;

    private string S_Count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        TextMeshProUGUI score_text = score_object.GetComponent<TextMeshProUGUI>();
        // テキストの表示を入れ替える
        C_Count = Score.score;
        S_Count = C_Count.ToString();
        score_text.SetText(S_Count);
    }
}
