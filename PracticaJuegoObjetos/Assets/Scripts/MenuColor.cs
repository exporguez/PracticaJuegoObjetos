using UnityEngine;

public class MenuColor : IEstado
{
    public Material materialRojo;
    public Material materialVerde;
    public Material materialAzul;
    public Material materialAmarillo;

    public ControlMenus controlMenus;

    private string tagEditable = "Editable";


    private GameObject objetoSeleccionado;
    private float distanciaMaxima = 300f;

    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.AnimarEntradaPopUps(menus.controlMenus.popUpColor);
        menus.AnimarEntradaPopUps(menus.controlMenus.popUpLateralColor);
        menus.controlMenus.menuColor.SetActive(true);
        
        objetoSeleccionado = null;
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        /*if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// Crea un rayo desde la cámara hacia la posición del ratón
        RaycastHit hit;// Variable para almacenar la información del punto de colisión

        if(nuevo_material != null && Input.GetMouseButtonDown(0))
        {
            if (objetoSeleccionado == null && Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, distanciaMaxima, menus.editableMask)) // Si el rayo golpea un objeto en la capa "Editable"
                {
                    if (hit.collider.CompareTag(tagEditable)) // Verifica si el objeto tiene la etiqueta "Editable"
                    {
                        objetoSeleccionado = hit.collider.gameObject;// Obtiene el objeto seleccionado
                    }

                }
            }
        }

        

             

        if (objetoSeleccionado != null && nuevo_material != null) //Si hay un objetoSeleccionado
        {
            if(Input.GetMouseButtonDown(0))
            {
                CambiarColor();
            }
        }*/           
    }

    public void CambiarColor(int indiceColor)
    {
        if (Camera.main == null) return;

        if (indiceColor < 0 || indiceColor >= controlMenus.materiales.Length)
        {
            return;
        }

        Material nuevo_material = controlMenus.materiales[indiceColor];

        objetoSeleccionado.GetComponent<MeshRenderer>().material = nuevo_material;

        if (nuevo_material == null) return;
    }

    public void Salir(MenuStateMachine menus)
    {
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado = null;
        }
        menus.controlMenus.menuColor.SetActive(false);
    }
}
