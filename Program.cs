
using JogoAdivinhação;


GameSistema game = new GameSistema();
    
game.GameStart();

Boolean rodar = true;

while (rodar)
{
    Console.WriteLine("Digite seu palpite: ");

    if (game.VerificarResposta(game.ReceberPalpite()))
        rodar = false;
    
}