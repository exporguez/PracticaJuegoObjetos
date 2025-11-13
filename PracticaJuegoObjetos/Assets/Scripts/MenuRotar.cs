using UnityEngine;

public class MenuRotar : IEstado
{
    public void Entrar(MenuStateMachine menus)
    {
        menus.menuRotar.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {

    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuRotar.SetActive(false);
    }
}
