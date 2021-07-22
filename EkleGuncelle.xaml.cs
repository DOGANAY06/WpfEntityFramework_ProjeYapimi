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
using System.Windows.Shapes;
using WpfEntityFramework.Data;

namespace WpfEntityFramework
{
    /// <summary>
    /// Interaction logic for EkleGuncelleWindow.xaml
    /// </summary>
    public partial class EkleGuncelleWindow : Window
    {
        private readonly MainWindow mainWindow;
        private bool EklemeModu { get; set; }
        public EkleGuncelleWindow(MainWindow mainWindow) //constructor ekleme modu
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.Title = "Yeni Müşteri Ekle"; //başlığı 
            this.EklemeModu = true;
        }

        //burada aşırı yükleme yaptık farklı metotlarla : overload adı verilir buna
        //override : Kalıtım yoluyla gidince metotlarını değiştiriyordu ezip bu o değil ama 
        public EkleGuncelleWindow(MainWindow mainWindow,Musteri musteri) //constructor güncelleme modu 
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.DataContext = musteri; //müsterinin referansını datacontext aktarıcazve bu sayede ad soyad adres yerleşir
            this.Title = "Müşteri Güncelle";
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //ekleWindow : Tamam buttonu add yapıcaz db.Musteri
        private void btnTamam_Click(object sender, RoutedEventArgs e)
        { //veritabanı nesnesine ulasacağız
            if (EklemeModu)
           //ekle constructor çalıştıysa oradaki değer true olur bu ife girer
            mainWindow.db.Musteri.Add((Musteri)this.DataContext);


            mainWindow.VerileriGuncelle(); //veri listesi güncellensin
            this.Close(); //veri girildikten sonra kapansın 
        }
    }
}
