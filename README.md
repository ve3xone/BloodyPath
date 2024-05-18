# BloodyPath

![readme_graphic.png](https://i.imgur.com/nlxxV2P.png)

- Это многопользовательская (2 игрока, 1 на 1 пока что) игра в жанре экшн, сочетающая в себе драки, стрельбу. Множество видов оружия, создавая абсурдный хаос, как в боевиках.

Жанр: Экшен, файтинг, драчки, может платформер если время дойдет

Платформа: PC

Фреймворк: [Monogame](https://github.com/MonoGame/MonoGame) (aka [Microsoft XNA Framework](https://en.wikipedia.org/wiki/Microsoft_XNA))

Геймплей: Перемещение, атака, дизайн (если конечно это считается)

Физика: 
1.	Перемещение: Player 1 может перемещаться верх, вниз, влево, вправо (кнопками W,A,S,D), а на Space атака; Player 2 может перемещаться верх, вниз, влево, вправо (кнопками Стрелочками), а на Enter атака;
2. После смерти одного из Player's появляется экран о том что если перезапустить игру нужно нажать R и все начинается заново;

Я может ещё доработаю все очень хотелось бы сделать что-то годное...

Графика: pixel-art (Где-то рисую сам либо сижу прям прописываю промты в [Stable Diffusion](https://github.com/AUTOMATIC1111/stable-diffusion-webui))

Идея зародилось когда я играл с друзьями в такие игры как [Superfighters Deluxe](https://store.steampowered.com/app/855860/Superfighters_Deluxe/) и [Duck Game](https://store.steampowered.com/app/312530/Duck_Game/) и очень захотелось сделать что-то похожое но со своими механиками и идеями, потому-что данные игры уже перестали обновляться и превносить что-то новое в свою игру. Но я думаю времени не хватит на реализацию всех идей

## Задачи на будущее и выполненые задачи

Главное:

- [ ] MVC
    - [x] Более-менее сделал только у игрока
    - Есть ещё функционнал который хотелось бы добавить поэтому MVC ещё не отмечено как сделано
- [x] Базовый функционал.
    - [x] Управление на обоих игроках
    - [x] Атака у обоих игроках
    - [x] Гравитация
    - [x] Hp bar плееров
        - [x] Названия Player 1 и Player 2
    - [x] Экран главное меню
        - Из-за этого не доступен геймплей так как нужно сделать отдельный экран поля битвы для геймплея
    - [ ] Экран поля битвы
- [ ] Бот Player 2
    - Тупой, но хоть какой-то атакующий npc, на тот случай если вы без друзей(
    - Будет включать по кнопке
    - Если будет время то сделаю
    - Заметка по сложному алгоритму: можно сделать 
- [ ] Оружия (мечи, пушки)
    - [ ] lucky blocks 
        - блоки с рандомным дропом падающими с неба из них можно выбить либо ускорение либо оружие (меч, пушку, RPG)
- [x] Дизайн (pixel-art)
    - [x] Фоны в стиле dark-fantasy
        - [ ] Анимированные фоны в стиле dark-fantasy
    - [ ] Персонажы
        - [ ] Анимированные персонажи
        - [ ] Тени у персонажей (чтоб смотрелось круто и хорошо)
    - [ ] Оружия
    - [ ] Иконку для игры
    - [ ] Иконки для оружия