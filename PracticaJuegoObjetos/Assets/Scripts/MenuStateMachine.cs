using Unity.VisualScripting;
using UnityEngine;

public class MenuStateMachine : MonoBehaviour
{
    public ControlMenus controlMenus;

    public GameObject[] prefabsObjetos;
    public LayerMask sueloMask;
    public LayerMask editableMask;
    public LayerMask capaDestruibleMask;

    private float duracionAnimacion = 0.5f;
    public LeanTweenType tipoEaseIn = LeanTweenType.easeOutBack;

    public GameObject particulas;

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
        Debug.Log("Estado actual del menú ejecutandose");
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
        estadoAtualMenu = new MenuCrear();
        estadoAtualMenu.Entrar(this);
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

    public void InstanciarParticulas(Vector3 posicion)// Instancia el efecto de partículas en la posición dada
    {
        if(particulas != null)
        {
            GameObject efecto = Instantiate(particulas, posicion, Quaternion.identity);
            ParticleSystem ps = efecto.GetComponent<ParticleSystem>();
            
            if(ps != null)
            {
                Destroy(efecto, ps.main.duration + ps.main.startLifetime.constantMax);
            }
            
        }
    }
    
    public void AnimarPopUps(GameObject popUp)
    {
        LeanTween.cancel(popUp);
        popUp.SetActive(true);
        popUp.transform.localScale = Vector3.one;
        popUp.transform.localScale = Vector3.zero;
        LeanTween.scale(popUp, Vector3.one, duracionAnimacion).setEase(tipoEaseIn);

    }
}

