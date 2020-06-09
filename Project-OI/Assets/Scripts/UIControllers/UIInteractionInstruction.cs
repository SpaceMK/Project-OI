using TMPro;
using UnityEngine;

public class UIInteractionInstruction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] string message;

    public void DisplayText(InteractionType type,string tag)
    {
        switch (type)
        {
            case (InteractionType.Weapon):
                instructionText.text = message + " " + tag; 
                break;
            case (InteractionType.None):
                instructionText.text = "";
                break;
            case (InteractionType.AmmoBox):

            break;
        }
    }

}
