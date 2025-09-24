using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ControlMenu
    {
        //Declarar a Variável que representará as classes control
        private ControlLivro controleLivro;
        private ControlAutor controleAutor;
        private ControlCategoria controleCategoria;
        private int opcaoPrincipal;
        private int opcaoGeral;

        public ControlMenu()
        {
            controleLivro     = new ControlLivro();
            controleAutor     = new ControlAutor();
            controleCategoria = new ControlCategoria();
        }//fim do construtor

        //Métodos GETs e SETs
        public int ModificarOpcaoPrincipal
        {
            get { return opcaoPrincipal; }
            set { opcaoPrincipal = value; }
        }//fim do método

        public int ModificarOpcaoGeral
        {
            get { return opcaoGeral;}
            set { opcaoGeral = value; }
        }//fim do getSet

        //Mostrar Menu
        public void MostrarMenu()
        {
            Console.Clear();//Limpar o console
            Console.WriteLine("\n\n Menu Principal \n\n"        + 
                              "Escolha uma das opções abaixo: " +
                              "\n0. Sair"                       +
                              "\n1. Livro"                      +
                              "\n2. Autor"                      +
                              "\n3. Categoria");
            ModificarOpcaoPrincipal = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void ExecutarMenuPrincipal()
        {
            //Mostrar Menu - Chamar o método do menu
            do
            {
                MostrarMenu();
                switch (ModificarOpcaoPrincipal)
                {
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;//fim de cada caso
                    case 1:
                        Console.WriteLine("Livro");
                        ExecutarLivro();
                        break;
                    case 2:
                        Console.WriteLine("Autor");
                        ExecutarAutor();
                        break;
                    case 3:
                        Console.WriteLine("Categoria");
                        ExecutarCategoria();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }//fim do escolha
            } while (ModificarOpcaoPrincipal != 0);//fim do while
        }//fim do executar

        public void MenuGeral()
        {
            Console.WriteLine("\n\nEscolha uma das ações do CRUD" +
                             "\n0. Voltar ao menu anterior" +
                             "\n1. Cadastrar" +
                             "\n2. Consultar" +
                             "\n3. Consultar por Código" +
                             "\n4. Atualizar" +
                             "\n5. Excluir");
            ModificarOpcaoGeral = Convert.ToInt32(Console.ReadLine());//Coleto a opção do usuário
        }//fim do método

        public void ExecutarLivro()
        {
            do
            {
                Console.WriteLine("\n\nMENU LIVRO\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");
                        //Pegar os dados do livro
                        Console.WriteLine("\nInforme o ISBN do livro: ");
                        long ISBN = Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("\nInforme o Título do livro: ");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("\nInforme o Ano de Lançamento do Livro: ");
                        DateTime ano = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme a Editora do Livro: ");
                        string editora = Console.ReadLine();

                        Console.WriteLine("\nInforme a Categoria do Livro: ");
                        int categoriaCodigo = Convert.ToInt32(Console.ReadLine());
                        //Chamar o livro
                        this.controleLivro = new ControlLivro(ISBN, titulo, ano, editora, categoriaCodigo);
                        //Finaliza
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados do livro
                        this.controleLivro.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("Consultar Categoria por Código");
                        this.controleCategoria.Imprimir();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar");
                        Console.WriteLine("\nInforme qual dos campos abaixo você deseja atualizar: " +
                                          "\n1. Título" +
                                          "\n2. Ano" +
                                          "\n3. Editora" +
                                          "\n4. Categoria");
                        int opcao = Convert.ToInt32(Console.ReadLine());
                        //Coletando o dado para atualizar
                        Console.WriteLine("Informe o novo dado: ");
                        string dado = Console.ReadLine();
                        //Atualizando...
                        this.controleLivro.Atualizar(opcao, dado);
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleLivro = new ControlLivro();//Zerando todos os dados - Exclui
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarLivro

        public void ExecutarAutor()
        {
            do
            {
                Console.WriteLine("\n\nMENU AUTOR\n\n");
                MenuGeral();//Mostrar o menu
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("Cadastrar Autor");
                        //Coletando os dados
                        Console.WriteLine("Informe o nome do autor: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe a sua nacionalidade: ");
                        string nacionalidade = Console.ReadLine();
                        //Criar o construtor
                        this.controleAutor = new ControlAutor(nome, nacionalidade);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar Autor");
                        this.controleAutor.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nAtualizar");
                        Console.WriteLine("\nInforme o que deseja atualizar: " +
                                          "\n1. Nome" +
                                          "\n2. Nacionalidade");
                        int opcao = Convert.ToInt32(Console.ReadLine());
                        //Pegar o novo dado
                        Console.WriteLine("Informe o novo dado: ");
                        string dado = Console.ReadLine();
                        //Executar a operação
                        this.controleAutor.Atualizar(opcao, dado);
                        break;
                    case 4:
                        Console.WriteLine("\nExcluir!");
                        this.controleAutor = new ControlAutor();
                        Console.WriteLine("\nExcluido!!!!!");
                        break;
                    default:
                        Console.WriteLine("Opção escolhida não existe!");
                        break;
                }//fim do escolha
            } while (ModificarOpcaoGeral != 0);//fim da repetição
        }//fim do método

        //Categoria
        public void ExecutarCategoria()
        {
            do
            {
                Console.WriteLine("\n\nMenu Categoria");
                MenuGeral();
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("Cadastrar Categoria");
                        //Solicitar os dados
                        Console.WriteLine("Informe a descrição: ");
                        string descricao = Console.ReadLine();
                        //Criar a estrutura
                        this.controleCategoria = new ControlCategoria(descricao);
              
                        break;
                    case 2:
                        Console.WriteLine("Consultar Categoria");
                        this.controleCategoria.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("Consultar Categoria por Código");
                        this.controleCategoria.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar Categoria");
                  
                        //Executando o método
                        this.controleCategoria.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("Excluir Categoria");
                        //Executando o método
                        this.controleCategoria.Excluir();
                        break;
                    default:
                        Console.WriteLine("Código informado não é válido!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);
        }//fim do método
    }//fim da classe
}//fim do Projeto
