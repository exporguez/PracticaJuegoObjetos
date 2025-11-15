using UnityEngine;

public class ControlMenus : MonoBehaviour
{
    public static ControlMenus Instance { get; private set; }

    public GameObject menuPrincipal;
    public GameObject menuCrear;
    public GameObject menuMover;
    public GameObject menuRotar;
    public GameObject menuEliminar;

    private void Awake()
    {
        if (Instance != null && Instance != this) // Si ya existe una instancia, destruye esta
        {            
            return;
        }        
    }

    public void Start() // Inicializa el menú principal al inicio
    {
        menuPrincipal.SetActive(true);
        menuCrear.SetActive(false);
        menuMover.SetActive(false);
        menuRotar.SetActive(false);
        menuEliminar.SetActive(false);

    }

    public void IrMenuCrear()
    {
        menuPrincipal.SetActive(false);
        menuCrear.SetActive(true);
    }

    public void IrMenuMover()
    {
        menuPrincipal.SetActive(false);
        menuMover.SetActive(true);
    }

    public void IrMenuRotar()
    {
        menuPrincipal.SetActive(false);
        menuRotar.SetActive(true);
    }

    public void IrMenuEliminar()
    {
        menuPrincipal.SetActive(false);
        menuEliminar.SetActive(true);
    }
}
