-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 20 Ara 2020, 00:05:18
-- Sunucu sürümü: 10.4.13-MariaDB
-- PHP Sürümü: 7.4.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `mikkeldb`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `username` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `name` text COLLATE utf8_turkish_ci NOT NULL,
  `surname` text COLLATE utf8_turkish_ci NOT NULL,
  `password` text COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`username`, `name`, `surname`, `password`) VALUES
('bahattin', 'Bahattin', 'Koç', '123');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `depo`
--

CREATE TABLE `depo` (
  `barkod` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `adet` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `depo`
--

INSERT INTO `depo` (`barkod`, `adet`) VALUES
('000', 13),
('001', 29),
('002', 9);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategori`
--

CREATE TABLE `kategori` (
  `kategori` varchar(56) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kategori`
--

INSERT INTO `kategori` (`kategori`) VALUES
('Ayakkabı'),
('Elbise'),
('Pantolon'),
('Sweatshirt'),
('Yiyecek');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `marka`
--

CREATE TABLE `marka` (
  `marka` varchar(56) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `marka`
--

INSERT INTO `marka` (`marka`) VALUES
('Akel'),
('AVVA'),
('Columbia'),
('Dockers'),
('Eti'),
('Hummel'),
('Karaca'),
('Kinetix'),
('Koton'),
('MAVİ'),
('TAT'),
('Ülker');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri`
--

CREATE TABLE `musteri` (
  `name` text COLLATE utf8_turkish_ci NOT NULL,
  `surname` text COLLATE utf8_turkish_ci NOT NULL,
  `phone` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `mail` text COLLATE utf8_turkish_ci NOT NULL,
  `address` text COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `musteri`
--

INSERT INTO `musteri` (`name`, `surname`, `phone`, `mail`, `address`) VALUES
('Hamza', 'Kaya', '0', 'hkaya@gmail.com', 'Yurt'),
('Derin', 'Yıldırım', '1', 'dyildirim@gmail.com', 'Sarıyer'),
('Yusuf', 'Yıldırım', '2', 'yyildirim@gmail.com', 'Yenibosna'),
('Songül', 'Ersoy', '3', 'songule@gmail.com', 'Esenler');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satis`
--

CREATE TABLE `satis` (
  `admin_username` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `musteri_tel` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `urun_no` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `adet` int(11) NOT NULL,
  `toplam_fiyat` double NOT NULL,
  `tarih` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `satis`
--

INSERT INTO `satis` (`admin_username`, `musteri_tel`, `urun_no`, `adet`, `toplam_fiyat`, `tarih`) VALUES
('bahattin', '0', '000', 2, 36, '2020-12-20'),
('bahattin', '0', '000', 2, 6, '2020-12-20'),
('bahattin', '0', '000', 2, 6, '2020-12-20'),
('bahattin', '1', '001', 5, 266, '2020-12-20'),
('bahattin', '1', '001', 5, 266, '2020-12-20'),
('bahattin', '1', '001', 5, 266, '2020-12-20'),
('bahattin', '1', '001', 5, 266, '2020-12-20'),
('bahattin', '1', '001', 5, 266, '2020-12-20'),
('bahattin', '1', '001', 5, 266, '2020-12-20'),
('bahattin', '0', '000', 2, 8, '2020-12-20'),
('bahattin', '0', '000', 2, 14, '2020-12-20'),
('bahattin', '0', '000', 2, 8, '2020-12-20'),
('bahattin', '2', '002', 3, 13, '2020-12-20');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sepet`
--

CREATE TABLE `sepet` (
  `musteri_tel` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `musteri_adi` text COLLATE utf8_turkish_ci NOT NULL,
  `urun_barkod` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `urun_adi` text COLLATE utf8_turkish_ci NOT NULL,
  `adet` int(11) NOT NULL,
  `birim_fiyat` double NOT NULL,
  `toplam_fiyat` double NOT NULL,
  `tarih` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `talep`
--

CREATE TABLE `talep` (
  `admin_username` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `tedarikci_tel` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `urun_barkod` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `adet` int(11) NOT NULL,
  `teslim_tarihi` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `talep`
--

INSERT INTO `talep` (`admin_username`, `tedarikci_tel`, `urun_barkod`, `adet`, `teslim_tarihi`) VALUES
('bahattin', '0212', '000', 100, '2020-12-27'),
('bahattin', '0212', '002', 100, '2020-12-27');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tedarikci`
--

CREATE TABLE `tedarikci` (
  `name` text COLLATE utf8_turkish_ci NOT NULL,
  `surname` text COLLATE utf8_turkish_ci NOT NULL,
  `phone` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `mail` text COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `tedarikci`
--

INSERT INTO `tedarikci` (`name`, `surname`, `phone`, `mail`) VALUES
('Talip', 'Müftüoğlu', '0212', 'tmüf@gmail.com'),
('Bahattin', 'Koç', '05367453496', 'bahattink3458@gmail.com');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tedarikci_mk`
--

CREATE TABLE `tedarikci_mk` (
  `tedarikci_tel` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `kategori` varchar(56) COLLATE utf8_turkish_ci NOT NULL,
  `marka` varchar(56) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `tedarikci_mk`
--

INSERT INTO `tedarikci_mk` (`tedarikci_tel`, `kategori`, `marka`) VALUES
('0212', 'Yiyecek', 'Ülker'),
('05367453496', 'Yiyecek', 'Eti');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun`
--

CREATE TABLE `urun` (
  `barkod` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `name` text COLLATE utf8_turkish_ci NOT NULL,
  `kategori` text COLLATE utf8_turkish_ci NOT NULL,
  `marka` text COLLATE utf8_turkish_ci NOT NULL,
  `fiyat` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `urun`
--

INSERT INTO `urun` (`barkod`, `name`, `kategori`, `marka`, `fiyat`) VALUES
('002', 'Çikolatalı Gofret', 'Yiyecek', 'Ülker', 3.25),
('000', 'Karam', 'Yiyecek', 'Ülker', 2),
('001', 'Garnitür', 'Yiyecek', 'TAT', 4.75);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`username`) USING BTREE;

--
-- Tablo için indeksler `depo`
--
ALTER TABLE `depo`
  ADD PRIMARY KEY (`barkod`);

--
-- Tablo için indeksler `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`kategori`);

--
-- Tablo için indeksler `marka`
--
ALTER TABLE `marka`
  ADD PRIMARY KEY (`marka`);

--
-- Tablo için indeksler `musteri`
--
ALTER TABLE `musteri`
  ADD PRIMARY KEY (`phone`);

--
-- Tablo için indeksler `tedarikci`
--
ALTER TABLE `tedarikci`
  ADD PRIMARY KEY (`phone`);

--
-- Tablo için indeksler `tedarikci_mk`
--
ALTER TABLE `tedarikci_mk`
  ADD PRIMARY KEY (`tedarikci_tel`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
