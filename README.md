# 🛰️ Orbita 

Orbita, **Küp Uydu (CubeSat) ve Küçük Uydu Sistemleri** üzerine geliştirilmiş kapsamlı bir yazılım projesidir. Bu proje, uydu sistemlerinin veri yönetimini, iş mantığını ve kullanıcı arayüzünü tek bir çatı altında toplamayı hedefler.

## 📋 Proje Özeti
Bu depo (repository), Orbita projesinin hem arka yüz (backend) API mimarisini hem de ön yüz (frontend) bileşenlerini barındırmaktadır. C# ile geliştirilen sağlam altyapısı sayesinde uydu verilerinin güvenli ve hızlı bir şekilde işlenmesi, arayüz üzerinden ise bu verilerin anlaşılır bir şekilde sunulması amaçlanmaktadır.

## 🚀 Özellikler
* **OrbinatAPI:** C# ve .NET mimarisi kullanılarak geliştirilmiş, ölçeklenebilir RESTful API.
* **Modüler Yapı:** Controller, Model ve veritabanı bağlantılarının (Database.cs) ayrıştırıldığı katmanlı mimari.
* **Kullanıcı Arayüzü:** Uydu verilerinin ve proje detaylarının görselleştirildiği frontend birimi.
* **Dokümantasyon:** Projeye ait şemalar, uydu görselleri ve teknik dokümanlar.

## 📁 Klasör Yapısı
Proje, temiz bir geliştirme ortamı sunmak amacıyla aşağıdaki gibi modüllere ayrılmıştır:

```text
Orbita/
├── backend/
│   └── OrbinatAPI/          # C# .NET Core API projesi, Controller ve Modeller
├── frontend/
│   └── goruntuler/          # Arayüz tasarımları ve web bileşenleri
├── docs/                    # Proje dokümantasyonları ve şemalar (ör. uydu.png)
└── README.md                # Proje ana açıklaması
