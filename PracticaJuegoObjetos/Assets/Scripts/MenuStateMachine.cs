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
    public LeanTweenType tipoEaseOut = LeanTweenType.easeInBack;

    public float posicionLateral = 400f;

    public GameObject particulas;

    public GameObject prefabSombra;
    public GameObject sombraInstanciada;
    public float tamañoSombra = 1.3f;

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
        if (particulas != null)
        {
            GameObject efecto = Instantiate(particulas, posicion, Quaternion.identity);
            ParticleSystem ps = efecto.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                Destroy(efecto, ps.main.duration + ps.main.startLifetime.constantMax);
            }
        }
    }

    public void AnimarEntradaPopUps(GameObject popUp)// Animación de entrada para los pop-ups
    {
        LeanTween.cancel(popUp);
        popUp.SetActive(true);
        popUp.transform.localScale = Vector3.one;
        popUp.transform.localScale = Vector3.zero;
        LeanTween.scale(popUp, Vector3.one, duracionAnimacion).setEase(tipoEaseIn);

    }

    public void AnimarSalidaPopUps(GameObject popUp)// Animación de salida para los pop-ups
    {
        LeanTween.cancel(popUp);
        LeanTween.scale(popUp, Vector3.zero, duracionAnimacion).setEase(tipoEaseOut).setOnComplete(() =>
        {
            popUp.SetActive(false);
        })
        ;
    }

    public void AnimarMenuPrincipal(GameObject menuPrincipal)// Animación de entrada para el menú principal
    {
        LeanTween.cancel(menuPrincipal);// Cancela cualquier animación en curso
        menuPrincipal.SetActive(true);// Asegura que el menú esté activo
        Vector3 posicionFinal = menuPrincipal.transform.localPosition;// Guarda la posición final del menú
        menuPrincipal.transform.localScale = Vector3.one;// Establece la escala inicial del menú
        menuPrincipal.transform.localPosition = posicionFinal;// Establece la posición inicial del menú
        menuPrincipal.transform.localScale = Vector3.zero;// Escala el menú a cero para la animación de entrada
        LeanTween.moveLocal(menuPrincipal, posicionFinal, duracionAnimacion).setEase(tipoEaseIn);// Anima la posición del menú a la posición final
        LeanTween.scale(menuPrincipal, Vector3.one * 2.4f, duracionAnimacion).setEase(tipoEaseIn);// Anima la escala del menú al tamaño original
    }

    public void AnimarEntradaMenuCrear(GameObject menuPopUpCrear)// Animación de entrada para el menú de crear
    {
        LeanTween.cancel(menuPopUpCrear);// Cancela cualquier animación en curso
        menuPopUpCrear.SetActive(true);// Asegura que el menú esté activo

        Vector3 posicionFinal = menuPopUpCrear.transform.localPosition;
        Vector3 posicionInicial = posicionFinal;
        posicionInicial.x += posicionLateral;
        menuPopUpCrear.transform.localPosition = posicionInicial;
        LeanTween.moveLocal(menuPopUpCrear, posicionFinal, duracionAnimacion).setEase(tipoEaseIn);
        
    }

    public void AnimarSalidaMenuCrear(GameObject menuPopUpCrear)
    {
        LeanTween.cancel(menuPopUpCrear);// Cancela cualquier animación en curso
        if (menuPopUpCrear == controlMenus.menuLateralCrear) // Asumimos que es el menú de creación
        {
            Vector3 posicionFinal = menuPopUpCrear.transform.localPosition;
            Vector3 posicionSalida = posicionFinal;
            posicionSalida.x -= posicionLateral;
            LeanTween.moveLocal(menuPopUpCrear, posicionSalida, duracionAnimacion).setEase(tipoEaseOut).setOnComplete(() =>
            {
                menuPopUpCrear.SetActive(false);
            });
        }
    }
  
    public void CrearSombra(Vector3 posicion, float escala)// Crea una sombra en la posición dada con la escala dada
    {
        if(prefabSombra == null) return;

        if (sombraInstanciada != null) Destroy(sombraInstanciada);
        
        sombraInstanciada = Instantiate(prefabSombra, posicion, Quaternion.identity);
        sombraInstanciada.transform.localScale = Vector3.one * escala * tamañoSombra;
    }
   
    public void MoverSombra(Vector3 nuevaPosicion)// Mueve la sombra a la nueva posición dada
    {
        if (sombraInstanciada != null)
        {
            nuevaPosicion.y += 0.01f;
            sombraInstanciada.transform.position = nuevaPosicion;
        }
    }

    public void DestruirSombra()// Destruye la sombra instanciada
    {
        if (sombraInstanciada != null)
        {
            Destroy(sombraInstanciada);
            sombraInstanciada = null;
        }
    }
}



