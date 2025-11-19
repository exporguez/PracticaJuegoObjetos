using UnityEngine;

public class MenuEliminar : IEstado
{
    private MenuStateMachine menus;

    private float distanciaMaxima = 300f;// Distancia máxima del rayo


    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.controlMenus.menuEliminar.SetActive(true);
        menus.capaDestruibleMask = LayerMask.GetMask("Default");

    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaMaxima, menus.capaDestruibleMask)) // Si el rayo golpea un objeto en la capa "NoEditable"
            {
                GameObject objetoSeleccionado = hit.collider.gameObject;
                Object.Destroy(objetoSeleccionado);

            }
        }
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuEliminar.SetActive(false);
    }
}
