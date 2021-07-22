using System;
using System.Collections.Generic;
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
using WpfEntityFramework.Data;

namespace WpfEntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Random r = new Random(); // gibi birşey 
        internal DatabaseContext db = new DatabaseContext(); //ÖRNEĞİ TANIMLADIK  sadece oluşturulduğu proje içerisinde oluşulabilir
        //db.Musteri burada bütün işlemler buradan dönecek  
        //ekleme yapmak için db.Musteri.Add();
        //silmek için = db.Musteri.Remove();
        //nereden tanımlayacağımızı bulmak için: db.Where();

        public MainWindow() //mainwindows tanımlandığında ilk yapılacak olanlar yapı method
        {
            InitializeComponent(); //nesneleri hazırlar
            VerileriGuncelle();
            //verileri güncellememiz lazım eklendiğini görmek için 

        }

        internal void VerileriGuncelle()
        {
            db.SaveChanges(); //sanal listedeki elemanları gerçek veri tabanına yazılmasını sağlayacak 
            this.DataContext = db.Musteri.ToList(); //musteri listeindeki verileri datacontext ekledik listeye cevirip
        }

        private void btnEkle_Click(object sender, RoutedEventArgs e)
        {//eklewindows kendisi bir sınıf onu nesneye dönüştürüp ekrana getirebiliriz
            new EkleGuncelleWindow(this).ShowDialog(); //showdialog kapatılmadan arka tarafa dönülmez show olsa dönülebilirdi
            //this -> MainWindow'dan üretilen nesnenin referansını taşır
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            new EkleGuncelleWindow(this, (Musteri)dataGrid.SelectedItem).ShowDialog(); //güncelleme modunda açılacak
            //secilmiş olan bölüm datagridde çekilecek 
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz ?","Uyarı",MessageBoxButton.YesNo,MessageBoxImage.Warning)==MessageBoxResult.Yes) 
                //kullanıcı gerçekten silmek için eminse sileceğiz
            {
                db.Musteri.Remove((Musteri)dataGrid.SelectedItem);
                VerileriGuncelle();
            }

            
        }
    }
}
