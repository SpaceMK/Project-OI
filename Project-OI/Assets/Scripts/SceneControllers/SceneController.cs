using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        CreateServiceLocator();    
    }

    void CreateServiceLocator()
    {
        ServiceLocator.Initiailze();
    }
}
