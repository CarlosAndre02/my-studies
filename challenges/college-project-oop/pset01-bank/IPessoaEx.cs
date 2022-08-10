interface IPessoaEx
{
    string nome { get; set; }
    string sobrenome { get; set; }

    bool validarDados();
}