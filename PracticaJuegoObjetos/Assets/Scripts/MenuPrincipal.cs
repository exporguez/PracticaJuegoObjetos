using UnityEngine;

public class MenuPrincipal : IEstado
{
    [SerializeField]
    GameObject[] botones;

        
    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.AnimarMenuPrincipal(menus.controlMenus.menuPrincipal);
        menus.controlMenus.menuPrincipal.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuPrincipal.SetActive(false);
    }

    
}
