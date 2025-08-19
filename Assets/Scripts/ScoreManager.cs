using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance { get; private set; }
    private GameObject scorePrefab;//分数预制体
    public Sprite[] scoreSprites3000;//3000分的分数图片
    public Sprite[] scoreSprites5000;//5000分的分数图片
    public Sprite[] scoreSprites10000;//10000分的分数图片
    private Dictionary<int, Sprite[]> scoreSpritesDict;//分数字典

    // Start is called before the first frame update
    void Awake()
    {
        scorePrefab = Resources.Load<GameObject>("Score");
        //Debug.Log(scorePrefab);
        Instance = this;
        scoreSpritesDict = new Dictionary<int, Sprite[]>();
        scoreSpritesDict.Add(3000, scoreSprites3000);
        scoreSpritesDict.Add(5000, scoreSprites5000);
        scoreSpritesDict.Add(10000, scoreSprites10000);
    }




    public void ShowScore(Vector3 position, int score)
    {
        GameObject scoreGo = GameObject.Instantiate(scorePrefab, position, Quaternion.identity);

        Sprite[] scoreArray;
        scoreSpritesDict.TryGetValue(score, out scoreArray);

        int index = Random.Range(0, scoreArray.Length);
        Debug.Log(index + "dd"+scoreArray.Length);
        Sprite sprite = scoreArray[index];

        scoreGo.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}

