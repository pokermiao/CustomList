using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Transform content;
    public GridLayout gridLayout;
    public GameObject item;
    public int pffsetValue;//偏离值
    public int moveValue;
    public int cellSize = 50;//单个item高度
    public int leftValue = 100;
    private List<GameObject> gameObjects = new List<GameObject>();
    public void Start()
    {
        Initial();
        scrollRect.onValueChanged.AddListener(onValueChanged);        
    }
    private void Update()
    {
        
    }
    private void Initial()
    {
        for(int i=0;i<20;i++)
        {
            GameObject go = GameObject.Instantiate(item);
            go.SetActive(true);
            gameObjects.Add(go);
            go.transform.SetParent(content);
        }
        InitialSize();
        CalutePos();
    }
    /// <summary>
    /// 初始化content大小
    /// </summary>
    private void InitialSize()
    {
        float width, height;
        height = gameObjects.Count * cellSize;
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, height);
    }
    /// <summary>
    /// 计算所有item的位置
    /// </summary>
    private void CalutePos()
    {
        for(int i=0;i< gameObjects.Count;i++)
        {
            GameObject temp = gameObjects[i];
            temp.transform.localScale = Vector3.one;
            temp.transform.localPosition = Vector3.zero + Vector3.right * pffsetValue * i + Vector3.down * i * cellSize + leftValue * Vector3.right;
        }
    }
    private void onValueChanged(Vector2 pos)
    {
        Debug.Log(pos);
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject temp = gameObjects[i];
            temp.transform.localScale = Vector3.one;
            //temp.transform.localPosition = Vector3.zero + Vector3.right * pffsetValue * i + Vector3.down * i * cellSize + leftValue * Vector3.right + moveValue * (1 - pos.y) * Vector3.right;
        }
    }
}
