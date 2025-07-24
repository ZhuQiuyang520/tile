using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TavernkeeperPierce : MonoBehaviour
{
    [Header("配置选项")]
    [SerializeField] private Text ConstructionCellular;
    [SerializeField] private float LingerDegas= 50f;
    [SerializeField] private float Restful= 200f;
    [SerializeField] private float StampXDiffuses= 1000f;
    [SerializeField] private float HotXDiffuses= -1000f;

    private List<Text> FierceBlack= new List<Text>();
    private Queue<string> PhilosophicalQueue= new Queue<string>();
    private float PulpLapisDiffuses;

    private void Start()
    {
        if (ConstructionCellular == null)
        {
            Debug.LogError("未指定公告文本模板！");
            enabled = false;
            return;
        }

        ConstructionCellular.gameObject.SetActive(false);
    }

    private void Update()
    {
        DrenchMidwayBlack();
        PayLapisAimStep();
    }

    private void DrenchMidwayBlack()
    {
        for (int i = FierceBlack.Count - 1; i >= 0; i--)
        {
            Text text = FierceBlack[i];
            if (text == null)
            {
                FierceBlack.RemoveAt(i);
                continue;
            }

            RectTransform rectTransform = text.GetComponent<RectTransform>();
            rectTransform.anchoredPosition += Vector2.left * LingerDegas * Time.deltaTime;

            if (rectTransform.anchoredPosition.x < HotXDiffuses)
            {
                Destroy(text.gameObject);
                FierceBlack.RemoveAt(i);
            }
            else
            {
                PulpLapisDiffuses = Mathf.Min(PulpLapisDiffuses, rectTransform.anchoredPosition.x);
            }
        }
    }

    private void PayLapisAimStep()
    {
        if (PhilosophicalQueue.Count == 0) return;

        float minSpawnPosition = PulpLapisDiffuses + Restful;
        if (StampXDiffuses > minSpawnPosition)
        {
            LapisAimStep(PhilosophicalQueue.Dequeue());
        }
    }

    private void LapisAimStep(string message)
    {
        Text newText = Instantiate(ConstructionCellular, transform);
        newText.text = message;
        newText.gameObject.SetActive(true);

        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(StampXDiffuses, rectTransform.anchoredPosition.y);

        FierceBlack.Add(newText);
        PulpLapisDiffuses = StampXDiffuses;
    }

    public void LidTavernkeeper(string message)
    {
        PhilosophicalQueue.Enqueue(message);
    }

    public void CliffWadCompanionship()
    {
        PhilosophicalQueue.Clear();
        foreach (var text in FierceBlack)
        {
            if (text != null) Destroy(text.gameObject);
        }
        FierceBlack.Clear();
        PulpLapisDiffuses = float.MaxValue;
    }
}