using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILifePanel : MonoBehaviour
{
    [SerializeField] private Image _fillableLifebar;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private Gradient healthGradient;

    public void UpdateGraphics(int currentHp, int maxHP)
    {
        _lifeText.text = "HP " + currentHp + "/" + maxHP;
        _fillableLifebar.fillAmount = (float)currentHp / maxHP;
        _fillableLifebar.color = healthGradient.Evaluate(_fillableLifebar.fillAmount);

    }
}
