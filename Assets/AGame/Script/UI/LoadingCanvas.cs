using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvas :MonoBehaviour
{
    public Text ProgressText;
    public Image ProgressImage;
    private float m_Progress;

    private void Start()
    {
        m_Progress = 0;
        ProgressText.text = "0%";
        ProgressImage.fillAmount = 0;
    }
    
    private void Update()
    {
        m_Progress += Time.deltaTime;
        ProgressImage.fillAmount = m_Progress;
        ProgressText.text = (int)(m_Progress * 100) + "%";
        if (m_Progress >= 1)
        {
            gameObject.SetActive(false);
            DestroyImmediate(gameObject);
            AGameManager.Instance.Init();
        }
    }
}