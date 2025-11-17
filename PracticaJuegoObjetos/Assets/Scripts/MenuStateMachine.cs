using Unity.VisualScripting;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    // Menus que hay en la Pantalla Principal
    public GameObject menuPrincipal, menuCrear, menuMover, menuRotar, menuEliminar;

    public GameObject[] prefabsEdificios;
    public LayerMask sueloMask;
    public LayerMask editableMask;

    // Estado actual del Menu
    private IEstado estadoAtualMenu;
    private GameObject edificioSeleccionado;  

     public ControlMenus controlMenus;

    public void Start()
    {
        // Inicializa el estado del menú al menú principal
        VolverAlMenuPrincipal();
    }


    void Update()
    {
        if (estadoAtualMenu != null)// Si hay un estado actual, ejecuta su lógica
        {
            estadoAtualMenu.Ejecutar(this);// Ejecuta la lógica del estado actual
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

    public void VolverAlMenuPrincipal()// Vuelve al menú principal
    {
        controlMenus.CerrarMenus();
        controlMenus.menuPrincipal.SetActive(true);
    }
    
    public void IrMenuCrear()// Va al menú de crear
    {
        controlMenus.CerrarMenus();
        controlMenus.menuCrear.SetActive(true);
    }

    public void IrMenuMover()// Va al menú de mover
    {
        controlMenus.CerrarMenus();
        controlMenus.menuMover.SetActive(true);
    }
    
    public void IrMenuRotar()// Va al menú de rotar
    {
        controlMenus.CerrarMenus();
        controlMenus.menuRotar.SetActive(true);
    }

    public void IrMenuEliminar()// Va al menú de eliminar
    {
        controlMenus.CerrarMenus();
        controlMenus.menuEliminar.SetActive(true);
    }

    public void SeleccionarEdificio(int indiceEdificio)// Selecciona el edificio a crear
    {
        if (indiceEdificio < 0 || indiceEdificio >= prefabsEdificios.Length) 
        {
            return;
        }

        edificioSeleccionado = prefabsEdificios[indiceEdificio];
        
    }
}

