using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    // Menus que hay en la Pantalla Principal
    public GameObject menuPrincipal, menuCrear, menuMover, menuRotar, menuEliminar;

    // Estado actual del Menu
    private IEstado estadoAtualMenu;

    void Start()
    {
        // Inicializa el estado del menú al menú principal
        menuPrincipal.SetActive(true);
        menuCrear.SetActive(false);
        menuMover.SetActive(false);
        menuRotar.SetActive(false);
        menuEliminar.SetActive(false);
    }

    void Update()
    {
        if (estadoAtualMenu != null)
        {
            estadoAtualMenu.Ejecutar(this);
        }
    }

    public void CambiarEstado(IEstado nuevoEstado)
    {
        // Cambia el estado actual del menú
        if (estadoAtualMenu != null)
        {
            estadoAtualMenu.Salir(this);
        }
        
        // Pasamos al nuevo estado
        estadoAtualMenu = nuevoEstado;
        // Entramos en el nuevo estado
        estadoAtualMenu.Entrar(this);
    }
}
