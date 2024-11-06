using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : AbstractButton
{
    [SerializeField] protected Text levelText = default;
    [SerializeField] protected Text upgradeText = default;
    [SerializeField] protected MoneyData moneyData = default;

    protected int level = 1;
    protected double costUpgrade = 1;
    protected double multipleUpgrade = 1.2f;

    protected virtual void Start()
    {
        moneyData.onChangeMoney += ChangeStateButton;
        UpdateText();
        ChangeStateButton();
    }

    protected override void OnButtonClick()
    {
        moneyData.DecreaseMoney(costUpgrade);
        level++;
        costUpgrade = level * Math.Pow(multipleUpgrade, (double)level);
        UpdateText();
        ChangeStateButton();
    }

    private void ChangeStateButton() => button.interactable = moneyData.Money < costUpgrade ? false : true;

    private void UpdateText()
    {
        levelText.text = $"Lvl {level}";
        upgradeText.text = string.Format("UPGRAGE {0:N2}", costUpgrade);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        moneyData.onChangeMoney -= ChangeStateButton;
    }
}
