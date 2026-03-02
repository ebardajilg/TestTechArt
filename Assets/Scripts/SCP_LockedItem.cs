using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class SCP_LockedItem : MonoBehaviour, IPointerEnterHandler
{
    [Header("References")]
    [SerializeField] private RectTransform iconTransform;

    [Header("Shake Configuration")]
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private float strength = 10f;
    [SerializeField] private int shakes = 20;

    public void OnPointerEnter(PointerEventData eventData)
    {
        iconTransform.DOKill(true);

        iconTransform.DOShakeAnchorPos(duration, strength, shakes);
    }
}