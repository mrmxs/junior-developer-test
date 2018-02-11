-- Create
CREATE TABLE Salesperson (
  "ID" serial PRIMARY KEY,
  "Name" varchar(10),
  "Age" int CHECK ("Age" > 0),
  "Salary" int CHECK ("Salary" > 0)
);

CREATE TABLE Customer(
  "ID" serial PRIMARY KEY,
  "Name" varchar(10), 
  "City" varchar(15), 
  "Industry Type" varchar(1)
);

CREATE TABLE Orders(
  "Number" serial PRIMARY KEY,
  "order_date" date,
  "cust_id" int REFERENCES Customer ("ID"),
  "salesperson_id" int REFERENCES Salesperson ("ID"),
  "Amount" int CHECK ("Amount" > 0)
);

-- Populate
INSERT INTO Salesperson
    ("ID", "Name", "Age", "Salary")
VALUES
    (1, 'Tom', 61, 140000),
    (2, 'Michael', 34, 44000),
    (5, 'Chris', 34, 40000),
    (7, 'Dan', 41, 52000),
    (8, 'Ken', 57, 115000),
    (11, 'Joe', 38, 38000)
;
    
INSERT INTO Customer
    ("ID", "Name", "City", "Industry Type")
VALUES
    (4, 'IVM', 'New York', 'J'),
    (6, 'Panosong', 'Florida', 'J'),
    (7, 'Seamens', 'Chicago', 'B'),
    (9, 'Nowkia', 'Houston', 'B')
;

    
INSERT INTO Orders
    ("Number", "order_date", "cust_id", "salesperson_id", "Amount")
VALUES
    (10, to_date('8/2/96', 'MM/DD/YY'), 4, 2, 540),
    (20, to_date('1/30/99', 'MM/DD/YY'), 4, 8, 1800),
    (30, to_date('7/14/95', 'MM/DD/YY'), 9, 1, 460),
    (40, to_date('1/29/98', 'MM/DD/YY'), 7, 2, 2400),
    (50, to_date('2/3/98', 'MM/DD/YY'), 6, 7, 600),
    (60, to_date('3/2/98', 'MM/DD/YY'), 6, 7, 720),
    (70, to_date('5/6/98', 'MM/DD/YY'), 9, 7, 150)
;
