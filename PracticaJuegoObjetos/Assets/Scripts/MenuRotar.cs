using UnityEngine;

public class MenuRotar : IEstado
{
    [SerializeField]
    private GameObject menuRotar;

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
