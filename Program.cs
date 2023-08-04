using labirinto.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[,] labirinto = new int[,]
{
                { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 2, 1, 1, 0, 0, 0, 0, 0, 0 }
};
                int linha = 0;
                int coluna = 0;
                int soma = 1;

                var parar = true;
                List<Positions> list_positions_ja_passou = new List<Positions>();
                List<Divisions> divisions = new List<Divisions>();

                List<List<Caminhos>> CaminhosListList = new List<List<Caminhos>>();
                int linha_antigo = 0;
                int coluna_antigo = 0;

                int atual = 0;
                Console.WriteLine("0,0");
                for (int caminho = 0; caminho < labirinto.Length; caminho++)
                {
                    parar = true;
                    List<Caminhos> CaminhoList = new List<Caminhos>();
                    Console.WriteLine("Caminho " + caminho + 1 + " \n -----------------------------");

                    while (parar == true)
                    {
                        bool validate_coluna_menos = false;
                        bool validate_coluna_mais = false;
                        bool validate_linha_mais = false;

                        List<bool> bools = new List<bool>() { false, false, false };
                        int contador_de_true = 0;

                        list_positions_ja_passou.Add(new Positions() { collumn = coluna, row = linha });
                        CaminhoList.Add(new Caminhos() { collumnCaminhos = coluna, rowCaminhos = linha });

                        if (labirinto[linha, coluna] == 1)
                        {
                            try
                            {
                                if (labirinto[linha, coluna - 1] == 1 && !list_positions_ja_passou.Any(position => position.collumn == coluna - 1 && position.row == linha)) //validate_coluna_menos
                                {
                                    bools[0] = true;
                                }
                            }
                            catch { }
                            try
                            {
                                if (labirinto[linha, coluna + 1] == 1 && !list_positions_ja_passou.Any(position => position.collumn == coluna + 1 && position.row == linha)) //validate_coluna_mais
                                {
                                    bools[1] = true;
                                }
                            }
                            catch { }
                            try
                            {
                                if (labirinto[linha + 1, coluna] == 1 && !list_positions_ja_passou.Any(position => position.collumn == coluna && position.row == linha + 1)) //validate_linha_mais
                                {
                                    bools[2] = true;
                                }
                            }
                            catch { }

                            for (int j = 0; j < bools.Count(); j++)
                            {
                                if (bools[j] == true)
                                {
                                    contador_de_true++;
                                }
                            }

                            //printa as coordenadas e adiciona as linhas e colunas
                            if (contador_de_true == 1)
                            {
                                if ((labirinto[linha, coluna] == 1))
                                {
                                    try
                                    {
                                        if ((labirinto[linha, coluna - 1] == 1 && !list_positions_ja_passou.Any(position => position.collumn == coluna - 1 && position.row == linha)))
                                        {
                                            linha_antigo = linha;
                                            coluna_antigo = coluna;
                                            coluna--;
                                            Console.WriteLine(linha + "," + coluna);
                                            continue;
                                        }
                                    }
                                    catch { };
                                    try
                                    {
                                        if (labirinto[linha, coluna + 1] == 1 && !list_positions_ja_passou.Any(position => position.collumn == coluna + 1 && position.row == linha))
                                        {
                                            linha_antigo = linha;
                                            coluna_antigo = coluna;
                                            coluna++;
                                            Console.WriteLine(linha + "," + coluna);
                                            continue;
                                        }
                                    }
                                    catch { };
                                    try
                                    {
                                        if (labirinto[linha + 1, coluna] == 1 && !list_positions_ja_passou.Any(position => position.collumn == coluna && position.row == linha + 1))
                                        {
                                            linha_antigo = linha;
                                            coluna_antigo = coluna;
                                            linha++;
                                            Console.WriteLine(linha + "," + coluna);
                                            continue;
                                        }
                                    }
                                    catch { };
                                }
                            }
                            if (contador_de_true == 2)
                            {
                                if (labirinto[linha, coluna] == 1)
                                {
                                    try
                                    {
                                        if ((labirinto[linha, coluna - 1] == 1) && (coluna - 1 != coluna_antigo))
                                        {
                                            linha_antigo = linha;
                                            coluna_antigo = coluna;
                                            coluna--;
                                            Console.WriteLine(linha + "," + coluna);
                                            validate_coluna_menos = true;
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        if ((labirinto[linha, coluna + 1] == 1) && (coluna + 1 != coluna_antigo))
                                        {
                                            if (!validate_coluna_menos)
                                            {
                                                linha_antigo = linha;
                                                coluna_antigo = coluna;
                                                coluna++;
                                                Console.WriteLine(linha + "," + coluna);
                                                validate_coluna_mais = true;
                                            }
                                            else
                                            {
                                                divisions.Add(new Divisions() { collumn = coluna, row = linha });
                                            }
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        if ((labirinto[linha + 1, coluna] == 1) && (linha + 1 != linha_antigo))
                                        {
                                            if (!validate_coluna_mais)
                                            {
                                                linha_antigo = linha;
                                                coluna_antigo = coluna;
                                                linha++;
                                                Console.WriteLine(linha + "," + coluna);
                                            }
                                            else
                                            {
                                                divisions.Add(new Divisions() { collumn = coluna, row = linha });
                                            }
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        try
                        {
                            if ((labirinto[linha, coluna + 1] == 2) || (labirinto[linha, coluna - 1] == 2) || (labirinto[linha - 1, coluna] == 2))
                            {
                                atual = 2;
                                Console.WriteLine("acabou");
                                parar = false;
                               
                            }
                        }
                        catch { }
                    }
                    CaminhosListList.Add(CaminhoList); //collumnCaminhos = coluna, rowCaminhos = linha 
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        public void validate_coluna_menos()
        {

        }
        public void validate_coluna_mais()
        {

        }
        public void validate_linha_mais()
        {

        }
    }
}

