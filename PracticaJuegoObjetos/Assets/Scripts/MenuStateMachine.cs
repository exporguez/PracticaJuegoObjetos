using Unity.VisualScripting;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    public ControlMenus controlMenus;

    public GameObject[] prefabsObjetos;
    public LayerMask sueloMask;
    public LayerMask editableMask;

    // Estado actual del Menu
    private IEstado estadoAtualMenu;
    private GameObject edificioSeleccionado;

    public GameObject objetoSeleccionado;// Objeto actualmente seleccionado
    public GameObject objetoMovimiento;// Objeto que se está moviendo
    public bool enMovimiento = false;// Indica si un objeto está en movimiento

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

    public void SeleccionarObjeto(int indiceObjeto)// Selecciona el edificio a crear
    {
        if (indiceObjeto < 0 || indiceObjeto >= prefabsObjetos.Length) 
        {
            return;
        }
        objetoMovimiento = Instantiate(prefabsObjetos[indiceObjeto]);
        enMovimiento = true;
        
    }
}

