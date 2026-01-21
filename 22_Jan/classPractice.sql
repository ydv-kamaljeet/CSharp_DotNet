use TestDB;
/* 
   SELECT WITH ALIAS
 */

SELECT 
    t.Name AS Human_Name,
    t.Age  AS Human_Age
FROM TestTbl t;

/* 
   CROSS JOIN (OLD STYLE)
   Cartesian Product - Use carefully
 */

SELECT *
FROM Customers t1, Customers t2;

/*
   PRACTICE QUERIES
 */

-- Add constant column
SELECT 'ValidRecords' AS MyCol, *
FROM TestTbl;

-- Convert result to JSON
SELECT *
FROM TestTbl
FOR JSON AUTO;

-- Convert result to XML
SELECT *
FROM TestTbl
FOR XML AUTO;

-- Copy table structure & data
SELECT *
INTO CopyTl
FROM TestTbl;

-- Verify copied table
SELECT *
FROM CopyTbl;

-- Expression without table (SQL Server style)
SELECT 10 + 400 AS Result;



/* 
   WHERE CLAUSE EXAMPLES
 */

-- Equal
SELECT *
FROM Customers
WHERE Segment = 'corporate';

-- Not equal
SELECT *
FROM Customers
WHERE Segment <> 'corporate';

-- NOT keyword
SELECT *
FROM Customers
WHERE NOT Segment = 'corporate';

-- AND condition
SELECT *
FROM Customers
WHERE City = 'Pune'
  AND Segment = 'corporate';

-- OR condition
SELECT *
FROM Customers
WHERE City = 'Pune'
   OR Segment = 'corporate';

-- IN clause
SELECT *
FROM Customers
WHERE City IN ('Banglore', 'pune');

-- NOT IN clause
SELECT *
FROM Customers
WHERE City NOT IN ('Banglore', 'pune');

-- BETWEEN
SELECT *
FROM Orders
WHERE Amount BETWEEN 800 AND 1500;


select * from Customers where FullName like 'a%';

-- listing the ouput in descending order
select * from Orders order by Amount desc;  

-- Limiting the number of rows of output
select top 3  *  from Orders order by Amount;

-- Nested Query to find 2nd largest order amount
select top 1 * from (
    select top 2 * from Orders order by Amount desc
)
tt ORDER BY tt.Amount;

