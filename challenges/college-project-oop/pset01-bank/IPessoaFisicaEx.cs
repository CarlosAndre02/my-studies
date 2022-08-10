using System;

class IPessoaFisicaEx : IPessoaEx
{
    public string nome { get; set; }
    public string sobrenome { get; set; }
    public string Cpf { get; set; }

    public IPessoaFisicaEx(string nome, string sobrenome, string cpf)
    {
        this.nome = nome;
        this.sobrenome = sobrenome;
        this.Cpf = cpf;
    }

    public bool validarDados()
    {
        string MsgErro = "inválido(a). Digite seus dados novamente";
        if(nome == null || nome.Length == 0 || nome.Length > 50) throw new Exception($"Nome {MsgErro}");
        if(sobrenome == null || sobrenome.Length == 0 || sobrenome.Length > 50) throw new Exception($"Sobrenome {MsgErro}");
        if(!validarCPF(Cpf)) throw new Exception($"Cpf {MsgErro}");
        return true;
    }

    public bool validarCPF(string cpf)
    {
        string valor = cpf.Replace(".", "");
        valor = valor.Replace("-", "");

        if (valor.Length != 11) return false;

        bool igual = true;
        for (int i = 1; i < 11 && igual; i++)
        {
            if (valor[i] != valor[0]) igual = false;
        }

        if (igual || valor == "12345678909") return false;

        int[] numeros = new int[11];
        for (int i = 0; i < 11; i++)
        {
            numeros[i] = int.Parse(valor[i].ToString());
        }

        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += (10 - i) * numeros[i];
        }

        int resultado = soma % 11;
        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0) return false;
        }
        else
        {
            if (numeros[9] != 11 - resultado) return false;
        }

        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += (11 - i) * numeros[i];
        }

        resultado = soma % 11;
        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0) return false;
        }
        else
        {
            if (numeros[10] != 11 - resultado) return false;
        }

        return true;
    }
}