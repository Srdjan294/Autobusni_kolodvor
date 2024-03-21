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
(3, 94, 37.07), (3, 95, 19.00), (3, 16, 14.00), (3, 78, 5.00);
--Biograd na moru



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