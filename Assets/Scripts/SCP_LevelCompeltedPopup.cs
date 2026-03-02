using UnityEngine;
using TMPro;
using DG.Tweening;

public class SCP_LevelCompletedPopup : SCP_BasePopup
{
    [Header("Screens")]
    [SerializeField] private GameObject homeScreenPanel;

    [Header("Victory Flair")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private RectTransform mainStar;
    [SerializeField] private ParticleSystem victoryParticles;


    private float scoreAni;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        // Primero activamos y animamos el panel base
        base.Open();

        // Reset de valores visuales
        scoreAni = 0f;
        scoreText.text = "0";
        mainStar.localScale = Vector3.zero;

        // Animaciones
        // Star
        mainStar.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBack);

        // Contador
        DOTween.To(() => scoreAni, x => scoreAni = x, 300f, 1f).OnUpdate(() => scoreText.text = ((int)scoreAni).ToString());

        // Partículas
        if (victoryParticles != null)
        {
            victoryParticles.Stop();
            victoryParticles.Play();
        }
    }

    protected override void OnOpenComplete()
    {
        if (homeScreenPanel != null) homeScreenPanel.SetActive(false);
    }

    public override void Close()
    {
        if (homeScreenPanel != null) homeScreenPanel.SetActive(true);

        base.Close();
    }
}