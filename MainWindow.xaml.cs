using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace сетка
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] AllButtons;
        Button[] firstRow;
        Button[] secondRow;
        Button[] thirdRow;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            AllButtons = new Button[9] {_1, _2, _3, _4, _5, _6, _7, _8, _9};
            firstRow = new Button[3] {_1, _2, _3};
            secondRow = new Button[3] { _4, _5, _6};
            thirdRow = new Button[3] { _7, _8, _9};

            
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = "X";
            (sender as Button).IsEnabled = false;

            
            //int Robot = random.Next(0, 9)
        }

        private void WinningConditions(object sender)
        {
            //удаление сыгранной кнопки из массива всех кнопок
            List<Button> temp = AllButtons.ToList();
            temp.Remove(sender  as Button);
            AllButtons = temp.ToArray();

            //удаление кнопки из массива своего ряда
            foreach (Button element in firstRow)
            {
                if (element == sender)
                {
                    List<Button> FirstRowList = firstRow.ToList();
                    FirstRowList.Remove(sender as Button);
                    firstRow = FirstRowList.ToArray();
                }
                else
                {

                }
            }
            foreach (Button element in secondRow)
            {
                if (element == sender)
                {
                    List<Button> secondRowList = secondRow.ToList();
                    secondRowList.Remove(sender as Button);
                    secondRow = secondRowList.ToArray();
                }
                else
                {

                }
            }
            foreach (Button element in thirdRow)
            {
                if (element == sender)
                {
                    List<Button> thirdRowList = thirdRow.ToList();
                    thirdRowList.Remove(sender as Button);
                    thirdRow = thirdRowList.ToArray();
                }
                else
                {

                }
            }

            //проверка на выигрыш, ничью
            if (AllButtons.Length == 1)
            {
                foreach (Button item in AllButtons)
                {
                    item.IsEnabled = false;
                }
                //ResultBox.IsEnabled = true;
                MessageBoxResult Result = MessageBox.Show("", "Ничья! \nСыграть еще раз?", MessageBoxButton.YesNo);
                if (Result == MessageBoxResult.Yes) 
                {
                
                }
                else if (Result == MessageBoxResult.No) 
                { 
                
                }
            }
            
        }

    }
}
