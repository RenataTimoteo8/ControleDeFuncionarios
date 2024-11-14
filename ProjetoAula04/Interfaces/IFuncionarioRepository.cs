using ProjetoAula04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Interfaces
{
    
    /// <summary>
    /// Interface para abstração do repositório de funcionário
    /// </summary>
    public interface IFuncionarioRepository
    {
        /// <summary>
        /// Método abstrato para exportar dados de funcionário.
        /// </summary>
        void ExportarDados(Funcionario funcionario);
    }
}
