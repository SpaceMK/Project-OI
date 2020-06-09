using TMPro;
using UnityEngine;

public class UIInteractionInstruction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] string weaponMessage,ammoBoxMessage;

    public void DisplayText(InteractionType type,string tag)
    {
        switch (type)
        {
            case (InteractionType.Weapon):
                instructionText.text = weaponMessage + " " + tag; 
                break;
            case (InteractionType.None):
                instructionText.text = "";
                break;
            case (InteractionType.AmmoBox):
                instructionText.text = ammoBoxMessage;
            break;
        }
    }

}
