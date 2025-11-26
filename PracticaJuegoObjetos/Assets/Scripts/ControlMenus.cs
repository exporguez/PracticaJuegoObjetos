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
    public GameObject menuColor;
    
    public GameObject popUpCrear;
    public GameObject popUpMover;
    public GameObject popUpRotar;
    public GameObject popUpEliminar;
    public GameObject menuLateralCrear;
    public GameObject menuLateralRotar;
    public GameObject popUpConfirmarEliminar;
    public GameObject popUpColor;
    public GameObject popUpEscalar;
    public GameObject popUpLateralColor;
    public GameObject popUpLateralEscalar;

    public Button botonCerrarPopUpCrear;
    public Button botonCerrarPopUpMover;
    public Button botonCerrarPopUpRotar;
    public Button botonCerrarPopUpEliminar;
    public Button botonCerrarPopUpColor;
    public Button botonCerrarPopUpEscalar;
    public Button botonCerrarPopUpLateralColor;
    public Button botonCerrarPopUpLateralEscalar;

    public Button botonConfirmarEliminar;
    public Button botonCancelarEliminar;

    public Button botonCerrarMenuLateral;
    public Button botonCerrarMenuLateralRotar;

    public GameObject[] prefabs;
    public Button[] botonesPrefabs;
    private GameObject objetoCreado;

    public Button botonCrear;
    public Button botonMover;
    public Button botonRotar;
    public Button botonEliminar;
    public Button botonEscalar;
    public Button botonColor;

    public Button botonVolverCrear;
    public Button botonVolverMover;
    public Button botonVolverRotar;
    public Button botonVolverEliminar;
    public Button botonVolverColor;
    public Button botonVolverEscalar;

    public Button[] botonesColores;
    public Material[] materiales;
    private GameObject objetoSeleccionado;
    private Material materialSeleccionado;



    //public GameObject objetoSeleccionadoParaEliminar;

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
        botonColor.onClick.AddListener(() => menus.IrMenuColor());
        botonEscalar.onClick.AddListener(() => menus.IrMenuEscalar());

        botonVolverCrear.onClick.AddListener(() => menus.VolverAlMenuPrincipal());// Asigna la funcion al botón Volver
        botonVolverMover.onClick.AddListener(() => menus.VolverAlMenuPrincipal());
        botonVolverRotar.onClick.AddListener(() => menus.VolverAlMenuPrincipal());
        botonVolverEliminar.onClick.AddListener(() => menus.VolverAlMenuPrincipal());
        botonVolverColor.onClick.AddListener(() => menus.VolverAlMenuPrincipal());
        botonVolverEscalar.onClick.AddListener(() => menus.VolverAlMenuPrincipal());

        botonCerrarPopUpCrear.onClick.AddListener(() => CerrarPopUpCrear());// Asigna la funcion al botón Cerrar del pop-up Crear
        botonCerrarPopUpMover.onClick.AddListener(() => CerrarPopUpMover());// Asigna la funcion al botón Cerrar del pop-up Mover
        botonCerrarPopUpRotar.onClick.AddListener(() => CerrarPopUpRotar());// Asigna la funcion al botón Cerrar del pop-up Rotar
        botonCerrarPopUpEliminar.onClick.AddListener(() => CerrarPopUpEliminar());// Asigna la funcion al botón Cerrar del pop-up Eliminar
        botonCerrarMenuLateralRotar.onClick.AddListener(() => CerrarPopUpLateralRotar());
        botonCerrarPopUpColor.onClick.AddListener(() => CerrarPopUpColor());
        botonCerrarPopUpLateralColor.onClick.AddListener(() => CerrarPopUpLateralColor());
        botonCerrarPopUpEscalar.onClick.AddListener(() => CerrarPopUpEscalar());
        botonCerrarPopUpLateralEscalar.onClick.AddListener(() => CerrarPopUpLateralEscalar());

        botonCerrarMenuLateral.onClick.AddListener(() => CerrarPopUpMenuLateral());// Asigna la funcion al botón Cerrar del menú lateral

        /*for (int i = 0; i < botonesColores.Length; i++) // Asigna la funcion a los botones de objetos
        {
            int index = i; // Necesario para evitar el problema de cierre
            botonesColores[i].onClick.AddListener(() => CambiarColor());
        }*/

        //botonConfirmarEliminar.onClick.AddListener(() => ConfirmarEliminar());// Asigna la funcion al botón Confirmar Eliminar
        //botonCancelarEliminar.onClick.AddListener(() => CancelarEliminar());// Asigna la funcion al botón Cancelar Eliminar

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
        menuColor.SetActive(false);
        menuEscalar.SetActive(false);

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
    public void CerrarPopUpLateralRotar()
    {
        menus.AnimarSalidaPopUps(menuLateralRotar);

    }
    public void CerrarPopUpEliminar()
    {
        menus.AnimarSalidaPopUps(popUpEliminar);
        
    }
    
    public void CerrarPopUpMenuLateral()
    {
        menus.AnimarSalidaMenuCrear(menuLateralCrear);
    }    

    public void CerrarPopUpColor()
    {
        menus.AnimarSalidaPopUps(popUpColor);
    }

    public void CerrarPopUpLateralColor()
    {
        menus.AnimarSalidaPopUps(popUpLateralColor);
    }

    public void CerrarPopUpEscalar()
    {
        menus.AnimarSalidaPopUps(popUpEscalar);
    }

    public void CerrarPopUpLateralEscalar()
    {
        menus.AnimarSalidaPopUps(popUpLateralEscalar);
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

    /*public void CambiarColor(int indiceColor)
    {
        if (Camera.main == null) return;

        if (indiceColor < 0 || indiceColor >= materiales.Length)
        {
            return;
        }

        Material nuevo_material = materiales[indiceColor];

        objetoSeleccionado.GetComponent<MeshRenderer>().material = nuevo_material;

        if (nuevo_material == null) return;
    }*/

    /*public void ConfirmarEliminar()
    {
        if (objetoSeleccionadoParaEliminar != null)
        {
            //linea de sonido de eliminacion
            Object.Destroy(objetoSeleccionadoParaEliminar); // Destrucción REAL
            objetoSeleccionadoParaEliminar = null;          // Limpiar referencia
        }        
        
        menus.AnimarSalidaPopUps(popUpConfirmarEliminar);
    }
    
    public void CancelarEliminar()
    {
        objetoSeleccionadoParaEliminar = null; // Limpiar referencia
        menus.AnimarSalidaPopUps(popUpConfirmarEliminar);
    }*/
}
