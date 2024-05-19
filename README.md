# BloodyPath

![readme_graphic.png](https://i.imgur.com/nlxxV2P.png)

- Это многопользовательская (2 игрока, 1 на 1 пока что) игра в жанре экшн, сочетающая в себе драки, стрельбу. Множество видов оружия, создавая абсурдный хаос, как в боевиках.

- Жанр: Экшен, файтинг, драчки, может платформер если время дойдет

- Платформа: PC

- Фреймворк: [Monogame](https://github.com/MonoGame/MonoGame) (aka [Microsoft XNA Framework](https://en.wikipedia.org/wiki/Microsoft_XNA))

- Геймплей: Перемещение, атака, дизайн (если конечно это считается)

- Физика:
    - Перемещение: Player 1 может перемещаться верх, вниз, влево, вправо (кнопками W,A,S,D), а на Space атака; Player 2 может перемещаться верх, вниз, влево, вправо (кнопками Стрелочками), а на Enter атака;появляется экран о том что если перезапустить игру нужно нажать R и
    - После смерти одного из Player's  все начинается заново;

- Графика: pixel-art (Где-то рисую сам, либо сижу прям прописываю промты в [Stable Diffusion](https://github.com/AUTOMATIC1111/stable-diffusion-webui))
    - Считаю за Stable Diffusion можно было бы накинуть баллов так как с ним нужно ещё уметь работать и да он у меня локально поднят на моем пк (rtx 3080 позволяет)

Я может ещё доработаю все очень хотелось бы сделать что-то годное... Чтоб получить больше баллов!)) Ну если будет больше 400 баллов я хотел бы отправить на конкурс хочу побольше баллов ^_^ !!!)

Идея зародилось когда я играл с друзьями в такие игры как [Superfighters Deluxe](https://store.steampowered.com/app/855860/Superfighters_Deluxe/) и [Duck Game](https://store.steampowered.com/app/312530/Duck_Game/) и очень захотелось сделать что-то похожое но со своими механиками и идеями, потому-что данные игры уже перестали обновляться и превносить что-то новое в свою игру. Но я думаю времени не хватит на реализацию всех идей

## Задачи на будущее и выполненые задачи

Главное:

- [x] MVC
    - [x] BasePlayer (Persona)
    - [x] MainMenuScreen (MainMenu)
        - [x] ClickableText (Button)
        - [x] AnimationPicture (Animation)
    - [x] BattleFieldScreen (BattleField)
    - Мной было принятно если добавлять новый функционнал сразу делать его по MVC а не по отдености
        - Так что скорее всего я не успею реализовать его весь, но я думаю что сейчас есть этого может быть достаточно для хорошего кол-во баллов
- [x] Базовый функционал.
    - [x] Управление на обоих игроках
    - [x] Атака у обоих игроках
    - [x] Гравитация
    - [x] Экран главное меню
        - [ ] Окно настроек (может не будет, долго делать)
    - [x] Экран поля битвы
        - [x] Hp bar плееров
            - [x] Названия Player 1 и Player 2
            - [ ] Отображение раундов и побед у Player's
        - [ ] Сделать нормальные хитбоксы (ну это когда текстуры полностью доделаю)
        - [ ] Механика Player
            - [ ] Приседание
            - [ ] Удары разные
                - Пока что есть один удар рукой правой
                - [ ] Ногами
                - [ ] Руками
            - [ ] От такого как направлен перс менялись текстуры (ну типо A - лево (левая текстура плеера) и D - право (правая текстура плеера))
- [ ] Бот Player 2
    - Будет сложный алгоритм
    - Тупой, но хоть какой-то атакующий npc, на тот случай если вы без друзей(
    - Будет включать по кнопке
    - Если будет время то сделаю
    - Заметка по сложному алгоритму: можно сделать 
- [x] Дизайн (pixel-art)
    - [x] Фоны в стиле dark-fantasy
        - [ ] Анимированные фоны в стиле dark-fantasy
    - [ ] Персонажы
        - [ ] Анимированные персонажи
        - [ ] Тени у персонажей (чтоб смотрелось круто и хорошо)
    - [ ] Оружия
    - [ ] Иконку для игры
    - [ ] Иконки для оружия
- [ ] Оружия (мечи, пушки)
    - [ ] lucky blocks 
        - блоки с рандомным дропом падающими с неба из них можно выбить либо ускорение либо оружие (меч, пушку, RPG)