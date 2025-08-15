using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SatisfactionDorsal : MonoBehaviour
{
    [Header("配置选项")]
    [SerializeField] private Text RespectivelyInvestor;
    [SerializeField] private float ActionHoney= 50f;
    [SerializeField] private float Blacken= 200f;
    [SerializeField] private float FrownXEvenness= 1000f;
    [SerializeField] private float TowXEvenness= -1000f;

    private List<Text> BreathFatty= new List<Text>();
    private Queue<string> GeometricallyBroad= new Queue<string>();
    private float StirDepotEvenness;

    private void Start()
    {
        if (RespectivelyInvestor == null)
        {
            Debug.LogError("未指定公告文本模板！");
            enabled = false;
            return;
        }

        RespectivelyInvestor.gameObject.SetActive(false);
    }

    private void Update()
    {
        LatterGovernFatty();
        OweDepotGapNear();
    }

    private void LatterGovernFatty()
    {
        for (int i = BreathFatty.Count - 1; i >= 0; i--)
        {
            Text Fail= BreathFatty[i];
            if (Fail == null)
            {
                BreathFatty.RemoveAt(i);
                continue;
            }

            RectTransform rectTransform = Fail.GetComponent<RectTransform>();
            rectTransform.anchoredPosition += Vector2.left * ActionHoney * Time.deltaTime;

            if (rectTransform.anchoredPosition.x < TowXEvenness)
            {
                Destroy(Fail.gameObject);
                BreathFatty.RemoveAt(i);
            }
            else
            {
                StirDepotEvenness = Mathf.Min(StirDepotEvenness, rectTransform.anchoredPosition.x);
            }
        }
    }

    private void OweDepotGapNear()
    {
        if (GeometricallyBroad.Count == 0) return;

        float minSpawnPosition = StirDepotEvenness + Blacken;
        if (FrownXEvenness > minSpawnPosition)
        {
            DepotGapNear(GeometricallyBroad.Dequeue());
        }
    }

    private void DepotGapNear(string message)
    {
        Text newText = Instantiate(RespectivelyInvestor, transform);
        newText.text = message;
        newText.gameObject.SetActive(true);

        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(FrownXEvenness, rectTransform.anchoredPosition.y);

        BreathFatty.Add(newText);
        StirDepotEvenness = FrownXEvenness;
    }

    public void SodSatisfaction(string message)
    {
        GeometricallyBroad.Enqueue(message);
    }

    public void HobbyJayCarboniferous()
    {
        GeometricallyBroad.Clear();
        foreach (var text in BreathFatty)
        {
            if (text != null) Destroy(text.gameObject);
        }
        BreathFatty.Clear();
        StirDepotEvenness = float.MaxValue;
    }
}