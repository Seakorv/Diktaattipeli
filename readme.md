# Diktaattipeli

## Pelin idea

Pelin ideana on opettaa eri asteikoita niitä kuuntelemalla. Pelissä taustalla soi aina musiikki, jonka melodia ja harmonia sisältyy yhteen asteikkoon. Pelaajan on tarkoitus tunnistaa asteikko soivan musiikin perusteella. Pelissä on kolme eri pelimuotoa, joissa asteikoita voi oppia eri tavoin. Pelin vaikeustasoa voi säätää päävalikosta. Vaikeutta peliin lisätään vastausvaihtoehtojen läheisyys toisiinsa (esim. Fryyginen-lokrinen-aiolinen-doorinen). Pelaaja voi myös valita mitä moodeja on pelissä mukana (Diatonisen asteikon, Harmonisen mollin, Melodisen mollin jne.) vai onko kaikki yhtäaikaa.

Ensimmäisessä pelimuodossa pelaaja arvaa neljästä eri vaihtoehdosta oikean asteikon taustalla soivan musiikin perusteella. Oikean arvattua vastausvaihtoehdot ja taustalla soiva musiikki vaihtuu. Peliä pelataan niin kauan kunnes aika loppuu. Tavoitteena on pelata niin pitkään kuin pystyy ja oikeista vastauksista saa pisteitä. Vääristä jäljellä oleva aika lyhenee. Kappaleita on tavoitteena olevan monta ja yhdestä kappaleesta on monen eri asteikon versioita. Kappaleet toisaalta valitaan satunnaisesti, joten samat kappaleet voivat toistua yhdellä pelikerralla. Tämän takia niitä on tavoitteena olla monta, jottei tämä kovinkaan useasti käy ja saman kappaleen eri versiot pakottavat pelaajan kuuntelemaan tarkasti aina.

Toisessa pelimuodossa taustalla soi ensimmäisen pelimuodon tyyliin musiikki ja pelaaja valitsee asteikon äänet kahdestatoista näppäimestä. Kun asteikon oikeat äänet on valittu, vaihtuu asteikko. Tässäkin pelimuodossa kerätään pisteitä oikeilla vastauksilla. Oikeat sävelet valittua asteikko valmistuu automaattisesti, joten vääriä vastauksia ei voi antaa. Jos asteikko ei ole oikein, peli ei etene. Tässä pelimuodossa pelataan myöskin aikaa vastaan, mutta aikaa ei kulu vääristä vastauksista. Tämän pelimuodon tavoitteena onkin opettaa asteikoita perusteellisemmin ilman väärien vastauksien aiheuttamaa stressiä.

Kolmas pelimuoto on niin sanottu "hiekkalaatikkopelimuoto". Tässä pelimuodossa ei kerätä pisteitä tai yritetä saada oikeita vastauksia. Käyttöliittymän yläreunassa on painikkeet, joilla voi valita soivan asteikon. Käyttöliittymän keskellä on asteikon sävelet intervallinumeroin, eli 1, 2, 3 jne. Sävelille annetaan asteikosta riippuen mahdollisuus vaihtaa niiden sävelkorkeutta puolikkaan sävelaskeleen ylös tai alas. Näitä vaihtelemalla taustalla soiva biisi myös muokkautuu vaihdettujen sävelien mukaan ja asteikon nimi myös vaihtuu vastaamaan oikeaa. Pelimuodon ideana on siis antaa pelaajalle testausalue, jossa pelaaja voi tutkia miltä mikäkin asteikko kuulostaa ja tutkia toisia lähellä olevien asteikoiden eroja.

Pelin ydindiagrammi:
- Ydinmekaniikka: Kuunteleminen
- Sivumekaniikka: vastauksien valitseminen
- Progressio: Pisteiden kerääminen ja ennätyksen parantaminen
- Narratiivi: Asteikoiden kuulemisen opettaminen pelaajalle

Pelissä kerätään tilastoja asteikkojen osaamisesta, joita pelaajat voivat käydä katsomassa mitkä osaa paremmin ja mitkä huonommin.

**Haasteita pelin konseptissa**
- Onko peli pelillisesti mielenkiintoinen?
	- Tavoitteena on tehdä opettavainen peli jota on hauska pelata. Pelin opettavaisuuden ja pelillisyyden välillä pitää tehdä tasapaintousta tarkkaan.
	- Jos taustalla soivat kappaleet ovat hirveitä, peliä ei ole kiva pelata. Niistä pitää myös tehdä tarpeeksi selkeitä ja simppeleitä, jotta niistä on mahdollista nopeasti kuulla jotain.
- Toimiiko kappaleiden välillä vaihtelu? Tämä tapahtuu ainakin ensimmäisessä pelimuodossa toivottavasti melko tiheään tahtiin, joten saattaa olla aika sekavaa. Kappaleiden pitää olla myös tyyliltään melko lähellä toisiaan, jottei korvat väsy totaaliseen vaihteluun
	-  Jos tyyliä haluaa vaihtaa, voisi pelissä olla aina muutaman kysymyksen välein radikaalimpi tyylilajimuutos joka arvotaan.
- Oppiiko pelaajat oikeasti asteikoita peliä pelatessa?
	- Tämä selviää kun tekee pelin demoa pidemmälle ja testaa sitä ihmisillä. Tämä on myöskin suunnitellutieteellisen gradun pääpointteja. Peli on suunnittelutieteen artefakti ja sillä tavoitellaan kohdeyleisön opettamista. Sitä testataan sopivalla kohdeyleisöllä
- Oppivatko pelaajat liian nopeasti asteikot ja pelistä tulee todella tylsä?
	- Tätä tavoittelen saman kappaleen, mutta vain asteikon tyypillisen äänen vaihtelulla. Pelaajan on silloin pakko kuunnella tarkkaan. Asteikon tunnusomaisen piirteen pitää kyllä olla nopeasti kuultavissa kappaleesta, jottei pelaaja turhaudu.

## Kohdeyleisö

Pelin kohdeyleisönä toimii muusikot, musiikkia opiskelevat ja musiikkia harrastavat ihmiset. Peli vaatinee myös pientä kilpailullisuutta pelaajilta, jotta pistemekaniikka motivoi pelaamaan peliä. Vaikeustasojen säätely mahdollistaa kohdeyleisön suuntaamisen niin pitkän linjan muusikoille kuin vain vähän aikaa harrastaneille. Peli ei kuitenkaan suuntaudu pienille lapsille tai musiikkiharrastuksen aivan alkumetreillä oleville.

## Grafiikat ja visuaalinen tyyli

Grafiikat tähän peliin teen todennäköisesti itse hyvin yksinkertaisia elementtejä käyttäen. Pelin visuaalinen tyyli on tavoitteena olla hyvin yksinkertainen, mutta miellyttävä. Värimaailma on iloinen, jotain keltaisen ja vihreän suuntaan taipuvaa. Pelin käyttöliittymä koostuu yksinkertaisista näppäimistä ja teksteistä.

## Musiikit ja äänet

Pelin on tarkoitus olla pirteä ja miellyttävä. Musiikki ei tule olemaan rauhallinen, jotta kilpailullisuuden tunne pysyy pelaajalla ja asteikot ovat nopea kuulla musiikista. Pelillisen kuuloinen fuusojazz on musiikin pääasiallinen tyylilaji.

Ääniefektejä pelissä ei ole paljon, jottei ne häiritse taustamusiikin kuuntelua. Ensimmäisen pelimuodon vastauksista tulee äänivaste, joka sopii taustamusiikkiin. Ajan ollessa vähissä, musiikin tempo nopeutuu super mario bros -tyyliin. Toisessa ja kolmannessa pelimuodossa asteikon ääniä valitessa kuulee äänen mitä valitaan. Valittava ääni kuuluu selkeästi taustamusiikin päällä, mutta se on myös tyyliin sopiva.

Kaiken ääneen liittyvän teen myös itse. Musiikin sujuva vaihtelu hoituu Wwisellä hyvin ja äänien tekeminen Logic Pro X:llä.

## Kontrollit

Peli on tarkoitettu pääasiallisesti puhelimella ja tabletilla pelattavaksi. Tavoitteena on saada peli toimimaan täydellisesti vain yhtä sormea käyttäen, puhelimella peukaloa ja tabletilla esimerkiksi etusormea. Pelistä tehdään myös täysin toimiva tietokoneversio, jossa kaikki toiminnot tehdään hiireä klikkaamalla.

## Käyttöliittymä

Käyttöliittymä toteutetaan käytännössä täysin näppäimillä, paitsi asetuksissa on liuku, jolla voi säätää ääniefektien ja taustamusiikin voimakkuutta. Käyttöliittymän on tarkoituksena olla hyvin yksinkertainen ja selkeä.

## Monetisaatio

Koska teen pelin yliopisto-opintojeni yhteydessä, pelillä ei tavoitella rahallista hyötyä. En pohdi siksi tätä sen enempää.!



## MVP

Minimum Viable Product:
- Pelissä on kaksi pelimuotoa, jotka toimii vähintään yhdellä kappaleella ja kaikilla diatonisilla moodeilla, harmonisen mollin moodeilla ja melodisen mollin moodeilla
- Pisteenlasku ja henkilökohtainen highscore-systeemi toimii.
- Tilastot asteikkojen osaamisesta keräytyy talteen pelaajan tutkittavaksi
- Pelimuodoissa aika toimii ja ensimmäisen pelimuodon virherankaisut toimivat
- Toimii tietokoneella ja iPad ja iPhone -simulaattoreissa Xcodessa.
- Testaamista varten pitäisi saada joko selainversio tai jopa mobiiliversio toimimaan.
