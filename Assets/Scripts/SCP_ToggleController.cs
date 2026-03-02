using UnityEngine;
using DG.Tweening;

public class SCP_SimpleToggle : MonoBehaviour
{
    public RectTransform circle;
    public float posOn = 30f;
    public float posOff = -30f;
    public float timePos = 0.2f;

    public void AnimationToggle(bool isOn)
    {
        circle.DOKill();

        if (isOn == true)
        {
            circle.DOAnchorPosX(posOn, timePos);
        }
        else
        {
            circle.DOAnchorPosX(posOff, timePos);
        }
    }
}