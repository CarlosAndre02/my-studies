using System;
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            banco.main();

            // Testes - cpf
            // 824.852.150-81 válido
            // 727.095.620-06 válido
            // 154.487.151-01 errado

            // // Teste - cnpj
            // 22.742.600/0001-68 válido
            // 02.287.062/0001-51 válido
            // 45.001.154/1547-99 errado

        }
    }