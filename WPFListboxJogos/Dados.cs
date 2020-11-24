
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;


namespace WPFListboxJogos
{
    static class Dados
    {
        static public string conString = "server=cstrix.com; database=esffpap_exemplo; uid=esffpap_lp; pwd=[}4=4(8AFl$l;";
        static public MySqlConnection conn = null;

        static private void AbrirLigacao()
        {
            // try
            // {
            conn = new MySqlConnection(conString);
            conn.Open();
            // Toast.MakeText(Application.Context, "Ligação estabelecida com sucesso", ToastLength.Long).Show();

            // }
            // catch (Exception ex)
            // {

            // Toast.MakeText(Application.Context, "Erro na ligação" + ex, ToastLength.Long).Show();
            //}
        }

        static public List<Jogo> Jogos()
        {
            AbrirLigacao();

            List<Jogo> listaJogos = new List<Jogo>();

            var querysql = "SELECT * FROM Jogo";

            MySqlDataReader leitor = null;
            MySqlCommand cmd = new MySqlCommand(querysql, conn);

            leitor = cmd.ExecuteReader();

            // MessageBox.Show(leitor.FieldCount + " z"+ leitor.HasRows.ToString() + " "+cmd.ToString());
            while (leitor.Read())
            {
                //MessageBox.Show("as");
                Jogo jogo = new Jogo(leitor["ID"].ToString(), leitor["titulo"].ToString(), leitor["preco"].ToString(), leitor["capa"].ToString());
                //Jogo jogo = new Jogo(12, "12", 12);

                listaJogos.Add(jogo);


            }
            FecharLigacao();
            return listaJogos;

        }

        static private void FecharLigacao()
        {
            try
            {

                conn.Close();
            }
            catch (Exception ex)
            {

                //Toast.MakeText(Application.Context, "Erro na ligação" + ex, ToastLength.Long).Show();
            }
        }
        /*
        static public Utilizador Login(string username, string password)
        {
            AbrirLigacao();
            Utilizador utilizador;
            var querysql = "SELECT * FROM utilizador WHERE username=@user AND password = @pass";
            MySqlDataReader leitor = null;
            MySqlCommand cmd = new MySqlCommand(querysql, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            leitor = cmd.ExecuteReader();
            //MessageBox.Show(leitor.FieldCount + " z"+ leitor.HasRows.ToString() + " "+cmd.ToString());
            if (leitor.HasRows)
            {
                leitor.Read();
                utilizador = new Utilizador(Convert.ToInt32(leitor["ID"]), leitor["nome"].ToString(), leitor["username"].ToString(), leitor["password"].ToString(), Convert.ToInt32(leitor["tipo"]));
                FecharLigacao();
                return utilizador;
                                  
            }
            FecharLigacao();
            return null;
        }*/
    }
}