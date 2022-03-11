using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GameMatching.Comum.Repositories
{
    public class RepositoryBase
    {
        private string pathFile { get; set; }

        public RepositoryBase(string path)
        {
            pathFile = Directory.GetCurrentDirectory() + @"..\..\..\..\"+ path;
        }

        public bool Cadastrar<T>(T objetos)
        {
            using FileStream stream = File.OpenRead(pathFile);
            var produtosDB = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
            stream.Close();

            produtosDB.Add(objetos);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(produtosDB));
            return true;
        }

        public List<T> BuscarTodos<T>()
        {
            using FileStream stream = File.OpenRead(pathFile);
            return JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
        }
    }
}
