namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(string v) { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite == null)
            {
                throw new Exception("A suíte não foi cadastrada.");
            }
            if (hospedes == null || hospedes.Count == 0)
            {
                throw new Exception("A lista de hóspedes não pode ser nula ou vazia.");
            }
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("A quantidade de hóspedes não pode ser maior que a capacidade da suíte.");
            }
            if (true)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception("A quantidade de hóspedes não pode ser maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            if (Suite == null)
            {
                throw new Exception("A suíte não foi cadastrada.");
            }
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1m; // Aplicando 10% de desconto
            }
            // Regra: Caso a suíte for do tipo "Premium", conceder um desconto de 20%
            if (Suite.TipoSuite == "Premium")
            {
                valor -= valor * 0.2m; // Aplicando 20% de desconto
            }
            // Regra: Caso a suíte for do tipo "Luxo", conceder um desconto de 15%
            if (Suite.TipoSuite == "Luxo")
            {
                valor -= valor * 0.15m; // Aplicando 15% de desconto
            }
            // Regra: Caso a suíte for do tipo "Básica", não conceder desconto
            if (Suite.TipoSuite == "Básica")
            {
                // Não há desconto para suítes básicas
            }

            // Verifica se o valor calculado é negativo ou zero
            if (valor < 0)
            {
                throw new Exception("O valor calculado não pode ser negativo.");
            }
            else if (valor == 0)
            {
                throw new Exception("O valor calculado não pode ser zero.");
            }
            // Retorna o valor calculado
            return valor;
        }
    }
}