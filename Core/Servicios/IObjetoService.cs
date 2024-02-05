using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IObjetoService
    {
        Task ChangingValue(Objeto objeto, double valor);
    }
}