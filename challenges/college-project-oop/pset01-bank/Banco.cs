using System;
using System.Collections.Generic;

class Banco {
    public List<ContaCorrenteEx> Contas; 
    private static int totalContas = 0; 

    public Banco() {
        Contas = new List<ContaCorrenteEx>();
    }

    public void main() {
        System.Console.WriteLine("Bem vindo ao Banco UVV!");
        while (true) {
            System.Console.WriteLine("\n1 - Criar Conta\n2 - Buscar conta\n3 - Apagar conta\n4 - Sair");
            System.Console.WriteLine("Digite o número da operação que deseja realizar: ");
            int op = Int32.Parse(Console.ReadLine());

            switch(op) {
                case 1: CriarConta(); break;
                case 2: BuscarConta(); break;
                case 3: ApagarConta(); break;
            }
            if(op == 4) break;
        }
    }

    public void CriarConta() {
        System.Console.WriteLine("Deseja criar conta como pessoa PF ou PJ");
        string tipoCorrentista = Console.ReadLine().ToLower().Trim();

        if(tipoCorrentista == "pf") {
            while(true) {
                try {
                    System.Console.WriteLine("\nNome: ");
                    string nome = Console.ReadLine();

                    System.Console.WriteLine("Sobrenome: ");
                    string sobrenome = Console.ReadLine();

                    System.Console.WriteLine("Cpf: ");
                    string cpf = Console.ReadLine();

                    System.Console.WriteLine("Saldo Inicial: ");
                    string saldoInicial = Console.ReadLine();

                    IPessoaEx pessoaF = new IPessoaFisicaEx(nome, sobrenome, cpf);
                    if(pessoaF.validarDados()) {
                        ContaCorrenteEx cc = new ContaCorrenteEx(Int32.Parse(saldoInicial));
                        cc.adicionarCorrentista(pessoaF);
                        cc.numeroDaConta = ++totalContas;
                        System.Console.WriteLine($"Criado com sucesso. O número da sua conta é {cc.numeroDaConta}");
                        Contas.Add(cc);
                        break;
                    }
                } catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                }
            }
        } 
        else if(tipoCorrentista == "pj") {
            while(true) {
                try {
                    System.Console.WriteLine("\nNome: ");
                    string nome = Console.ReadLine();

                    System.Console.WriteLine("Sobrenome: ");
                    string sobrenome = Console.ReadLine();

                    System.Console.WriteLine("Cnpj: ");
                    string cnpj = Console.ReadLine();

                    System.Console.WriteLine("Credito: ");
                    string credito = Console.ReadLine();

                    System.Console.WriteLine("Saldo Inicial: ");
                    string saldoInicial = Console.ReadLine();

                    IPessoaEx pessoaJ = new PessoaJuridicaEx(nome, sobrenome, cnpj, Int32.Parse(credito));
                    if(pessoaJ.validarDados()) {
                        ContaCorrenteEx cc = new ContaCorrenteEx(Int32.Parse(saldoInicial));
                        cc.adicionarCorrentista(pessoaJ);
                        cc.numeroDaConta = ++totalContas;
                        System.Console.WriteLine($"Criado com sucesso. O número da sua conta é {cc.numeroDaConta}");
                        Contas.Add(cc);
                        break;
                    }
                } catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                }
            }
        } 
        else {
            System.Console.WriteLine("Entrada inválida");
        }
    }

    public void BuscarConta() {
        System.Console.WriteLine("Para buscar, digite o número da conta: ");
        int numeroConta;
        Int32.TryParse(Console.ReadLine(), out numeroConta);
        if(numeroConta == 0) {
          Console.WriteLine("Entra inválida");
          return;
        }

        bool contaFoiEncontrada = false;
        foreach (ContaCorrenteEx cc in Contas) {
            if(cc.numeroDaConta == numeroConta) {
                if(cc.Correntista is IPessoaFisicaEx) {
                    System.Console.WriteLine(cc.imprimirDadosPF());
                }
                else {
                    System.Console.WriteLine(cc.imprimirDadosPJ());
                }
                contaFoiEncontrada = true;
            }
        }

        if(!contaFoiEncontrada) { 
            System.Console.WriteLine("Conta não foi encontrada");
        }
    }

    public void ApagarConta() {
        System.Console.WriteLine("Para apagar, digite o número da conta: ");
        int numeroConta;
        Int32.TryParse(Console.ReadLine(), out numeroConta);
        if(numeroConta == 0) {
          Console.WriteLine("Entrada inválida");
          return;
        }

        ContaCorrenteEx conta = null;
        foreach (ContaCorrenteEx cc in Contas) {
            if(cc.numeroDaConta == numeroConta) conta = cc;
        }

        if(conta != null) {
            Contas.Remove(conta);
            System.Console.WriteLine("Conta removida com sucesso");
        } else { 
            System.Console.WriteLine("Conta não foi encontrada");
        }
    }
}