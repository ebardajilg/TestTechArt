using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SCP_BottomBarItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private CanvasGroup backgroundHighlight; 
    [SerializeField] private RectTransform iconTransform;

    [Header("Config")]
    [SerializeField] private float animDuration = 0.2f;
    [SerializeField] private float scaleAmount = 1.15f;
    [SerializeField] private float moveAmount = 15f;

    private Vector2 originalPos;
    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        if (iconTransform != null) originalPos = iconTransform.anchoredPosition;

        if (backgroundHighlight != null) backgroundHighlight.alpha = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (toggle != null && toggle.isOn) return;

        AnimateIn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (toggle != null && toggle.isOn) return;

        AnimateOut();
    }

    public void HandleToggleVisuals(bool isOn)
    {
        if (isOn)
        {
            AnimateIn();
        }
        else { 
            AnimateOut();
        }
    }

    private void AnimateIn()
    {
        backgroundHighlight.DOKill();
        iconTransform.DOKill();

        // Aparece el fondo
        backgroundHighlight.DOFade(1f, animDuration);

        // El icono crece y sube un poco
        iconTransform.DOScale(scaleAmount, animDuration).SetEase(Ease.OutBack);
        iconTransform.DOAnchorPosY(originalPos.y + moveAmount, animDuration).SetEase(Ease.OutBack);
    }

    private void AnimateOut()
    {
        backgroundHighlight.DOKill();
        iconTransform.DOKill();

        // Desaparece el fondo
        backgroundHighlight.DOFade(0f, animDuration);

        // El icono vuelve a su tamaño original
        iconTransform.DOScale(1f, animDuration);
        iconTransform.DOAnchorPosY(originalPos.y, animDuration);
    }
}