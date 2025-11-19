using UnityEngine;
using UnityEngine.UI;

public class ControlMenus : MonoBehaviour
{
    public static ControlMenus Instance { get; private set; }
    public MenuCrear menuCrearScript;

    public MenuStateMachine menus;
    public GameObject menuPrincipal;
    public GameObject menuCrear;
    public GameObject menuMover;
    public GameObject menuRotar;
    public GameObject menuEliminar;
    public GameObject menuEscalar;

    
    public GameObject popUpCrear;
    public GameObject popUpMover;
    public GameObject popUpRotar;
    public GameObject popUpEliminar;
    public GameObject menuLateralCrear;

    public Button botonCerrarPopUpCrear;
    public Button botonCerrarPopUpMover;
    public Button botonCerrarPopUpRotar;
    public Button botonCerrarPopUpEliminar;

    public Button botonCerrarMenuLateral;

    public GameObject[] prefabs;
    public Button[] botonesPrefabs;
    private GameObject objetoCreado;

    public Button botonCrear;
    public Button botonMover;
    public Button botonRotar;
    public Button botonEliminar;
    public Button botonEscalar;

    public Button botonVolverCrear;
    public Button botonVolverMover;
    public Button botonVolverRotar;
    public Button botonVolverEliminar;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Start() // Inicializa el menú principal al inicio
    {

        botonCrear.onClick.AddListener(() => menus.IrMenuCrear());// Asigna la funcion al botón Crear
        botonMover.onClick.AddListener(() => menus.IrMenuMover());// Asigna la funcion al botón Mover
        botonRotar.onClick.AddListener(() => menus.IrMenuRotar());// Asigna la funcion al botón Rotar
        botonEliminar.onClick.AddListener(() => menus.IrMenuEliminar());// Asigna la funcion al botón Eliminar

        botonVolverCrear.onClick.AddListener(() => menus.VolverAlMenuPrincipal());// Asigna la funcion al botón Volver
        botonVolverMover.onClick.AddListener(() => menus.VolverAlMenuPrincipal());
        botonVolverRotar.onClick.AddListener(() => menus.VolverAlMenuPrincipal());
        botonVolverEliminar.onClick.AddListener(() => menus.VolverAlMenuPrincipal());

        botonCerrarPopUpCrear.onClick.AddListener(() => CerrarPopUpCrear());// Asigna la funcion al botón Cerrar del pop-up Crear
        botonCerrarPopUpMover.onClick.AddListener(() => CerrarPopUpMover());// Asigna la funcion al botón Cerrar del pop-up Mover
        botonCerrarPopUpRotar.onClick.AddListener(() => CerrarPopUpRotar());// Asigna la funcion al botón Cerrar del pop-up Rotar
        botonCerrarPopUpEliminar.onClick.AddListener(() => CerrarPopUpEliminar());// Asigna la funcion al botón Cerrar del pop-up Eliminar

        botonCerrarMenuLateral.onClick.AddListener(() => CerrarPopUpMenuLateral());// Asigna la funcion al botón Cerrar del menú lateral

        for (int i = 0; i < botonesPrefabs.Length; i++) // Asigna la funcion a los botones de objetos
        {
            int index = i; // Necesario para evitar el problema de cierre
            botonesPrefabs[i].onClick.AddListener(() => CrearObjeto(index));
        }

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
    public void CerrarPopUpCrear() // Cierra todos los pop-ups
    {
        menus.AnimarSalidaPopUps(popUpCrear);
        
    }
    public void CerrarPopUpMover()
    {
        menus.AnimarSalidaPopUps(popUpMover);
        
    }
    public void CerrarPopUpRotar()
    {
        menus.AnimarSalidaPopUps(popUpRotar);
        
    }
    public void CerrarPopUpEliminar()
    {
        menus.AnimarSalidaPopUps(popUpEliminar);
        
    }
    
    public void CerrarPopUpMenuLateral()
    {
        menus.AnimarSalidaMenuCrear(menuLateralCrear);
    }    

    public void CrearObjeto(int indiceObjeto)
    {
        

        if (Camera.main == null) return;

        if (indiceObjeto < 0 || indiceObjeto >= prefabs.Length)
        {
            return;
        }

        GameObject prefabInstanciado = menus.controlMenus.prefabs[indiceObjeto];
        objetoCreado = Object.Instantiate(prefabInstanciado);
        objetoCreado.layer = LayerMask.NameToLayer("Editable"); // Cambia la capa del edificio para que sea editable

        GameObject suelo = GameObject.FindWithTag("Suelo");
        Vector3 posicionInicial = new Vector3(0f, 2f, 77.5f); // Posición por defecto en caso de no encontrar el suelo

        if (suelo != null)
        {
            objetoCreado.transform.position = posicionInicial;
            objetoCreado.layer = LayerMask.NameToLayer("Default"); // Cambia la capa del edificio para que sea editable
        }
    }

}
