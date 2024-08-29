using Microsoft.Data.SqlClient;
using System.Data;

// Avant de commencer → Installer le bibliotheque ADO pour le type de server ciblé !
// Package NuGet : Microsoft.Data.SqlClient


const string connectionString = @"Data Source=TFNSDOT0500A;Initial Catalog=Demo_ADO;Trusted_Connection=True;Trust Server Certificate=True";

// Demo 01 - Connection à la DB
// ****************************
{
    SqlConnection connection = new SqlConnection(connectionString);
    Console.WriteLine($"Connexion à la DB : {connection.State}");

    // Ouverture de la connexion vers la DB
    connection.Open();
    Console.WriteLine($"Connexion à la DB : {connection.State}");

    // Fermeture de la connexion vers la DB
    connection.Close();
    Console.WriteLine($"Connexion à la DB : {connection.State}");
}
Console.WriteLine();


// Demo 02 - Obtenir des données sur la DB (Mode connecté)
// *******************************************************
// - Obtenir le nombre d'auteur dans la table « Author »
{
    // Nouvelle instance de "SqlConnection" pour exploiter la DB
    // → Utilisation d'un using pour libérer les ressources
    using(SqlConnection connection = new SqlConnection(connectionString))
    {
        // Instance d'une command lié à la connexion
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) FROM [Author]";

            // Ouverture de la connexion avant d'executer la requete !
            connection.Open();

            // Execution de la requete -> Type de resultat : Une seul valeur "Scalaire"
            int nbAutor = (int)command.ExecuteScalar();

            // Affichage du resultat
            Console.WriteLine($"Le nombre d'auteur est de {nbAutor}");
        }

        // → Si la connexion n'a pas été fermé, la fin du "using" s'en occupe
    }
}

// - Obtenir la liste des auteurs
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Firstname, Lastname, BirthDate FROM Author";

            // Ouverture de la connexion
            connection.Open();

            // Execution de la requete -> Type de resultat : Une table
            using (var reader = command.ExecuteReader())
            {
                // Traitement de chaque ligne du resultat !
                while (reader.Read())
                {
                    // Lecture via l'index dans les resultats
                    // → Attention, l'ordre des colonnes ne doit pas être modifié !!!
                    string firstname1 = reader.GetString(0);
                    string lastname1 = (string)reader[1];
                    DateTime birtdate1 = Convert.ToDateTime(reader[2]);

                    // Lecture via le nom de la colonne des resultats
                    string firstname2 = reader.GetString(reader.GetOrdinal("Firstname"));
                    string lastname2 = (string)reader["Lastname"];
                    DateTime birtdate2 = Convert.ToDateTime(reader["BirthDate"]);

                    Console.WriteLine($" - {firstname2} {lastname2} ({birtdate2.ToShortDateString()})");
                }
            }

            // Fermeture de la connexion
            connection.Close();
        }
    }
}
Console.WriteLine();


// Demo 03 - Modifer des données sur la DB (Mode connecté)
// *******************************************************


// - Ajouter un nouveau Genre (Avec un faille de securité (╯°□°）╯︵ ┻━┻)
/*
using (SqlConnection connection = new SqlConnection(connectionString))
{
    Console.Write("Ajouter un nouveau genre : \n>");
    string genreToAdd = Console.ReadLine()!;


    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandType = CommandType.Text;
        command.CommandText = $"INSERT INTO [Genre](Name) VALUES ('{genreToAdd}')";
        // Faille de securité -> Injection SQL
        // - Valeur Ok : Sport
        // - Injection : test'); DELETE FROM [Author_Book]; --
            
        connection.Open();
        int nbRowAdd = command.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine($"Nombre de ligne ajouter : {nbRowAdd}");
    }
}
*/


// - Ajouter un nouveau Genre (Sans un faille de securité ^_^)
using (SqlConnection connection = new SqlConnection(connectionString))
{
    Console.Write("Ajouter un nouveau genre : \n>");
    string genreToAdd = Console.ReadLine()!;

    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandType = CommandType.Text;
        command.CommandText = $"INSERT INTO [Genre](Name) VALUES (@GenreName)";

        command.Parameters.AddWithValue("@GenreName", genreToAdd);

        connection.Open();
        int nbRowAdd = command.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine($"Nombre de ligne ajouter : {nbRowAdd}");
    }
}

