using UnityEngine;

public class MenuPrincipal : IEstado
{
    [SerializeField]
    GameObject[] botones;

    [SerializeField]
    GameObject menuPrincipal;
        
    public void Entrar(MenuStateMachine menus)
    {
        menus.menuPrincipal.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        ActivarBotones();
        PulsarBoton();
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuPrincipal.SetActive(false);
    }

    public void ActivarBotones()
    {
        foreach (var boton in botones) // Recorre cada botón en el array
        {
            boton.SetActive(true);
        }
    }

    public void PulsarBoton()
    {
        Debug.Log("Botón pulsado");
    }
}
