using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Panels")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _winPanel;

    [Header("Text Elements")]
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _baseHealthText;

    [Header("Buttons")]
    [SerializeField] private Button _nextWaveButton;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        GameManager.OnCurrencyChanged += UpdateCurrencyText;
        GameManager.OnWaveChanged += UpdateWaveText;
        PlayerBase.OnHealthChanged += UpdateBaseHealthText;
    }

    private void OnDisable()
    {
        GameManager.OnCurrencyChanged -= UpdateCurrencyText;
        GameManager.OnWaveChanged -= UpdateWaveText;
        PlayerBase.OnHealthChanged -= UpdateBaseHealthText;
    }

    private void Start()
    {
        
        
    }

    private void UpdateCurrencyText(int amount)
    {
        _currencyText.text = $"COINS: {amount}";
    }

    private void UpdateWaveText(int current, int total)
    {
        _waveText.text = $"WAVE: {current} / {total}";
    }

    private void UpdateBaseHealthText(int health)
    {
        _baseHealthText.text = $"HEALTH: {health}";
    }

    public void SetNextWaveButtonActive(bool isActive)
    {
        _nextWaveButton.gameObject.SetActive(isActive);
    }

    public void ShowGameOverScreen()
    {
        _gameOverPanel.SetActive(true);
    }

    public void ShowWinScreen()
    {
        _winPanel.SetActive(true);
    }

    public void OpenShop()
    {
        _shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        _shopPanel.SetActive(false);
    }
}