class JogoDoAdivinha{
    public int SecretNumber { get; set; }
    public int GameAttempts { get; set; }

    public JogoDoAdivinha(int secretNumber, int gameAttempts)
    {
        SecretNumber = secretNumber;
        GameAttempts = gameAttempts;
    }
    public bool isUserWinner(string playerAttempt) => playerAttempt == this.SecretNumber.ToString();

    public string giveHint(int attemptsLeft)
    {
        string hint = null;
        if (attemptsLeft == 3)
        {
            hint = "\nDica -> Chuta um número entre 1 e 10";
        }
        if (attemptsLeft == 8)
        {
            hint = "\nDica -> Chuta um número entre 1 e 100";
        }
        if (attemptsLeft == 13)
        {
            hint = "\nDica -> Chuta um número entre 1 e 1000";
        }
        return hint;
    }
}