using ServiceLocatorSample.ServiceLocator;
using UnityEngine;

public class SceneServiceLocator : MonoBehaviour
{
    void Awake()
    {
        CreateServiceLocator();
    }

    void CreateServiceLocator()
    {
        ServiceLocator.Initiailze();
    }
}
