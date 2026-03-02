using UnityEngine;
using DG.Tweening;

public class SCP_BasePopup : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] protected CanvasGroup canvasGroup;
    [SerializeField] protected RectTransform container;
    [SerializeField] protected float animDuration = 0.3f;

    public virtual void Open()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        container.localScale = Vector3.zero;

        canvasGroup.DOFade(1f, animDuration);

        container.DOScale(Vector3.one, animDuration).SetEase(Ease.OutBack).OnComplete(OnOpenComplete);
    }

    public virtual void Close()
    {
        canvasGroup.DOFade(0f, animDuration);
        container.DOScale(Vector3.zero, animDuration).SetEase(Ease.InBack).OnComplete(() => gameObject.SetActive(false));
    }

    // Esta es la función que los hijos usarán
    protected virtual void OnOpenComplete()
    {

    }
}