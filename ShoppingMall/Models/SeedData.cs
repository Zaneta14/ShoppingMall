using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingMall.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShoppingMallContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<ShoppingMallContext>>()))
            {
                // Look for any movies.
                if (context.Category.Any() || context.Subcategory.Any() || context.Employee.Any() || context.Shop.Any() || context.Application.Any())
                {
                    return; // DB has been seeded
                }
                context.Category.AddRange(
                new Category { Name = "Шопинг" },
                new Category { Name = "Храна" },
                new Category { Name = "Услуги" }
                );
                context.SaveChanges();
                context.Subcategory.AddRange(
                new Subcategory { Name = "Облека и обувки", CategoryId = context.Category.Single(c => c.Name == "Шопинг").Id },
                new Subcategory { Name = "Часовници и накит", CategoryId = context.Category.Single(c => c.Name == "Шопинг").Id },
                new Subcategory { Name = "Спортска опрема", CategoryId = context.Category.Single(c => c.Name == "Шопинг").Id },
                new Subcategory { Name = "Солени јадења", CategoryId = context.Category.Single(c => c.Name == "Храна").Id },
                new Subcategory { Name = "Десерти", CategoryId = context.Category.Single(c => c.Name == "Храна").Id },
                new Subcategory { Name = "Телекомуникации", CategoryId = context.Category.Single(c => c.Name == "Услуги").Id },
                new Subcategory { Name = "Убавина", CategoryId = context.Category.Single(c => c.Name == "Услуги").Id },
                new Subcategory { Name = "Аптеки", CategoryId = context.Category.Single(c => c.Name == "Услуги").Id }
                );
                context.SaveChanges();
                context.Shop.AddRange(
                new Shop
                {
                    Name="Bitsiani",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/bitsiani.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/bitsiani.jpg",
                    Location = "Прв кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227-409",
                    Email= "bitsiani@fashiongroup.com.mk",
                    Description= "Bitsiani S.A е основан во 1986 од страна на дизајнерот Aristotelis Bitsiani како чекор напред во креативното дизајнирањето на машката облека.\n\n" +
                    "Развојот со брзо темпо и овозможува на компанијата лидерска позиција на грчкиот пазар и истовремено станува синоним за бренд кој произведува квалитетна облека за модерни европски мажи.\n\n" + "" +
                    "Bitsiani е првиот бренд кој Fashion Group го вклучува во своето портфолио во 1995 година.",
                    SubCategoryId= context.Subcategory.Single(c => c.Name == "Облека и обувки").Id
                },
                new Shop
                {
                    Name = "Mango",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/mango.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/IMG_1927.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227-132",
                    Email = "mangoscm@gmail.com",
                    Description = "Мода за урбана, атрактивна и модерна жена.Секоја сезона Mango нуди облека и модни додатоци кои се во согласност со најновите модни трендови, дополнети со квалитет и разумни цени.\n\n"+
                    "Иако е шпански бренд со седиште во Барселона, стратегијата на Mango е да има што поголема интернационална застапеност, што резултира во отворање на 2.415 продавници во 107 земји во светот.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Облека и обувки").Id
                },
                new Shop
                {
                    Name = "Okaidi",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/okaidi.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/okaidi.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227 125",
                    Email = " okaidi@fashiongroup.com.mk",
                    Description = "Okaidi е француски бренд за деца, официјално лансиран во септември 2000-та година.\n\n"+
                    "Во 2001 година навлегува на британскиот пазар и со тоа станува интернационален бренд.\n\n"+
                    "Современите интереси на детскиот свет се интегрирани во дизајнот на Okaidi, не занемарувајќи го детскиот сензибилитетот и детскиот став.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Облека и обувки").Id
                },
                new Shop
                {
                    Name = "Fashion&Friends",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/fashion-and-friends.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/fashion-friends.jpg",
                    Location = "Прв кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227 131",
                    Email = "fnf@fashiongroup.com.mk",
                    Description = "Fashion&Friends e концепт на мултибренд продавници каде се среќаваат најголемите имиња во урбаната облека, обувки и галантерија како Replay, Diesel, Hugo Boss Orange, Gaudi, Guess, Levi’s, Scotch&Soda, Maison Scotch, Desigual, New Zealand и Cesare Paciotti.\n\n"+
                    "СОВРЕМЕНИОТ MIX & MATCH концепт е поврзан со експериментирање на стајлинг од различни брендови.Kога ќе се навикнете на ваков стил на облекување станувате TREND SETTER, или она во кој секој гледа кога се зборува за мода.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Облека и обувки").Id
                },
                new Shop
                {
                    Name = "Timberland",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/timberland.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/Timberland.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227-109",
                    Email = "timberland@fashiongroup.com.mk",
                    Description = "Моден бренд кој има за цел да направи разлика во животот на потрошувачите. Timberland произведува обувки и облека за сите категории на потрошувачи.\n\n"+
                    "Timberland работи со висока технологија со цел да обезбеди квалитетни производи, кои се удобни да се носат преку целиот ден и се во добра форма во текот на целата година.\n\n"+
                    "Истовремено, општествената одговорност кон животната средина е главниот принцип според кој фукнционира оваа компанија.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Облека и обувки").Id
                },
                new Shop
                {
                    Name = "Božinovski",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/07/bozinovski.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/07/Bozinovski.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 30 81 722",
                    Email = " citymall@bozinovski.com.mk",
                    Description = "Брендот Божиновски часовници и накит веќе 20 години е синоним за успех и квалитет обединувајќи ги луксузот, убавото живеење, стилот и луѓето преку искуства кои инспирираат. Компанијата Божиновски часовници и накит, пионер во стилот и иновацијата во Македонија уште од 1996 година, започна со работа во Битола и набрзо ја прошири својата продажна мрежа и во Скопје. Покрај трите сопствени продажни салони, Божиновски ги нуди своите производи и низ мрежата на агенти и франшизи низ Македонија. Компанијата веќе 20 години создава вредности, доверба и квалитет, кои секојдневно преку вложување и грижа кон своите вработени ги пренесува на сите свои купувачи. Брендот Божиновски, како официјален претставник, е препознатлив по врвните, исклучителни модели на: Omega, Breitling, Longines, Hamilton, Montblanc, Tissot, Ititoli, Calvin Klein, Swatch, Troika, и Flik Flak. Кај нас, за сите ваши посебни моменти, можете да најдете и уникатни колекции на златни прстени.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Часовници и накит").Id
                },
                new Shop
                {
                    Name = "MY:TIME",
                    LogoUrl = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAflBMVEX///8AAACUlJTs7Ozm5ub8/Pzv7+9ERERBQUFqampQUFC+vr6lpaVJSUnb29v29vbNzc0PDw/g4OCFhYVlZWV+fn6vr69hYWGbm5ujo6M4ODiysrK7u7vS0tKWlpbExMQsLCwdHR13d3ckJCRZWVkzMzNxcXGEhIQVFRUgICDaLQItAAAFNUlEQVR4nO3Y2XqCOAAF4CQsbggoBXHFrWrf/wUnIQsJ0qrVmbbznf+ihQgkh4SwEAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPBtwXrJMlak3k835F9SzajWL4Kfbs3rVQtqm0Q/3aBXy2WwASs3+bZeHIfuFv72PXZLisOb+DfrjXuJKeuPt60d5fEXPcdWD5L5oj/Ty7PD3N3L2+7qgwWLsWXxjQGW1B2Y6wRheRDrazchL5k6ASkdiv8p/2Gvm8SXs64aZrRFt5Lxa0Iv9yl1ho6osp4Tgu597xfwQ9Ojb5cwcSSnz0R1F2ubEVUJyanZdEDpLiEdjvck7PHyZbNP+GEnnBjfSChOcNkqEz1zscebSEh3ZpqtqEmYiDFdL63dJtp7x1NOHPTsiyVz8toJ6Ur/ktRXi0nYukQeEnUEJCQW/Wq3sT71F9VDKW0SivEqg/HB3vuqJjGIN27RVUJayZWkT1+VUHRB3lE+amoTZEL6XkeMqZ2QjPkykUmthnjnrDViRULmFl0npKm98oqEGaWHzh/4/Lpt1kTCQkUUAQ+sSTitT1JoTTlC310l9yRkfTnFBUMxsCYvSZhcrLHv/mLOp06YrKgYh6KhE69oEoqzRP29PuWSaNbbowmLenqJ66lhGdp96JPv4lPGxyc/5XYnyKl7KcammAKm4vI1CYMd71xe6tzPMmeUC7cTRsTjHTd5o2LRuVvoG2p/9mjC/JM7GKmnxubuqqor5OUREyehnFrpzt3fb9/770lI/El9rPKz++H7ownH9lB0iWFqGqmrm+vJwEkob+nV9TEcdyWsr+r6rHcnvDwQTu/sDPHYOvFj6wI31W3UKXEThtdX3bX7EoqJ7OxU+dR1GLjTAz96v5niZ1a3mOpIKlO7CcW2rbGwPh6nbsmdCck0dat8ai5tJ+Sz9MJE5K0e6WW/tWE74dtVQj4hndySexO2q3w6oT0AxH3IRBw+lXDyOxKKJy175yE9mDqT3VMJC/rRatbPJNy7j4pDmvGmH+pKxaT2RMJrzyT8/h2/cJ+Wh3waK3mtYkbd/KaExzft+ODbk0edd93BjjehlHMo/U0JLY++Hw7cltY2Ilh5M+HYWr2+W1zrTriw3vGdx75XJRRXW9FRLl+XTMIgDD3n0EkYhs6qd7tmvkvrhSrxmqO0f22q5Bs1Hv/YmdPu08+chH9ZsO2I6BXyneh/kVCOR/frQjURFz17fcIf+tRcf5R4X5mLYC3ez3jEk52wIHFMEvWcqr5PhHMWycsoKuUksY6JJ8fDuozkY2lRNnfrglnv1JmMu5xHiawgrMTfuiySZb7a3GcbeZBlQLomjZt88fpKPwZFlVarXH/+7jmjNCMeI5G8zP2z/qSmPmGtRkQmHaXEl01YxbpxVsc5I6WUp0kFJas1GZB45WwXq3qmSyKfANfL6tY72icY7dYkjFerGVEvyyzRb80qIdMTYnoqM9mqaqBuDOXZDI4qY8ncrKmETO0QML8fMhk3U6dQJ/TOkWpJ3vXV7C4eu3ydkOzLNZPnLxhEJ99JGOmBmKb1JMWNzNj0zEeEOfHz5pZXyISmX9nG07+aPlSfkLxNps5hdfOu+4U42g9aZtbjTjkiQ3mGq1jHIKpFwZ5lugG+7sNzndHfn03W6b7MctOHqm9Zrq7q9Zmc1BulLpvOznWy6YrsX5DwPxb+obYCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMDf9g+v9jzvS+brBAAAAABJRU5ErkJggg==",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2019/05/my-time.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 3091333",
                    Email = "contact@mytime.mk",
                    Description = "MY:TIME е компанија со семејна традиција од 1920-та година за продажба, дистрибуција и сервисирање на високо квалитетни часовници и накит.\n\n"+
                    "Ексклузивни застапници и дистрибутери сме за часовници и накит од брендовите: Fossil, Skagen, Emporio Armani, Michael Kors, DKNY, Diesel, Tommy Hilfiger, Casio, Edifice, Zeppelin, Esprit, Nautica, Morellato и Guess.\n\n"+
                    "На задоволство на нашите клиенти располагаме со сопствен сервис предводен од професионалци за сервис на часовници и накит од брендовите кои ги застапуваме.Покрај ова вршиме и сервисирање на часовници кои не се дел од нашето портфолио.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Часовници и накит").Id
                },
                new Shop
                {
                    Name = "Oxette",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/oxette.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/oxette.jpg",
                    Location = "Прв кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 30 60 210",
                    Email = "oxettemk@yahoo.com",
                    Description = "Oxette е бренд за независни и модерни жени кои ја сакаат модата и ја користат да ја изразат својата посебност.\n\n"+
                    "Oxette креира модерен накит, часовници и модни додатоци инспирирани од современата жена.\n\n"+
                    "Продажната мрежа на Oxette е во повеќе од 25 земји низ целиот свет. Продавниците на Original Marines може да се најдaт во целиот свет – постојат над 600 еден бренд продавници, а 66 од нив се во странство.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Часовници и накит").Id
                },
                new Shop
                {
                    Name = "Adidas",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/adidas.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/IMG_1651.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "02 3066 922",
                    Email = "scm2@urbanxstore.mk",
                    Description = "Adidas e водечки бренд во доменот на спортската опрема во светот. Компанијаta e основана од Adolf (Adi) Dassler во 1948-ма година, a името Adidas потекнува од името на основачот Adi Dassler.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Спортска опрема").Id
                },
                new Shop
                {
                    Name = "Nike",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/nike.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/nike.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 (0)2 3069404",
                    Email = "nikeshop@sportvision.mk",
                    Description = "Nike е водечки светски снабдувач на спортски обувки и облека и главен производител на спортска опрема. Од 2008 година Најк вработува 30.000 луѓе ширум светот. Седиштето на компанијата е во Бивертон, Орегон.\n\n"+
                    "Компанијата е основана во 1964 година од страна на Bill Bowerman и Philip Knight а во февруари 1972 година, ја преставиле својата прва линија Nike патики, со името Nike кое потекнува од името на грчката божица на победата.Слоганот ¨Just do it¨ кој се одржа до ден денес е креиран кон крајот на ’80 - те и веќе стана замена за името на самиот бренд кој го препознаваат сите генерации.\n\n"+
                    "Nike е производител не само на обувки за различни спортови туку и на спортска гардероба за фудбал, кошарка, тенис и други спортови. Nike амбасадори се водечките светски спортисти – Роже Федерер, Рафаел Надал, Коби Брајант, Џејмс Леброн, Кевин Дјурант, Тајгер Вудс, Марија Шарапова, Кристијано Роналдо, Неимар, и многу други.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Спортска опрема").Id
                },
                new Shop
                {
                    Name = "Burger King",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/burger-king-logo.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/burger.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 3051-625",
                    Email = "uskupcitymall_bk@tabgida.com.tr",
                    Description = "Burger King за прв пат е основан во 1954 година. Синџирот на ресторани за брза храна се застапени во над 74 држави, со повеќе од 12.100 локации.\n\n"+
                    "Секојдневно задоволни лица. Над 11,4 милиони секојдневни насмевки.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Солени јадења").Id
                },
                new Shop
                {
                    Name = "Spizzicotto",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/spizzicato.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/spizzicato.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 3074-018",
                    Email = "info@spizzicotto.com.mk",
                    Description = "Спицикото е еден од најстарите и најпознатите македонски брендови за свежо подготвена храна кој постои од 1998 година и кој во октомври 2012 година го отвори и своето трето продажно место овде.\n\n"+
                    "Сите состојки кои Спицикото ги користи за подготовка на производите се со висок квалитет и македонско потекло.Зад Спицикото стои тим од четириесетина вистински љубители на добрата храна, посветени на подготовка на вкусни и свежи оброци.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Солени јадења").Id
                },
                new Shop
                {
                    Name = "KFC",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2018/09/KFC-logo-880x660.png",
                    ImageUrl = "https://www.biznisvesti.mk/wp-content/uploads/2013/08/KFC-600x400.jpeg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227-409",
                    Email = "info@kfc.com.mk",
                    Description = "Компанијата KFC e основата во 1991 година, а седиштето е во Кентаки. Со повеќе од 20 илјади продажни места распоредени во 123 земји KFC е втор најголемо ресторан за брза храна, веднаш по Мекдоналдс.\n\n"+
                    "Еден од најпопуларните специјалитети по кои е познат овој ресторан е пилешкото месо и вкусните компирчиња.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Солени јадења").Id
                },
                new Shop
                {
                    Name = "Nu House & Friends",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/nu-house.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/nu-house-2.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 77 443 399",
                    Email = "info@nutellahouse.com.mk",
                    Description = "Nu House & Friends e специјализиран бренд за палачинки со Нутела. Но, на менито може да најдете и останати слатки вкусови. Новиот Nu House & Friends е местото каде што ќе може да уживате во најубавите палачинки во градот.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Десерти").Id
                },
                new Shop
                {
                    Name = "Европа",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/evropa.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/evropa.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 3 114 066",
                    Email = "evropa@evropa.com.mk",
                    Description = "Европа е компанија која остава свој белег на голем број генерации и тоа признание гордо го носи повеќе од 130 години, што ја прави една од најстарите компании во кондиторската индустрија на Балканот. Така, пренесувајќи го искуството и зголемувајќи го квалитетот низ повеќе генерации, таа станува она што е денес – стабилна индустриска компанија со производство од околу 5.000 тона годишно и продажба на домашен и над 20 странски пазари.\n\n"+
                    "Европа своите почетоци ги започнува како занаетчиска работилница за производство на бонбони, локум и слични производи од шеќер.За разлика од тогаш, денес таа е модернизирана фабрика за чоколади, вафли и бонбони која може да се пофали со своите достигнувања, a за непогрешливиот квалитет на производите, доволно говорат сертификатите за исполнување на потребните стандарди.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Десерти").Id
                },
                new Shop
                {
                    Name = "Телеком продажен салон",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/telekom.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/IMG_1888.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 3096-917",
                    Email = "pos_citymall@telekom.mk",
                    Description = "Телеком продажниот салон на корисниците им нуди комплетно ново доживување, преку интерактивни елементи и мултимедијални содржини. Во Телеком продажниот салон, најсовремен и модерен простор на Македонски Телеком АД – Скопје и Т - Мобиле Македонија, можат да се најдат сите продукти и услуги на T - Home и T - Mobile брендот.\n\n"+
                    "Македонски Телеком АД – Скопје станува дел од меѓународната групација Дојче Телеком и успешно работи под закрила на светскиот Т бренд на Македонскиот пазар од 2011 година. Компанијата е водечки национален оператор за електронски комуникации, кој на своите корисници им нуди широк спектар на врвни телекомуникациски услуги и забавни содржини, во доменот на фиксната мрежа, широкопојасни услуги и интегрирани решенија, како и телевизија преку интернет протокол(IPTV).\n\n"+
                    "Т - Мобиле Македонија е првиот мобилен оператор и лидер на пазарот на мобилната телефонија во Македонија. Брендот нуди продукти и услуги за мобилна комуникација, интернет со големи брзини и конвергирани сервиси за приватни и бизнис корисници.Т - Мобиле Македонија ја има најдобрата мрежа која покрива повеќе од 99,9% од населението.\n\n"+
                    "На територијата нa Р.Македонија, Македонски Телеком АД – Скопје и Т - Мобиле Македонија имаат малопродажна мрежа со 42 Телеком продавници.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Телекомуникации").Id
                },
                new Shop
                {
                    Name = "A1 продажен салон",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/Logo-za-city-mall_198_198.jpg",
                    ImageUrl = "https://www.seeinside.mk/wp-content/uploads/2020/02/SeeInsideMK-Google-2.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "0771234",
                    Email = "kontakt@a1.mk",
                    Description = "Компанијата А1 Македонија е член на А1 Телеком Австрија Групацијата, водечки провајдер за комуникациски и дигитални решенија во Централна и Источна Европа кој работи во седум држави и обезбедува услуги на над 25 милиони корисници. На македонскиот пазар компанијата опслужува 1,2 милиони корисници, овозможувајќи им одлично корисничко искуство.\n\n"+
                    "Во согласност со дигиталниот начин на живот, А1 е насочена кон обезбедување на најдобри телекомуникациски и дигитални решенија и нуди обемно портфолио на услуги.Услугите кои ги нуди компанијата се целосно насочени кон потребите на корисниците, а опфаќаат услуги во мобилната телефонија, фиксната телефонија, мобилен и оптички интернет, кабелска и дигитална телевизија, конвергентна понуда која вклучува комбинирани пакети со сите услуги, како и напредни ICT решенија.\n\n"+
                    "Преку најсовремена сопствена мрежа А1 на корисниците им овозможува целосна покриеност со 4G LTE мобилен интернет насекаде во земјата и 4G + во урбаните средини и покриеност на 99,8 % од населението.Со услугата за грижа на своите корисници достапна 24 часа во текот на целата недела и константното надградување на каналите за комуникација, А1 ја докажува супериорната грижа за корисниците.Услугите кои ги нуди компанијата овозможуваат дигитален начин на живот и работа како и можност на компаниите и работите да се поврзат насекаде и во секое време.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Телекомуникации").Id
                },
                new Shop
                {
                    Name = "Silhouette",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/siluete.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/05/siluete.jpg",
                    Location = "Втор кат",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 2 3234 567",
                    Email = "meliha@silhouette.com.mk",
                    Description = "Silhouette е најпрочуениот бренд на салони за убавина во Македонија со 22 годишно работно искуство. Раполага со над 50 видови најсовремени апарати и стручен кадар кој загарантирано ќе Ви обезбеди:\n"+
                    "– третмани за тело кои ќе ја оформат, затегнат и зацврстат Вашата силуета, доведувајќи ја до степен на совршенство;\n"+
                    "– целосно безболни и пријатни третмани за лице со резултати еднакви на оние од пластичната хирургија;\n"+
                    "– третмани за коса кои Вашата која ќе ја направат погуста, подолга, со беспрекорна боја, форма и сјај;\n"+
                    "– други третмани за убавина, кои ќе направат секој дел од Вашето тело да блеска: нокти со посакувана должина, форма и боја, трајна шминка, нежни раце и негувани стапала, како и мазна кожа без влакна.\n\n"+
                    "Silhouette постои за да го оствари Вашиот сон и да Ве претвори во она што сакате да бидете.\n\n"+
                    "Во своите 25 години успешна работа овој бренд успеа да фати и да држи чекор со светските трендови за убавина.Како редовни посетители на најпознатите семинари и конгреси за убавина во светот, вработените се во тек со сите светски  трендови и ги прават достапни најдокажаните и најефективните иновации од светските центри на убавина како Италија, Англија, Франција, Америка. Салон прави спој на најсовремена светска технологија и обучен персонал. Салонот располага со различни видови апарати со повеќе функции и програми кои опфаќаат третмани на лице, тело и коса, кои во рацете на едуциран и високостручен персонал прават вистински чуда и не само што ги остваруваат, туку и ги надминуваат вашите соништа за убавина.Третманите кои се нудат, од вас ќе направат олицетворение на убавината!",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Убавина").Id
                },
                new Shop
                {
                    Name = "Zegin",
                    LogoUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/zegin.fw_.png",
                    ImageUrl = "http://skopjecitymall.mk/wp-content/uploads/2017/09/Zegin.jpg",
                    Location = "Приземје",
                    WorkingHours = "10:00 - 22:00ч",
                    TelephoneNumber = "+389 71 227-409",
                    Email = "citymall@zegin.com.mk",
                    Description = "Нашата мисија е да се понуди широк спектар на производи од разни области во медицината, преку лекови,додатоци на исхрана, производи за бебиња, па се до козметички препарати по најприфатливи, достапни и најниски цени. Нашата цел е да им се понуди на пациентите стручна помош, и постојана достапност преку совети за нивното здравје. Ние сакаме да бидеме нивни пријатели.",
                    SubCategoryId = context.Subcategory.Single(c => c.Name == "Аптеки").Id
                }
                );
                context.SaveChanges();
                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName="Жанета", 
                        LastName="Тренчева", 
                        Email="zanetatrenceva1@gmail.com", 
                        PictureUrl= "https://media.istockphoto.com/photos/beauty-woman-portrait-girl-with-beautiful-face-smiling-picture-id936967024?k=6&m=936967024&s=612x612&w=0&h=OIOTru5Ll93_504da-cg9IsTf87b2zAve-n9fRL07A4="
                    },
                    new Employee
                    {
                        FirstName = "Јасна",
                        LastName = "Манева",
                        Email = "jasnamaneva@gmail.com",
                        PictureUrl = "https://images.pexels.com/photos/1036623/pexels-photo-1036623.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    },
                    new Employee
                    {
                        FirstName = "Милица",
                        LastName = "Мурџева",
                        Email = "milicam78@yahoo.com",
                        PictureUrl = "https://st3.depositphotos.com/1003989/17911/i/450/depositphotos_179113020-stock-photo-portrait-thinking-woman-isolated-white.jpg"
                    },
                    new Employee
                    {
                        FirstName = "Марија",
                        LastName = "Ристова",
                        Email = "ristova98@yahoo.com",
                        PictureUrl = "https://images.pexels.com/photos/733872/pexels-photo-733872.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    },
                    new Employee
                    {
                        FirstName = "Стефанија",
                        LastName = "Маџункова",
                        Email = "stefanija_madzunkova@gmail.com",
                        PictureUrl = "https://www.adventist.org/wp-content/uploads/2019/12/women-scaled.jpg"
                    },
                    new Employee
                    {
                        FirstName = "Емилија",
                        LastName = "Ристова",
                        Email = "ristovae14@gmail.com",
                        PictureUrl = "https://images.unsplash.com/photo-1508214751196-bcfd4ca60f91?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1000&q=80"
                    },
                    new Employee
                    {
                        FirstName = "Иван",
                        LastName = "Петровски",
                        Email = "ivan256@hotmail.com",
                        PictureUrl = "https://st2.depositphotos.com/1075946/5334/i/950/depositphotos_53346763-stock-photo-handsome-40-year-old-man.jpg"
                    },
                    new Employee
                    {
                        FirstName = "Бојан",
                        LastName = "Марковски",
                        Email = "bmarkovski@gmail.com",
                        PictureUrl = "https://images.pexels.com/photos/736716/pexels-photo-736716.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    },
                    new Employee
                    {
                        FirstName = "Никола",
                        LastName = "Стојановски",
                        Email = "nikolastojanovski55@gmail.com",
                        PictureUrl = "https://burgessplasticsurgery.com/wp-content/uploads/2019/11/istockphoto-825083570-612x612.jpg"
                    },
                    new Employee
                    {
                        FirstName = "Стефан",
                        LastName = "Поповски",
                        Email = "popovs@hotmail.com",
                        PictureUrl = "https://app.employmentjamaica.com/uploads/jobseekers/4eba1078899bfa19831ee81a99daac3e.jpg"
                    });
                context.SaveChanges();
                context.Employment.AddRange
                (
                new Employment { EmployeeId = context.Employee.Single(c => c.LastName == "Поповски").Id, ShopId = context.Shop.Single(c => c.Name == "Bitsiani").Id, StartDate = DateTime.Parse("2018-12-15") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "popovs@hotmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Okaidi").Id, StartDate = DateTime.Parse("2019-11-10") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "nikolastojanovski55@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Fashion&Friends").Id, StartDate = DateTime.Parse("2018-2-20") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "nikolastojanovski55@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Timberland").Id, StartDate = DateTime.Parse("2020-6-5") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "bmarkovski@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Zegin").Id, StartDate = DateTime.Parse("2017-12-1") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "ivan256@hotmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Телеком продажен салон").Id, StartDate = DateTime.Parse("2020-2-14") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "ivan256@hotmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Европа").Id, StartDate = DateTime.Parse("2020-1-31") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "ristovae14@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "A1 продажен салон").Id, StartDate = DateTime.Parse("2020-7-16") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "ristova98@yahoo.com").Id, ShopId = context.Shop.Single(c => c.Name == "Mango").Id, StartDate = DateTime.Parse("2016-8-1") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "ristova98@yahoo.com").Id, ShopId = context.Shop.Single(c => c.Name == "Oxette").Id, StartDate = DateTime.Parse("2019-2-27") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "ristovae14@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Božinovski").Id, StartDate = DateTime.Parse("2020-3-7") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "stefanija_madzunkova@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "MY:TIME").Id, StartDate = DateTime.Parse("2016-5-20") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "milicam78@yahoo.com").Id, ShopId = context.Shop.Single(c => c.Name == "Nu House & Friends").Id, StartDate = DateTime.Parse("2019-4-22") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "jasnamaneva@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Spizzicotto").Id, StartDate = DateTime.Parse("2020-10-10") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "jasnamaneva@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "KFC").Id, StartDate = DateTime.Parse("2020-12-13") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "stefanija_madzunkova@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Silhouette").Id, StartDate = DateTime.Parse("2020-6-18") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "milicam78@yahoo.com").Id, ShopId = context.Shop.Single(c => c.Name == "Burger King").Id, StartDate = DateTime.Parse("2020-10-15") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "jasnamaneva@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Bitsiani").Id, StartDate = DateTime.Parse("2020-5-28") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "popovs@hotmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Adidas").Id, StartDate = DateTime.Parse("2018-11-1") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "zanetatrenceva1@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Adidas").Id, StartDate = DateTime.Parse("2017-9-12") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "zanetatrenceva1@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Европа").Id, StartDate = DateTime.Parse("2020-4-30") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "zanetatrenceva1@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Mango").Id, StartDate = DateTime.Parse("2017-2-27") },
                new Employment { EmployeeId = context.Employee.Single(c => c.Email == "bmarkovski@gmail.com").Id, ShopId = context.Shop.Single(c => c.Name == "Nike").Id, StartDate = DateTime.Parse("2019-3-29") }
                );
                context.SaveChanges();
            }
        }

    }
}
