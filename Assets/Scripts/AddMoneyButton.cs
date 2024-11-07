using UnityEngine;
using UnityEngine.UI;

public class AddMoneyButton : AbstractButton
{
    [SerializeField] protected Text currentMoneyText = default;
    [SerializeField] protected Text addMoneyText = default;
    [SerializeField] protected Button upgradeButton = default;
    [SerializeField] protected MoneyData moneyData = default;
    [SerializeField] protected GameObject objectPrefab;
    [SerializeField] protected int addMoney = 1;
    [SerializeField] protected int upgradeStep = 1;

    protected GameObject newImage = default;
    protected RectTransform rectTransform = default;

    protected virtual void Start()
    {
        moneyData.onChangeMoney += UpdateMoneyText;
        upgradeButton.onClick.AddListener(UpgradeMoney);
        UpdateMoneyText();
        UpdateAddMoneyText();
    }

    protected override void OnButtonClick()
    {
        moneyData.AddMoney(addMoney);
        UpdateMoneyText();

        newImage = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
        rectTransform = newImage.GetComponent<RectTransform>();
        rectTransform.SetParent(transform, false);
    }

    private void UpdateMoneyText() => currentMoneyText.text = string.Format("{0:N2}", moneyData.Money);
    private void UpdateAddMoneyText() => addMoneyText.text = addMoney.ToString();

    private void UpgradeMoney()
    {
        addMoney += upgradeStep;
        UpdateAddMoneyText();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        moneyData.onChangeMoney -= UpdateMoneyText;
        upgradeButton.onClick.RemoveListener(UpgradeMoney);
    }
}
