# Lisansüstü Başvuru Sistemi

- Bu proje, bir Lisansüstü Başvuru Sistemi'nin örnek bir uygulamasını içermektedir. Proje, katmanlı mimari yapısını, SOLID prensiplerini, DTO'ları ve Caching'i kullanmaya çalışarak geliştirilmiştir.

## Projenin Yapısı

- Proje, iki ana yapıya ayrılmıştır:
   1. Web API
   2. Web MVC

    ![Projenin Klasör Yapısı](ReadmeScreenshots/Klasör_yapısı.png)

## Kullanıcı Arayüzü

### Kullanıcıyı Karşılayan Sayfa(Home/Index)

- Home/Index sayfası

    ![IRepository](ReadmeScreenshots/HomeIndex.png)

- Sayfada Duyurular ve Başvuruya Açılan Programlar olmak üzere iki bölüm bulunur.

    1. AnnouncementDisplayResponse

        ![IRepository](ReadmeScreenshots/Announcement.png)

    2. AnnouncementDisplayResponse

        ![IRepository](ReadmeScreenshots/GraduateProgram.png)

- Burada kullanılacak veriler veritabanından çekilir ve belleğe kayıt edilir. Böylece her istekte ilk önce bellekte olup olmadığı kontrol edilir, eğer yoksa veritabanından veriler çekilir ve belleğe kaydedilir.

    ![IRepository](ReadmeScreenshots/Index.png)

- GetIndexPageModelFromCacheOrDb metodunda ilk önce verinin cache'te olup olmadığı TryGetValue extension metodu ile kontrol ediliyor. Eğer varsa o veri geri döndürülüyor, eğer yoksa GetIndexPageModelFromDb metodu ile veritabanından ilgili veri çekiliyor. Çekilen bu veri belleğe kaydedildikten sonra return ile isteğe cevap veriliyor.

    ![IRepository](ReadmeScreenshots/IndexModelCache.png)

- IndexPageModel, içerisinde duyuruların ve açılan lisansüstü programların listelerini tutan bir view model'dir.

    ![IRepository](ReadmeScreenshots/IndexPageModel.png)

- Duyuruların ve Programların sorgulanması:

    ![IRepository](ReadmeScreenshots/GetIndexpagemodel.png)

- AutoMapper kullanarak dto-entity map'leme işlemleri generic extension metot ile gerçekleştiriliyor.

    ![IRepository](ReadmeScreenshots/ConvertDto.png)

    ![IRepository](ReadmeScreenshots/MapProfile.png)

- Sisteme kayıt 2 aşamadan oluşuyor. İlk önce ad, soyad, T.C. kimlik numarası ve doğum yılı doğrulaması yapılır. Doğrulama başarılı olduktan sonra kullanıcıdan e-mail ve şifre bilgileri alınır ve kayıt gerçekleştirilir.

    ![IRepository](ReadmeScreenshots/BilgiDoğrulama.png)

    ![IRepository](ReadmeScreenshots/kayitTamalama.png)

- Doğrulama için CitizenCheck metodu kullanılır. Burada kullanıcı bilgilerinin tutarlılığı kontrol edilir ve doğrulanmış kullanıcıların sisteme kayıtlı olup olmadığı da kontrol edilir.

    ![IRepository](ReadmeScreenshots/CitizenCheck.png)

- CitizenCheck metodu içerisinde CheckAndGetCitizenId adındaki metot ile API'ye alınan bilgiler POST edilir ve response alınır. API, eğer bilgiler doğru ise response'nin Header'indeki Location özelliğini kullanarak <code> https://localhost:7084/api/Citizen/GetIdentityInformationsByCitizenId?id=28 </code> şeklinde bir adres döndürür. Bu adresi <code>Regex.Match(location, @"\?id=(\d+)$")</code> kullanarak ``` id ``` elde edilir.

    ![IRepository](ReadmeScreenshots/RegexMatch.png)

- Doğrulama için kullanılan bu API, İçişleri Bakanlığı Kimlik Doğrulama Sistemi benzeri bir API gibi kullanılmaktadır. API, sisteme kayıt olmak isteyen kullanıcıların Ad, Soyad, T.C. Kimlik numarası ve Doğum Yılı gibi bilgilerini alır ve bu bilgileri kullanarak özel olarak oluşturulan bir veritabanında sorgular. Veritabanında, sahte kullanıcı verileri bulunur.

- API çalıştığında veritabanı kontrol edilir ve boş olan tablolar sahte veriler oluşturularak doldurulur.

    ![API'de kullanılan veritabanı](ReadmeScreenshots/ProgramCs.png)

- Bu sahte verileri SeedDatabase extension metodu ve Bogus kütüphanesini kullanarak gerçekleştirilmiştir.

    ![API'de kullanılan veritabanı](ReadmeScreenshots/SeedDatabase.png)

- CreateFakeCitizens extension metodu:

    ![API'de kullanılan veritabanı](ReadmeScreenshots/CreateFakeCitizens.png)

- Her kullanıcı için kimlik bilgisi ile birlikte eğitim bilgileri de eklenir.

    ![API'de kullanılan veritabanı](ReadmeScreenshots/CreateFakeCitizensInfos1.png)

    ![API'de kullanılan veritabanı](ReadmeScreenshots/CreateFakeCitizensInfos1.png)

- API, başvuru sistemine kullanıcının kimlik bilgilerini ve eğitim bilgilerini sağlamak için çalışır. Kullanıcılar tarafından sağlanan T.C. Kimlik numarasını ve diğer bilgileri kullanılarak, bu API servisinden ilgili bilgiler alınır ve sisteme sunulur.

- Bu API için DB-First (Veritabanı Odaklı) geliştirme yöntemi kullanılmıştır. Var olan bir veritabanı şeması temel alınarak, Entity Framework Core kullanılarak veritabanı bağlantısı ve sorguları yönetilmektedir.

- Veritabanı

    ![API'de kullanılan veritabanı](ReadmeScreenshots/API_Veritabanı.png)

- Kullanılan entity'lere ait repository'lerin yönetimini kolaylaştıran generic interface oluşturabilmek için boş, IEntity adında bir interface oluşturdum.

    ![IEntity](ReadmeScreenshots/IEntity.png)

- Böylece her entity için aynı metotları(CRUD) tekrar tekrar yazmaya gerek kalmadı. IRepository ile bu gerçekleştirildi.

    ![IRepository](ReadmeScreenshots/API_IRepository.png)

- Bir kullanıcıya ait bilgileri doğrulamak için <code>https://localhost:7084/api/Citizen/CheckCitizen</code> adresine gelen istekler CheckCitizenRequest adındaki dto'ya dönüştürülür.

    ![Kullanıcı Bilgilerini Doğrulama](ReadmeScreenshots/CheckCitizenRequest.png)

- Gelen request'in kullanılan dto'ya uygun olup olmadığı kontrol edilerek, kullanıcı bilgileri CitizenService içerisindeki <code>IsValidCitizenAsync</code> metodu kullanılarak kontrol edilir. Kullanıcı bilgileri doğrulandığında kullanıcının id değeri döndürülür.

    ![Kullanıcı Bilgilerini Doğrulama](ReadmeScreenshots/CheckCitizenRequest.png)

- IsValidCitizen Metotları:

    ![Kullanıcı Bilgilerini Doğrulama](ReadmeScreenshots/IsValidCitizen.png)

- IsValidCitizen Metotları aldığı bu parametreleri kullanarak EFCitizenRepository içerisindeki CheckCitizen metodunu kullanır. IsValidCitizen Metotları:

    ![Kullanıcı Bilgilerini Doğrulama](ReadmeScreenshots/CheckCitizen.png)

- Bilgileri doğrulanmış ve sisteme kaydı olmayan kullanıcılar bir sonraki işlem olan kayıt tamalama sayfasına yönlendirilir. Yönlendirme yapılırken doğrulanan kişinin id değeri ve encrypt edilmiş Kimlik Numaraları da o sayfaya gönderilir. Böylece sisteme kayıt yapılırken e-mail ve şifre ile birlikte bu bilgiler de sisteme kayıt edilir.

    ![IRepository](ReadmeScreenshots/StepTwo.png)

- Kimlik numaraları ve şifreler encrypted bir şekilde veritabanında saklanır. Decrypt işlemi sadece kullanıcı bilgilerinin gösterildi kısımlarda kimlik numarasını gösterebilmek için kullanılır.

    ![IRepository](ReadmeScreenshots/SecurityExtensions.png)

- Kullanıcı bilgileri doğrulandıktan ve mail-şifre bilgileri alındıktan sonra bu bilgiler CreateNewUserRequest adındaki dto'ya ait bir nesneye eklenir ve kayıt işlemini tamamlamak için UserService içerisindeki RegisterUser metoduna gönderilir. Burada dto, User entity'e mapping işlemi ile dönüştürülür ve Create metoduna kayıt işlemini tamamlamak üzere gönderilir.

    ![IRepository](ReadmeScreenshots/UserRegister.png)

- Create metotları:

    ![IRepository](ReadmeScreenshots/Kayıt.png)

### Login Sayfası(Home/Login)

- Kullanıcdan alınan kimlik numarası ve şifre encrypt edilerek kontrol edilir.

    ![IRepository](ReadmeScreenshots/Login.png)

- Kimlik numarası ve şifre, LoginModel olarak Login sayfasına post edilir ve gelen bu bilgiler GetUserCitizenId metodu ile kontrol edilir. Eğer doğru ise kullanıcıya ait id değeri elde edilir. Bu id değeri kullanılarak kullanıcının rol bilgisi elde ediler ve kullanıcı rolüne bağlı olarak ilgili sayfaya yönlendirilir.

- Login:

    ![IRepository](ReadmeScreenshots/GetUserCitizenId.png)

- LoginModel

    ![IRepository](ReadmeScreenshots/LoginModel.png)

- CheckUser metodu:

    ![IRepository](ReadmeScreenshots/CheckUser.png)

### Kullanıcı Sayfası(Applicant/Index)

- Home/Index sayfasında olduğu gibi duyurular ve açılan programların bilgisi, önce bellekte olup olmadığı kontrol edilir yoksa veritabanından çekilmesi sağlanır ve IndexPageModel nesnesine atanır.

    ![IRepository](ReadmeScreenshots/ApplicantIndex.png)

- Ayrıca kullanıcıya ait tüm bilgiler de bir ApplicantInformationsModel olarak elde edilir.

    ![IRepository](ReadmeScreenshots/ApplicantInformationsModel.png)

- Bu modelde bulunan dto'lar API'den elde edilen verilerle doldurulur.

    ![IRepository](ReadmeScreenshots/UserIdentity.png)
    ![IRepository](ReadmeScreenshots/UserAles.png)
    ![IRepository](ReadmeScreenshots/UserBachelor.png)
    ![IRepository](ReadmeScreenshots/UserDoctorate.png)
    ![IRepository](ReadmeScreenshots/UserMaster.png)
    ![IRepository](ReadmeScreenshots/UserYds.png)

- Bu bilgiler GetApplicantInformationsModel metodu ile alınır. Bu metot içerisinde ilgili bilgiler UserService'deki  Get***DTOByCitizenId metotları ile API'den elde edilir.

    ![IRepository](ReadmeScreenshots/GetApplicantInfos.png)

- Get***DTOByCitizenId metotları:

    ![IRepository](ReadmeScreenshots/GetDTOs.png)

- Bu metotlarda GetApiResponse extension metodu kullanıldı. Bu metot istek yapılacak API bağlantısının endpoint bilgisini alır ve ilgili API bağlantısına ekleyerek isteği gerçekleştirir. Bu istek sonucunda ilgili dto türünde bir nesne döndürür.

    ![IRepository](ReadmeScreenshots/GetApiResponse.png)

- API'deki metotlar:

    ![IRepository](ReadmeScreenshots/SendResponses.png)

### Admin Sayfası(Admin/Index)

- Bu sayfada daha önce açılmış olan lisansüstü programların bilgileri bulunmaktadır.

    ![IRepository](ReadmeScreenshots/AdminIndex.png)

- Bu sayfadaki bilgiler diğer index sayfalarında olduğu gibi daha önceden belleğe atılmış bilgilerden elde edilir. Eğer bellekte bulunmuyorsa, veritabanından sorgu ile bilgiler alınır ve belleğe yazılarak kullanılır.

    ![IRepository](ReadmeScreenshots/AdminIndexCode.png)

### Program Ekleme Sayfası(Admin/CreateGraduateProgram)

- Bu metotta select list'leri doğru olarak doldurabilmek için verileri SelectListItem olarak alınmasını sağlayan metotlar kullanıldı. Bu metotlar tek bir ``` GetProgramsItemsForSelectList ``` adında tek bir metoda dönüştürülebilir ve ViewBag atamaları da bu metot içerisinde yapılabilir.

    ![IRepository](ReadmeScreenshots/SelectListForProgramAdding.png)

- Program ekleme işleminde CreateNewGraduateProgramRequest adındaki dto kullanıldı.

    ![IRepository](ReadmeScreenshots/CreateNewGraduateProgramRequest.png)

- Gelen bu request ModelState.IsValid ile kontrol edilir ve buna göre ekleme işlemi gerçekleştirilir. Ekleme işlemi gerçekleştirildikten sonra index sayfasına yönlendirilir.

    ![IRepository](ReadmeScreenshots/CreateProgram.png)

>**Yönlendirme yapılmadan önce ```_memoryCache``` nesnesinden ```IndexPageModelData``` anahtarına sahip veriyi kaldırmak ve bir sonraki istekte veri olmadığı için verinin veritabanından alınarak belleğe yazılmasını sağlamak için ```_memoryCache.Remove("IndexPageModelData")``` kullanıldı.**
