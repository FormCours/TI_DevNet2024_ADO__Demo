using Microsoft.Data.SqlClient;

// Avant de commencer → Installer le bibliotheque ADO pour le type de server ciblé !
// Package NuGet : Microsoft.Data.SqlClient


const string connectionString = @"Data Source=DESKTOP-QLR948L;Initial Catalog=DemoADO_Book;Trusted_Connection=True;Trust Server Certificate=True";


SqlConnection connection = new SqlConnection(connectionString);
Console.WriteLine($"Connexion à la DB : {connection.State}");

// Ouverture de la connexion vers la DB
connection.Open();
Console.WriteLine($"Connexion à la DB : {connection.State}");


// Fermeture de la connexion vers la DB
connection.Close();
Console.WriteLine($"Connexion à la DB : {connection.State}");

