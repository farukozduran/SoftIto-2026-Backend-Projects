USE [MovieDb];
GO

-- 1. Tabloları sıfırlama (TRUNCATE komutu hem verileri siler hem de IDENTITY sayacını sıfırlar)
TRUNCATE TABLE [Movies];
TRUNCATE TABLE [Sessions];
TRUNCATE TABLE [Announcements];
GO

-- 2. Movies tablosuna 10 adet dummy data ekleme
INSERT INTO [Movies] ([MovieTitle], [Genre], [Director], [Duration], [Description], [ImageUrl])
VALUES 
('Yıldızlararası Yolculuk', 'Bilim Kurgu', 'Ahmet Yılmaz', 145, 'Uzayın derinliklerinde geçen nefes kesici bir serüven.', 'https://picsum.photos/seed/movie1/300/450'),
('Karanlık Şehir', 'Aksiyon', 'Mehmet Demir', 120, 'Suçla dolu bir şehirde adaleti arayan bir adamın hikayesi.', 'https://picsum.photos/seed/movie2/300/450'),
('Komik Aile', 'Komedi', 'Ayşe Kaya', 95, 'Sıradan bir ailenin sıradışı ve komik hafta sonu macerası.', 'https://picsum.photos/seed/movie3/300/450'),
('Geçmişin Gölgesi', 'Dram', 'Ali Can', 110, 'Geçmişiyle yüzleşmek zorunda kalan genç bir kadının dramı.', 'https://picsum.photos/seed/movie4/300/450'),
('Son Umut', 'Bilim Kurgu', 'Zeynep Çelik', 135, 'Dünyanın son umudu olan bir grup bilim insanının mücadelesi.', 'https://picsum.photos/seed/movie5/300/450'),
('Hızlı ve Cesur', 'Aksiyon', 'Caner Tekin', 105, 'Sokak yarışlarında zirveye çıkmaya çalışan iki dostun hikayesi.', 'https://picsum.photos/seed/movie6/300/450'),
('Aşkın Renkleri', 'Romantik', 'Elif Yılmaz', 115, 'Tesadüfen tanışan iki gencin romantik ve eğlenceli aşk hikayesi.', 'https://picsum.photos/seed/movie7/300/450'),
('Kayıp Hazine', 'Macera', 'Ahmet Yılmaz', 130, 'Eski bir haritanın peşine düşen maceraperest bir grubun hikayesi.', 'https://picsum.photos/seed/movie8/300/450'),
('Sessiz Çığlık', 'Korku', 'Mehmet Demir', 90, 'Terk edilmiş bir kasabada geçen ürkütücü bir hayatta kalma mücadelesi.', 'https://picsum.photos/seed/movie9/300/450'),
('Zamanda Yolculuk', 'Bilim Kurgu', 'Ayşe Kaya', 125, 'Zaman makinesi icat eden bir dâhinin geçmişe yolculuğu.', 'https://picsum.photos/seed/movie10/300/450');
GO

-- 3. Sessions tablosuna 10 adet dummy data ekleme
INSERT INTO [Sessions] ([MovieTitle], [HallName], [SessionDate], [SessionTime], [TicketPrice], [EmptySeatCount])
VALUES 
('Yıldızlararası Yolculuk', 'Salon 1', DATEADD(day, 1, GETDATE()), '10:00', 150.00, 45),
('Karanlık Şehir', 'Salon 2', DATEADD(day, 1, GETDATE()), '13:30', 160.00, 20),
('Komik Aile', 'Salon 3', DATEADD(day, 2, GETDATE()), '15:45', 140.00, 60),
('Geçmişin Gölgesi', 'Salon 1', DATEADD(day, 2, GETDATE()), '18:15', 150.00, 30),
('Son Umut', 'Salon 4', DATEADD(day, 3, GETDATE()), '21:00', 170.00, 15),
('Hızlı ve Cesur', 'Salon 2', DATEADD(day, 3, GETDATE()), '11:30', 160.00, 50),
('Aşkın Renkleri', 'Salon 5', DATEADD(day, 4, GETDATE()), '14:00', 145.00, 80),
('Kayıp Hazine', 'Salon 3', DATEADD(day, 4, GETDATE()), '16:30', 140.00, 40),
('Sessiz Çığlık', 'Salon 6', DATEADD(day, 5, GETDATE()), '23:30', 180.00, 10),
('Zamanda Yolculuk', 'Salon 1', DATEADD(day, 5, GETDATE()), '19:00', 150.00, 25);
GO

-- 4. Announcements tablosuna 10 adet dummy data ekleme
INSERT INTO [Announcements] ([Title], [Content], [PublishDate], [IsActive])
VALUES 
('Hafta Sonu İndirimi!', 'Bu hafta sonu tüm seanslarda %20 indirim fırsatını kaçırmayın.', DATEADD(day, -1, GETDATE()), 1),
('Yeni Salonlarımız Açıldı', 'Daha konforlu bir sinema deneyimi için Salon 5 ve Salon 6 hizmete girmiştir.', DATEADD(day, -2, GETDATE()), 1),
('Öğrenci Kampanyası', 'Öğrenci kimliğini gösteren herkese mısır ve içecek menüsü yarı fiyatına!', DATEADD(day, -3, GETDATE()), 1),
('Yaz Sineması Günleri', 'Açık hava sineması etkinliklerimiz önümüzdeki ay başlıyor. Detaylar yakında.', DATEADD(day, -4, GETDATE()), 1),
('Sistem Bakımı', 'Sistemlerimizde yapılacak bakım çalışması nedeniyle gece 03:00 - 05:00 arası bilet satışı yapılamayacaktır.', DATEADD(day, -5, GETDATE()), 0),
('Gece Seansları Başlıyor', 'Korku ve gerilim severler için 23:30 seanslarımız bu hafta itibarıyla aktif!', DATEADD(day, -6, GETDATE()), 1),
('Ön Satışlar Başladı', 'Yılın en çok beklenen filmi "Son Umut" için biletler ön satışa çıktı.', DATEADD(day, -7, GETDATE()), 1),
('VIP Salonumuz Hizmette', 'Geniş yatar koltuklar ve özel ikramlarla VIP salonumuzu deneyimleyin.', DATEADD(day, -8, GETDATE()), 1),
('Geçici Kapanış', 'Salon 2 teknik bir arıza nedeniyle 2 günlüğüne bakıma alınmıştır.', DATEADD(day, -9, GETDATE()), 0),
('Çocuklara Özel Hafta', 'Bu hafta boyunca animasyon filmlerinde çocuklara özel sürpriz hediyeler var!', DATEADD(day, -10, GETDATE()), 1);
GO
