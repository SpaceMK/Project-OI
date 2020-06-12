using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIInventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inventoryLabelText;
    [SerializeField][Range(0.1f,0.5f)] float fadeIn;
    [SerializeField][Range(1f, 2f)] float fadeOut;

    void Start()
    {
        inventoryLabelText.DOFade(0f, 0f);
    }

    public void DisplayInventoryStatus(string status)
    {
        inventoryLabelText.text = status;
        Sequence textSequence = DOTween.Sequence();
        textSequence.Append(inventoryLabelText.DOFade(1,fadeIn));
        textSequence.Append(inventoryLabelText.DOFade(1, 5f));
        textSequence.Append(inventoryLabelText.DOFade(0, fadeOut));
    }
}
