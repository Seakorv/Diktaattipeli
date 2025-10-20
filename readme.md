# Diktaattipeli

## Suunnitelma
Tässä pelissä testaat korvasi kykyjä ja opit eri asteikoita.

Ydindiagrammi:
- Ydinmekaniikka: Kuunteleminen
- Sivumekaniikka: Pisteiden kerääminen
- Progressio: Vaikeustasojen avaaminen
- Narratiivi: Opi asteikoita ja kehitä korvaasi

Pelin ideana on kuunnella taustalla soivaa musiikkia ja päätellä mitä asteikkoa se käyttää. On kolme pelimuotoa, joista kolmaus on harjoitteluun tarkoitettu hiekkalaatikkopelimuoto. Peli pitää kirjaa pelaajan osaamista asteikoista, jotta tilastoista pelaaja näkee, mitkä osaa ja missä on kehitettävää. Main menussa pääsee valitsemaan pelimuodon, pääsee katsomaan profiiliaan jossa on asteikkojen osaamistilastot ja highscore näkyvissä sekä voi valita mitä asteikkotyylejä treenaa (Kirkkomoodit, harmonisen mollin moodit, melodisen mollin moodit, pentatoniset vai kaikki sekasin). Jokaiselle näistä on omat pistetilastot ja pelimuodoille on myös omansa. Hiekkalaatikkopelimuodossa pääsee myös leikkimään omalla luovuudella kun voi (melko)vapaasti testata asteikkojen eri ääniä ja miltä minkäkin äänen vaihtaminen kuulostaa. Peli tehdään Unityllä ja ääniin käytetään apuna Wwise audio middlewarea

Kahoot-tyylinen nopeuspeli:
- Kerätään pisteitä vastaamalla mahdollisimman paljon oikein
- Pelillä on kokonaisaika, joka pitenee oikeilla vastauksilla ja lyhenee väärillä
- Eteenpäin pääsee vain oikeilla vastauksilla ja vääristä vastauksista tulee ärsyttävä Guitar Hero -tyylinen
- Rikkaat rikastuu tyylinen pisteytys, eli mitä nopeammin saa oikean vastauksen, sitä enemmän pisteitä saa (Kahoot-tyyli)
    - Tässä vaihtoehdossa on hyvä juttu siinä, että peli voisi myös loppua joskus eikä tarvitsisi jatkua loputtomiin
    - Pisteiden määritys olisi sen verran rankaisevaa, että pitäisi olla epäinhimillisen nopea saadakseen teoreettiset maksimipisteet
    - Asteikkoja olisi kuitenkin sen verran monta, että heti ei kysymykset lopu ja uudelleenpelattavuus säilyy
        - Muutama eri biisi (yli 10, voivat nimittäin olla vain yhtä looppia)
        - Jokaisesta biisistä eri asteikkoversioita, jotta oikeasti pitää kuunnella joka kerta eikä voisi vain muistaa parin äänen jälkeen
    - Voisi olla myös sen verran rankaiseva, että pitäisi olla pelinkehittäjän tieto kappaleista, jotta voisi edes päästä loppuun
        - Tämä toteutettaisiin mieluummin niin, että on enemmän biisejä kuin että aika loppuu parin biisin jälkeen hyvilläkin suorituksilla
- Tavoitteena ei ole luoda ahdistusta, joten epäonnistuminen ei tapahdu ensimmäisen biisin aikana
    - Vaihtoehtoja on kivat neljä
    - Neljännellä vasta oikein pääsee vielä seuraavaan kappaleeseen
    - Vasta jos vastaat kahdessa kappaleessa yhteensä kuusi väärin ja kolmannessa vielä kerran väärin peli loppuisi
        - Tästä tulee opettavaisuus, koska mitään osaamattakin oppii kahden ensimmäisen oikeat vastaukset
- Ruudulla kuitenkin on aikaa näyttävä palkki
    - Tämä välttämättä tuo ahdistusta, mutta se kulkee sen verran hitaasti, että sen ei pitäisi olla ongelma
    - Ahdistus on myös peleissä hyvä ja nopeuspeleissä tämän välttäminen on mahdotonta
    - Palkki alkaa täynnä ja vaihtaa väriä vihreästä punaiseksi ajan vähentyessä
        - Punavihervärisokeat ignoorattu mutta palkin näkee tottakai myös muutenkin niin ei pitäisi olla ongelma
        - En jaksa värisokeamodea tehdä
- Biisien siirtymät nopeuspelissä pitää tehdä hyvin ettei kuulosta hirveältä
    - Saattaa joutua tekemään pientä viivettä eri kysymysten välillä, joten aika ei saisi kulua näissä
    - Toisaalta nämä voi ottaa kokonaisajassa huomioon niin ei tarvitse erikseen säätää

Päättele asteikko Scaledokun alun tyyliin:
- Taustalla soi biisi ja edessä on kromaattinen asteikko
- Kromaattisesta asteikosta pitää painella oikeat asteikon äänet
- Oikeiden äänien valinnan jälkeen asteikon nimi tulee esille ja siirrytään seuraavaan kappaleeseen
- Kromaattisessa asteikossa näkyy sävelien nimet, mutta priimi on aina valmiiksi lukittu, jotta asteikon perusääni tulee selväksi.
- Peli on myöskin nopeuspeli, mutta vaatii pelaajalta enemmän tietämystä
- Nopeuspeli estää sen, että arvaa vain jokaisen äänen ja pääsee oikeaan, koska tietämällä pääsee nopeammin eteenpäin
- Äänien valitsemisella ei ole rajaa, eli voi vaikka valita kaikki kaksitoista ääntä
    - Asteikoilla on eri määrä ääniä tietyissä tilanteissa, joten rajaaminen johonkin lukuun voisi spoilata asteikon tyylin (esim pentatoninen sallisi vain 5)
- Vääriä vastauksia ei siis ole, ei vain pääse eteenpäin ennen kuin on oikea asteikko valittuna
- Biisit ovat samoja kuin ensimmäisessä pelimuodossa

Hiekkalaatikkopelimuoto:
- Samaan tyyliin kuin toisessa pelimuodossa valitaan asteikon äänet kromaattisesta asteikosta
- Asteikko on valmiiksi näkyvissä (valmiiksi valittuna) ja sitä voi siitä lähteä muokkaamaan
- Sävelien vaihtaminen vaihtaa soivan kappaleen asteikkoa.
- Asteikon nimi on aluksi jo näkyvissä ja sävelien vaihtaminen vaihtaa myös sitä
- Pitää testata, kuinka helppoa on luoda kappale, jonka asteikon jokaista ääntä voi vaihtaa
    - Vähemmän vapaa versio voisi olla, että asteikkoa voisi muokata vain ylentämällä/alentamalla asteikon ääniä
    - Asteikon äänien määrää ei myöskään voi vaihtaa. Äänien lisääminen ja poistaminen asteikosta tekee asiasta varmaankin liian vaikeaa sävellyksen näkökulmasta
- Voisi olla kaksi eri tyyliä myös tässä ja tyylin voisi vaihtaa lennosta
    - Valittavaksi asteikon nimiä ja asteikko vaihtuu aina kerralla
    - Scaledokutyyli jossa on sitten helppo testailla yhden äänen eroja
- Biisejä voisi olla viiden, kuuden ja kahdeksan äänen asteikoille. Montaa eri kappaletta ei tarvitse, mutta pelimukavuuden takia voisi olla tyylilajivaihtelua kuitenkin
    - Viiden äänen asteikot ovat pentatonisia
    - Kuuden äänen asteikot ovat blues ja kokosävel
    - Kahdeksan äänen asteikot ovat “normaalit”
    - Kuuden äänen asteikot voisi olla vasta joku tulevaisuuden lisäys, tärkeimmät ovat varmaankin “normaalit” asteikot

## MVP

Minimum Viable Product:
- Pelissä on kaksi pelimuotoa, jotka toimii vähintään yhdellä kappaleella ja kaikilla kirkkomoodeilla, harmonisen mollin moodeilla ja melodisen mollin moodeilla
- Pisteenlasku ja henkilökohtainen highscore-systeemi toimii.
- Tilastot asteikkojen osaamisesta keräytyy talteen pelaajan tutkittavaksi
- Pelimuodot ovat kahoot tyyli ja scaledoku tyyli
- Pelimuodoissa aika toimii ja ensimmäisen pelimuodon virherankaisut toimivat
- Toimii tietokoneella iPad ja iPhone -simulaattoreissa Xcodessa
