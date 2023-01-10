using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UkrainianAktiv.Core.Constant;

namespace UkrainianAktiv.Core.Models
{
    public class DataSeeder
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            SeedClubs();
            SeedCourses();
            SeedSchedule();
            SeedUsers();
        }

        private void SeedUsers()
        {
            var user = _userManager.FindByNameAsync("admin");
            user.Wait();

            if (user.Result == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin"
                };

                _userManager.CreateAsync(admin, "aXw52zg!").Wait();
                _userManager.AddClaimAsync(admin, new Claim("CanUpdate", "true")).Wait();
                _userManager.AddClaimAsync(admin, new Claim("CanDelete", "true")).Wait();

            }
        }

        private void SeedClubs()
        {
            if (!_context.Clubs.Any())
            {
                _context.Clubs.AddRange(
                    new Club
                    {
                        Title = "Мовний клуб",
                        Subtitle = "Тематичні дискусії Зовнішнього Незалежного Оцінювання. Обговорення здачі ЗНО.",
                        Summary = "Підготовка до ЗНО. Приєднуйтесь!",
                        Controller = "Club",
                        Action = "GetClubs",
                        ImageUrl = "/img/clubs/disc1.png",
                        IconClass = "fa fa-comments",
                        Enabled = true,
                        Type = ClubType.Club,
                        Description = @"<p>Кожної п'ятниці ми організовуємо тематичні дискусії. Дискусія відноситься до активних методів навчання, сприяє свідомому набуттю знань учнями.<br />Вона створює умови для застосвування знань у незвичних ситуаціях, для відстоювання власної позиції, що грунтується на переконаннях, здобутих в результаті відповідної підготовки. У дискусіях виявляються сильні сторони учнів, ступінь їх обдарованості, моральної вихованості!</p>
                        <p>В межах інтерактивного підходу до процесу вивчення мови найважливішим є принцип інтерактивності навчання. Цей принцип дозволяє припустити підключення учасників процесу навчання до такої 'моделі міжособистісної комунікації, яка є спрямованою на розвиток співпраці та орієнтованою на взаємодію учасників комунікації'
                        </p>"
                    },
                    new Club
                    {
                        Title = "Лайфхаки",
                        Subtitle = "Секрети вибору правильної відповіді у тестах з української мови та літератури!",
                        Summary = "Лайфхаки для успішної здачі ЗНО",
                        Controller = "Club",
                        Action = "GetClubs",
                        ImageUrl = "/img/clubs/exam.jpg",
                        IconClass = "fa fa-bus",
                        Enabled = true,
                        Type = ClubType.Club,
                        Description = @"
                        <p>
                        «Лайфхаки з української літератури» складаються з 15 лекцій. Тут можна опанувати теоретико-літературні поняття та навчитися аналізувати художні твори.
                        </p>
                        <p>
                        Крім того ви знайдете повний курс «Українська мова та література» для підготовки до ЗНО з цього предмету. Тут доступні шість модулів та більше 200 тестів. Є відео, подкасти та цікаві тексти.
                        </p>".Trim().Replace(Environment.NewLine, string.Empty)
                    },
                    new Club
                    {
                        Title = "Тести",
                        Subtitle = "Тести з програми ЗНО починаючи з 2006 року за офіційною програмою!",
                        Summary = "Практикуємо тести з української мови та літератури",
                        Controller = "Club",
                        Action = "GetClubs",
                        ImageUrl = "/img/clubs/test2.png",
                        IconClass = "fa fa-video-camera",
                        Enabled = true,
                        Type = ClubType.Club,
                        Description = @"
                        <p>
                            На <a href='https://zno.osvita.ua/ukrainian/'>ЗНО-онлайн</a> можна набути практичні навички та вміння роботи з тестами. Тут розміщені тести основної та додаткової сесії ЗНО від 2009 до 2020 років. На порталі представлене тестування з усіх предметів ЗНО.
                        </p>
                        <p>
                            У розділі розміщені тести ЗНО онлайн з української мови та літератури, що були запропоновані для виконання абітурієнтам під час основних та додаткових сесій зовнішнього незалежного оцінювання, а також варіанти тестів, що пропонувались абітурієнтам під час пробного зовнішнього незалежного оцінювання.
                        </p>
                        <p>
                            Під кожним завданням у тестах з української мови та літератури ви знайдете посилання на опис правильного виконання завдання та схему його оцінювання.
                        </p>".Trim().Replace(Environment.NewLine, string.Empty)
                    },
                    new Club
                    {
                        Title = "Пробне ЗНО",
                        Subtitle = "Ukrainian Aktiv представляє новий формат зустріч для оцінки знань наших студентів",
                        Summary = "Розкриваємо секрети здачі ЗНО!",
                        Controller = "Club",
                        Action = "GetMasterClasses",
                        ImageUrl = "/img/exam1.jpg",
                        IconClass = "fa fa-bullhorn",
                        Enabled = true,
                        Price = 700,
                        Type = ClubType.MasterClass,
                        Description = @"
                        <p>
                            На зустрічі ми проведемо тести ЗНО онлайн з української мови та літератури, що були розроблені нашими викладачами для виконання абітурієнтам під час основних та додаткових сесій зовнішнього незалежного оцінювання, а також варіанти тестів, що пропонувались абітурієнтам під час пробного зовнішнього незалежного оцінювання.
                        </p>
                        <p>
                            Спосіб виконання всіх завдань у запропонованих тестах ЗНО онлайн з української мови та літератури максимально наближений до реального тесту, а форма відповіді відповідає виду, що пропонується абітурієнтам у бланку відповідей під час проходження реальних тестів ЗНО.
                        </p>
                        <p>
                            Після виконання всіх тестів вам будуть надані правильні відповіді на всі завдання та розраховано ваш результат у тестових та рейтингових балах. Під час розрахунку бала за завдання з розгорнутою відповіддю (власне висловлення) використовується спеціальна формула розрахунку в залежності від якості виконання інших завдань тесту.
                        </p>
                        <p>
                            Загальна кількість завдань тесту з української мови – 40, на їх виконання учасникам відведено 150 хвилин. Максимальна кількість тестових балів, яку може отримати учасник ЗНО з української мови, правильно виконавши всі завдання, становить 74 бали.
                        </p>
                        <p>
                            Загальна кількість завдань тесту з української мови і літератури – 67, на їх виконання учасникам відводиться 210 хвилин.
                        </p>
                        <p>
                            Максимальна кількість тестових балів, що може отримати учасник тесту з української мови і літератури, становить 116 балів. <strong>Ми організовуємо цю зустріч для того, щоб наші студенти підготувались до ЗНО!</strong> Після виконання тесту ми будемо розглядати та обговорювати результати з кожним студентом!
                        </p>
                        <p>
                            Дата наступного проведення пробного ЗНО з нашими викладачами: <strong>20 лютого 2023 року!</strong> У Вас ще є час для того щоб записатись на нашу зустріч!   
                        </p>".Trim().Replace(Environment.NewLine, string.Empty)
                    }

                );

                _context.SaveChanges();
            }
        }

        private void SeedCourses()
        {
            if (!_context.Courses.Any())
            {
                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 100,
                        Title = "Фонетика",
                        Subtitle = "Алфавіт. Букви та звуки української мови. Наголос та засоби милозвучності",
                        Level = "middle",
                        Day = "Четвер - Субота",
                        Time = "17:00-19:00"
                    });

                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 250,
                        Title = "Орфографія",
                        Subtitle = "Правопис літер, що позначають ненаголошені голосні Е, И, О. Спрощення в групах приголосних",
                        Day = "П'ятниця<br />Неділя",
                        Level = "high",
                        Time = "15:00-17:00"
                    });

                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 280,
                        Title = "Лексика",
                        Day = "Середа - Четвер",
                        Subtitle = "Групи слів за  значенням, походженням, уживанням та емоційним забарвленням",
                        Level = "custom",
                        Time = "15:00-17:00"
                    });

                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 90,
                        Title = "Словотвір",
                        Subtitle = "Спільнокореневі слова",
                        Level = "middle",
                        Day = "Понеділок - Середа<br/>Субота",
                        Time = "14:00-15:00"
                    });

                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 280,
                        Title = "Фразеологія",
                        Subtitle = "Фразеологізми та їхні властивості. Фразеологізми-синоніми та антоніми",
                        Level = "high",
                        Day = "Вівторок<br />Субота",
                        Time = "15:00-17:00"
                    });      

                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 200,
                        Title = "Морфологія",
                        Subtitle = "Частини мови. Морфологічні ознаки іменника. Морфологічні ознаки  дієслова.",
                        Level = "high",
                        Day = "Вівторок - П'ятниця",
                        Time = "18:00-19:30"
                    });

                _context.Courses.Add(
                    new Course
                    {
                        Enabled = true,
                        Price = 180,
                        Title = "Стилістика",
                        Subtitle = "Стилі української мови. Текст. Типи мовлення. Власне висловлювання",
                        Level = "middle",
                        Day = "Понеділок - Середа<br/>Вівторок - Четвер",
                        Time = "19:00-20:30"
                    });
                

                _context.SaveChanges();
            }
        }

        private void SeedSchedule()
        {
            if (!_context.Schedule.Any())
            {
                _context.Schedule.AddRange(
                    new ScheduleItem
                    {
                        Title = "Усна народна творчість",
                        Subtitle = "Пісні Марусі Чурай. Історичні пісні. Загальна характеристика",
                        Day = "Кожного понеділка",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 1, 16),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Давня українська література",
                        Subtitle = "Повість минулих літ. Слово про похід Ігорів. Григорій Сковорода",
                        Day = "Кожного вівторка",
                        Time = "19:00 - 21:00",
                        Price = 350,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 1, 17),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Література кінця XVIII — початку XX ст",
                        Subtitle = "Іван Котляревський. Тарас Шевченко. Пантелеймон Куліш. Панас Мирний",
                        Day = "Кожну п'ятницю",
                        Time = "17:00 - 20:30",
                        Price = 550,
                        Place = "Онлайн",
                        Teacher = "Марія",
                        Date = new DateTime(2023, 1, 27),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Література XX ст.",
                        Subtitle = "Павло Тичина. Максим Рильський. Микола Хвильовий. Остап Вишня. Микола Куліш",
                        Day = "Кожну п'ятницю",
                        Time = "20:30 - 21:30",
                        Price = 250,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 1, 20),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Твори українських письменників-емігрантів",
                        Subtitle = "Іван Багряний. Євген Маланюк",
                        Day = "Кожну середу",
                        Time = "17:00 - 18:00",
                        Price = 200,
                        Place = "Онлайн",
                        Teacher = "Марія",
                        Date = new DateTime(2023, 2, 1),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Сучасний літературний процес",
                        Subtitle = "Загальний огляд. Основні тенденції",
                        Day = "Кожну другу субботу",
                        Time = "14:00 - 17:00",
                        Price = 400,
                        Place = "Онлайн",
                        Teacher = "Віктор",
                        Date = new DateTime(2023, 1, 28),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Морфологія. Іменник",
                        Subtitle = "Іменник. Морфологічні ознаки. Синтаксична роль. Рід та відмінювання",
                        Day = "Кожний четвер",
                        Time = "15:00 - 17:00",
                        Price = 250,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 1, 19),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Морфологія. Прикметник",
                        Subtitle = "Прикметник. Морфологічні ознаки. Синтаксична роль. Розряди та відмінювання",
                        Day = "Кожний четвер",
                        Time = "17:00 - 19:00",
                        Price = 250,
                        Place = "Онлайн",
                        Teacher = "Віктор",
                        Date = new DateTime(2023, 3, 19),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Морфологія. Числівник",
                        Subtitle = "Морфологічні ознаки. Синтаксична роль. Типи відмінювання. Особливості правопису",
                        Day = "Кожну середу",
                        Time = "11:00 - 13:00",
                        Price = 300,
                        Place = "Онлайн",
                        Teacher = "Марія",
                        Date = new DateTime(2023, 1, 25),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Морфологія. Займенник",
                        Subtitle = "Морфологічні ознаки. Синтаксична роль. Типи відмінювання. Означені та заперечні",
                        Day = "Кожну другу п'ятницю",
                        Time = "10:00 - 12:00",
                        Price = 200,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 1, 20),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Морфологія. Дієслово",
                        Subtitle = "Морфологічні ознаки. Синтаксична роль. Вид дієслова. Форми дієслова",
                        Day = "Кожну другу п'ятницю",
                        Time = "12:00 - 14:00",
                        Price = 200,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 2, 10),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Морфологія. Прислівник",
                        Subtitle = "Морфологічні ознаки. Синтаксична роль. Ступені порівняння прислівників",
                        Day = "Кожну п'ятницю",
                        Time = "10:00 - 12:00",
                        Price = 200,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 2, 24),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Службові частини мови",
                        Subtitle = "Прийменник. Сполучник. Частка. Групи та правопис",
                        Day = "Кожну суботу",
                        Time = "9:00 - 12:00",
                        Price = 350,
                        Place = "Онлайн",
                        Teacher = "Віктор",
                        Date = new DateTime(2023, 2, 25),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Вигук",
                        Subtitle = "Вигук як частина мови. Правопис вигуків",
                        Day = "Кожний понеділок",
                        Time = "17:00 - 18:00",
                        Price = 150,
                        Place = "Онлайн",
                        Teacher = "Марія",
                        Date = new DateTime(2023, 2, 27),
                        Enabled = true
                    },
                    new ScheduleItem
                    {
                        Title = "Речення",
                        Subtitle = "Граматична основа. Порядок слів. Види речень",
                        Day = "Кожний другий четвер",
                        Time = "15:00 - 18:00",
                        Price = 200,
                        Place = "Онлайн",
                        Teacher = "Мар'яна",
                        Date = new DateTime(2023, 3, 2),
                        Enabled = true
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
