using System.Runtime.CompilerServices;

namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo: ");
            string placa = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa inválida!");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Veículo já está estacionado!");
                return;
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {

            Console.WriteLine("Digite a placa para remover:");
            string placa = Console.ReadLine().Trim().ToUpper();

            // Verifica se o veículo existe
            if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Veículo não encontrato. Confira a placa!");
                return;
            }

            int horas = 0;
            decimal valorTotal = 0;

            Console.WriteLine("Digite quantidade de horas que veículo permaneceu estacionado:");
            int.TryParse(Console.ReadLine(), out horas);

            valorTotal = precoInicial + precoPorHora * horas;

            veiculos.Remove(placa);

            Console.WriteLine($"Veículo de {placa} removido, preço total: R$ {valorTotal}");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}