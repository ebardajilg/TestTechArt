using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SCP_SettingsPopup : SCP_BasePopup
{
    [Header("Settings Specifics")]
    [SerializeField] private Image overlay;
    [SerializeField] private RectTransform idleShine;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // Animación del overlay
        if (overlay != null)
        {
            overlay.gameObject.SetActive(true);
            overlay.DOKill();
            overlay.DOFade(0.8f, animDuration).From(0f);
        }

        // Abrimos panel
        base.Open();
    }

    protected override void OnOpenComplete()
    {
        // Cuando termina de abrirse, empieza el brillo
        StartIdleAnimation();
    }

    private void StartIdleAnimation()
    {
        idleShine.DOKill();
        idleShine.localScale = Vector3.one;

        // Escala, duración, suavizado y bucle infinito del Shine
        idleShine.DOScale(1.1f, 1.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public override void Close()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        if (overlay != null)
        {
            overlay.DOKill();
            overlay.DOFade(0f, animDuration).OnComplete(() => overlay.gameObject.SetActive(false));
        }

        if (idleShine != null) idleShine.DOKill();

        base.Close();
    }
}