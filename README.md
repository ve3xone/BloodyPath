# BloodyPath

![Readme_graphic.png](https://github.com/ve3xone/BloodyPath/blob/master/.github/Readme_graphic.png?raw=true)

- Это многопользовательская игра в жанре экшн, сочетающая в себе драки. В данной игре вы сами выбераете когда остановиться и кто по итогу выйграл (пример таких игр: duck game чисто в который тоже можно играть до бесконечности).

- Жанр: Экшен, файтинг, драчки.

- Платформа: PC

- Фреймворк: [Monogame](https://github.com/MonoGame/MonoGame) (aka [Microsoft XNA Framework](https://en.wikipedia.org/wiki/Microsoft_XNA))

## Геймплей 

Перемещение, атака, защита

Главное меню:

![General_Menu.gif](https://github.com/ve3xone/BloodyPath/blob/master/.github/General_Menu.gif?raw=true)

Самая игра:

![General_Menu.gif](https://github.com/ve3xone/BloodyPath/blob/master/.github/Gameplay.gif?raw=true)

## Графика

- pixel-art (Где-то рисую сам, либо сижу прям прописываю промты в [Stable Diffusion](https://github.com/AUTOMATIC1111/stable-diffusion-webui))
    - Считаю за Stable Diffusion можно было бы накинуть баллов так как с ним нужно ещё уметь работать и да он у меня локально поднят на моем пк (rtx 3080 позволяет)
Точно могу с увереностью сказать рисовал сам персонажей и это было очень мутарно.

Фон из главного меню:

![Background_from_main_menu.gif](https://github.com/ve3xone/BloodyPath/blob/master/.github/Background_from_main_menu.gif?raw=true)

Фон из поля битвы:

![Landscape_800_600.png](https://github.com/ve3xone/BloodyPath/blob/master/Content/Backgrounds/Landscape_800_600.png?raw=true)

Персонажи:

![Characters.png](https://github.com/ve3xone/BloodyPath/blob/master/.github/Characters.png?raw=true)

## Надежда

Я может ещё доработаю все очень хотелось бы сделать что-то годное... Чтоб получить больше баллов!)) Хотелось бы 500 баллов и более тогда на конкурс не придятся отправлять !!!)

## Управление в игре

![Control.png](https://github.com/ve3xone/BloodyPath/blob/master/.github/Control.png?raw=true)

- Управление игроком 1
    - A, D - Движение влево, вправо
    - W - Прыжок
    - S - Упасть из прыжка быстро
    - X - Присесть на корточки
    - С - Атака руками
    - Left Shift - Атака ногами
- Управление игроком 2
    - ←, → - Движение влево, вправо
    - ↑ - Прыжок
    - ↓ - Упасть из прыжка быстро
    - Right Ctrl - Присесть на корточки
    - Enter - Атака руками
    - Right Shift - Атака ногами
    - Delete - вкл/выкл бота за игрока 2
- Выход в главное меню - ESC

## Идея

Идея зародилось когда я играл с друзьями в такие игры как [Superfighters Deluxe](https://store.steampowered.com/app/855860/Superfighters_Deluxe/) и [Duck Game](https://store.steampowered.com/app/312530/Duck_Game/) и очень захотелось сделать что-то похожое но со своими механиками и идеями, потому-что данные игры уже перестали обновляться и превносить что-то новое в свою игру. Но я думаю времени не хватит на реализацию всех идей

## Задачи на будущее и выполненые задачи

Главное:

- [x] MVC
    - [x] BasePlayer (Persona)
    - [x] MainMenuScreen (MainMenu)
        - [x] ClickableText (Button)
        - [x] AnimationPicture (Animation)
    - [x] BattleFieldScreen (BattleField)
    - [x] Перевести всё к MVC
    - Мной было принятно если добавлять новый функционнал сразу делать его по MVC а не по отдености
        - Так что скорее всего я не успею реализовать его весь, но я думаю что сейчас есть этого может быть достаточно для хорошего кол-во баллов
- [x] Базовый функционал.
    - [x] Управление на обоих игроках
    - [x] Атака у обоих игроках
    - [x] Гравитация
    - [x] Экран главное меню
        - [x] Регулятор громкости
        - [x] Название игры сделать сверху посередине
    - [x] Экран поля битвы
        - [x] Hp bar плееров
            - [x] Названия Player 1 и Player 2
            - [x] Отображение побед у Player's
        - [x] Сделать нормальные хитбоксы (ну это когда текстуры полностью доделаю)
        - [x] Механика Player
            - [x] Приседание
            - [x] Удары разные
                - [x] Ногами
                - [x] Руками
            - [x] От такого как направлен перс менялись текстуры (ну типо A - лево (левая текстура плеера) и D - право (правая текстура плеера))
            - [x] Сделать сценарий когда 0 hp у одного из player и нужно перезапускать battleFieldScreen полностью 
- [x] Бот Player 2
    - В игре он сделан чтоб могли оценить игру как сложный алгоритм
    - Работает по кнопке (DELETE)
- [x] Дизайн (pixel-art)
    - [x] Фоны в стиле dark-fantasy
        - [x] Анимированные фоны в стиле dark-fantasy
        - Пока что только в главном меню
          - На поле битвы статичный фон (времени не хватит на реализацию анимации)
    - [x] Персонажы (рисовал сам)
        - [ ] Анимированные персонажи (у меня есть анимации но походу времени не хватит)
        - [ ] Тени у персонажей (чтоб смотрелось круто и хорошо)
    - [ ] Оружия
    - [ ] Иконку для игры
    - [ ] Иконки для оружия
- [ ] Оружия (мечи, пушки)
    - [ ] lucky blocks 
        - блоки с рандомным дропом падающими с неба из них можно выбить либо ускорение либо оружие (меч, пушку, RPG)
