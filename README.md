# Movie-Review
asp.net core c# project


Visoka škola strukovnih studija za informacione i komunikacione tehnologije

DOKUMENTACIJA

Katica Ranković 6/17

<https://github.com/KaticaKaja>

1





Visoka škola strukovnih studija za informacione i komunikacione tehnologije

Sadržaj

Table of Contents

[1.](#br3)[ ](#br3)[Opis](#br3)[ ](#br3)[projekta](#br3)[ ](#br3)[–](#br3)[ ](#br3)[Movie](#br3)[ ](#br3)[Review](#br3)[ ](#br3)[..........................................................................................................3](#br3)

[Funkcionalnosti](#br3)[ ](#br3)[:...................................................................................................................................3](#br3)

[Opis](#br3)[ ](#br3)[\[tehnički\]](#br3)[ ](#br3)[:](#br3)[ ](#br3)[.....................................................................................................................................3](#br3)

[Opis](#br3)[ ](#br3)[:](#br3)[ ](#br3)[.....................................................................................................................................................3](#br3)

[Dodatne](#br3)[ ](#br3)[informacije:](#br3)[ ](#br3)[............................................................................................................................3](#br3)

[Dijagram](#br3)[ ](#br3)[baze:](#br3)[ ](#br3)[......................................................................................................................................3](#br3)

2





Visoka škola strukovnih studija za informacione i komunikacione tehnologije

1. Opis projekta – Movie Review

Funkcionalnosti :

Registracija, login

Pretraga, paginacija, filtriranje

Crud operacije sa svim entitetima

Ograničen pristup sadržaju

Opis [tehnički] :

Korisnici mogu da pretražuju sve entitete, ali samo autentifikovani mogu da dodaju ‘’review’’

na određeni film I da ga ocene. Samo npr. administratori (ili kako god koncipiran sistem bio) mogu da

imaju kompletnu kontrolu nad sadržajem (crud nad svim entitetima).

Opis :

Korisnici imaju opciju login-a, registracije. Takođe mogu pretraživati filmove po godini,

nazivu I trajanju, glumcu u tom filmu, žanru. Utiske mogu filtrirati/pretražiti po nazivu, tekstu samog

utiska, filmu o kojem je kao I po korisnikovom username-u I samoj oceni. Kada se uloguju na sistem,

mogu dodati svoj utisak o određenom filmu I ostaviti ocenu za taj film.

Dodatne informacije:

‘’Admin’’ I ‘’Žika’’ korisnici se mogu koristiti za proveru, ostali korisnici su dodati faker-om I

šifre im nisu provučene kroz metod za enkriptovanje I dekriptovanje pa se ne mogu koristiti osim za

prikaz ili za brisanje. Šifre su 12345678 za oba korisnika.

3

Dijagram baze:

![dijagram baze](http://url/to/img.png)

