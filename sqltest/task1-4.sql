-- 1. Имена всех продавцов, имеющих заказы от Seamens
SELECT
  Salesperson."Name"
FROM Orders
JOIN Salesperson
  ON Orders.salesperson_id = Salesperson."ID"
JOIN Customer
  ON Orders.cust_id = Customer."ID"
WHERE
  Customer."Name" = 'Seamens'
GROUP BY Orders.salesperson_id, Salesperson."Name";
  
-- 2. Имена всех продавцов, не имеющих заказы от Seamens
SELECT
  Salesperson."Name"
FROM Salesperson
WHERE
  Salesperson."ID" NOT IN (
      SELECT
        Salesperson."ID"
      FROM Orders
      JOIN Salesperson
        ON Orders.salesperson_id = Salesperson."ID"
      JOIN Customer
        ON Orders.cust_id = Customer."ID"
      WHERE
        Customer."Name" = 'Seamens'
  );
  
-- 3. Имена всех продавцов, имеющих два и более заказов
SELECT
  Salesperson."Name"
FROM Salesperson
JOIN (
    SELECT
      salesperson_id id,
      count(*) count
    FROM Orders
    GROUP BY salesperson_id
) sales_count_by_salesperson
  ON Salesperson."ID" = sales_count_by_salesperson.id
WHERE sales_count_by_salesperson.count >= 2;

-- 4. Вставить в таблицу TopSales (Name, Age) записи обо всех продавцах,
--    зарплата которых больше 100 000.
DROP TABLE IF EXISTS TopSales;
CREATE TABLE TopSales AS (
  SELECT "Name", "Age"
  FROM Salesperson
  WHERE "Salary" > 100000
);
SELECT * FROM TopSales;







