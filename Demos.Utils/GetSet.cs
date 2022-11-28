using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.Utils
{

    //var joka = new Jacare();
    //joka.Nome = "Joka";
    public class Jacare
    {
        private int _idade;
        private string _nome;

        //criar getter
        public int GetIdade() => _idade;

        //criar setter
        public void SetIdade(int idade) => _idade = idade;


        //forma implícita de criar 
        public string Nome
        {
            get { return _nome.ToUpper(); }
            set { _nome = value; }
        }

        public int Idade
        {
            get { return _idade; }
            set
            {
                if (value < 18)
                    throw new Exception("Idade +18");
                //palavra reservada value, que permite aceder ao valor que foi atríbuido
                _idade = value;
            }
        }
    }
}
