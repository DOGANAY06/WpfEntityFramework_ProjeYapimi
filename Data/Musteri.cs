namespace WpfEntityFramework.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")] //entity framework model ile aktardık veritabanını buraya 
    public partial class Musteri
        //code first yöntemi ile veritabanından getirdik from database entity model 
    {
        public int Id { get; set; }

        [StringLength(50)] //tablodaki uzunlukları  veritabanı 
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(50)]
        public string Adresi { get; set; }
    }
}
