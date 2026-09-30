using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Agregar(T entidad);
        List<T> ObtenerTodos();
        List<T> ObtenerTodosCon(string propiedadRelacionada);
        T ObtenerPorId(int id);
        void Modificar(T entidad);
        void Eliminar(object id);
    }
}
