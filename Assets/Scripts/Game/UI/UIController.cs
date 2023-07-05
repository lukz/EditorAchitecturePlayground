using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelLabel;
    [SerializeField] private TextMeshProUGUI modeLabel;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    public event Action OnPrev;
    public event Action OnNext;
    
    private void OnEnable()
    {
        prevButton.onClick.AddListener(OnPrevClicked);
        nextButton.onClick.AddListener(OnNextClicked);
    }

    private void OnDisable()
    {
        prevButton.onClick.RemoveListener(OnPrevClicked);
        nextButton.onClick.RemoveListener(OnNextClicked);
    }

    private void OnPrevClicked() => OnPrev?.Invoke();
    
    private void OnNextClicked() => OnNext?.Invoke();

    public void SetLevel(int level) => levelLabel.text = $"Level {level + 1}";
    
    public void SetMode(string mode) => modeLabel.text = mode;
}
