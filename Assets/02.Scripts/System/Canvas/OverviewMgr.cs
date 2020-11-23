using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// 오버뷰 매니저 
// 하이어라키 탐색 후 거리계산 오버뷰 표시

public class OverviewMgr : MonoBehaviour
{
    private List<GameObject> objList = new List<GameObject>();

    RectTransform m_RectTransform;
    float m_XAxis, m_YAxis;
    float m_Width, m_Height;

    private void Start()
    {
        m_XAxis = 0; m_YAxis = -40;
        m_Width = 300; m_Height = 80;

        objList.Add(GameObject.FindGameObjectWithTag("Sun"));
        objList.Add(GameObject.FindGameObjectWithTag("Planet"));
        objList.Add(GameObject.FindGameObjectWithTag("Station"));
        objList.Add(GameObject.FindGameObjectWithTag("Anomaly"));

        for (int i = 0; i < objList.Count; ++i)
        {
            if(objList[i] == null)
            {
                objList.RemoveAt(i);
            }

            Debug.Log(objList[i].name);
        }

        for(int i = 0; i < objList.Count; ++i)
        {
            CreateText(i, objList[i].name);
        }
    }

    private void CreateText(int count, string name)
    {
        // 텍스트 박스 생성
        GameObject gameObject = new GameObject("Text");

        // 텍스트 박스 부모 설정
        gameObject.transform.SetParent(this.transform.Find("Overview"));

        // 텍스트 이름, 폰트 설정
        gameObject.AddComponent<Text>().text = name;
        gameObject.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
        gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        // 텍스트 위치 설정
        m_RectTransform = gameObject.GetComponent<RectTransform>();
        m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis + (count * -80));
        m_RectTransform.sizeDelta = new Vector2(m_Width, m_Height);
        m_RectTransform.anchorMin = new Vector2(0.5f, 1.0f);
        m_RectTransform.anchorMax = new Vector2(0.5f, 1.0f);
    }
}
