#pragma warning disable 0649

using UnityEditor;
using UnityEngine;
using System;
using DG.Tweening;
using System.Collections;

namespace Watermelon
{
    public class TileBehavior : MonoBehaviour, IClickableObject, ISlotable
    {
        //public Sprite MSprite => SRenderer.sprite; // 当前精灵
        //public Transform spriteTransform => SRenderer.transform; // 精灵变换
        // 记录抖动原点，防止多次Shake累计偏移
        private Vector3 shakeOriginPos = Vector3.zero;
        public Animator Ani;
        public GameObject MofabangObj;
        public GameObject TileEffect;
        private static readonly int OVERLAY_STRENGTH_ID = Shader.PropertyToID("_OverlayStrength");

        [SerializeField] SpriteRenderer iconSpriteRenderer;
        public SpriteRenderer IconSpriteRenderer => iconSpriteRenderer;

        [SerializeField] SpriteRenderer RemindSpriteRenderer;

        [SerializeField] SpriteRenderer backgroundSpriteRenderer;
        public SpriteRenderer BackgroundSpriteRenderer => backgroundSpriteRenderer;

        [SerializeField] Transform visuals;
        public Transform VisualsTransform => visuals;

        [SerializeField] BoxCollider boxCollider;

        public Transform Transform => transform;

        private bool isClickable;
        public bool IsClickable => isClickable;

        public int LayerID => elementPosition.LayerId;

        protected ElementPosition elementPosition;
        public ElementPosition ElementPosition => elementPosition;

        protected bool isSubmitted;
        public bool IsSubmitted => isSubmitted;

        protected bool isBlocked;
        public bool IsBlocked => isBlocked;

        protected TileData tileData;

        public TileData TileData => tileData;

        public int UniqueElementID => tileData.GetHashCode();


        private static GameData gameData;

        public static implicit operator ElementPosition(TileBehavior tileBehavior) => tileBehavior.elementPosition;

        private int RecordOrder;

        public virtual void Initialise(TileData tileData, ElementPosition elementPosition)
        {
            BackgroundSpriteRenderer.size = new Vector2(1, 1.09f);
            this.tileData = tileData;
            isBlocked = false;
            SetPosition(elementPosition);
        }

        public void SetPosition(ElementPosition elementPosition)
        {
            this.elementPosition = elementPosition;
            RecordOrder = -(elementPosition.LayerId + 1) * 100 + elementPosition.X - elementPosition.Y;
            SetSortingOrder(-(elementPosition.LayerId + 1) * 100 + elementPosition.X - elementPosition.Y);
        }

        public void SetScale(Vector2 scale)
        {
            var smallerSize = scale.x > scale.y ? scale.y : scale.x;
            visuals.localScale = new Vector3(1.03f, 1.03f, 1) * smallerSize;
            boxCollider.size = scale;
        }

        public void SetAnimation(string AniName)
        {
            Ani.enabled = true;
            Ani.Play(AniName,0,0);
            
            SetSortingOrder(0);
            Ani.speed = 1;
        }

        public void CloseAni()
        {
            SetSortingOrder(RecordOrder);
            Ani.speed = 0;
            Ani.enabled = false ;
            RemindSpriteRenderer.gameObject.SetActive(false);
        }

        public void SetSortingOrder(int order)
        {
            //RemindSpriteRenderer.sortingOrder = order * 3;
            iconSpriteRenderer.sortingOrder = order * 3 - 1;
            backgroundSpriteRenderer.sortingOrder = order * 3 - 2;
        }

        public void DockShuffleMove(Transform position, SimpleCallback onCompleted)
        {
            transform.DOMove(position.position, 0.15f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                onCompleted?.Invoke();
            });
        }

        public void SubmitMove(Transform position, Vector3 scale, SimpleCallback onCompleted)
        {
            SetSortingOrder(0);

            transform.DORotate(Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.value * 5 + 15 * (UnityEngine.Random.value > 0.5f ? -1 : 1))).eulerAngles, 0.05f);
            transform.DOScale(1.4f, 0.05f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                var smallerSize = scale.x > scale.y ? scale.y : scale.x;
                visuals.DOScale(smallerSize, 0.15f);
                transform.DOScale(1, 0.15f);

                transform.DOMove(position.position, 0.15f).SetEase(Ease.OutSine).OnComplete(() =>
                {
                    transform.DORotate(Vector3.zero, 0.15f);
                    onCompleted?.Invoke();
                });
            });
        }

        public void SubmitMove(Vector3 position, Vector3 scale, SimpleCallback onCompleted = null)
        {
            SetSortingOrder(0);

            transform.DORotate(Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.value * 5 + 15 * (UnityEngine.Random.value > 0.5f ? -1 : 1))).eulerAngles, 0.05f);
            transform.DOScale(1.4f, 0.05f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                var smallerSize = scale.x > scale.y ? scale.y : scale.x;
                visuals.DOScale(smallerSize, 0.15f);
                transform.DOScale(1, 0.15f);

                transform.DOMove(position, 0.15f).SetEase(Ease.OutSine).OnComplete(() =>
                {
                    transform.DORotate(Vector3.zero, 0.15f);
                    onCompleted?.Invoke();
                });
            });
        }

        public void SetState(bool state, bool withAnimation = true)
        {
            if (isBlocked) return;
            isClickable = state;

            var tintColor = (Color.white * (state ? 1f : 0.7f)).SetAlpha(1f);
            SetColor(tintColor, withAnimation);
        }

        public void SetColor(Color color, bool withAnimation)
        {
            //backgroundColorTweenCase.KillActive();
            //iconColorTweenCase.KillActive();
            if(withAnimation)
            {
                if(iconSpriteRenderer.color != color)
                    iconSpriteRenderer.DOColor(color, 0.25f);

                if (backgroundSpriteRenderer.color != color)
                    backgroundSpriteRenderer.DOColor(color, 0.25f);
            }
            else
            {
                iconSpriteRenderer.color = color;
                backgroundSpriteRenderer.color = color;
            }
        }

        public virtual void OnObjectClicked()
        {
            if (isSubmitted)
                return;

            bool isClickAllowed = true;
            if (isBlocked) isClickAllowed = false;
            if (!isClickable) isClickAllowed = false;
            RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Click);
            RoadTenuous.GetInstance().UsuallyStuff();
            if (isClickAllowed)
            {
                CloseAni();
                RoadBrother.instance.EdibleScholar(this);
            }
            else
            {
                gameObject.transform.DOShakePosition(
            duration: 0.2f,
            strength: new Vector3(0.1f, 0, 0),
            vibrato: 50,
            randomness: 90
        );
                //gameObject.transform.DOShakePosition(0.2f,0.08f);
            }
        }

        ///// <summary>
        ///// 抖动动画反馈（先快后慢，幅度逐渐减小，更自然）
        ///// </summary>
        //public void Shake(float duration = 0.5f, float strength = 0.16f, int vibrato = 10)
        //{
        //    // 第一次Shake时记录原点
        //    if (shakeOriginPos == Vector3.zero)
        //        shakeOriginPos = spriteTransform.localPosition;
        //    // 每次抖动前都归位
        //    spriteTransform.localPosition = shakeOriginPos;
        //    Vector3 originalPos = shakeOriginPos;
        //    int totalSteps = vibrato;
        //    float totalTime = duration;
        //    float timePassed = 0f;
        //    float[] stepTimes = new float[totalSteps];
        //    float[] stepStrengths = new float[totalSteps];
        //    float baseTime = totalTime * 0.5f / totalSteps; // 前半段快
        //    float slowTime = totalTime * 0.5f / totalSteps; // 后半段慢
        //    float baseStrength = strength;

        //    // 生成每步的时间和幅度（前快后慢，幅度递减）
        //    for (int i = 0; i < totalSteps; i++)
        //    {
        //        if (i < totalSteps / 2)
        //        {
        //            stepTimes[i] = baseTime;
        //            stepStrengths[i] = baseStrength;
        //        }
        //        else
        //        {
        //            stepTimes[i] = slowTime * (1.2f + (i - totalSteps / 2) * 0.2f); // 越来越慢
        //            stepStrengths[i] = baseStrength * (1f - 0.7f * (i - totalSteps / 2) / (totalSteps / 2)); // 幅度递减
        //        }
        //    }

        //    // 启动协程实现分步抖动
        //    StartCoroutine(ShakeCoroutine(spriteTransform, originalPos, stepTimes, stepStrengths));
        //}

        //private IEnumerator ShakeCoroutine(Transform target, Vector3 originalPos, float[] stepTimes, float[] stepStrengths)
        //{
        //    for (int i = 0; i < stepTimes.Length; i++)
        //    {
        //        float offset = (i % 2 == 0 ? 1 : -1) * stepStrengths[i];
        //        float t = 0f;
        //        Vector3 start = shakeOriginPos;
        //        Vector3 end = shakeOriginPos + new Vector3(offset, 0, 0);
        //        while (t < stepTimes[i])
        //        {
        //            t += Time.deltaTime;
        //            float lerp = Mathf.Clamp01(t / stepTimes[i]);
        //            target.localPosition = Vector3.Lerp(start, end, lerp);
        //            yield return null;
        //        }
        //        // 回到原位
        //        target.localPosition = shakeOriginPos;
        //    }
        //}

        public void MarkAsSubmitted()
        {
            isSubmitted = true;
        }

        public void ResetSubmitState()
        {
            isSubmitted = false;
        }

        public void Clear()
        {
            gameObject.SetActive(false);

            transform.SetParent(GildTenuous.MissionDiversifyGenuinely);

            ResetSubmitState();
        }

        public void PlaySpawnAnimation(float delay = 0)
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }

        public bool IsSameType(ISlotable other)
        {
            if (other == null)
                return false;

            var otherTile = (TileBehavior)other;
            if (otherTile == null)
                return false;

            return otherTile.tileData == this.tileData;
        }


        public void MatchAnimation(float delay)
        {
            transform.DOScale(0, 0.25f);
            //Tween.DelayedCall(0.15f + delay, () => ParticlesController.PlayParticle("Slot Highlight").SetDuration(1).SetPosition(transform.position + Vector3.back * 0.2f).SetRotation(Quaternion.Euler(Vector3.right * -90f)));
        }

        public void SetBlockState(bool state)
        {
            isBlocked = state;
        }
    }
}
