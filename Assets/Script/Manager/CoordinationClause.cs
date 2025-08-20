using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CoordinationClause : MonoBehaviour
{
    [Header("配置选项")]
    [SerializeField] private Text MythologicalIronwork;
    [SerializeField] private float InventLabel= 50f;
    [SerializeField] private float Ascribe= 200f;
    [SerializeField] private float StealXDatebase= 1000f;
    [SerializeField] private float LogXDatebase= -1000f;

    private List<Text> StrainCajun= new List<Text>();
    private Queue<string> StabilizationBlack= new Queue<string>();
    private float RelyStoneDatebase;

    private void Start()
    {
        if (MythologicalIronwork == null)
        {
            Debug.LogError("未指定公告文本模板！");
            enabled = false;
            return;
        }

        MythologicalIronwork.gameObject.SetActive(false);
    }

    private void Update()
    {
        HazardBattleCajun();
        LopStoneCopEdit();
    }

    private void HazardBattleCajun()
    {
        for (int i = StrainCajun.Count - 1; i >= 0; i--)
        {
            Text Wren= StrainCajun[i];
            if (Wren == null)
            {
                StrainCajun.RemoveAt(i);
                continue;
            }

            RectTransform rectTransform = Wren.GetComponent<RectTransform>();
            rectTransform.anchoredPosition += Vector2.left * InventLabel * Time.deltaTime;

            if (rectTransform.anchoredPosition.x < LogXDatebase)
            {
                Destroy(Wren.gameObject);
                StrainCajun.RemoveAt(i);
            }
            else
            {
                RelyStoneDatebase = Mathf.Min(RelyStoneDatebase, rectTransform.anchoredPosition.x);
            }
        }
    }

    private void LopStoneCopEdit()
    {
        if (StabilizationBlack.Count == 0) return;

        float minSpawnPosition = RelyStoneDatebase + Ascribe;
        if (StealXDatebase > minSpawnPosition)
        {
            StoneCopEdit(StabilizationBlack.Dequeue());
        }
    }

    private void StoneCopEdit(string message)
    {
        Text newText = Instantiate(MythologicalIronwork, transform);
        newText.text = message;
        newText.gameObject.SetActive(true);

        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(StealXDatebase, rectTransform.anchoredPosition.y);

        StrainCajun.Add(newText);
        RelyStoneDatebase = StealXDatebase;
    }

    public void BurCoordination(string message)
    {
        StabilizationBlack.Enqueue(message);
    }

    public void FlakeIceImpressionist()
    {
        StabilizationBlack.Clear();
        foreach (var text in StrainCajun)
        {
            if (text != null) Destroy(text.gameObject);
        }
        StrainCajun.Clear();
        RelyStoneDatebase = float.MaxValue;
    }
}