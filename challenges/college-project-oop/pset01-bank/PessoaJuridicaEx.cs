using System;

class PessoaJuridicaEx : IPessoaEx
{
    public string nome { get; set; }
    public string sobrenome { get; set; }
    public string Cnpj { get; set; }
    public int credito { get; set; }

    public PessoaJuridicaEx(string nome, string sobrenome, string cnpj, int credito)
    {
        this.nome = nome;
        this.sobrenome = sobrenome;
        this.Cnpj = cnpj;
        this.credito = credito;
    }

    public bool validarDados()
    {
        string MsgErro = "inválido(a). Digite seus dados novamente";
        if(nome == null || nome.Length == 0 || nome.Length > 50) throw new Exception($"Nome {MsgErro}");
        if(sobrenome == null || sobrenome.Length == 0 || sobrenome.Length > 50) throw new Exception($"Sobrenome {MsgErro}");
        if(credito < 0) throw new Exception($"Crédito {MsgErro}");
        if(!validarCNPJ(Cnpj)) throw new Exception($"Cnpj {MsgErro}");
        return true;
    }

    public bool validarCNPJ(string cnpj)
    {
        string CNPJ = cnpj.Replace(".", "");
        CNPJ = CNPJ.Replace("/", "");
        CNPJ = CNPJ.Replace("-", "");

        int[] digitos, soma, resultado;
        int nrDig;
        string ftmt;
        bool[] CNPJOk;

        ftmt = "6543298765432";
        digitos = new int[14];
        soma = new int[2];
        soma[0] = 0;
        soma[1] = 0;
        resultado = new int[2];
        resultado[0] = 0;
        resultado[1] = 0;
        CNPJOk = new bool[2];
        CNPJOk[0] = false;
        CNPJOk[1] = false;

        try
        {
            for (nrDig = 0; nrDig < 14; nrDig++)
            {
                digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));

                if (nrDig <= 11)
                    soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                if (nrDig <= 12)
                    soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
            }

            for (nrDig = 0; nrDig < 2; nrDig++)
            {
                resultado[nrDig] = (soma[nrDig] % 11);

                if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                else
                    CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
            }

            return (CNPJOk[0] && CNPJOk[1]);
        }
        catch
        {
            return false;
        }
    }
}