USE SandeepLodhi_SIT363

--TABLE : CUSTOMER

-- customer_id |   cust_name    |    city    | grade | salesman_id 
---------------+----------------+------------+-------+-------------
--        3002 | Nick Rimando   | New York   |   100 |        5001
--        3007 | Brad Davis     | New York   |   200 |        5001
--        3005 | Graham Zusi    | California |   200 |        5002
--        3008 | Julian Green   | London     |   300 |        5002
--        3004 | Fabian Johnson | Paris      |   300 |        5006
--        3009 | Geoff Cameron  | Berlin     |   100 |        5003
--        3003 | Jozy Altidor   | Moscow     |   200 |        5007
--        3001 | Brad Guzan     | London     |       |        5005
--	----------------------------------------------------------------------

--	TABLE ORDERS 

--		ord_no      purch_amt   ord_date    customer_id  salesman_id
------------  ----------  ----------  -----------  -----------
--70001       150.5       2012-10-05  3005         5002
--70009       270.65      2012-09-10  3001         5005
--70002       65.26       2012-10-05  3002         5001
--70004       110.5       2012-08-17  3009         5003
--70007       948.5       2012-09-10  3005         5002
--70005       2400.6      2012-07-27  3007         5001
--70008       5760        2012-09-10  3002         5001
--70010       1983.43     2012-10-10  3004         5006
--70003       2480.4      2012-10-10  3009         5003
--70012       250.45      2012-06-27  3008         5002
--70011       75.29       2012-08-17  3003         5007
--70013       3045.6      2012-04-25  3002         5001
--------------------------------------------------------------

--TABLE PRODUCTS

-- PRO_ID PRO_NAME                       PRO_PRICE    PRO_COM
--------- ------------------------- -------------- ----------
--    101 Mother Board                    3200.00         15
--    102 Key Board                        450.00         16
--    103 ZIP drive                        250.00         14
--    104 Speaker                          550.00         16
--    105 Monitor                         5000.00         11
--    106 DVD drive                        900.00         12
--    107 CD drive                         800.00         12
--    108 Printer                         2600.00         13
--    109 Refill cartridge                 350.00         13
--    110 Mouse                            250.00         12

--	--------------------------------------------------------------

CREATE TABLE Customer
(
CustomerID int not null , 
CustomerName varchar(225), 
city varchar(225),
grade int not null,
salesmanId int not null
);



CREATE TABLE Orders
(
OrderID int not null,
OrderNumber int not null,
PurchageAmount float not null,
orderDate date ,
customerId int not null,
salesmanId int not null
);



CREATE TABLE Products
(
ProductID int not null,
ProductName varchar(225),
PoductPrice float not null,
Productquantity int not null,
P_TotalAmount float not null,
ProductCode int not null
);