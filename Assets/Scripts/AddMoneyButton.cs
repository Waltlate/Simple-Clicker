using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMoneyButton : AbstractButton
{
    [SerializeField] protected Text currentMoneyText = default;
    [SerializeField] protected Text addMoneyText = default;
    [SerializeField] protected Button upgradeButton = default;
    [SerializeField] protected MoneyData money = default;
    [SerializeField] protected GameObject objectPrefab;

    protected int addMoney = 1;
    protected float spawnHeight = 10f;

    protected virtual void Start()
    {
        money.onChangeMoney += UpdateMoneyText;
        upgradeButton.onClick.AddListener(UpgradeMoney);
        UpdateMoneyText();
        UpdateAddMoneyText();
    }

    protected override void OnButtonClick()
    {
        money.AddMoney(addMoney);
        UpdateMoneyText();
        //Vector3 spawnPosition = Input.mousePosition - new Vector3(Screen.width/2, Screen.height/2, 0);
        Debug.Log(Input.mousePosition);
        GameObject newImage = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);

        // Настройка корректной позиции в RectTransform
        RectTransform rectTransform = newImage.GetComponent<RectTransform>();
        rectTransform.SetParent(transform, false); // Устанавливаем родителя
        //rectTransform.anchoredPosition = spawnPosition; // Устанавливаем позицию
    }

    private void UpdateMoneyText() => currentMoneyText.text = string.Format("{0:N2}", money.Money);
    private void UpdateAddMoneyText() => addMoneyText.text = addMoney.ToString();

    private void UpgradeMoney()
    {
        addMoney += 1;
        UpdateAddMoneyText();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        money.onChangeMoney -= UpdateMoneyText;
        upgradeButton.onClick.RemoveListener(UpgradeMoney);
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Проверяем, попали ли в какой-либо объект
        {
            return hit.point; // Возвращаем точку попадания на объект
        }

        return Vector3.zero; // Возврат, если ничего не попали
    }

    public void SpawnObject(Vector3 position)
    {
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
//        newObject.transform.position = new Vector3(position.x, spawnHeight, position.z);
  //      newObject.AddComponent<Rigidbody>();
    }
}
