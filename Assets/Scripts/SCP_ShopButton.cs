using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SCP_ShopButton : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private SCP_ShopPopup shopPopup;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        if (button != null) button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        transform.DOKill();

        // Animación del botón
        transform.DOPunchScale(new Vector3(-0.1f, -0.1f, 0), 0.2f, 1, 0.5f);

        // Abrimos
        if (shopPopup != null) shopPopup.Open();
    }
}
