using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Gravar_Arq_TXT_01
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Cadastro { get; set; }
        public float Preco { get; set; }

        public Produto(int Id, string Descricao, DateTime Cadastro, float Preco)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Cadastro = Cadastro;
            this.Preco = Preco;
        }

        public Produto()
        {
            this.Id = 0;
            this.Descricao = "";
            this.Cadastro = DateTime.Now;
            this.Preco = 0;
        }

        public override string ToString()
        {
            return "Dados do Produto:\n"+"Id:\t\t"+Id+"\nDescricao:\t"+Descricao+
                "\nData Cadastro:\t"+Cadastro.ToString("dd/MM/yyyy")+"\nPreço:\t\t"+Preco;
        }

        public string getData()
        {
            return Id + ";" + Descricao + ";" + Cadastro.ToString("dd/MM/yyyy") + ";" + Preco.ToString("0.00")+";";
        }
    }
}
