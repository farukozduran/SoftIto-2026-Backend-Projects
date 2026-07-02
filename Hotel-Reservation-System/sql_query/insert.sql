-- 1. Hotels (Oteller) Tablosuna 10 Veri (URL'leri ile birlikte)
SET IDENTITY_INSERT [Hotels] ON;
INSERT INTO [Hotels] (Id, Name, City, Address, StarRating, Photo) VALUES
(1, 'Hilton Bosphorus', 'Istanbul', 'Harbiye, Cumhuriyet Cd. No:50', 5, 'https://assets.hiltonstatic.com/hilton-asset-cache/image/upload/c_fill,w_1920,h_1080,q_70,f_auto,g_auto/Imagery/Property%20Photography/Hilton%20International/I/ISTHITW/HIB_exterior_Drone_Shot__2_.jpg'),
(2, 'Rixos Premium', 'Antalya', 'Ileribasi Mevkii, Belek', 5, 'https://imgcy.trivago.com/c_fill,d_dummy.jpeg,e_sharpen:60,f_auto,h_627,q_auto,w_1200/hotelier-images/de/7f/c36e5fa04f5a2cbe4f21824a90f16afcfb63f01080d67092ac345e1a09eb.jpeg'),
(3, 'Swissotel Buyuk Efes', 'Izmir', 'Gaziosmanpasa Bulvari No:1', 5, 'https://cf.bstatic.com/xdata/images/hotel/max1024x768/889273426.jpg?k=6662ad3b0e8b0f67dc8dde3bda9a99cabab7f2c7a4f821ba01bc16bbe31960de&o='),
(4, 'Divan Hotel', 'Ankara', 'Kavaklidere, Tunali Hilmi Cd.', 4, 'https://divancdn.azureedge.net/divan/media/divan/otel/divan-istanbul/gallery/divan-istanbul-gallery-(1)-810x525.jpg'),
(5, 'Ramada Resort', 'Mugla', 'Bodrum Merkez', 4, 'https://ramadaresortlara.com/public/webp/Ramada_Resort_Lara_Right.webp'),
(6, 'Titanic Deluxe', 'Antalya', 'Lara Turizm Merkezi', 5, 'https://images.etstur.com/imgproxy/files/images/hotelImages/TR/51957/l/Titanic-Deluxe-Golf-Belek-Genel-371557.jpg'),
(7, 'Mövenpick Hotel', 'Istanbul', 'Levent, Buyukdere Cd.', 5, 'https://m.ahstatic.com/is/image/accorhotels/6365-08:8by10?wid=412&hei=515&dpr=on,2.625&qlt=75&resMode=sharp2&op_usm=0.5,0.3,2,0&iccEmbed=true&icc=sRGB'),
(8, 'Dedeman', 'Konya', 'Erenkoy, Esenler Sk.', 4, 'https://cf.bstatic.com/xdata/images/hotel/max1024x768/603890818.jpg?k=e3479e04468365156acb336750f68db1029dee4906fb95ad8ed007793dfa8e23&o='),
(9, 'Kempinski Barbaros', 'Mugla', 'Kizilagac Koyu, Bodrum', 5, 'https://cdn.tatilsepeti.com/Files/Images/Tesis/01716/1050X700/tsr01716638735675002182909.jpg'),
(10, 'Green Park', 'Bursa', 'Osmangazi, Ataturk Cd.', 3, 'https://www.thegreenpark.com/wp-content/uploads/2025/05/img-loginslider-5779-1.jpg');
SET IDENTITY_INSERT [Hotels] OFF;

-- 2. RoomTypes (Oda Tipleri) Tablosuna 10 Veri (URL'leri ile birlikte)
SET IDENTITY_INSERT [RoomTypes] ON;
INSERT INTO [RoomTypes] (Id, TypeName, MaxCapacity, Description, Photo) VALUES
(1, 'Standart Tek Kisilik', 1, 'Standart tek kisilik rahat oda.', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQN9A1MFRK-CicNfgy882ng8yI7OlvC2uOSXlNOBveOx4A8Qfohm6hE9P0e&s=10'),
(2, 'Standart Cift Kisilik', 2, 'Standart cift kisilik yatakli oda.', 'https://www.sidonyahotel.com.tr/wp-content/uploads/2020/08/iki-kisilik-oda-5.jpg'),
(3, 'Deluxe Oda', 2, 'Daha genis ve luks donanimli oda.', 'https://www.dreamhillhotel.com/wp-content/uploads/deluxe_french_room.jpg'),
(4, 'Aile Odasi', 4, 'Cocuklu aileler icin uygun genis oda.', 'https://www.seapalmotel.com/wp-content/uploads/deluxe-aile-odasi-1.jpg'),
(5, 'Kral Dairesi', 2, 'En ust duzey konfor ve luks.', 'https://www.swissotel.com/assets/0/92/2119/2932/2971/2973/6442451685/0c6cc577-82b9-4d6c-8965-771813b1dd63.jpg'),
(6, 'Suit Oda', 3, 'Oturma alani bulunan suit oda.', 'https://adenyahotels.com.tr/upload/blog/otel-konaklamalarinda-suit-oda-ne-demek-071099.webp'),
(7, 'Ekonomik Oda', 2, 'Uygun fiyatli, penceresiz oda.', 'https://www.libertyhotels.com/wp-content/uploads/2025/11/liberty-lara-odalar-ekonomik-oda.webp'),
(8, 'Balayi Suiti', 2, 'Yeni evli ciftler icin ozel dekorasyonlu oda.', 'https://elbis.b-cdn.net/images/balayi_odasi_1.jpg'),
(9, 'Deniz Manzarali Oda', 2, 'Ozel balkon ve mukemmel deniz manzarasi.', 'https://www.orkaboutique.com/img/yeni/deniz/2.jpg'),
(10, 'Penthouse', 4, 'Otelin en ust katinda ozel terasli oda.', 'https://www.thestay.com.tr/Resources/RoomImage/ImageFile/penthouse-bosphorus-suite-100001_l.jpg');
SET IDENTITY_INSERT [RoomTypes] OFF;

-- 3. Rooms (Odalar) Tablosuna 10 Veri
SET IDENTITY_INSERT [Rooms] ON;
INSERT INTO [Rooms] (Id, HotelId, RoomTypeId, RoomNumber, NightlyPrice, Photo) VALUES
(1, 1, 1, '101', 1500.00, 'room1.jpg'),
(2, 2, 5, '102', 5000.00, 'room2.jpg'),
(3, 3, 2, '103', 2000.00, 'room3.jpg'),
(4, 4, 3, '104', 2500.00, 'room4.jpg'),
(5, 5, 4, '105', 3000.00, 'room5.jpg'),
(6, 6, 6, '106', 4000.00, 'room6.jpg'),
(7, 7, 7, '107', 1000.00, 'room7.jpg'),
(8, 8, 8, '108', 3500.00, 'room8.jpg'),
(9, 9, 9, '109', 2800.00, 'room9.jpg'),
(10, 10, 10, '110', 8000.00, 'room10.jpg');
SET IDENTITY_INSERT [Rooms] OFF;

-- 4. Managers (Yöneticiler) Tablosuna 10 Veri 
SET IDENTITY_INSERT [Managers] ON;
INSERT INTO [Managers] (Id, HotelId, FullName, Email, PasswordHash, Photo) VALUES
(1, 1, 'Ahmet Yilmaz', 'ahmet.yilmaz@hilton.com', 'hash123', 'manager1.jpg'),
(2, 2, 'Mehmet Kaya', 'mehmet.kaya@rixos.com', 'hash123', 'manager2.jpg'),
(3, 3, 'Ayse Demir', 'ayse.demir@swissotel.com', 'hash123', 'manager3.jpg'),
(4, 4, 'Fatma Sahin', 'fatma.sahin@divan.com', 'hash123', 'manager4.jpg'),
(5, 5, 'Ali Ozturk', 'ali.ozturk@ramada.com', 'hash123', 'manager5.jpg'),
(6, 6, 'Veli Celik', 'veli.celik@titanic.com', 'hash123', 'manager6.jpg'),
(7, 7, 'Zeynep Yildiz', 'zeynep.yildiz@movenpick.com', 'hash123', 'manager7.jpg'),
(8, 8, 'Hasan Aydin', 'hasan.aydin@dedeman.com', 'hash123', 'manager8.jpg'),
(9, 9, 'Huseyin Arslan', 'huseyin.arslan@kempinski.com', 'hash123', 'manager9.jpg'),
(10, 10, 'Elif Dogan', 'elif.dogan@greenpark.com', 'hash123', 'manager10.jpg');
SET IDENTITY_INSERT [Managers] OFF;

-- 5. Guests (Misafirler) Tablosuna 10 Veri (URL'leri ile birlikte)
SET IDENTITY_INSERT [Guests] ON;
INSERT INTO [Guests] (Id, IdentityNumber, FirstName, LastName, Phone, Photo) VALUES
(1, '12345678901', 'Burak', 'Yilmaz', '5551112233', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlf96h5MZxmqCfEsNJpylSswu4D3JZOVMbKOakZEPVGg&s=10'),
(2, '23456789012', 'Caner', 'Erkin', '5552223344', 'https://img.a.transfermarkt.technology/portrait/big/39333-1730286093.jpg?lm=1'),
(3, '34567890123', 'Gokhan', 'Gonul', '5553334455', 'https://img.a.transfermarkt.technology/portrait/big/33793-1742217396.jpg?lm=1'),
(4, '45678901234', 'Arda', 'Turan', '5554445566', 'https://img.a.transfermarkt.technology/portrait/big/115059-1755368878.png?lm=1'),
(5, '56789012345', 'Selcuk', 'Inan', '5555556677', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQPl1ISbHLCd91zcvb2-8ZEw6fXGS_Bqhdm31OYbkM3Og&s'),
(6, '67890123456', 'Volkan', 'Demirel', '5556667788', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi2xmt0rHcOetpydMPUzpdZkxjbsmAnJFBs-P04PuHGA&s=10'),
(7, '78901234567', 'Ozan', 'Tufan', '5557778899', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmDYd9_7DtXaf_SEro5TA0km3mHRaW6Raa8ZKicWzV_w&s=10'),
(8, '89012345678', 'Hakan', 'Calhanoglu', '5558889900', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9w1N4vhD9eR8VH0EPP8qk6aAEMyuzsVHKEUC1Z9ZGRQ&s=10'),
(9, '90123456789', 'Caglar', 'Soyuncu', '5559990011', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQasBzpltyK4YAltZ_GcggScyibFgqGA9CF55a4jz3CgQ&s=10'),
(10, '01234567890', 'Merih', 'Demiral', '5550001122', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRpQfd-SSuGoGhCFblO_eKo533ib4rsQtYKb2a-xKrr9A&s');
SET IDENTITY_INSERT [Guests] OFF;

-- 6. Reservations (Rezervasyonlar) Tablosuna 10 Veri
SET IDENTITY_INSERT [Reservations] ON;
INSERT INTO [Reservations] (Id, GuestId, RoomId, CheckInDate, CheckOutDate, TotalAmount, Status) VALUES
(1, 1, 1, '2026-07-10', '2026-07-15', 7500.00, 'Onaylandi'),
(2, 2, 2, '2026-08-01', '2026-08-05', 20000.00, 'Beklemede'),
(3, 3, 3, '2026-07-20', '2026-07-22', 4000.00, 'Onaylandi'),
(4, 4, 4, '2026-09-10', '2026-09-15', 12500.00, 'Iptal Edildi'),
(5, 5, 5, '2026-07-05', '2026-07-10', 15000.00, 'Tamamlandi'),
(6, 6, 6, '2026-10-01', '2026-10-03', 8000.00, 'Onaylandi'),
(7, 7, 7, '2026-07-08', '2026-07-10', 2000.00, 'Beklemede'),
(8, 8, 8, '2026-11-15', '2026-11-20', 17500.00, 'Onaylandi'),
(9, 9, 9, '2026-08-25', '2026-08-30', 14000.00, 'Onaylandi'),
(10, 10, 10, '2026-12-28', '2026-12-31', 24000.00, 'Onaylandi');
SET IDENTITY_INSERT [Reservations] OFF;