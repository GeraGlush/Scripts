using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    public Image bar;
    public float fillSmoothness = 0.01f;

    public float regenerationInSecond;


    public void SetBarValue(float value, float maxValue)
    {
        float prevFill = bar.fillAmount;
        float currFill = value / maxValue;

        while (prevFill != currFill)
        {
            if (currFill > prevFill)
                prevFill = Mathf.Min(prevFill + fillSmoothness, currFill);
            else if (currFill < prevFill)
                prevFill = Mathf.Max(prevFill - fillSmoothness, currFill);
            bar.fillAmount = prevFill;
        }
    }
}
