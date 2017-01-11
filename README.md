# DutyCycle

Game Logic
-
- CPU design,
- CPU market,
- Prestige point (To release APIs to the market),
- Money (for the expenses of R&D staff, factories and production),
- R&D points (to make the 16-bit → MMX→ SSE → AVX transitions),
- 2D transistor factories,
- A world of users with certain incomes (1,000 low, 10,000 medium, 10 high),
- Turn-based world life,
- API and benchmark design (not in code, but with stacked blocks, in short stacks),
- The player will level up by gaining experience points. Attributes of the character:
 - Logical optimization: 1-100 (ALU productivity, productivity of CACHE algorithms, thread limit per core...),
 - Physical optimization: 1-100 (less heating, fitting in less amount of space, shorter data paths, less voltage...),
 - Prestige gaining rate: 1-100 (more prestige per won benchmark battle),
 - Ability to push an API with less prestige: 1-100,
 - Teamwork: 1-100 (will affect other staff's productivity),
 - Geniality: 1-100 (will only work on advertisements),
 - R&D point gaining rate: 1-100 (AVX commands can be unlocked in 8 turns instead of 10),
 - Experience point gaining rate: 1-100,
 - Error correction: 1-100 (processors won't have a missing transistor, softwares won't have security holes, optimization will be solid...),
- Gaining prestige for benchmarks that users do, gaining prestige and money for professional users who use other software, gaining experience for the amount of users who use the CPU, and for the usage rate of APIs.
- Companies will be able to get state support when they are weak, including the player's company.
- Start from the ENIAC times, all the way to 2050s.
- Important events in history will affect the game flow:
 - Earthquakes can destroy factories,
 - Wars will cause R&D loss and factory damage; even companies to be destroyed,
 - The staff of a company that has been bought by the player's company will be able to poorly produce their first product,
 - Other companies will strike an attitude when the player's company has less need for RAM, or when it starts producing its own RAM,
 - Other companies will stop at nothing when the player's company bans a certain API to others.
- When a CPU is revised or released to the market, it will have a chance of having a flaw; in that case, refund, re-revising, or making software correction will be necessary,
- It will be possible to start producing GPUs by either buying a GPU manufacturer with money or with R&D points by doing lots of R&D,
- Because of the production of GPUs, usable/producable benchmark or software count will increase,
- As the CPU die area increases, chance of CPUs having a flaw will increase,
- As the transistors get smaller, the chance of voltage leak will increase (there still will be flaw chance), so the voltage will be needed to be decreased.

Design
-
###  CPU Design Section ###
Drag&drop, user will be able to make the connections. (similar to LabVIEW)

- **Left side of the screen** tool box:
 - **1x32-bit FPU**－ Shape: --o-- (5 R&D points),
 - **2x32-bit FPU** － Shape: =o--o= when out-of-order operations arrive, they will both be used. Also the INT versions of these (if int versions don't exist, it will be necessary to emulate with software, so it will be really slow.). (20 R&D points),
 - **4x32-bit SIMD** － Shape: Little wide box, has input and output, but only one wire, not too much detail,
 - **1x64-bit SIMD** － Will only be able to make 512-bit calculations; won't make 32-bit calculations, but will take up less amount of space,
 - **Cache** － Properties like size, channel count, shape,
 - **32-bit memory controller** － Shape: --o-- (25 R&D points)

- **Middle of the screen** drag&drop area.
 - Because it has a tower defense logic, memory inputs will be from the four sides.
- **Right side of the screen** list of properties of the selected component. Frequency or voltage of each component will be adjustable.

### Market Section ###
Stock market up&downs of all companies, forum users' feedbacks and benchmark results.

Eğer tüm parçalar eşit frekansta çalışıyorsa işlemci fiyatı biraz azalacak. Farklı parça ama aynı frekans olursa, hem fazladan modüler yapı nedeniyle fiyatı artacak, hem de test sürecinin 1-2 tur uzamasına neden olacak.

Örneğin benchmark'lardan birinde `a = b + c` yazılmış olsun. Bu işlem, bellekten oku-topla-belleğe yaz şeklinde ayrı üç işlem olarak da gelebilecek. Gelişmiş işlemci ise tek komut ile de gelebilecek ama o gelişmiş komutu piyasaya itelemek için prestij harcanması gerekecek ki programcılar kullansın. Sonra bu 3 işlem sırayla soldaki bellek kontrolcüsüne, oradan dekodere, oradan ALU'ya, oradan register modülüne, oradan da bellek kontrolcüsüne gitsin; arka arkaya kırmızı-sarı-kırmızı renklerde işlemler, bloklardan geçerek ilerlesin. Tabii bunlar instruction'lar. Gerekli veri ise başka renklerde ve yine bellek kontrolcülerinden getirtilecekler, ama instruction cache ve data cache olarak bir şeyler eklenmişse ve aynısı yapılıyorsa bu cache'lerden gelecekler.

### Ana Menü ###
İtele, Ar-Ge, CPU tasarım, Satın al, Satışa çıkar, Takım, Çıkış menü seçenekleri.

- **İtele**: API, komut seti, benchmark seçenekleri.
 - **Benchmark**: İşlemcimize uygun (önceden hazıladığımız) bir benchmark'ı seçersek prestij puanımız azalır. Ama benchmark'ı kullanıcılara sunduğumuz için ve uzun süre kullanılacağı için diğer şirketler de bu benchmark yüzünden ezilecekler.
 - Başka bir şirketin benchmark'ını seçerek, o benchmark'ta kullanıcının donanımının özelliklerinin farklı olduğunu belirterek, o benchmark'ta eşitlik sağlanmasa da ezilmekten kurtululabilir. (Nvidia'nın DirectX 12'de yaptığı gibi)
- "Takım" ve "Ar-Ge" aynı sayfaya yönlendirecek, ama "Takım" kısmında bölge satış yetkilisinden bakım-onarıma, reklamcılığa kadar hepsi olurken, "Ar-Ge"de sadece Ar-Ge takımı gözükecek.

Benchmark hazırlama kısmıysa lego parçaları gibi üst üste konulan, farklı renklerdeki küplerle de olabilecek, klavyeden yazdığımız basit bir program parçasını küplere dönüştürmek de olacak ama bunun için komutları küplerle ilişkilendirmek gerekecek.

*İleride bu sayede çocukların programlama eğitimine destek sağlayabilir. Diğer programlama oyunlarıyla yarışması beklenemez tabii ki.*

Sonra bu küpler işlemci çalışırken bellek borularından geçerek işlemci modüllerinde küçük parçalara ayrılıp veya olduğu gibi geçip işlemi tamamlayacaklar. Ne kadar çabuk geçerlerse o kadar deneyim veya prestij de kazanılacak.

CPU tasarımında 3-5 çekirdekli bile olsa Drawcall 10,000-20,000'i geçemeyecektir. Cache, yamuk veya dikdörtgen olacak; onu çekirdeğe, ALU'ya bağlayan bus da ince bir dikdörtgen olacak.

Yani sanatsal anlamda da çok yük olmayacak ama diğer sayfalarda ekonomi kötüye giderken çatık kaşlı bir insan yüzü olabilir.

Oyuna başlarken bir karakter seçilecek:

- **Lisa T Su:** +35 API iteleme prestiji ile başlayacak (sadece API için harcayabilir)
- **Brian Krzanic:** 1 adet Ar-Ge aktivasyonu ve 1 adet patent(komut-seti) ile başlayacak
- **Ginni Rometty:** +25 mantıksal optimizasyon (karakter puanı) ile başlayacak ve her seviye atlama ile daha fazla eklenecek
- **Jen Hsun Huang:** En fazla 3 benchmark için +15'er iteleme puanına ek olarak her seviye atlamaya +2 güleryüzlülük eklenecek
- **Richard J Harshman:** 1 adet ücretsiz API ve 15 fiziksel optimizasyon puanu ile başlayacak ama her tur %10 ihtimalle 1 prestij kaybedecek

## Oyun Akışı ##
Her tur için farklı fazlar

1. **CPU tasarımı:** Oyuncunun canını sıkmayacak kadar basit hesabı olan, gerektiğinde baloncuğu tıklatınca ayrıntılara girilebilen (örneğin SIMD, içine girince toplama, çarpma, özel fonksiyonlar açığa çıkar, bunlar iptal edilebilirler) ve akıcı, hiç kasmayan bir görünüm.
2. **Banka işlemleri:** Borç alınsın, hisse açılsın, alınsın, satılsın.
3. **Fabrikalarla anlaşma:** SimCity kadar değil, Lemonade Tycoon'dan hallice, Theme Hospital tadında.
4. **Yazılım geliştirme:** Benchmark, API, işlemci hata testleri.
5. **Test sızdırmaları:** "X şirketinin y testi sonuçları silinmeden önce elimize geçti." gibi haberleri bloglara ve forumlara bilerek verme işlemi
6. **Seri üretime geçme:** Hangi fabrikada ne üretileceği, nerelere gönderileceği, hangi kıtada hangi fiyat olacak...
7. **Dünya yaşamı:** Oyuncunun kontrolünde olmayacak, kullanıcılar benchmark yapacak, forumlar test yapacak, bazı şirketler anlaşma yapacaklar, patlayan işlemciler bile olacak. En sonunda bunlardan para, prestij, Ar-Ge, deneyim puanları kazanılacak.
8. **Eleman kiralama:** Satın alımlar. Veya kâr elde etmek için işten çıkarmalar (prestiji azaltacak, kovulanlar başka şirketlere geçerse bazı teknolojileri gizlice üretebilecekler)

Oyun ekranının en altında bir gösterge olacak, diğer şirketlerin ortalamalarından çok gerideysek kumdan kale yapan bebek göreceğiz, şirket güçlendikçe o da büyüyecek ve en sonunda karakterimizin günümüzdeki haline dönüşecek. Mesela Lisa T Su ise fotoğrafı (güncel kalması için AMD sitesinden belirli aralıklarla indirecek)

**Şirket yönetim biçimi:** Efor/enerji miktarının belli alanlara paylaştırılması ile olacak:

- **Günlük çalışma süresi**
- **Mobbing** (örneğin şirket AMD, ama içinde kesinlikle NVidia'cı istemiyor. Elemanlara psikolojik baskı var.)
- **Moral, motivasyon**
- **Güvenlik, yedekleme ve fiziksel kondisyon** (şirket dışından gelecek tehlikelere de karşı önlem olarak)
- **Saldırı** (kule savunma mantığı burada da geçerli olacak, savaş zamanında komuta merkezi olan "kule"den lazer topları devreye girebilecek)
- **İstihbarat** (hem karşı şirketlere eleman yerleştirme, hem de savaş zamanında ana binalarına saldırı düzenleme gibi işlemler. Böylece düşmanlara karşı, onların yapabileceklerini iyi biliyor olacağız.)
- **Sağlık** ("HP" olarak değil, daha çok elemanların hastalanıp işe gelememeleri gibi, hastalık salgınlarına karşı. Mesela birisi hastalanmışsa günlük izin vermek için bir kutucuk işaretlenebilecek, ama yalan mı söylüyor öğrenmek için istihbarat'tan birisi o kişiyi uzaktan izleyecek.)
- **İş güvenliği**

Üstteki maddelerde grafiksel bir şey olmayacak, sadece matematiksel kısa bir hesap sonunda rapor olarak tur sonunda sunulacak ve varsayılan bir değerle başlayacak; sadece detaylı yönetim isteyenler bunları ayarlayabilecek ve görebilecekler.

Yani şirket yönetimine ne kadar çok kaynak (para) ayrılırsa, bu özellikler de o kadar iyi olacaklar.

---
Oyun dünyasındaki kullanıcıların gelir düzeylerine göre ayrılacaktı. Buna ek olarak rastgele özellikleri olacakk:

- **Program tercihi:** 1-100 arasında bir rastgele değerle başlayacak.
	- 1-40: Oyunlar
	- 41-70: Oyunlar, benchmark'lar ve ofis yazılımları
	- 71-89: Programlama araçları
	- 90-99: Web siteleri, online eğitim yazılımları ve masaüstü depo takip yazılımları
	- 100: Yapay zeka
	- Kullanıcının her turda bu puanını 1-2 arttırma (%50), 1 azaltma (%30) veya sabit bırakma (%20) olasılığı olacak.

- **Benchmark güven değeri:** 1-100 arasında bir rastgele değerle başlayacak.
	- 1: Benchmark'ları önemsemiyor, kafasına göre satın alıyor. ("Herhangi bir i5 işlemci istiyorum.")
	- 100: Benchmark'ları önemsiyor. ("i5-5775C işlemcisini istiyorum.").
	- Her tur, işlemcisinden istediği hızı veya fazlasını yakalamışsa, ve benchmark'lar da bu yöndeyse, bu puan 1 artar; değilse %50 oranla sabit kalır veya azalır.

- **Fanboy endeksi:** 1-25 arasında bir rastgele değerle başlayacak, en yüksek değer 100 olacak.
	- 1: Marka gözetmeksizin mantıklı seçimi yapar.
	- 100: Forumlardaki "fanboy" tanımına uyan kişi. Hep bir markanın ürünlerini seçer.
	- İlk işlemci hatasında veya iyi benchmark değerinde 1 artacak/azalacak, her tur bu değişim olasılığı azalacak. Örneğin başlarda her tur 1 puan değişme olabilecekken, 100 tur sonra bu değişimin olma olasılığı %1'e düşecek.

- **Hız ihtiyacı:** 1-30 arasında bir rastgele değerle başlayacak, en yüksek değer 100 olacak.
	- 1: "Oyunları açsın yeter, FPS fark etmez, Visual Studio'da Hello World yazabileyim yeter."
	- 100: "Gözüm hep FPS sayacında olduğu için frag kasamadım." veya "simülasyonum için en az 80 TFLOP gerekli."
	- Bu özellik, benchmark güven değerini etkiler. Artma eğilimindedir ama az olasılıkla azalabilir de.

- **Gelir değişim olasılığı:** %1-2 olasılıkla zengin olunabilecek veya iflas edilebilecek (3 turda bir kez çalışır)

- Her tur, her kullanıcı %1 olasılıkla yok olacak (istatistiksel olarak 10,000 kullanıcının 100 tanesi) ve dünyaya %2.1 olasılıkla yeni bir kullanıcı katılacak (her 2 kullanıcı başına %1.2, yani 10,000 kullanıcı için 102 yeni kullanıcı). Kullanıcının yaşı arttıkça %1 olan yok olma olasılığı, %5'e kadar çıkıp sabitlenecek. Böylece dünya sürekli değişecek.

- Kullanıcılara ek olarak her tur oyuncunun yok olma olasılığı da %1 olacak, ama spora ve sağlığa zaman ayırarak bu olasılık, %0.5'lere indirilebilecek. (Efor/enerji kısmında buna değinildi)

- **Overclock çılgınlığı:** 1-100 arasında bir rastgele değerle başlayacak.
	- 1: Overclock nedir bilmez, bozulursa garantiye gönderir.
	- 100: Örneğin: İlk gün i7'ye %50 OC yaptıktan sonra bozulmazsa, ertesi gün %60 OC yapar ve bozulursa yedekteki %40 OC'li i3 ile oyuna devam eder.)
	- Bu değerin 50'den farkına göre en fazla overclock tutturulabilecek.
		- 1: OC yapmayacak.
		- 20: Biraz OC yapacak ama sınıra yakın bile olmayacak.
		- 50: Sınıra kadar OC yapacak.
		- 70: Çok fazla OC yapacak ve sınırı geçebilecek.
		- 100: Bozulacak.
	- Hesabı şu şekilde olabilir:
		- `delta_frekans = (frekans(max) - frekans(stok)) * (1.0 - ((50.0 - çılgınlık) / 50.0))`
	- Kullanıcının OC yapma olasılığı da çılgınlık / 100 kadar olacak.
	- Yani çılgınlık 50 ise, %50 olasılıkla OC yapacak ama tam yapacak. Tam değeri çipe özgü olmayacak, tüm forumlarda yapılan benchmark'ların ortalaması olacak, ve çipin kendi maksimumu tamamen rastgele ama anlaşılan fabrika ile alakalı olacak, ve tabii çipin kalitesi ne kadar çok seçilmişse o kadar kaliteli olacak; hatta 7/24 bile çalışabilecek.


ÖNCE DÜZENLENECEK:
===
İşlemci dizayn sayfasındaki kontroller:

- SurukleBirak ---> farenin tıklandığı dünya kordinatını alır, sonraki karede son fare kordinatından çıkartır, delta x ve delta y olarak elde edilen vektör kadar kendi bağlı olduğu nesneyi kaydırır ama gene dünya koordinatlarında. Eğer buna bağlı cisimler ve onlara da bağlı başka cisimler varsa hepsini geçici olarak buna bağlar ve bununla beraber onlar da sürüklenir. Farenin basılı olan sol veya sağ tuşu bırakıldığında tıklı olan cisme bağlı olan nesneleri tekrar serbest bırakır ama konumları gene aynı kalır.(ortadaki parçaların yeri değiştirilirken) (arama işlemindeki bağdan kasıt, mantıksal bağ, bağlanmadaki bağ ise grafiksel bağ, oyun motorundaki yani)

- CevirBirak ---> farenin orta tuşu basılı tutularak yapılır. sağa sola oynattıkça tıklı olan parça ve ona bağlı olanlar onun etrafında (tabi bağlı oldukları için otomatik) dönecekler, orta tuş bırakılınca o açıda kalacak. (böylece kolayca bütün çekirdek döndürülebilecek)

- HayaletSurukleBirak ---> sürükle bırak gibi ama tıklanan cismin hafif transparan kopyası gelecek ve bırakıldığında gerçek bir kopyası yaratılacak.(toolboxtan alıp ortaya yerleştirme işlemi için mesela)

- BagliModulleriBul ---> bir parçanın üzerine fare imleci gelir gelmez, ona bağlı olan tüm parçalar bulunacak (atıyorum floodfill yöntemi gibi ama kordinat yerine mantık geçitlerindeki bağları takip ederek bulacak) ve siyah çerçeve oluşacak. Tüm işlemci bağlıysa tüm işlemcinin etrafında bir çerçeve oluşturacak. İki parça birbirine bağlıysa o ikisini içinde tutan bir çerçeve gözükecek yani tüm modülleri tek tek çerçeve değil de kabataslak çevreleyen çerçeve mesela.

Tabi doğal olarak hayaletli sürükle bırak yapılan cismin hayalet classı silinecek veya türü hayalet olmayana dönüştürülecek. Hatta true/false ile tek classtan bile türetilebilirler belki ducktyping gibi.
