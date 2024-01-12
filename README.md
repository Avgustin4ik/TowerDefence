# TowerDefence
ECS test task. Entitas ECS

ТЗ https://docs.google.com/document/d/1AIgBwYgaxbX6AxU_cZ7ct95xKnmxlnUTnTraWzuUCvA/edit?usp=sharing

В основе лежит ECSCore кторый связыввает ECS и Unity. ECSCore создает экземпляр класса GameSystems который, в свою очередь, создает экземпляры сисетем, ответственных за конкретную логику.

Смерть врагов реализована через пул объектов.


Система апгрейдов врагов реализована через сущности (я решил не прибегать к Queue). При наступлении новой волны создается (request)Entity которая хранит в себе количество новых врагов, номер волны к которой они привязаны и характеристики этих N врагов. Характеристики улучшаются от характеристик врагов их предыдущей волны.

EnemySpawner собирает эти (request)Entity, выбирает сущность с наименьшем номером волны (следующим по игровой логике) и спавнит враго в нужном количестве и с нужными статами. Когда все враги из конкретной волны заспавнятся, (request)Entity удаляется.


|                         Game View                          |                      Editor View                       |
|:----------------------------------------------------------:|:------------------------------------------------------:|
| ![](https://github.com/Avgustin4ik/TowerDefence/blob/main/Screenshots/Screenshot%202023-09-15%20at%2011.08.54.png?raw=true) | ![](https://github.com/Avgustin4ik/TowerDefence/blob/main/Screenshots/Screenshot%202023-09-15%20at%2011.09.20.png?raw=true) |
