using System;
using System.Collections; // IList
using System.Collections.Generic; //List
using System.IO; //Utilizado para Manipulação de Arquivos

namespace Ex_Gravar_Arq_TXT_01
{
    internal class Program
    {
        static Produto Ler_Cadastro_Produto()
        {
            Console.Clear();
            Console.WriteLine(">>> Cadastro do Produto <<<");
            Console.Write("Informe o ID: ");
            int Id = int.Parse(Console.ReadLine());
            Console.Write("Informe a Descrição do Produto: ");
            string Descricao = Console.ReadLine();
            Console.Write("Informe o Preço de Venda: ");
            float Preco = float.Parse(Console.ReadLine());
            DateTime Cadastro = System.DateTime.Now;

            return new Produto(Id, Descricao, Cadastro, Preco);
        }

        static void Menu()
        {
            Produto produto = new Produto(); //Nesse exemplo será manipulado um objeto Produto por vez
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine(">>> MENU <<<");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Gravar Arquivo");
                Console.WriteLine("3 - Ler Arquivo");
                Console.WriteLine("4 - Imprimir Produto");
                Console.WriteLine("5 - Ler Produto do Arquivo");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        produto = Ler_Cadastro_Produto();
                        break;
                    case 2:
                        Gravar_Arquivo(produto);
                        break;
                    case 3:
                        Ler_Arquivo();
                        break;
                    case 4:
                        Imprimir_Dados(produto);
                        Pausa();
                        break;
                    case 5:
                        produto = Ler_Produto_Arquivo(); //Retorna o Produto que localizar no arquivo. No nosso caso terá apenas 1.
                        Imprimir_Dados(produto);
                        break;
                }

            } while (opc != 0);
            Console.WriteLine(">>> FIM <<<");
        }

        private static Produto Ler_Produto_Arquivo()
        {
            //Outra forma de manipular dados de um arquivo
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\5by5\Test.txt"); //faz a leitura de todas as linhas de um arquivo

                string[] informacoes; //Controlará as informações de um produto

                List<string> dados = new List<string>(); //será utilizada para guardar os dados para criar um produto

                foreach (string line in lines) // Para cada uma das linhas recuperadas... (No nosso caso será apenas uma única linha)
                {
                    informacoes = line.Split(';');//divide os dados da linha e armazena em posições diferentes do vetor.  Utiliza o caracter delimitador como referência

                    if (informacoes.Length == 4) //Tamanho 4 devido à quantidade de informações que estruturam um Produto
                    {
                        for (int i = 0; i < informacoes.Length; i++)
                            dados.Add(informacoes[i]); //Para cada dado do Produto, ele percorre o vetor e adiciona na LIST(DADOS)
                    }
                    else
                        return new Produto(); //Se não encontrar um Produto no arquivo, retornará um Produto Padrão (VAZIO).
                }
                return new Produto(int.Parse(dados[0].ToString()), dados[1].ToString(), DateTime.Parse(dados[2].ToString()), float.Parse(dados[3].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }
            Pausa();
            return new Produto(); //Se chegar até aqui...deu algum problema...
        }

        private static void Imprimir_Dados(Produto produto)
        {
            Console.Clear();
            Console.WriteLine(">>> Dados do Produto <<<");
            Console.WriteLine(produto.ToString());
            return;
        }

        static void Gravar_Arquivo(Produto produto)
        {
            Console.WriteLine("Iniciando a Gravação de Dados...");
            try
            {
                StreamWriter sw = new StreamWriter("c:\\5by5\\Test.txt");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                //sw.WriteLine("Treinamento de C#");  //Escreve uma linha no Arquivo
                //sw.WriteLine("maria;araraquara;190;contato;"); //Exemplo de escrita - formato da escrita será de acordo com a necessidade do projeto
                sw.WriteLine(produto.getData());
                sw.Close();  // Comando para Fechar o Arquivo
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }
            Console.WriteLine("FIM DA GRAVAÇÃO");
            Pausa();
            return;
        }

        static void Pausa()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        static void Ler_Arquivo()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\5by5\\Test.txt");//Instancia um Objeto StreamReader (Classe de Manipulação de Leitura de Arquivos)
                line = sr.ReadLine(); //Faz a Leitura de uma linha do arquivo e atribui a string line
                while (line != null)// Laço de Repetição para fazer a leitura de linhas do arquivo até o EOF (End Of File - Fim do Arquivo)
                {
                    Console.WriteLine(line);//Imprime o retorno do arquivo no Console
                    line = sr.ReadLine(); //Faz a Leitura de linha do arquivo e atribui a string line
                }
                sr.Close();//Fecha o Arquivo
                Console.WriteLine("Fim da Leitura do Arquivo");
                Console.ReadLine();
            }
            catch (Exception e) // Tratamento de erro na abertura do arquivo
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comando - Sem Erros");
            }
            Pausa();
            return;
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
