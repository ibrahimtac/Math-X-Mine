-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 05 Oca 2025, 18:34:04
-- Sunucu sürümü: 8.2.0
-- PHP Sürümü: 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `mathxmine`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanıcılar`
--

DROP TABLE IF EXISTS `kullanıcılar`;
CREATE TABLE IF NOT EXISTS `kullanıcılar` (
  `id` int NOT NULL AUTO_INCREMENT,
  `kullanici_adi` varchar(50) NOT NULL,
  `sifre` varchar(255) NOT NULL,
  `eposta` varchar(100) NOT NULL,
  `dogum_tarihi` date NOT NULL,
  `cinsiyet` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `kayit_tarihi` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `kullanici_adi` (`kullanici_adi`),
  UNIQUE KEY `eposta` (`eposta`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `kullanıcılar`
--

INSERT INTO `kullanıcılar` (`id`, `kullanici_adi`, `sifre`, `eposta`, `dogum_tarihi`, `cinsiyet`, `kayit_tarihi`) VALUES
(2, 'Murphy', 'Jeckal123#', 'murphy@gmail.com', '2004-03-02', 'E', '2024-12-11 22:54:18'),
(3, 'Gökdeniz', 'gokdeniz123', 'gokdenizsezer557@gmail.com', '2004-03-02', 'E', '2024-12-11 22:55:09'),
(5, 'Osman', 'ozz', 'osman@gmail.com', '2004-12-09', 'E', '2024-12-12 11:28:14'),
(8, 'SERGİ', 'sergi123', 'sergi2024@gmail.com', '2024-12-24', 'E', '2024-12-24 00:30:43');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `matematiksorulari`
--

DROP TABLE IF EXISTS `matematiksorulari`;
CREATE TABLE IF NOT EXISTS `matematiksorulari` (
  `id` int NOT NULL AUTO_INCREMENT,
  `oyun_modu` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `soru` text NOT NULL,
  `dogru_cevap` varchar(255) NOT NULL,
  `yanlis_cevap1` varchar(255) NOT NULL,
  `yanlis_cevap2` varchar(255) NOT NULL,
  `yanlis_cevap3` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=88 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `matematiksorulari`
--

INSERT INTO `matematiksorulari` (`id`, `oyun_modu`, `soru`, `dogru_cevap`, `yanlis_cevap1`, `yanlis_cevap2`, `yanlis_cevap3`) VALUES
(1, '0', '(-2) * [7 - 3] işleminin sonucu kaçtır?', '-8', '-7', '-9', '-10'),
(2, '0', '[12 ÷ 3] + (-6) işleminin sonucu kaçtır?', '-2', '-1', '-3', '0'),
(3, '0', '[5 * (-4)] + 15 işleminin sonucu kaçtır?', '-5', '-4', '-6', '-3'),
(4, '0', '[(-8) * 3] + 16 işleminin sonucu kaçtır?', '-8', '-7', '-9', '-6'),
(5, '0', '(-6) - (-10) işleminin sonucu kaçtır?', '4', '3', '5', '6'),
(6, '0', '[15 ÷ 5] * [2 - (-3)] işleminin sonucu kaçtır?', '15', '14', '16', '17'),
(7, '0', '[12 ÷ (-3)] * (-2) işleminin sonucu kaçtır?', '8', '6', '7', '9'),
(8, '0', '[(-5) + 10] * 4 işleminin sonucu kaçtır?', '20', '25', '15', '30'),
(9, '0', '[25 - 5] ÷ (-2) işleminin sonucu kaçtır?', '-10', '-12', '-8', '-9'),
(10, '0', '[10 + (-5)] * [4 ÷ 2] işleminin sonucu kaçtır?', '10', '12', '8', '14'),
(11, '0', '[(-3) * (-6)] + [12 - 8] işleminin sonucu kaçtır?', '22', '21', '23', '20'),
(12, '0', '[(-8) + 10] * (-3) işleminin sonucu kaçtır?', '-6', '-4', '-8', '-5'),
(13, '0', '[24 ÷ 4] + (-7) işleminin sonucu kaçtır?', '-1', '0', '-2', '-3'),
(14, '0', '[20 - (-10)] ÷ 2 işleminin sonucu kaçtır?', '15', '10', '20', '25'),
(15, '0', '[(-4) * 5] + [10 - 3] işleminin sonucu kaçtır?', '-13', '-14', '13', '14'),
(16, '0', '[30 ÷ 3] + (-5) işleminin sonucu kaçtır?', '5', '10', '0', '-5'),
(17, '0', '[15 + (-8)] * [2 ÷ 2] işleminin sonucu kaçtır?', '7', '8', '6', '5'),
(18, '0', '[10 - (-5)] * 3 işleminin sonucu kaçtır?', '45', '40', '50', '35'),
(19, '0', '[(-7) + 14] * (-2) işleminin sonucu kaçtır?', '-14', '-13', '-15', '-16'),
(20, '0', '[18 ÷ (-3)] - 5 işleminin sonucu kaçtır?', '-11', '-12', '-10', '-9'),
(21, '0', '[25 - 10] ÷ 3 işleminin sonucu kaçtır?', '5', '4', '6', '7'),
(22, '0', '[(-12) ÷ (-4)] + 8 işleminin sonucu kaçtır?', '11', '10', '12', '9'),
(23, '0', '[10 + (-2)] * [6 ÷ 2] işleminin sonucu kaçtır?', '24', '20', '22', '26'),
(24, '0', '[15 * (-2)] + 5 işleminin sonucu kaçtır?', '-25', '-20', '-30', '-15'),
(25, '0', '[(-9) ÷ 3] - (-4) işleminin sonucu kaçtır?', '1', '2', '0', '-1'),
(26, '0', '[20 ÷ (-5)] * (-3) işleminin sonucu kaçtır?', '12', '10', '15', '9'),
(27, '0', '[30 - (-10)] ÷ 4 işleminin sonucu kaçtır?', '10', '8', '9', '11'),
(28, '0', '[(-15) + 20] * (-2) işleminin sonucu kaçtır?', '-10', '-12', '-8', '-15'),
(29, '1', '(-2) * [-42 + 18] * (-3 + 2) işleminin sonucu kaçtır?', '-48', '-52', '-46', '-50'),
(30, '1', '[25 - 15] * (-8 ÷ 2) işleminin sonucu kaçtır?', '-40', '-38', '-42', '-45'),
(31, '1', '(-10) * [6 - (-2)] işleminin sonucu kaçtır?', '-80', '-75', '-85', '-78'),
(32, '1', '[15 ÷ (-3)] * [9 - 12] işleminin sonucu kaçtır?', '15', '16', '14', '17'),
(33, '1', '[(-8) * 5] + (-12) işleminin sonucu kaçtır?', '-52', '-50', '-54', '-55'),
(34, '1', '[20 - (-15)] ÷ 5 işleminin sonucu kaçtır?', '7', '6', '8', '9'),
(35, '1', '[(-6) + 12] * (-4 ÷ 2) işleminin sonucu kaçtır?', '-12', '-10', '-14', '-16'),
(36, '1', '[(-12) * (-3)] + [15 - 20] işleminin sonucu kaçtır?', '31', '30', '32', '33'),
(37, '1', '[10 + (-5)] * [8 ÷ (-2)] işleminin sonucu kaçtır?', '-20', '-25', '-15', '-30'),
(38, '1', '[15 ÷ (-3)] + [20 + (-5)] işleminin sonucu kaçtır?', '10', '12', '8', '15'),
(39, '1', '[50 - (-20)] ÷ [4 + 3] işleminin sonucu kaçtır?', '10', '11', '9', '12'),
(40, '1', '[(-20) ÷ (-5)] + [3 * (-4)] işleminin sonucu kaçtır?', '-8', '-7', '7', '8'),
(41, '1', '[(-30) + 12] ÷ [5 + (-2)] işleminin sonucu kaçtır?', '-6', '-5', '-7', '-4'),
(42, '1', '[15 + (-10)] * [-3 + (-2)] işleminin sonucu kaçtır?', '-25', '-30', '-20', '-15'),
(43, '1', '[(-5) * (-4)] + [30 ÷ (-3)] işleminin sonucu kaçtır?', '10', '12', '16', '18'),
(44, '1', '[60 - (-20)] ÷ 10 işleminin sonucu kaçtır?', '8', '7', '9', '6'),
(45, '1', '[(-12) ÷ (-4)] + [25 - 30] işleminin sonucu kaçtır?', '-2', '-1', '-3', '0'),
(46, '1', '[(-15) + 25] ÷ [3 + (-2)] işleminin sonucu kaçtır?', '10', '11', '9', '8'),
(47, '1', '[(-4) * (-3)] - [18 ÷ (-2)] işleminin sonucu kaçtır?', '21', '20', '22', '19'),
(48, '1', '[(-20) * 4] ÷ [8 - (-2)] işleminin sonucu kaçtır?', '-8', '-7', '-9', '-10'),
(49, '1', '[50 ÷ (-10)] + [25 + (-30)] işleminin sonucu kaçtır?', '-10', '-6', '-5', '-20'),
(50, '1', '[(-16) ÷ (-4)] + [40 ÷ (-5)] işleminin sonucu kaçtır?', '-4', '-3', '-5', '-6'),
(51, '1', '[(-25) + 50] * [10 ÷ (-5)] işleminin sonucu kaçtır?', '-50', '-45', '-55', '-40'),
(52, '1', '[20 ÷ (-5)] + [(-30) ÷ (-6)] işleminin sonucu kaçtır?', '1', '0', '-2', '-1'),
(53, '1', '[60 ÷ (-10)] + [25 - (-15)] işleminin sonucu kaçtır?', '36', '20', '18', '21'),
(54, '1', '[(-40) ÷ 5] + [3 * (-4)] işleminin sonucu kaçtır?', '-20', '-25', '-30', '-10'),
(55, '1', '[(-12) ÷ (-6)] + [18 ÷ (-3)] işleminin sonucu kaçtır?', '-4', '0', '-2', '-3'),
(56, '1', '[25 + (-11)] ÷ [5 - (-2)] işleminin sonucu kaçtır?', '2', '1', '0', '-1'),
(57, '1', '[(-30) ÷ (-6)] + [20 - (-5)] işleminin sonucu kaçtır?', '30', '20', '9', '12'),
(58, '2', '[(-2) + (-3)] * [(-4) + 7] işleminin sonucu kaçtır?', '-15', '-12', '-18', '-21'),
(59, '2', '[12 - (-2)] * [(-5) + 1] işleminin sonucu kaçtır?', '-56', '-54', '-58', '-60'),
(60, '2', '[[(-6) + (-4)] * 3] + 2 işleminin sonucu kaçtır?', '-28', '-27', '-32', '-26'),
(61, '2', '[[5 - (-3)] ÷ (-2)] işleminin sonucu kaçtır?', '-4', '-3', '-5', '-6'),
(62, '2', '[[(-8)*(-2)] + (-3)] - 5 işleminin sonucu kaçtır?', '8', '10', '6', '7'),
(63, '2', '[[(-10)+4]*[(-2)+(-3)]] işleminin sonucu kaçtır?', '30', '25', '-30', '35'),
(64, '2', '[(-12)*(-3)] + [(-6)*2] işleminin sonucu kaçtır?', '24', '22', '20', '28'),
(65, '2', '[[15 - (-5)] ÷ [(-4)+6]] işleminin sonucu kaçtır?', '10', '8', '12', '9'),
(66, '2', '[(-3)*(-4)*(-1)] işleminin sonucu kaçtır?', '-12', '12', '-4', '-8'),
(67, '2', '[(-16)+(-4)] + [(-5)*(-2)] işleminin sonucu kaçtır?', '-10', '-5', '-8', '-12'),
(68, '2', '[[(-9)*2] - (-6)] + (-1) işleminin sonucu kaçtır?', '-13', '-11', '-14', '-15'),
(69, '2', '[(-15) + (-5)] * [4 - (-2)] işleminin sonucu kaçtır?', '-120', '-110', '-100', '-130'),
(70, '2', '[[(-10) ÷ (-2)] + 5] işleminin sonucu kaçtır?', '10', '11', '9', '8'),
(71, '2', '[[8 + (-3)] * [(-4) - 1]] işleminin sonucu kaçtır?', '-25', '-20', '-30', '-15'),
(72, '2', '[[(-2)*(-2)] + [(-3)*(-3)]] işleminin sonucu kaçtır?', '13', '12', '14', '11'),
(73, '2', '[5 - [(-5)*2]] işleminin sonucu kaçtır?', '15', '-5', '10', '25'),
(74, '2', '[(-1)*(-2)*(-3)] işleminin sonucu kaçtır?', '-6', '-5', '-4', '-8'),
(75, '2', '[[(-6)+(-2)] * [(-4)+4]] işleminin sonucu kaçtır?', '0', '-8', '8', '-16'),
(76, '2', '[[-5 + (-5)] * [(-1)*(-2)]] işleminin sonucu kaçtır?', '-20', '-18', '-22', '-15'),
(77, '2', '[18 - [(-3)*6]] işleminin sonucu kaçtır?', '36', '35', '34', '40'),
(78, '2', '[[(-12)*(-2)] - [8 + (-4)]] işleminin sonucu kaçtır?', '20', '18', '16', '22'),
(79, '2', '[[9 + (-1)] * [(-6) + (-4)]] işleminin sonucu kaçtır?', '-80', '-70', '-60', '-90'),
(80, '2', '[(10 - (-5)) ÷ [(-3)+(-2)]] işleminin sonucu kaçtır?', '-3', '-2', '-4', '-1'),
(81, '2', '[(-9) - [(-2)*3]] işleminin sonucu kaçtır?', '-3', '-15', '-5', '-7'),
(82, '2', '[[(-2)*5] + [(-4)*(-3)]] işleminin sonucu kaçtır?', '2', '0', '1', '3'),
(83, '2', '[(20 + (-10)) * [(-2)*(-2)]] işleminin sonucu kaçtır?', '40', '30', '36', '44'),
(84, '2', '[(-16) + (-4)] * [(-3) - 2] işleminin sonucu kaçtır?', '100', '90', '80', '110'),
(85, '2', '[(-15)*2] + [[-4 + (-1)] * (-3)] işleminin sonucu kaçtır?', '-15', '-12', '-10', '-18'),
(86, '2', '[[(-10)*(-10)] + [(-1)*5]] işleminin sonucu kaçtır?', '95', '100', '90', '85'),
(87, '2', '[[(-8)+(-2)] ÷ 2] işleminin sonucu kaçtır?', '-5', '-4', '-6', '-7');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oyunkayitlari`
--

DROP TABLE IF EXISTS `oyunkayitlari`;
CREATE TABLE IF NOT EXISTS `oyunkayitlari` (
  `id` int NOT NULL AUTO_INCREMENT,
  `kullanici_id` int NOT NULL,
  `oyun_modu` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `puan` int NOT NULL,
  `oyun_tarihi` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `kullanici_id` (`kullanici_id`)
) ENGINE=MyISAM AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `oyunkayitlari`
--

INSERT INTO `oyunkayitlari` (`id`, `kullanici_id`, `oyun_modu`, `puan`, `oyun_tarihi`) VALUES
(6, 3, '0', 74, '2024-12-11 22:57:03'),
(7, 3, '0', 295, '2024-12-11 22:58:58'),
(16, 5, '0', 294, '2024-12-12 11:29:12'),
(17, 5, '2', 190, '2024-12-12 11:34:13'),
(43, 8, '0', 49, '2024-12-24 06:12:10'),
(38, 8, '2', 267, '2024-12-24 00:38:33'),
(39, 8, '2', 269, '2024-12-24 00:42:30'),
(40, 8, '2', 192, '2024-12-24 00:48:08'),
(41, 8, '2', 243, '2024-12-24 00:54:21'),
(42, 8, '2', 126, '2024-12-24 00:58:58');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
