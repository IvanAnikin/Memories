using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Memories
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            SqliteConnection db_connection;
            db_connection = new SqliteConnection("Data Source=MyDatabase.sqlite;");
            db_connection.Open();

            string sql_command = "select * from testMemories order by rowid asc limit 1";
            SqliteCommand command = new SqliteCommand(sql_command, db_connection);
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();
            
            TextBox_1.Text = reader["name"].ToString();

            db_connection.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void List_classic_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MemoriesList_classic));
        }

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Map));
        }
    }
}
