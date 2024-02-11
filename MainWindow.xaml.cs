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
        Button[] firstColumn;
        Button[] secondRow;
        Button[] secondColumn;
        Button[] thirdRow;
        Button[] thirdColumn;
        Button[] firstDiag;
        Button[] secondDiag;
        Random random = new Random();      

        public MainWindow()
        {
            InitializeComponent();

            Everything();
        }

        private void Everything()
        {
            AllButtons = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            //
            firstRow = new Button[3] { _1, _2, _3 };
            firstColumn = new Button[3] { _1, _4, _7 };
            secondRow = new Button[3] { _4, _5, _6 };
            thirdRow = new Button[3] { _7, _8, _9 };
            //
            firstColumn = new Button[3] { _1, _4, _7 };
            secondColumn = new Button[3] { _2, _5, _8 };
            thirdColumn = new Button[3] { _3, _6, _9 };
            //
            firstDiag = new Button[3] { _1, _5, _9 };
            secondDiag = new Button[3] { _3, _5, _7 };
            //очистка и включение кнопок
            foreach (Button element in AllButtons) 
            {
                (element as Button).IsEnabled = true;
                (element as Button).Content = "";
            }
            //выбор крестиков или ноликов
            MessageBoxResult Result = MessageBox.Show("", "Хотите сыграть за крестики?", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                
                    Player(null, null, 1);
                
            }
            else if (Result == MessageBoxResult.No)
            {
                Player(null, null, 2);
            }
        }

        private void Player(object sender, RoutedEventArgs e, int a)
        {
            if (a == 1)
            {

                (sender as Button).Content = "X";
                (sender as Button).IsEnabled = false;
                WinningConditions(sender);
                Robot(2);

            }
            if (a == 2)
            {

                (sender as Button).Content = "O";
                (sender as Button).IsEnabled = false;
                WinningConditions(sender);
                Robot(1);

            }
        }
 

        private void Robot( int b)
        {      
            if (b == 1)
            {
                WinningConditions(null);
                int knopka = random.Next(0, 9);
                while (AllButtons[knopka].IsEnabled == false)
                {
                    knopka = random.Next(0, 9);
                }

                AllButtons[knopka].Content = "O";
                AllButtons[knopka].IsEnabled = false;
                WinningConditions(AllButtons[knopka]);
            }
            if (b == 2)
            {
                int knopka = random.Next(0, 9);
                while (AllButtons[knopka].IsEnabled == false)
                {
                    knopka = random.Next(0, 9);
                }

                AllButtons[knopka].Content = "X";
                AllButtons[knopka].IsEnabled = false;
                WinningConditions(AllButtons[knopka]);
            }
        }

        private void WinningConditions(object sender)
        {
            //удаление сыгранной кнопки из массива всех кнопок
            List<Button> temp = AllButtons.ToList();
            temp.Remove(sender  as Button);
            AllButtons = temp.ToArray();

            //удаление кнопки из массива своего ряда, колонки, диагонали
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
            foreach (Button element in firstColumn)
            {
                if (element == sender)
                {
                    List<Button> FirstColumnList = firstColumn.ToList();
                    FirstColumnList.Remove(sender as Button);
                    firstColumn = FirstColumnList.ToArray();
                }
                else
                {

                }
            }
            foreach (Button element in firstDiag)
            {
                if (element == sender)
                {
                    List<Button> FirstDiagList = firstDiag.ToList();
                    FirstDiagList.Remove(sender as Button);
                    firstDiag = FirstDiagList.ToArray();
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
            foreach (Button element in secondColumn)
            {
                if (element == sender)
                {
                    List<Button> secondColumnList = secondColumn.ToList();
                    secondColumnList.Remove(sender as Button);
                    secondColumn = secondColumnList.ToArray();
                }
                else
                {

                }
            }
            foreach (Button element in secondDiag)
            {
                if (element == sender)
                {
                    List<Button> secondDiagList = secondDiag.ToList();
                    secondDiagList.Remove(sender as Button);
                    secondDiag = secondDiagList.ToArray();
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
            foreach (Button element in thirdColumn)
            {
                if (element == sender)
                {
                    List<Button> thirdColumnList = thirdColumn.ToList();
                    thirdColumnList.Remove(sender as Button);
                    thirdColumn = thirdColumnList.ToArray();
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
                
                MessageBoxResult Result = MessageBox.Show("", "Ничья! \nСыграть еще раз?", MessageBoxButton.YesNo);
                if (Result == MessageBoxResult.Yes) 
                {
                    Everything();
                }
                else if (Result == MessageBoxResult.No) 
                {
                    System.Environment.Exit(0);
                }
                else
                {

                }
            }

            if (firstRow.Length == 0)
            {

                //firstrowComplete.IsVisible = true;
                //Ошибка CS0200  Невозможно присвоить значение свойству или индексатору "UIElement.IsVisible"
                //— доступ только для чтения.	
                //сетка C:\Users\xizzi\OneDrive\Рабочий стол\си шарп\сетка\MainWindow.xaml.cs   201 Активные
                //хэлп
                //хочу вывести кросивую красную линию для оого чтобы показать где4 была победа, но хз что не так

                //очень надеюсь что здесь получилось создать "если содержимое равно smth"
                if (_1.Content == "X" && _2.Content == "X" && _3.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_1.Content == "O" && _2.Content == "O" && _3.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
                
            }
            if (firstColumn.Length == 0) 
            {
                if (_1.Content == "X" && _4.Content == "X" && _7.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_1.Content == "O" && _4.Content == "O" && _7.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }
            if (firstDiag.Length == 0)
            {
                if (_1.Content == "X" && _5.Content == "X" && _9.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_1.Content == "O" && _5.Content == "O" && _9.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }

            if (secondRow.Length == 0)
            {
                if (_4.Content == "X" && _5.Content == "X" && _6.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_4.Content == "O" && _5.Content == "O" && _6.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }
            if (secondColumn.Length == 0)
            {
                if (_2.Content == "X" && _5.Content == "X" && _8.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_2.Content == "O" && _5.Content == "O" && _8.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }
            if (secondDiag.Length == 0)
            {
                if (_3.Content == "X" && _5.Content == "X" && _8.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_3.Content == "O" && _5.Content == "O" && _8.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }

            if (thirdRow.Length == 0)
            {
                if (_7.Content == "X" && _8.Content == "X" && _9.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_7.Content == "O" && _8.Content == "O" && _9.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }
            if (thirdColumn.Length == 0)
            {
                if (_3.Content == "X" && _6.Content == "X" && _9.Content == "X")
                {
                    KrestShorthand();
                }
                else if (_3.Content == "O" && _6.Content == "O" && _9.Content == "O")
                {
                    NulShorthand();
                }
                else
                {

                }
            }
        }


        private void KrestShorthand()
        {
            foreach (Button item in AllButtons)
            {
                item.IsEnabled = false;
            }
            MessageBoxResult Result = MessageBox.Show("Победа Крестиков", "Победа Крестиков!! \nСыграть еще раз?", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                Everything();
            }
            else if (Result == MessageBoxResult.No)
            {
                System.Environment.Exit(0);
            }
        }
        private void NulShorthand()
        {
            foreach (Button item in AllButtons)
            {
                item.IsEnabled = false;
            }
            MessageBoxResult Result = MessageBox.Show("Победа Ноликов", "Победа Ноликов!! \nСыграть еще раз?", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                Everything();
            }
            else if (Result == MessageBoxResult.No)
            {
                System.Environment.Exit(0);
            }
        }


    }
}
