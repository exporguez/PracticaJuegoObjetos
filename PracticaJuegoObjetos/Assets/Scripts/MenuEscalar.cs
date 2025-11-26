using UnityEngine;

public class MenuEscalar : IEstado
{
    private GameObject objetoSeleccionado;
    private float distanciaMaxima = 300f;// Distancia máxima del rayo
    private string tagEditable = "Editable";// Tag de los objetos editables

    private float factorEscalado = 0.5f; // Factor de escala     
    private Vector3 escalaMinima = new Vector3(0.5f, 0.5f, 0.5f); // Escala mínima del objeto
    private Vector3 escalaMaxima = new Vector3(2f, 2f, 2f); // Escala máxima del objeto

    private Vector3 escalaReducida = new Vector3(0.7f, 0.7f, 0.7f);// Escala reducida para el objeto seleccionado
    private float duracionAnimacion = 0.2f;


    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();            
        menus.AnimarEntradaPopUps(menus.controlMenus.popUpEscalar);
        menus.AnimarEntradaPopUps(menus.controlMenus.popUpLateralEscalar);
        menus.controlMenus.menuEscalar.SetActive(true);
        objetoSeleccionado = null;
        
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main == null) return;       
        
        if (objetoSeleccionado != null)
        {
            float scale = Input.GetAxis("Mouse Y"); //* velocidadRotacion * Time.deltaTime; 
            
            if (scale != 0f)
            {
                Vector3 cambioEscala = Vector3.one * scale * factorEscalado;
                Vector3 nuevaEscala = objetoSeleccionado.transform.localScale + cambioEscala;

                nuevaEscala.x = Mathf.Clamp(nuevaEscala.x, escalaMinima.x, escalaMaxima.x);
                nuevaEscala.y = Mathf.Clamp(nuevaEscala.y, escalaMinima.y, escalaMaxima.y);
                nuevaEscala.z = Mathf.Clamp(nuevaEscala.z, escalaMinima.z, escalaMaxima.z);

                
                objetoSeleccionado.transform.localScale = nuevaEscala;
            }

            if (Input.GetMouseButtonDown(1))
            {
                menus.ReproducirSonidoSoltar();
                menus.InstanciarParticulas(objetoSeleccionado.transform.position);
                
                objetoSeleccionado = null;
            }
            return;
        }


        if (Input.GetMouseButtonDown(0))// Si se hace clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, distanciaMaxima))
            {
                if (hit.collider.CompareTag(tagEditable))// Verifica si el objeto tiene la etiqueta "Editable"
                {
                    
                    objetoSeleccionado = hit.collider.gameObject;// Selecciona el objeto                    

                }
            }
        }
    }
    public void Salir(MenuStateMachine menus)
    {
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado = null;
        }
        menus.controlMenus.menuEscalar.SetActive(false);
        
    }

}

