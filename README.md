# Movie-Review
asp.net core c# project
__DOKUMENTACIJA__

> Katica Ranković 6/17

> Visoka škola strukovnih studija za informacione i komunikacione tehnologije

__Sadržaj__

1. Funkcionalnosti projekta
2. Tehnički opis
3. Opis
4. Baza podataka


Movie Review

1. Funkcionalnosti :

* Registracija, login

* Pretraga, paginacija, filtriranje

* Crud operacije sa svim entitetima

* Ograničen pristup sadržaju

* Mogućnost slanja e-maila

* Mogućnost upload-a fajla
---
 &nbsp;

2. Opis [tehnički] :

Korisnici mogu da pretražuju sve entitete, ali samo autentifikovani mogu da dodaju ‘’review’’

na određeni film I da ga ocene. Samo npr. administratori (tj. user-i sa neophodnim privilegijama) mogu da imaju kompletnu kontrolu nad sadržajem (crud nad svim entitetima).

 &nbsp;

3. Opis :

Korisnici imaju opciju login-a, registracije. Takođe mogu pretraživati filmove po godini,

nazivu I trajanju, glumcu u tom filmu, žanru. Utiske mogu filtrirati/pretražiti po nazivu, tekstu samog

utiska, filmu o kojem je kao I po korisnikovom username-u I samoj oceni. Kada se uloguju na sistem,

mogu dodati svoj utisak o određenom filmu I ostaviti ocenu za taj film.

__Dodatne informacije:__

‘’Admin’’ I ‘’Žika’’ korisnici se mogu koristiti za proveru, ostali korisnici su dodati faker-om I

šifre im nisu provučene kroz metod za enkriptovanje I dekriptovanje pa se ne mogu koristiti osim za

prikaz ili za brisanje. Šifre su 12345678 za oba korisnika.

 &nbsp;

4. Dijagram baze:

![dijagram baze](https://github.com/KaticaKaja/Movie-Review/blob/master/baza.png)

