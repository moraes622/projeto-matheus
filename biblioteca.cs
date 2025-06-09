public class Biblioteca
{
    private List<Usuario> usuarios = new();
    private List<Livro> livros = new();

    public Biblioteca()
    {
        AdicionarLivrosPadrao();
    }

    private void AdicionarLivrosPadrao()
    {
   livros.AddRange(new List<Livro>
{
    new Livro("Dom Casmurro", "Machado de Assis", "001"),
    new Livro("Memórias Póstumas de Brás Cubas", "Machado de Assis", "002"),
    new Livro("O Cortiço", "Aluísio Azevedo", "003"),
    new Livro("Iracema", "José de Alencar", "004"),
    new Livro("A Moreninha", "Joaquim Manuel de Macedo", "005"),
    new Livro("Capitães da Areia", "Jorge Amado", "006"),
    new Livro("A Hora da Estrela", "Clarice Lispector", "007"),
    new Livro("Grande Sertão: Veredas", "João Guimarães Rosa", "008"),
    new Livro("Auto da Compadecida", "Ariano Suassuna", "009"),
    new Livro("Senhora", "José de Alencar", "010"),
    new Livro("O Guarani", "José de Alencar", "011")
});

    }

    public void CadastrarUsuario(int id, string nome)
    {
        if (!usuarios.Any(u => u.Id == id))
        {
            usuarios.Add(new Usuario { Id = id, Nome = nome });
            Console.WriteLine("Usuário cadastrado com sucesso.");
        }
        else
        {
            Console.WriteLine("Usuário já existe.");
        }
    }

    public void ListarLivros()
    {
        foreach (var livro in livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, ISBN: {livro.Isbn}, Disponível: {livro.Disponivel}");
        }
    }

    public void EmprestarLivro(int idUsuario, string isbn)
    {
        var usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);
        var livro = livros.FirstOrDefault(l => l.Isbn == isbn && l.Disponivel);

        if (usuario != null && livro != null)
        {
            livro.Disponivel = false;
            usuario.Emprestimos.Add(new Emprestimo(livro));
            Console.WriteLine("Livro emprestado com sucesso.");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado ou livro indisponível.");
        }
    }

    public void DevolverLivro(int idUsuario, string isbn)
    {
        var usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);

        if (usuario != null)
        {
            var emprestimo = usuario.Emprestimos.FirstOrDefault(e => e.Livro.Isbn == isbn && e.DataDevolucao == null);
            if (emprestimo != null)
            {
                emprestimo.Devolver();
                Console.WriteLine("Livro devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("Empréstimo não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }

    public void ExibirRelatorios()
    {
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"\nUsuário: {usuario.Nome}");
            foreach (var emprestimo in usuario.Emprestimos)
            {
                var status = emprestimo.DataDevolucao.HasValue ? "Devolvido" : "Em aberto";
                Console.WriteLine($" - {emprestimo.Livro.Titulo} ({status})");
            }
        }
    }
}