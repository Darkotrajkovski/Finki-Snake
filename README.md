# FINKI Snake

```
Дарко Трајковски 183187
Магдалена Кириловска 182015
Сара Петрушевска 182008
```
## Објаснување на проблемот

Snake е една од најстарите игри за забава на мобилните платформи која се уште е многу
актуелна.

![](images/gameplay.png)

Нашата апликација се состои од

```
 Почнување на нова игра
 Прикажување на тековни резултати
 Внесување на име на играч
 Опција за повторување на играта
```

Имплементацијата на ова решение ја започнавме така што со самото стартување на играта
се извршува и кодот на формата Form1 односно се креира матрица од полиња. Индексите
на полињата се добиваат од класата Coordinates.cs каде што има само два методи (Get I
Set за x и y).

Во следниот чекор започнува визуелната промена на играта во којашто се креира битмапа
од слики (650px,650px) бидејќи секоја слика е 50px односно 13 реда по 50px. Со готовата
класа Graphics и функцијата DrawImage лепиме слики на секое поле од битмапата.

Креирање на змија

При почеток на играта главата на змијата секогаш се наоѓа на позиција 6,6 и остатокот од
змијата на 6,7 и 6,8. Нејзината насока во старт е нагоре а потоа соодветно со изборот на
играчот змијата може да ја менува својата насока.

Начин на игра

Кога змијата се поместува секој нејзин елемент се поместува за 1 зависно од насоката, а
кога ќе се помести последниот елемент позади него треба да се обои во бело, односно
бојата на позадината.

Змијата треба да ги јаде програмските јазици и со тоа да добива поени.

Има два услови кои ја терминираат играта, доколку змијата се удри во ѕид или се гризне
самата себеси. После тоа играта завршува и се бара од играчот да внесе име за да се
внесе во листата на играчи.

![](images/credentials.jpg)

![](images/play-again.jpg)

Функција DodajScore

На крајот од играта се повикува функцијата DodajScore каде како атрибут се праќа името и
добиените поени, потоа креира StreamReader кој чита од текстуална датотека и доколку
датотеката постои на почетокот од датотеката го додава новиот играч, инаку креира нова
датотека

![](images/addScore.png)

