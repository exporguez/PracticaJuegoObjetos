using UnityEngine;

public class ControlMenus : MonoBehaviour
{
    [SerializeField]
    GameObject[] botones;

    [SerializeField]
    GameObject menuInicial;
    
        
    void Start()
    {
        menuInicial.SetActive(true);
    }

    
    void Update()
    {
        
    }
}
