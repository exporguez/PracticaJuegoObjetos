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
    public Button botonVolver;

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
        menuPrincipal.SetActive(true);
        menuCrear.SetActive(false);
        menuMover.SetActive(false);
        menuRotar.SetActive(false);
        menuEliminar.SetActive(false);

        botonCrear.onClick.AddListener(() => menuStateMachine.IrMenuCrear());// Asigna la funcion al botón Crear
        botonMover.onClick.AddListener(() => menuStateMachine.IrMenuMover());// Asigna la funcion al botón Mover
        botonRotar.onClick.AddListener(() => menuStateMachine.IrMenuRotar());// Asigna la funcion al botón Rotar
        botonEliminar.onClick.AddListener(() => menuStateMachine.IrMenuEliminar());// Asigna la funcion al botón Eliminar
        botonVolver.onClick.AddListener(() => menuStateMachine.VolverAlMenuPrincipal());// Asigna la funcion al botón Volver

    }

    public void IrMenuCrear()
    {
        CerrarMenus();
        menuCrear.SetActive(true);
    }

    public void IrMenuMover()
    {
        CerrarMenus();
        menuMover.SetActive(true);
    }

    public void IrMenuRotar()
    {
        CerrarMenus();
        menuRotar.SetActive(true);
    }

    public void IrMenuEliminar()
    {
        CerrarMenus();
        menuEliminar.SetActive(true);

    }

    public void VolverAlMenuPrincipal()
    {
        CerrarMenus();
        menuPrincipal.SetActive(true);
    }

    public void CerrarMenus()
    {
        menuCrear.SetActive(false);
        menuMover.SetActive(false);
        menuRotar.SetActive(false);
        menuEliminar.SetActive(false);
        menuPrincipal.SetActive(false);
    }
}
