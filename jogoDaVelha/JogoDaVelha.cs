
namespace jogoDaVelha
{
    internal class JogoDaVelha
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida = 0;

        public JogoDaVelha()
        {
            fimDeJogo = false;
            posicoes= new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
        }
        public void Iniciar()
        {
            while(!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaUsusario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();
            }
        }
        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }
        private void VerificarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal()) {
                fimDeJogo = true;
                Console.WriteLine($"Fim de Jogo! Vitória de: {vez}");
                return;

            }
            if (quantidadePreenchida is 9) {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo! EMPATE!");
                }
        }
        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaColuna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaColuna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaColuna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaColuna1 || vitoriaColuna2 || vitoriaColuna3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaDiagona1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool vitoriaDiagonal2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            

            return vitoriaDiagona1 || vitoriaDiagonal2;
        }
        private void LerEscolhaUsusario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, escolha sua casa de 1 a 9 que esteja disponível na tabela!");
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolha(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9, que esteja disponivel na tabela!");
                int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }
            PreencherEscolha(posicaoEscolhida); 
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;
            quantidadePreenchida++;
        }
        private bool ValidarEscolha(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida - 1;

            return posicoes[indice] != 'O' && posicoes[indice] != 'X';
            
        }
        private void RenderizarTabela()
        {
           Console.Clear();
            Console.WriteLine(ObterTabela());
        }
        private string ObterTabela()
        {

            Console.WriteLine("------------------------------------");
            Console.WriteLine("   BEM VINDO AO JOGO DA VELHA   ");
            Console.WriteLine("------------------------------------");
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}
