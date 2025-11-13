using UnityEngine;

public class MenuMover : IEstado
{
    [SerializeField]
    private GameObject menuMover;

    public void Entrar(MenuStateMachine menus)
    {
        menus.menuMover.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {

    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuMover.SetActive(false);
    }
}
