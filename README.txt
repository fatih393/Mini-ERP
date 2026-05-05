Stock tablosuna kayıt işlemi başarıyla tamamlanmıştır. Mevcut sistemde, yeni bir milk collection işlemi gerçekleştiğinde önceki stock kayıtları sorgulanarak güncel miktar elde edilmekte ve bu değer üzerine yeni gelen miktar eklenerek stok güncellenmektedir. Bu işlem MilkCollectionHandler içerisinde gerçekleştirilmektedir.

Gerekli hata düzeltmelerinin ardından Production tablosu oluşturulmuş ve veritabanına migration işlemi uygulanmıştır. Buna ek olarak, repository ve service katmanları sadeleştirilerek şu an için yalnızca Add ve Get operasyonlarını destekleyecek şekilde düzenlenmiştir.

Proje şu aşamada temel stok ve üretim akışını destekler hale getirilmiş olup, yarın kaldığı yerden geliştirmelere devam edilecektir.