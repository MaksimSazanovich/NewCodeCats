using DG.Tweening;
using NTC.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Internal.Codebase.Runtime.UI.GameUI.NotificationCoin
{
    [DisallowMultipleComponent]
    public sealed class NotificationCoin : MonoBehaviour, ISpawnable
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private Ease moveEase;
        [SerializeField] private Ease fadeEase;

        [SerializeField] private NotificationCoinConfig config;

        public void Init(string number)
        {
            text.text = $"+{number}";

            float end = transform.position.y + config.Offset;
            transform.DOMoveY(end, config.Speed).SetEase(moveEase);
            
            canvasGroup.DOFade(0, config.FadeSpeed).SetEase(fadeEase).
                OnComplete(() =>
                {
                    transform.position = Vector3.zero;
                    canvasGroup.alpha = 1;
                    NightPool.Despawn(gameObject);
                });
        }

        public void OnSpawn()
        {
            
        }
    }
}