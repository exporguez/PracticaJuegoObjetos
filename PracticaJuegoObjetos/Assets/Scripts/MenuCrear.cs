using UnityEngine;

public class MenuCrear : IEstado
{
    [SerializeField]
    private GameObject menuCrear;

    public void Entrar(MenuStateMachine menus)
    {
        menus.menuCrear.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuCrear.SetActive(false);
    }

    [SerializeField]
    GameObject[] prefabsEdificios;

    [SerializeField]
    GameObject[] prefabsArboles;

    [SerializeField]
    GameObject[] prefabsDecoracion;
    void CrearObjeto()
    {
        Debug.Log("Botón Crear Objeto pulsado");
    }
}
