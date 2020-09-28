using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ObmenApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DateTime LastTime = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();
            AppData.Ent = new ObmenEntities();
            History.ItemsSource = AppData.Ent.History.ToList();


            //Вставка даты последнего изменения из БД
            
            var lastedits = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
            foreach (Buy b in lastedits)
            {
                LastTime = b.Date;
            }
            TimeLastEdit.Text = LastTime.ToString();


            // Заполенение курса валют из БД
            var buys = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
            foreach (Buy b in buys)
            {
                UsdBuy.Text = Convert.ToString(b.USD);
                EurBuy.Text = Convert.ToString(b.EUR);
                GbpBuy.Text = Convert.ToString(b.GBP);
                UahBuy.Text = Convert.ToString(b.UAH);

            }
            var sells = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
            foreach (Sell b in sells)
            {
                UsdSell.Text = Convert.ToString(b.USD);
                EurSell.Text = Convert.ToString(b.EUR);
                GbpSell.Text = Convert.ToString(b.GBP);
                UahSell.Text = Convert.ToString(b.UAH);

            }
        
        }

       
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустые строчки
            if (UsdBuy.Text == "" || EurBuy.Text == "" || UahBuy.Text == "" || GbpBuy.Text == "" || UsdSell.Text == "" || EurSell.Text == "" || UahSell.Text == "" || GbpSell.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            // Отправка значений в БД
            else
            {
                Buy buy = new Buy()
                {
                    USD = Convert.ToDecimal(UsdBuy.Text),
                    EUR = Convert.ToDecimal(EurBuy.Text),
                    UAH = Convert.ToDecimal(UahBuy.Text),
                    GBP = Convert.ToDecimal(GbpBuy.Text),
                    Date = DateTime.Now,
                };
                Sell sell = new Sell()
                {
                    USD = Convert.ToDecimal(UsdSell.Text),
                    EUR = Convert.ToDecimal(EurSell.Text),
                    UAH = Convert.ToDecimal(UahSell.Text),
                    GBP = Convert.ToDecimal(GbpSell.Text),
                    Date = DateTime.Now,
                };
                AppData.Ent.Buy.Add(buy);
                AppData.Ent.Sell.Add(sell);
                MessageBox.Show("Вы успешно обновили курс","Успешно");
                AppData.Ent.SaveChanges();
                TimeLastEdit.Text = LastTime.ToString();
            }


        }

      

        private void BuyStroka_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Проверка на пустую строчку и точку
            if (BuyStroka.Text == "" || BuyStroka.Text.Contains(".")) { Summ1.Text = "0"; }
            else
            {
                Regex regex1 = new Regex("[a-zA-Z]");
                MatchCollection matches = regex1.Matches(BuyStroka.Text);
                if (matches.Count > 0)
                {
                    Summ1.Text = "0";
                }
                // Получение суммы в соотвествии с последним курсом покупки
                else if (matches.Count == 0)
                {
                    decimal k1 = 0, k2 = 0, k3 = 0, k4 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k1 = b.USD;
                        k2 = b.EUR;
                        k3 = b.UAH;
                        k4 = b.GBP;
                    }
                    if (CB1.SelectedIndex == 0)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k1;
                        Summ1.Text = a.ToString("0.00");
                    }

                    else if (CB1.SelectedIndex == 1)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k2;
                        Summ1.Text = a.ToString("0.00");
                    }

                    else if (CB1.SelectedIndex == 2)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k3;
                        Summ1.Text = a.ToString("0.00");
                    }

                    else if (CB1.SelectedIndex == 3)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k4;
                        Summ1.Text = a.ToString("0.00");
                    }
                }

            }
        }

        private void SellStroka_TextChanged(object sender, TextChangedEventArgs e)
        {   
            //Проверка на пустую строчку
            if (SellStroka.Text == "") { Summ2.Text = "0"; }

            // Получение суммы в соотвествии с последним курсом продажи
            else
            {
                Regex regex1 = new Regex("[a-zA-Z]");
                MatchCollection matches = regex1.Matches(SellStroka.Text);
                if (matches.Count > 0)
                {
                    Summ2.Text = "0";
                }
                else if (matches.Count == 0)
                {
                    decimal k1 = 0, k2 = 0, k3 = 0, k4 = 0;
                    var abc = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abc)
                    {
                        k1 = b.USD;
                        k2 = b.EUR;
                        k3 = b.UAH;
                        k4 = b.GBP;
                    }

                    if (CB2.SelectedIndex == 0)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k1;
                        Summ2.Text = a.ToString("0.00");
                    }

                    else if (CB2.SelectedIndex == 1)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k2;
                        Summ2.Text = a.ToString("0.00");
                    }

                    else if (CB2.SelectedIndex == 2)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k3;
                        Summ2.Text = a.ToString("0.00");
                    }

                    else if (CB2.SelectedIndex == 3)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k4;
                        Summ2.Text = a.ToString("0.00");
                    }
                }
            }
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            // Проверка на пустую строчку и точку
            if (BuyStroka.Text == "" || BuyStroka.Text.Contains(".")) { Summ1.Text = "0"; }

            // Получение суммы в соотвествии с последним курсом покупки
            else
            {
                Regex regex1 = new Regex("[a-zA-Z]");
                MatchCollection matches = regex1.Matches(BuyStroka.Text);
                if (matches.Count > 0)
                {
                    Summ1.Text = "0";
                }
                else if (matches.Count == 0)
                {
                    decimal k1 = 0, k2 = 0, k3 = 0, k4 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k1 = b.USD;
                        k2 = b.EUR;
                        k3 = b.UAH;
                        k4 = b.GBP;
                    }

                    if (CB1.SelectedIndex == 0)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k1;
                        Summ1.Text = a.ToString("0.00");
                    }

                    else if (CB1.SelectedIndex == 1)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k2;
                        Summ1.Text = a.ToString("0.00");
                    }

                    else if (CB1.SelectedIndex == 2)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k3;
                        Summ1.Text = a.ToString("0.00");
                    }

                    else if (CB1.SelectedIndex == 3)
                    {
                        decimal a = Convert.ToDecimal(BuyStroka.Text) * k4;
                        Summ1.Text = a.ToString("0.00");
                    }
                }
            }
        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            // Проверка на пустую строчку и точку
            if (SellStroka.Text == "" || SellStroka.Text.Contains(".")) { Summ2.Text = "0"; }

            // Получение суммы в соотвествии с последним курсом продажи
            else
            {
                Regex regex1 = new Regex("[a-zA-Z]");
                MatchCollection matches = regex1.Matches(SellStroka.Text);
                if (matches.Count > 0)
                {
                    Summ2.Text = "0";
                }
                else if (matches.Count == 0)
                {
                    decimal k1 = 0, k2 = 0, k3 = 0, k4 = 0;
                    var abc = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abc)
                    {
                        k1 = b.USD;
                        k2 = b.EUR;
                        k3 = b.UAH;
                        k4 = b.GBP;
                    }

                    if (CB2.SelectedIndex == 0)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k1;
                        Summ2.Text = a.ToString("0.00");
                    }

                    else if (CB2.SelectedIndex == 1)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k2;
                        Summ2.Text = a.ToString("0.00");
                    }

                    else if (CB2.SelectedIndex == 2)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k3;
                        Summ2.Text = a.ToString("0.00");
                    }

                    else if (CB2.SelectedIndex == 3)
                    {
                        decimal a = Convert.ToDecimal(SellStroka.Text) / k4;
                        Summ2.Text = a.ToString("0.00");
                    }
                }
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустые строчки
            if (Name1.Text == "" || Surname1.Text == "" || Passport1.Text == "" || BuyStroka.Text == "" || Summ1.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }

            //
            else
            {
                Client client = new Client
                {
                    FirstName = Name1.Text,
                    SurName = Surname1.Text,
                    Passport = Passport1.Text,
                };

                if (CB1.SelectedIndex == 0)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.USD;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.USD;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "USD",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Покупка",
                        CountMoney = Convert.ToDecimal(Summ1.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }

                else if (CB1.SelectedIndex == 1)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.EUR;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.EUR;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "EUR",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Покупка",
                        CountMoney = Convert.ToDecimal(Summ1.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }

                else if (CB1.SelectedIndex == 2)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.UAH;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.UAH;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "UAH",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Покупка",
                        CountMoney = Convert.ToDecimal(Summ1.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }

                else if (CB1.SelectedIndex == 3)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.GBP;
                    }
                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.GBP;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "GBP",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Покупка",
                        CountMoney = Convert.ToDecimal(Summ1.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }
                AppData.Ent.Client.Add(client);
                AppData.Ent.SaveChanges();
                MessageBox.Show("Обмен завершён");
            }
        }

        private void BtnOk2_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустые строчки
            if (Name2.Text == "" || Surname2.Text == "" || Passport2.Text == "" || SellStroka.Text == "" || Summ2.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }

            //
            else
            {
                Client client = new Client
                {
                    FirstName = Name1.Text,
                    SurName = Surname1.Text,
                    Passport = Passport1.Text,
                };

                if (CB2.SelectedIndex == 0)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.USD;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.USD;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "USD",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Продажа",
                        CountMoney = Convert.ToDecimal(SellStroka.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }

                else if (CB2.SelectedIndex == 1)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.EUR;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.EUR;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "EUR",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Продажа",
                        CountMoney = Convert.ToDecimal(SellStroka.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }

                else if (CB2.SelectedIndex == 2)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.UAH;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.UAH;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "UAH",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Продажа",
                        CountMoney = Convert.ToDecimal(SellStroka.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }

                else if (CB2.SelectedIndex == 3)
                {
                    decimal k = 0; decimal k1 = 0;
                    var abc = AppData.Ent.Buy.OrderBy(x => x.Date).ToList();
                    foreach (Buy b in abc)
                    {
                        k = b.GBP;
                    }

                    var abv = AppData.Ent.Sell.OrderBy(x => x.Date).ToList();
                    foreach (Sell b in abv)
                    {
                        k1 = b.GBP;

                    }

                    History history = new History
                    {
                        IdClient = client.Id,
                        Value = "GBP",
                        Value2 = "RUB",
                        BuyRate = k,
                        SellRate = k1,
                        Operation = "Продажа",
                        CountMoney = Convert.ToDecimal(SellStroka.Text),
                        Date = DateTime.Now,
                    };
                    AppData.Ent.History.Add(history);
                }
                AppData.Ent.Client.Add(client);
                AppData.Ent.SaveChanges();
                MessageBox.Show("Обмен завершён");
            }
        }

        

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            History.ItemsSource = AppData.Ent.History.ToList();
        }
    }
}
