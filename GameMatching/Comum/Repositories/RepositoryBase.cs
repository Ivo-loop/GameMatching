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
            pathFile = Directory.GetCurrentDirectory() + path;
        }

        public bool Cadastrar<T>(T objeto)
        {
            using FileStream stream = File.OpenRead(pathFile);
            var database = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
            stream.Close();

            database.Add(objeto);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(database));
            return true;
        }

        public List<T> BuscarTodos<T>()
        {
            using FileStream stream = File.OpenRead(pathFile);
            return JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
        }

        public bool Excluir<T>(T objeto)
        {
            using FileStream stream = File.OpenRead(pathFile);
            var database = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
            stream.Close();

            database.Remove(objeto);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(database));

            return true;
        }
    }
}
