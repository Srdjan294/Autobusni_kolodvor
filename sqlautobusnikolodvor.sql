SELECT name, collation_name FROM sys.databases;
GO
ALTER DATABASE db_aa67a1_autobusnikolodvor SET SINGLE_USER WITH
ROLLBACK IMMEDIATE;
GO
ALTER DATABASE db_aa67a1_autobusnikolodvor COLLATE Croatian_CI_AS;
GO
ALTER DATABASE db_aa67a1_autobusnikolodvor SET MULTI_USER;
GO
SELECT name, collation_name FROM sys.databases;
GO

create table mjesta(

	sifra int not null primary key identity(1,1),
	naziv varchar(255) not null

);

create table relacije(

	sifra int not null primary key identity(1,1),
	polaziste int not null,
	odrediste int not null,
	cijena decimal(18,2) not null

);

create table korisnici(

	sifra int not null primary key identity(1,1),
	ime varchar(255) not null,
	prezime varchar(255) not null,
	email varchar(255),
	brojMobitela varchar(255) not null

);

create table racuni(

	sifra int not null primary key identity(1,1),
	korisnik int not null,
	datumKupnje datetime 

);

create table stavke(

	racun int not null,
	relacija int not null,
	kolicina int,
	datumPutovanja datetime
);

alter table stavke add foreign key (racun) references racuni(sifra);
alter table stavke add foreign key (relacija) references relacije(sifra);

alter table racuni add foreign key (korisnik) references korisnici(sifra);

alter table relacije add foreign key (odrediste) references mjesta(sifra);
alter table relacije add foreign key (polaziste) references mjesta(sifra);

insert into mjesta(naziv) values
('Beli Manastir'),('Belišće'),('Benkovac'),('Biograd na moru'),('Bjelovar'),('Buzet'),('Cernik'),('Cres'),('Crikvenica'),('Čakovec'),('Čazma'),
('Daruvar'),('Delnice'),('Donji Miholjac'),('Drniš'),('Dubrovnik'),('Dugo Selo'),('Ðakovo'),('Ðurđevac'),('Garešnica'),('Glina'),('Gospiæ'),
('Grubišno Polje'),('Imotski'),('Ivanec'),('Ivanić-Grad'),('Karlovac'),('Knin'),('Koprivnica'),('Korčula'),('Krapina'),('Križevci'),('Krk'),
('Kutina'),('Labin'),('Ludbreg'),('Makarska'),('Mali Lošinj'),('Metković'),('Mursko Središće'),('Našice'),('Nova Gradiška'),('Novalja'),
('Novi Marof'),('Novi Vinodolski'),('Novigrad'),('Novska'),('Ogulin'),('Omiš'),('Opatija'),('Orahovica'),('Osijek'),('Otočac'),('Pag'),
('Pakrac'),('Pazin'),('Petrinja'),('Plitvička Jezera'),('Ploče'),('Poreč'),('Požega'),('Pregrada'),('Pula'),('Rab'),('Rijeka'),
('Rovinj'),('Samobor'),('Senj'),('Sinj'),('Sisak'),('Slatina'),('Slavonski Brod'),('Split'),('Stari Grad'),('Stubičke Toplice'),('Sukošan'),
('Sveti Ivan Zelina'),('Šibenik'),('Trogir'),('Umag'),('Valpovo'),('Varaždin'),('Varaždinske Toplice'),('Velika Gorica'),('Vinkovci'),
('Vir'),('Virovitica'),('Vodice'),('Vojnić'),('Vrbovec'),('Vrbovsko'),('Vukovar'),('Zabok'),('Zadar'),('Zagreb'),('Zlatar'),('Županja');


--select * from mjesta;


insert into relacije(polaziste, odrediste, cijena) values
--Beli Manastir
(1, 95, 23.40), (1, 52, 4.70), (1, 72, 11.30),
--Belišće
(2, 52, 4.70), (2, 95, 23.40),
--Benkovac
(3, 94, 37.07), (3, 95, 19.00), (3, 16, 14.00), (3, 78, 5.00),
--Biograd na moru
(4,65,24.60),
--Bjelovar
(5,95,6.00),(5,90,3.42),(5,32,3.10),(5,52,11.58),(5,26,6.03),
--Buzet
(6,63,3.10),(6,95,25.40),(6,27,24.00),(6,56,3.10),(6,60,7.10),(6,80,9.70),
--Cernik
(7,61,4.70),(7,95,13.40),(7,42,2.30),
--Cres
(8,65,16.00),(8,95,28.20),(8,38,9.00),(8,66,16.00),
--Crikvenica
(9,95,16.00),(9,65,7.00),(9,82,16.00),(9,27,14.60),(9,43,6.00),(9,73,31.30),(9,33,14.00),(9,52,40.40),
--Čakovec
(10,95,11.68),(10,82,3.05),(10,73,30.00),(10,78,30.30),
--Čazma
(11,5,6.03),
--Daruvar
(12,95,13.30),(12,34,11.19),(12,29,4.56),(12,87,4.56),(12,70,9.10),
--Delnice
(13,95,13.20),(13,65,7.30),(13,82,13.20),(13,56,13.60),(13,63,19.20),
--Donji Miholjac
(14,52,6.60),(14,9,4.70),(14,90,4.70),(14,95,20.00),
--Drniš
(15,78,4.56),(15,95,25.00),(15,28,6.20),(15,73,4.56),(15,69,5.97),(15,27,15.93),(15,94,4.56),
--Dubrovnik
(16,95,33.00),(16,73,22.10),(16,78,27.40),(16,65,50.30),
--Dugo selo
(17,95,4.66),
--Đakovo
(18,52,5.10),(18,95,12.50),(18,39,16.40),(18,94,32.60),(18,22,16.40),(18,63,40.80),
--Đurđevac
(19,95,9.73),(19,29,2.93),(19,86,9.73),(19,63,25.70),(19,87,4.35),(19,94,16.20),(19,9,13.99),(19,82,5.71),
--Garešnica
(20,95,9.64),(20,34,4.56),(20,5,6.03),(20,12,5.20),(20,70,35.40),
--Glina
(21,95,9.50),(21,52,18.70),(21,9,13.99),(21,27,6.70),(21,70,7.56),(21,92,22.50),
--Gospić
(22,95,14.00),(22,58,6.80),(22,94,11.00),(22,68,12.90),(22,65,19.60),(22,16,19.00),(22,73,11.00),(22,64,12.90),(22,13,19.60),
--Grubišno Polje
(23,95,12.45),(23,87,4.56),
--Imotski
(24,73,13.45),(24,95,21.24),(24,52,18.70),(24,39,11.00),
--Ivanec
(25,95,17.60),
--Ivanić-Grad
(26,95,3.42),(26,65,12.99),(26,5,7.79),(26,70,3.42),(26,86,3.42),(26,94,14.47),
--Karlovac
(27,95,6.70),(27,65,14.80),(27,94,16.80),(27,73,22.70),(27,58,10.20),
--Knin
(28,78,6.37),(28,73,13.45),(28,95,17.25),(28,94,10.96),(28,69,5.97),(28,58,11.95),
--Koprivnica
(29,95,7.17),(29,19,2.93),(29,36,1.63),(29,86,7.17),(29,78,7.17),(29,94,18.00),(29,32,2.93),(29,82,3.77),
--Korčula
(30,16,14.50),(30,65,30.30),(30,73,19.50),(30,95,40.10),
--Krapina
(31,95,9.70),(31,93,6.20),(31,50,18.80),(31,82,9.56),
--Križevci
(32,5,5.60),(32,29,2.93),(32,95,5.90),(32,63,10.12),(32,86,5.99),
--Krk
(33,65,9.30),(33,95,24.40),(33,27,23.10),(33,63,9.30),(33,94,6.30),(33,9,13.60),
--Kutina
(34,95,9.40),(34,70,5.67),(34,87,6.65),(34,20,4.56),(34,12,7.56),(34,5,5.77),
--Labin
(35,63,8.10),(35,95,23.90),(35,65,8.10),
--Ludbreg
(36,82,4.76),(36,29,4.76),(36,10,3.05),(36,83,4.76),(36,95,3.05),(36,9,3.05),
--Makarska
(37,73,10.90),(37,78,15.40),(37,95,30.20),(37,94,20.90),(37,85,30.20),
--Mali Lošinj
(38,65,21.80),(38,52,40.60),(38,95,33.60),(38,8,9.00),
--Metković
(39,73,18.20),(39,95,42.00),(39,94,15.00),(39,16,7.00),(39,18,43.40),(39,59,5.60),(39,24,42.00),
--Mursko Središće
(40,10,4.76),
--Našice
(41,52,6.60),(41,51,4.20),(41,95,13.22),(41,18,6.60),(41,14,4.70),(41,61,6.00),(41,70,13.22),

select * from relacije;

select a.naziv as polaziste, c.naziv as odrediste, b.cijena as cijena
from mjesta a
inner join relacije b on a.sifra = b.polaziste
inner join mjesta c on c.sifra = b.odrediste;

-- insert u korisnici

insert into korisnici(ime, prezime, email, brojMobitela) values
('Marko', 'Marković', 'mmarkovic@gmail.com', '0983843847'),
('Marin', 'Marić', 'mmaric@gmail.com', '0983843947'),
('Jasna', 'Jelić', 'jjelic@gmail.com', '0983842233');

-- insert u racuni

insert into racuni(korisnik, datumKupnje) values
(1,'2024-1-23'),(2,'2024-1-23'),(3,'2024-1-23');

-- insert u stavke

insert into stavke(racun, relacija, kolicina, datumPutovanja) values
(1,1,1,'2024-02-01'), (2,2,2,'2024-02-01'), (3,3,3,'2024-03-01');