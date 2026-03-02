using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SCP_HomeButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SCP_LevelCompletedPopup levelCompletePopup;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        transform.DOKill();

        transform.DOPunchScale(new Vector3(-0.1f, -0.1f, 0), 0.2f, 1, 0.5f);

        if (levelCompletePopup != null)
        {
            levelCompletePopup.Close();
        }
    }

}
