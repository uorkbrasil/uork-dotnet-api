using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace uork_api
{
    class Program
    {
        const string BaseUrl = "https://uork.org/search/status/";
        static readonly HttpClient httpClient = new HttpClient();

        static async Task<string> GetUserInput(string question)
        {
            Console.Write(question);
            return await Task.Run(() => Console.ReadLine());
        }

        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Uork - API Example");
                Console.WriteLine("1 - Consultar Status de um serviço");
                Console.WriteLine("2 - Consultar Conta");
                Console.WriteLine("3 - Consultar Notícias");

                Console.Write("Qual a escolha desejada: ");
                string option = await GetUserInput("");

                if (option == "1")
                {
                    Console.Write("Insira o ID ou e-mail do usuário: ");
                    string userInput = await GetUserInput("");
                    string url = BaseUrl + $"check-status.php?idsolicitacao={userInput}";
                    string status = await httpClient.GetStringAsync(url);
                    Console.WriteLine(status);
                }
                else if (option == "2")
                {
                    Console.Write("Insira o ID ou e-mail do usuário: ");
                    string userInput = await GetUserInput("");
                    string url = BaseUrl + $"check-account.php?id={userInput}";
                    string status = await httpClient.GetStringAsync(url);
                    Console.WriteLine(status);
                }
                else if (option == "3")
                {
                    string url = BaseUrl + "check-noticias.php";
                    string status = await httpClient.GetStringAsync(url);
                    Console.WriteLine(status);
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
