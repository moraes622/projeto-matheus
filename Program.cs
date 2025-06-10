class Program
{
    static void Main()
    {
        var biblioteca = new Biblioteca();
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n--- Menu Biblioteca ---");
            Console.WriteLine("1. Cadastrar Usuário");
            Console.WriteLine("2. Listar Livros");
            Console.WriteLine("3. Emprestar Livro");
            Console.WriteLine("4. Devolver Livro");
            Console.WriteLine("5. Relatórios");
            Console.WriteLine("6. Cadastrar Livro");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string? opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("ID do usuário: ");
                    if (int.TryParse(Console.ReadLine(), out int idUsuario))
                    {
                        Console.Write("Nome do usuário: ");
                        string? nome = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nome))
                        {
                            biblioteca.CadastrarUsuario(idUsuario, nome);
                        }
                    }
                    break;

                case "2":
                    biblioteca.ListarLivros();
                    break;

                case "3":
                    Console.Write("ID do usuário: ");
                    if (int.TryParse(Console.ReadLine(), out int idEmp))
                    {
                        Console.Write("ISBN do livro: ");
                        string? isbnEmp = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(isbnEmp))
                        {
                            biblioteca.EmprestarLivro(idEmp, isbnEmp);
                        }
                    }
                    break;

                case "4":
                    Console.Write("ID do usuário: ");
                    if (int.TryParse(Console.ReadLine(), out int idDev))
                    {
                        Console.Write("ISBN do livro: ");
                        string? isbnDev = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(isbnDev))
                        {
                            biblioteca.DevolverLivro(idDev, isbnDev);
                        }
                    }
                    break;

                case "5":
                    biblioteca.ExibirRelatorios();
                    break;

                case "6":
                    Console.Write("Título do livro: ");
                    string? titulo = Console.ReadLine();

                    Console.Write("Autor do livro: ");
                    string? autor = Console.ReadLine();

                    Console.Write("ISBN do livro: ");
                    string? isbn = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(autor) && !string.IsNullOrWhiteSpace(isbn))
                    {
                        biblioteca.CadastrarLivro(titulo, autor, isbn);
                    }
                    else
                    {
                        Console.WriteLine("Dados inválidos. O livro não foi cadastrado.");
                    }
                    break;

                case "0":
                    sair = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
