using System;

class ContaCorrenteEx
{
    public IPessoaEx Correntista { get; set; }
    public int Saldo { get; set; }
    public int numeroDaConta { get; set; }

    public ContaCorrenteEx(int saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void adicionarCorrentista(IPessoaEx correntista)
    {
        if(Correntista != null) throw new Exception("Operação inválida");
        Correntista = correntista;
    }

    public string imprimirDadosPF()
    {
        if(!(Correntista is IPessoaFisicaEx)) throw new Exception("Operação inválida");
        
        IPessoaFisicaEx CorrentistaPF = Correntista as IPessoaFisicaEx;
        return $"Número da conta: {numeroDaConta} | Nome: {CorrentistaPF.nome} | Sobrenome: {CorrentistaPF.sobrenome} | CPF: {CorrentistaPF.Cpf} | Saldo: R$ {Saldo}";
    }
    public string imprimirDadosPJ()
    {
        if(!(Correntista is PessoaJuridicaEx)) throw new Exception("Operação inválida");

        PessoaJuridicaEx CorrentistaPJ = Correntista as PessoaJuridicaEx;
        return $"Número da conta: {numeroDaConta} | Nome: {CorrentistaPJ.nome} | Sobrenome: {CorrentistaPJ.sobrenome} | CNPJ: {CorrentistaPJ.Cnpj} | Crédito: {CorrentistaPJ.credito} | Saldo: R$ {Saldo}";
    }
}