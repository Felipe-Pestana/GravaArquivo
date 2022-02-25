using System;
using System.IO; //Utilizado para Manipulação de Arquivos

namespace Ex_Gravar_Arq_TXT_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamWriter sw = new StreamWriter("c:\\5by5\\Test.txt");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                //sw.WriteLine("Treinamento de C#");  //Escreve uma linha no Arquivo
                //sw.WriteLine("Escrita de Arquivos com StreamWriter");
                sw.WriteLine("maria;araraquara;190;contato;");
                sw.WriteLine("fabio;araraquara;911;recado;");
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
        }
    }
}
