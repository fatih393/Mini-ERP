Bugün Production modülü üzerinde çalışmalar tamamlanmıştır. Production ekleme ve listeleme işlemleri geliştirilmiş, ilgili alanların güncellenmesi sağlanmıştır. Üretim sürecine ait verilerin izlenebilirliği için BatchCode ve QR Code üretim mekanizması sisteme entegre edilmiştir.

CQRS mimarisi kullanılarak Command ve Query yapısı oluşturulmuş, servis ve repository katmanları bu yapıya uygun şekilde düzenlenmiştir. Production ile ilgili controller endpoint’leri eklenerek API üzerinden erişilebilir hale getirilmiştir.

Genel olarak üretim akışının temel CRUD işlemleri ve QR kod üretim süreci tamamlanmış olup, sistem üretim takibini destekleyecek hale getirilmiştir. Yarın geliştirmelere kaldığı yerden devam edilecektir.