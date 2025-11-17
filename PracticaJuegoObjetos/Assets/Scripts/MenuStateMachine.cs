using Unity.VisualScripting;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    public ControlMenus controlMenus;

    public GameObject[] prefabsEdificios;
    public LayerMask sueloMask;
    public LayerMask editableMask;

    // Estado actual del Menu
    private IEstado estadoAtualMenu;
    private GameObject edificioSeleccionado;  

    

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
        CambiarEstado(new MenuPrincipal());
    }
    
    public void IrMenuCrear()// Va al menú de crear
    {
        CambiarEstado(new MenuCrear());
    }

    public void IrMenuMover()// Va al menú de mover
    {
        CambiarEstado(new MenuMover());
    }
    
    public void IrMenuRotar()// Va al menú de rotar
    {
        CambiarEstado(new MenuRotar());
    }

    public void IrMenuEliminar()// Va al menú de eliminar
    {
        CambiarEstado(new MenuEliminar());
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

