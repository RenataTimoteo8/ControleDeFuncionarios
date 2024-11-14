using Newtonsoft.Json;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Implementação de repositório de funcionário
    /// para gravação de dados em arquivo em JSON
    /// </summary>
    public class funcionarioRepositoryJson : IFuncionarioRepository
    {
        public void ExportarDados(Funcionario funcionario)
        {
            /// <summary>
            ///Converter os dados do funcionario em JSON
            /// </summary>
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);
            
            //abrindo um arquivo para gravação
            var streamWriter = new StreamWriter("c:\\temp\\funcionario_"+ funcionario.Nome +".json", true);

            //gravar os dados no arquivo
            streamWriter.WriteLine(json);

            //fechando o arquivo
            streamWriter.Close();


        }
    }
}
