using UnityEngine;

public class MenuCrear : IEstado
{
    [SerializeField]
    GameObject menuCrear;

    public void Entrar(MenuStateMachine menus)
    {
        menus.menuCrear.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        OnClick();
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuCrear.SetActive(false);
    }

    void OnClick()
    {
        Debug.Log("Botón Crear Objeto pulsado");
    }
}
