namespace JogoAdivinhação;

public class GameSistema
{
    public int GameStart()
    {
        Random random = new Random();
        int resposta = random.Next(1, 100);
        
        return resposta;
    }
}