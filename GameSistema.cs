namespace JogoAdivinhação;

public class GameSistema
{

    private int _resposta;
    private int _pontos;
    private int _rodada = 1;
    private int _rodadafinal;
    private int _dificuldade;
    
   /*
    * Difculdades:
    * 1 -> fácil
    * 2 -> médio
    * 3 -> difícil
    */
    
    public void GameStart()
    {
        EscolherDificuldade();
        
        Random random = new Random();
        this._resposta = random.Next(1, this._dificuldade*12);
        this._rodadafinal = 10 - this._dificuldade;
    }
    
    public int ReceberPalpite()
    {
        int palpite = 0;
        
        try
        {
           palpite = int.Parse(Console.ReadLine() ?? "1");
        }
        catch
        {
            ReceberPalpite();
        }
        
        return palpite;
    }

    private void EscolherDificuldade()
    {
        Console.WriteLine("Escolha uma dificuldade");
        Console.WriteLine("1 -> fácil");
        Console.WriteLine("2 -> médio");
        Console.WriteLine("3 -> difícil");
        Console.Write("-> " );
        int escolha = int.Parse(Console.ReadLine() ?? "1");
        
        this._dificuldade = escolha;
    }


    public Boolean VerificarResposta(int palpite)
    {
        Console.Clear();
        Console.WriteLine("|--------------------------------------------------|");
        Console.WriteLine("|--------------------------------------------------|\n");
        
        
        
        if (palpite > this._resposta)
        {
            Console.WriteLine("Respota incorreta! \nA resposta correta é menor");
            Console.WriteLine("\n|--------------------------------------------------|");
            Console.WriteLine("|--------------------------------------------------|");
            Console.ReadKey();
        }
        else if (palpite < this._resposta)
        {
            Console.WriteLine("Respota incorreta! \nA resposta correta é maior");
            
            Console.WriteLine("\n|--------------------------------------------------|");
            Console.WriteLine("|--------------------------------------------------|");
            Console.ReadKey();
        }
        else if (palpite == this._resposta)
        {
            Console.WriteLine("REPOSTA CORRETA!");
            CalcularPontos();
            
            Console.WriteLine("\n|--------------------------------------------------|");
            Console.WriteLine("|--------------------------------------------------|");
            
            Console.ReadKey();
            Vitoria();
            return true;
        }

        if (this._rodada == this._rodadafinal)
        {
            Derrota();
            return true;
        }

        this._rodada++;
        return false;
    }

    private void CalcularPontos()
    {
        this._pontos = (this._rodadafinal+1 - this._rodada)*this._dificuldade*100;
    }
    
    private void Vitoria()
    {
        Console.Clear();
        Console.WriteLine("|--------------------------------------------------|");
        Console.WriteLine("|--------------------------------------------------|\n\n");

        Console.WriteLine("VOCÊ VENCEU!                   ");
        Console.WriteLine("Pontuação: "+ this._pontos+"                   ");
        
        Console.WriteLine("\n\n|--------------------------------------------------|");
        Console.WriteLine("|--------------------------------------------------|");
        Console.ReadKey();
    }

    private void Derrota()
    {
        Console.Clear();
        Console.WriteLine("|--------------------------------------------------|");
        Console.WriteLine("|--------------------------------------------------|\n");

        Console.WriteLine("Acabaram as tentativas");
        Console.WriteLine(":(");
        
        Console.WriteLine("\n|--------------------------------------------------|");
        Console.WriteLine("|--------------------------------------------------|");
        Console.ReadKey();
    }
    
}