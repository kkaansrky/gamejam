using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class ProgressBar : Panel
{
    [SerializeField]
    Image progressFillImage;
    public TMP_Text waterText;

    public GameObject player;
    void OnEnable()
    {
        progressFillImage.fillAmount = 0f;

        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
    }

    private void Update()
    {
        UpdateLevelProgress();
    }
    public void UpdateLevelProgress()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        int water = Mathf.RoundToInt((float)playerStats.getWater());
        if(water >= 100 )
        {
             water = 100;
        }
        waterText.text = "%" + water.ToString();

        float val = ((float)water/ (float)100);
        progressFillImage.fillAmount = val ; 
    }
}