using System;

class Program {
    static void Main(string[] args) {
        Time time = new Time("Time 1");
        Jogador j1 = new Jogador("Gabriel", 13, true);
        Jogador j2 = new Jogador("Julia", 10, false);
        Jogador j3 = new Jogador("Marcelo", 1, false);
        Jogador j4 = new Jogador("Fonti", 9, false);
        time.Inserir(j1);
        time.Inserir(j2);
        time.Inserir(j3);
        time.Inserir(j4);

        foreach (Jogador j in time.Listar()) {
            Console.WriteLine(j);
        }
    }
}

class Jogador {
    private string nome;
    private int camisa;
    private bool capitao;
    public Jogador(string nome, int camisa, bool capitao) {
        this.nome = nome;
        this.camisa = camisa;
        this.capitao = capitao;
    }

    public string getNome() {
        return this.nome;
    }

    public int getCamisa() {
        return this.camisa;
    }

    public bool getCapitao() {
        return this.capitao;
    }

    public override string ToString() {
        return $"Jogador {this.nome}, Camisa {this.camisa}, Capitao: {this.capitao}";
    }
}

class Time {
    private string nome;
    private Jogador[] jogadores;
    private int count;

    public Time(string nome) {
        this.count = 0;
        this.jogadores = new Jogador[count];
        this.nome = nome;
    }

    public void Inserir(Jogador j) {
        if (this.Capitao() != null && j.getCapitao()) {
            Console.WriteLine("Esse time ja possui um capitao!");
        }
        else {
            if (count == jogadores.Length) Array.Resize(ref jogadores, count + 1);
            jogadores[count] = j;
            count++;
        }
    }
    public Jogador[] Listar() {
        return this.jogadores;
    }

    public Jogador Capitao() {
        Jogador? capitao = null;
        foreach (Jogador j in this.jogadores) {
            if (j.getCapitao()) capitao = j;
        }

        return capitao;
    }
}