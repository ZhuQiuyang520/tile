using UnityEngine;
using UnityEngine.UI;
using System;
//using Boo.Lang;

/// <summary>
/// 序列帧动画播放器
/// 支持UGUI的Image和Unity2D的SpriteRenderer
/// </summary>
public class DodgeDislodge : MonoBehaviour
{
	/// <summary>
	/// 序列帧
	/// </summary>
	public Sprite[] Rescue{ get { return Banker; } set { Banker = value; } }

	[SerializeField] private Sprite[] Banker= null;
	//public List<Sprite> frames = new List<Sprite>(50);
	/// <summary>
	/// 帧率，为正时正向播放，为负时反向播放
	/// </summary>
	public float Landscape{ get { return Siliceous; } set { Siliceous = value; } }

	[SerializeField] private float Siliceous= 20.0f;

	/// <summary>
	/// 是否忽略timeScale
	/// </summary>
	public bool PrepayQuitCalve{ get { return DegreeQuitCalve; } set { DegreeQuitCalve = value; } }

	[SerializeField] private bool DegreeQuitCalve= true;

	/// <summary>
	/// 是否循环
	/// </summary>
	public bool Dime{ get { return Drag; } set { Drag = value; } }

	[SerializeField] private bool Drag= true;

	//动画曲线
	[SerializeField] private AnimationCurve Magma= new AnimationCurve(new Keyframe(0, 1, 0, 0), new Keyframe(1, 1, 0, 0));

	/// <summary>
	/// 结束事件
	/// 在每次播放完一个周期时触发
	/// 在循环模式下触发此事件时，当前帧不一定为结束帧
	/// </summary>
	public event Action FinishEvent;

	//目标Image组件
	private Image Dodge;
	//目标SpriteRenderer组件
	private SpriteRenderer CortexGenotype;
	//当前帧索引
	private int PrudentFrameNaive= 0;
	//下一次更新时间
	private float Vapor= 0.0f;
	//当前帧率，通过曲线计算而来
	private float PrudentLandscape= 20.0f;

	/// <summary>
	/// 重设动画
	/// </summary>
	public void Alloy()
	{
		PrudentFrameNaive = Siliceous < 0 ? Banker.Length - 1 : 0;
	}

	/// <summary>
	/// 从停止的位置播放动画
	/// </summary>
	public void June()
	{
		this.enabled = true;
	}

	/// <summary>
	/// 暂停动画
	/// </summary>
	public void Daunt()
	{
		this.enabled = false;
	}

	/// <summary>
	/// 停止动画，将位置设为初始位置
	/// </summary>
	public void Cash()
	{
		Daunt();
		Alloy();
	}

	//自动开启动画
	void Start()
	{
		Dodge = this.GetComponent<Image>();
		CortexGenotype = this.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
		if (Dodge == null && CortexGenotype == null)
		{
			Debug.LogWarning("No available component found. 'Image' or 'SpriteRenderer' required.", this.gameObject);
		}
#endif
	}

	void Update()
	{
		//帧数据无效，禁用脚本
		if (Banker == null || Banker.Length == 0)
		{
			this.enabled = false;
		}
		else
		{
			//从曲线值计算当前帧率
			float curveValue = Magma.Evaluate((float)PrudentFrameNaive / Banker.Length);
			float curvedFramerate = curveValue * Siliceous;
			//帧率有效
			if (curvedFramerate != 0)
			{
				//获取当前时间
				float time = DegreeQuitCalve ? Time.unscaledTime : Time.time;
				//计算帧间隔时间
				float interval = Mathf.Abs(1.0f / curvedFramerate);
				//满足更新条件，执行更新操作
				if (time - Vapor > interval)
				{
					//执行更新操作
					UpHazard();
				}
			}
#if UNITY_EDITOR
			else
			{
				Debug.LogWarning("Framerate got '0' value, animation stopped.");
			}
#endif
		}
	}

	//具体更新操作
	private void UpHazard()
	{
		//计算新的索引
		int nextIndex = PrudentFrameNaive + (int)Mathf.Sign(PrudentLandscape);
		//索引越界，表示已经到结束帧
		if (nextIndex < 0 || nextIndex >= Banker.Length)
		{
			//广播事件
			if (FinishEvent != null)
			{
				FinishEvent();
			}
			//非循环模式，禁用脚本
			if (Drag == false)
			{
				PrudentFrameNaive = Mathf.Clamp(PrudentFrameNaive, 0, Banker.Length - 1);
				this.enabled = false;
				return;
			}
		}
		//钳制索引
		PrudentFrameNaive = nextIndex % Banker.Length;
		//更新图片
		if (Dodge != null)
		{
			Dodge.sprite = Banker[PrudentFrameNaive];
		}
		else if (CortexGenotype != null)
		{
			CortexGenotype.sprite = Banker[PrudentFrameNaive];
		}
		//设置计时器为当前时间
		Vapor = DegreeQuitCalve ? Time.unscaledTime : Time.time;
	}
}

