using UnityEngine;

public class MenuEliminar : IEstado
{
    [SerializeField]
    private GameObject menuEliminar;

    public void Entrar(MenuStateMachine menus)
    {
        menus.menuEliminar.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {

    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuEliminar.SetActive(false);
    }
}
