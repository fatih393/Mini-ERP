Bugün Mini-ERP projesinde MilkCollection modülü üzerinde yoğunlaşarak özellikle get ve post operasyonlarının geliştirilmesi ve iyileştirilmesi üzerine çalışıldı. Bu süreçte, Entity Framework Core ile Oracle veritabanı arasındaki migration ve database update işlemlerinde karşılaşılan hatalar analiz edilerek giderildi ve migration yönetimi daha sağlıklı bir yapıya kavuşturuldu.

MilkCollection entity’si ile ilişkili Supplier ve Employee yapıları üzerinden gelen verilerde yaşanan circular reference problemleri incelendi ve bu sorunu çözmek adına DTO (Data Transfer Object) kullanımı benimsendi. Service katmanında yapılan projeksiyon işlemleri ile sadece ihtiyaç duyulan alanların dönülmesi sağlanarak hem performans hem de veri kontrolü açısından daha doğru bir yapı oluşturuldu.

Ayrıca mapping sırasında foreign key alanlarının doğru şekilde yönetilmesi üzerine çalışıldı ve navigation property yerine doğrudan entity içerisindeki ID alanlarının kullanılması gerektiği netleştirildi. Yapılan bu düzenlemelerle birlikte API response yapısı daha tutarlı hale getirildi.

Gerçekleştirilen bu çalışmalar sonucunda MilkCollection modülü, katmanlı mimariye daha uygun, hatalardan arındırılmış ve sürdürülebilir bir yapıya ulaştırılmış oldu.
