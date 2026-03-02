using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SCP_SettingsButton : MonoBehaviour
{
    [Header("UI References")]
    // Referencia específica a la especialización de ajustes
    [SerializeField] private SCP_SettingsPopup settingsPopup;
    [SerializeField] private RectTransform gearIcon;

    [Header("Animation Settings")]
    [SerializeField] private float rotationAmount = 180f;
    [SerializeField] private float animDuration = 0.3f;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        if (button != null) button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        gearIcon.DOKill();
        transform.DOKill();

        // Animación del engrajnaje
        if (gearIcon != null)
        {
            gearIcon.DORotate(new Vector3(0, 0, -rotationAmount), animDuration, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
        }

        // Animación del botón
        transform.DOPunchScale(new Vector3(-0.1f, -0.1f, 0), 0.2f, 1, 0.5f);

        // Abrimos
        if (settingsPopup != null) settingsPopup.Open();
    }
}