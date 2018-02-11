# Тестовые задания для разработчика / SQL

### 1. Описание задания
Дана база данных следующей структуры:

_Salesperson_
| ID | Name | Age | Salary |
|:---:|:-----:|:-----:|:-----:|
| 1 | Tom | 61 | 140000 |
| 2 | Michael | 34 | 44000 |
| 5 | Chris | 34 | 40000 |
| 7 | Dan | 41 | 52000 |
| 8 | Ken | 57 | 115000 |
| 11 | Joe | 38 | 38000 |

_Customer_
| ID | Name | City | Inфdustry Type |
|:---:|:-----:|:-----:|:-----:|
|4|IVM|New York|J|
|6|Panosong|Florida|J|
|7|Seamens|Chicago|B|
|9|Nowkia|Houston|B|

_Orders_
| Number | order_date | cust_id | salesperson_id | Amount |
|:---:|:-----:|:-----:|:-----:|:---:|
|10|8/2/96|4|2|540|
|20|1/30/99|4|8|1800|
|30|7/14/95|9|1|460|
|40|1/29/98|7|2|2400|
|50|2/3/98|6|7|600|
|60|3/2/98|6|7|720|
|70|5/6/98|9|7|150|

Напишите запросы, которые делают следующее:
1. Выводит имена всех продавцов, имеющих заказы от Seamens
2. Выводит имена всех продавцов, не имеющих заказы от Seamens
3. Выводит имена всех продавцов, имеющих два и более заказов
4. Вставляет в таблицу TopSales (Name, Age) записи обо всех продавцах, зарплата которых больше 100 000.

### 2. Решение

SQLFiddle: http://sqlfiddle.com/#!17/02343/1
(Здесь результаты запросов выводятся последовательно.)

Файлы с листингом
* *create_populate.sql* - создание таблиц
* *task1-4.sql* - запросы из задания