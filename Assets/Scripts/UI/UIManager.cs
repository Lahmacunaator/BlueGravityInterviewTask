using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject shopUI;
        [SerializeField] private TMP_Text goldAmountText;

        public void UpdateGoldAmountText(string text) => goldAmountText.text = text;
        public void ToggleShopUI() => shopUI.SetActive(!shopUI.activeSelf);
        public void OnExitButton() => Application.Quit();
        public void OnRestartButton() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}