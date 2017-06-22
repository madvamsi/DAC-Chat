using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using chat_client_ui.ServiceReference1;
using System.ServiceModel;
using System.Threading;
using System.Windows.Threading;

namespace chat_client_ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IService1Callback
    {
        static string stto;
        DispatcherTimer timer = new DispatcherTimer();
        public void servertoclient(string mess)
        {
            listBox2.Items.Add(mess);
            listBox2.ScrollIntoView(mess);
        }
        //string usersList;
        public void OnlineUsers(string[] userList)
        {
            List<string> list = new List<string>(userList);
            list.Remove(textBox1.Text);
           listBox1.ItemsSource = list;
        }

        InstanceContext cntxt;
        Service1Client proxy;
        public MainWindow()
        {
             cntxt = new InstanceContext(this);
             proxy = new Service1Client(cntxt);
            InitializeComponent();
        }

        public void abc(string mes)
        {
            listBox2.Items.Add(mes);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            if (button1.Content.ToString() == "Connect")
            {
               
                    button1.Content = "Disconnect";
                    textBox1.IsEnabled = false;
                    proxy.Duplexcall(textBox1.Text);
         
            }
            else
            {
                button1.Content = "Connect";
                textBox1.IsEnabled = true; 
                proxy.disconnect(textBox1.Text);
                listBox1.ItemsSource = null;
               
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {  
            string touser;
            string tomess;
            touser = listBox1.SelectedItem.ToString();
            tomess = textBox2.Text;
            proxy.sendmsg(touser, textBox1.Text + ": " + tomess);
            textBox2.Clear();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // stto = listBox1.SelectedItem.ToString();
        }

        private void MyUnLoad(object sender, RoutedEventArgs e)
        {
            proxy.disconnect(textBox1.Text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            proxy.disconnect(textBox1.Text);
        }
    }
}
