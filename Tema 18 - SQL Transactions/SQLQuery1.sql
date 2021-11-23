-- autocommit transaction
SELECT * FROM class;
UPDATE class SET class_name = 'OOP' WHERE class_name = 'POO';
SELECT * FROM class;

--IMPLICIT TRANSACTION
SET IMPLICIT_TRANSACTIONS ON
UPDATE class SET class_name = 'POO' WHERE class_name = 'OOP';
SELECT * FROM class;
COMMIT TRAN

--EXPLICIT TRANSACTION
BEGIN TRAN 
UPDATE class SET class_name = 'OOP' WHERE class_name = 'POO';
SELECT * FROM class;
COMMIT TRAN

-- LOCK Ex
BEGIN TRAN
--pas 1
UPDATE class SET class_name = 'POO' WHERE id = 1;
--pas 3
UPDATE classroom SET classroom_name = 'new name' WHERE id = 1;
--pas 5
select  
    object_name(p.object_id) as TableName, 
    resource_type, resource_description
from
    sys.dm_tran_locks l
    join sys.partitions p on l.resource_associated_entity_id = p.hobt_id

COMMIT TRAN

--Dirty read
BEGIN TRAN
-- pas 1
SELECT * FROM classroom;
-- pas 3
SELECT * FROM classroom;

COMMIT TRAN

--Non repeatable read
BEGIN TRAN
--pas 1
SELECT * FROM classroom;
--pas 3
SELECT * FROM classroom;
COMMIT TRAN

-- Phantom read
BEGIN TRAN
--pas 1
SELECT * FROM classroom;
--pas 3
SELECT * FROM classroom;
COMMIT TRAN