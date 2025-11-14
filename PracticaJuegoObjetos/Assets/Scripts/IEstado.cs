//Todos los estados tendran lo que dice aqui

public interface  IEstado
{
    void Entrar(MenuStateMachine menus);
    void Ejecutar(MenuStateMachine menus);
    void Salir(MenuStateMachine menus);

}
 