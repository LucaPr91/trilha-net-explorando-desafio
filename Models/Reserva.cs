namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade da suíte menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes => Hospedes != null ? Hospedes.Count : 0;

        public decimal CalcularValorDiaria()
        {
            if(Hospedes.Count > 0)
            {
                if (Suite == null)
                {
                    throw new Exception("Suíte não cadastrada para a reserva.");
                }

                // Retorna o valor da diária
                decimal valor = DiasReservados * Suite.ValorDiaria;

                // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
                if (DiasReservados >= 10)
                {
                    valor *= 0.9m; // Aplica desconto de 10%
                }

                return valor;
            }
            else
            {
                throw new Exception("Não há hospedes cadastrados.");
            }
        }
    }
}