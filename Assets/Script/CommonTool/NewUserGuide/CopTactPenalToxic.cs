using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopTactPenalToxic : FormUIBasin
{
    public static CopTactPenalToxic instance;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]
    public GameObject Open;

    /// <summary>
    /// 高亮显示目标
    /// </summary>
    private GameObject Cobalt;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]
    public Text Edit;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Explain= new Vector3[4];
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float CobaltLagoonX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float CobaltLagoonY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Stagnant;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float PrudentLagoonX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float PrudentLagoonY= 0f;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float FierceQuit= 0.1f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private CapacityNeverViscosity CountViscosity;

    protected override void Awake()
    {
        base.Awake();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 显示引导遮罩
    /// </summary>
    /// <param name="_target">要引导到的目标对象</param>
    /// <param name="text">引导说明文案</param>

    public void BluePenal(GameObject _target, string text)
    {
        if (_target == null)
        {
            Open.SetActive(false);
            if (Stagnant == null)
            {
                Stagnant = GetComponent<Image>().material;
            }
            Stagnant.SetVector("_Center", new Vector4(0, 0, 0, 0));
            Stagnant.SetFloat("_SliderX", 0);
            Stagnant.SetFloat("_SliderY", 0);
            // 如果没有target，点击任意区域关闭引导
            GetComponent<Button>().onClick.AddListener(() =>
            {
                HatchUIWork(GetType().Name);
            });
        }
        else
        {
            DOTween.Kill("NewUserHandAnimation");
            Bull(_target);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (!string.IsNullOrEmpty(text))
        {
            Edit.text = text;
            Edit.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Edit.transform.parent.gameObject.SetActive(false);
        }
    }

    private float CobaltDecay= 1;
    private float CobaltEleven= 1;
    public void Bull(GameObject _target)
    {
        this.Cobalt = _target;

        CountViscosity = GetComponent<CapacityNeverViscosity>();
        if (CountViscosity != null)
        {
            CountViscosity.LayIndoorLabor(_target.GetComponent<Image>());
        }

        Canvas canvas = UIMimetic.PenMonopoly().VentBuffer.GetComponent<Canvas>();

        //获取高亮区域的四个顶点的世界坐标
        if (Cobalt.GetComponent<RectTransform>() != null)
        {
            Cobalt.GetComponent<RectTransform>().GetWorldCorners(Explain);
        }
        else
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(_target.transform.position);
            pos = UIMimetic.PenMonopoly()._KeyUICarpet.GetComponent<Camera>().ScreenToWorldPoint(pos);
            Explain[0] = new Vector3(pos.x - CobaltDecay, pos.y - CobaltEleven);
            Explain[1] = new Vector3(pos.x - CobaltDecay, pos.y + CobaltEleven);
            Explain[2] = new Vector3(pos.x + CobaltDecay, pos.y + CobaltEleven);
            Explain[3] = new Vector3(pos.x + CobaltDecay, pos.y - CobaltEleven);
        }
        //计算高亮显示区域在画布中的范围
        CobaltLagoonX = Vector2.Distance(FarceMyBufferLap(canvas, Explain[0]), FarceMyBufferLap(canvas, Explain[3])) / 2f;
        CobaltLagoonY = Vector2.Distance(FarceMyBufferLap(canvas, Explain[0]), FarceMyBufferLap(canvas, Explain[1])) / 2f;
        //计算高亮显示区域的中心
        float x = Explain[0].x + ((Explain[3].x - Explain[0].x) / 2);
        float y = Explain[0].y + ((Explain[1].y - Explain[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Retail= FarceMyBufferLap(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Retail.x, Retail.y, 0, 0);
        Stagnant = GetComponent<Image>().material;
        Stagnant.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Explain);
            //计算偏移初始值
            for (int i = 0; i < Explain.Length; i++)
            {
                if (i % 2 == 0)
                {
                    PrudentLagoonX = Mathf.Max(Vector3.Distance(FarceMyBufferLap(canvas, Explain[i]), Retail), PrudentLagoonX);
                }
                else
                {
                    PrudentLagoonY = Mathf.Max(Vector3.Distance(FarceMyBufferLap(canvas, Explain[i]), Retail), PrudentLagoonY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Stagnant.SetFloat("_SliderX", PrudentLagoonX);
        Stagnant.SetFloat("_SliderY", PrudentLagoonY);
        Open.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(BlueOpen(Retail));
    }

    private IEnumerator BlueOpen(Vector2 center)
    {
        Open.SetActive(false);
        yield return new WaitForSeconds(FierceQuit);

        Open.transform.localPosition = center;
        OpenConestoga();

        Open.SetActive(true);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float FierceGratefulX= 0f;
    private float FierceGratefulY= 0f;
    private void Update()
    {
        if (Stagnant == null) return;

        PrudentLagoonX = CobaltLagoonX;
        Stagnant.SetFloat("_SliderX", PrudentLagoonX);
        PrudentLagoonY = CobaltLagoonY;
        Stagnant.SetFloat("_SliderY", PrudentLagoonY);
        //从当前偏移量到目标偏移量差值显示收缩动画
        //float valueX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref shrinkVelocityX, shrinkTime);
        //float valueY = Mathf.SmoothDamp(currentOffsetY, targetOffsetY, ref shrinkVelocityY, shrinkTime);
        //if (!Mathf.Approximately(valueX, currentOffsetX))
        //{
        //    currentOffsetX = valueX;
        //    material.SetFloat("_SliderX", currentOffsetX);
        //}
        //if (!Mathf.Approximately(valueY, currentOffsetY))
        //{
        //    currentOffsetY = valueY;
        //    material.SetFloat("_SliderY", currentOffsetY);
        //}


    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 FarceMyBufferLap(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }

    public void OpenConestoga()
    {

        var s = DOTween.Sequence();
        s.Append(Open.transform.DOLocalMoveY(Open.transform.localPosition.y + 10f, 0.5f));
        s.Append(Open.transform.DOLocalMoveY(Open.transform.localPosition.y, 0.5f));
        s.Join(Open.transform.DOScaleY(1.1f, 0.125f));
        s.Join(Open.transform.DOScaleX(0.9f, 0.125f).OnComplete(() =>
        {
            Open.transform.DOScaleY(0.9f, 0.125f);
            Open.transform.DOScaleX(1.1f, 0.125f).OnComplete(() =>
            {
                Open.transform.DOScale(1f, 0.125f);
            });
        }));
        s.SetLoops(-1);
        s.SetId("NewUserHandAnimation");
    }

    public void OnDisable()
    {
        DOTween.Kill("NewUserHandAnimation");
    }
}
