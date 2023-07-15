using Bogus;
using GraduateAppProject.Entities;
using GraduateAppProject.WebMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.WebMVC.Infrastructure.Data
{
    public static class CreateSeedDataExtensions
    {
        public static List<Announcement> MultiAnnouncementCreator(int count)
        {
            var announcementList = new List<Announcement>();
            for (int i = 0; i < count; i++)
            {
                var startDate = new Faker().Date.Between(DateTime.Now, DateTime.Now.AddDays(7));
                announcementList.Add(new Announcement()
                {
                    ImageURL = "https://source.unsplash.com/collection/190727/1280x420",
                    StartDate = startDate,
                    EndDate = startDate.AddDays(7),
                    Title = new Faker().Commerce.ProductName(),
                    Message = new Faker().Commerce.ProductDescription(),
                    IsActive = true,
                });
            }
            return announcementList;
        }

        public static List<GraduateMajorForProgram> GraduateMajorsList()
        {
            var majors = new List<GraduateMajorForProgram>()
            {
#region Filling Graduate Majors With Institute Relation
                    new() { GraduateMajorName = "Adli Tıp", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Ağız Diş ve Çene Cerrahisi", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Ağız Diş ve Çene Radyolojisi", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Anatomi", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Beden Eğitimi ve Spor", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Biyofizik", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Biyoistatistik", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Çocuk Sağlığı ve Hastalıkları", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Ebelik", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Fizyoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Halk Sağlığı", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Hemşirelik", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Histoloji ve Embriyoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "İç Hastalıkları", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Kulak Burun Boğaz (Odyoloji)", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Medikal Fizik", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Ortodonti", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Parazitoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Pediatrik Onkoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Pedodonti", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Periodontoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Protetik ve Diş Tedavisi", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Radyasyon Onkolojisi", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Restoratif Diş Tedavisi ve Endodonti", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Tıbbi Biyokimya", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Tıbbi Biyoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Tıbbi Farmakoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Tıbbi Mikrobiyoloji", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Tıp Tarihi ve Etik", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Translasyonel Tıp", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Veterinerlik Patolojisi", InstituteForGraduateProgramId =3},
                    new() { GraduateMajorName = "Adli Bilimler Anabilim Dalı", InstituteForGraduateProgramId =4},
                    new() { GraduateMajorName = "Bağımlılık Anabilim Dalı", InstituteForGraduateProgramId =4},
                    new() { GraduateMajorName = "Arkeoloji Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Bilgisayar ve Öğretim Teknolojileri Eğitimi Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Eğitim Bilimleri Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Ekonometri Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Felsefe ve Din Bilimleri Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "İç Mimarlık Ana Sanat Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "İktisat Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "İletişim Çalışmaları Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "İslam Tarihi ve Sanatları Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "İşletme Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Maliye Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Matematik ve Fen Bilgisi Eğitimi Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Müzik Ana Sanat Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Özel Hukuk Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Radyo, Televizyon ve Sinema Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Resim-İş Eğitimi Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Sahne Sanatları Ana Sanat Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Sanat ve Tasarım Ana Sanat Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Seramik Ana Sanat Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Tekstil ve Moda Tasarımı Ana Sanat Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Temel Eğitim Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Temel İslam Bilimleri Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Türkçe ve Sosyal Bilimler Eğitimi Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Türk Dili ve Edebiyatı Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Uluslararası İlişkiler Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Yabancı Diller Eğitimi Ana Bilim Dalı", InstituteForGraduateProgramId =2},
                    new() { GraduateMajorName = "Arkeometri", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Astronomi ve Astrofizik", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Bahçe Bitkileri", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Bilgisayar Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Bitki Koruma", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Biyoloji", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Biyomedikal Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Biyoteknoloji", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Biyoteknoloji (İngilizce)", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Çevre Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Elektrik-Elektronik Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Endüstri Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Enerji ve Enerji Sistemleri", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Fizik", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Gıda Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "İleri Malzemeler ve Nanoteknoloji", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "İnşaat Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "İstatistik", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "İş Sağlığı ve Güvenliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Jeoloji Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Kimya", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Maden Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Makine Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Makine Mühendisliği (Türkçe)", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Matematik", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Mimarlık", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Mühendislik ve Teknoloji Yönetimi", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Otomotiv Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Peyzaj Mimarlığı", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Su Ürünleri", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Su Ürünleri Avlama ve İşleme Teknolojisi", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Su Ürünleri Temel Bilimler", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Su Ürünleri Yetiştiricilik", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Sürdürülebilir Tarım ve Gıda Güvenliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Tarım Ekonomisi", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Tarım Makinaları ve Teknolojileri Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Tarımsal Yapılar ve Sulama", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Tarla Bitkileri", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Tekstil Mühendisliği", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Toprak Bilimi ve Bitki Besleme", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Uzaktan Algılama ve Coğrafi Bilgi Sistemleri", InstituteForGraduateProgramId =1},
                    new() { GraduateMajorName = "Zootekni", InstituteForGraduateProgramId =1}
#endregion
            };
            return majors;
        }
    }
}
