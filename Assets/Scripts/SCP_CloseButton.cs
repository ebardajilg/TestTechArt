using UnityEngine;
using UnityEngine.UI;

public class SCP_CloseButton : MonoBehaviour
{
    private Button button;
    private SCP_BasePopup parentPopup;

    void Start()
    {
        button = GetComponent<Button>();

        parentPopup = GetComponentInParent<SCP_BasePopup>();

        if (button != null && parentPopup != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(parentPopup.Close);
        }
    }
}