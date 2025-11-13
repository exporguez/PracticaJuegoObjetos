using UnityEngine;

public class MenuPrincipal : IEstado
{
    [SerializeField]
    GameObject[] botones;

    [SerializeField]
    private GameObject menuPrincipal;
        
    public void Entrar(MenuStateMachine menus)
    {
        menus.menuPrincipal.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuPrincipal.SetActive(false);
    }

    
}
