using TMPro;
using UnityEngine;

public class UIInteractionInstruction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] string boxMessage;

    public void DisplayText(InteractionType type,string tag)
    {
        switch (type)
        {
            case (InteractionType.Weapon):
                instructionText.text = boxMessage + " " + tag; 
                break;
            case (InteractionType.None):
                instructionText.text = "";
                break;
            case (InteractionType.AmmoBox):
                instructionText.text = boxMessage + " " + tag + " ammo";
            break;
        }
    }

}
