using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BottomBarView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private RectTransform barPanel;
    [SerializeField] private ToggleGroup toggleGroup;

    [Header("Positions")]
    [SerializeField] private float yHidden = -130f;
    [SerializeField] private float yVisible = 175f;
    [SerializeField] private float duration = 0.3f;

    [Header("Events")]
    public UnityEvent OnContentActivated;
    public UnityEvent OnClosed;

    void Start()
    {
        barPanel.anchoredPosition = new Vector2(barPanel.anchoredPosition.x, yHidden);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        barPanel.DOKill();
        barPanel.DOAnchorPosY(yVisible, duration).SetEase(Ease.OutCubic);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        barPanel.DOKill();
        barPanel.DOAnchorPosY(yHidden, duration).SetEase(Ease.InCubic);
    }

    public void OnButtonToggled(bool isOn)
    {
        if (isOn)
        {
            OnContentActivated?.Invoke();
        }
        else if (toggleGroup.AnyTogglesOn() == false)
        {
            OnClosed?.Invoke();
        }
    }
}