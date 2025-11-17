using UnityEngine;
using UnityEngine.UI;

public class ControlMenus : MonoBehaviour
{
    public static ControlMenus Instance { get; private set; }

    public MenuStateMachine menuStateMachine;
    public GameObject menuPrincipal;
    public GameObject menuCrear;
    public GameObject menuMover;
    public GameObject menuRotar;
    public GameObject menuEliminar;

    public Button botonCrear;
    public Button botonMover;
    public Button botonRotar;
    public Button botonEliminar;

    public Button botonVolverCrear;
    public Button botonVolverMover;
    public Button botonVolverRotar;
    public Button botonVolverEliminar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {            
            return;
        } 
        Instance = this;
    }

    public void Start() // Inicializa el menú principal al inicio
    {        

        botonCrear.onClick.AddListener(() => menuStateMachine.IrMenuCrear());// Asigna la funcion al botón Crear
        botonMover.onClick.AddListener(() => menuStateMachine.IrMenuMover());// Asigna la funcion al botón Mover
        botonRotar.onClick.AddListener(() => menuStateMachine.IrMenuRotar());// Asigna la funcion al botón Rotar
        botonEliminar.onClick.AddListener(() => menuStateMachine.IrMenuEliminar());// Asigna la funcion al botón Eliminar
        
        botonVolverCrear.onClick.AddListener(() => menuStateMachine.VolverAlMenuPrincipal());// Asigna la funcion al botón Volver
        botonVolverMover.onClick.AddListener(() => menuStateMachine.VolverAlMenuPrincipal());
        botonVolverRotar.onClick.AddListener(() => menuStateMachine.VolverAlMenuPrincipal());
        botonVolverEliminar.onClick.AddListener(() => menuStateMachine.VolverAlMenuPrincipal());

        CerrarMenus(); // Cierra todos los menús al inicio
        menuPrincipal.SetActive(true); // Abre el menú principal al inicio
    }

    public void CerrarMenus() // Cierra todos los menús
    {
        menuPrincipal.SetActive(false);
        menuCrear.SetActive(false);
        menuMover.SetActive(false);
        menuRotar.SetActive(false);
        menuEliminar.SetActive(false);
    }
}
